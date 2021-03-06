﻿using System;
using System.Collections.Generic;
using System.Text;
using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException;
using System.Web.UI.WebControls;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using System.Web;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException.OrderAccount;
using System.Web.Security.AntiXss;

namespace com.ds201625.fonda.View.BackOfficePresenter.OrderAccount
{
    public class OrderInvoicesPresenter : Presenter
    {
        //Enlace Modelo - Vista
        private IOrderInvoicesContract _view;
        private int totalColumns = 4;
        private int _restaurantId;
        private IList<Invoice> listInvoice;
        private Account _account;

        ///<summary>
        ///Constructor
        /// </summary>
        /// <param name="viewOrderInvoices">Interfaz</param>
        public OrderInvoicesPresenter(IOrderInvoicesContract viewOrderInvoices) 
            : base(viewOrderInvoices)
        {
            //Enlace Modelo - Vista
            _view = viewOrderInvoices;
        }

        /// <summary>
        /// Metodo encargado de llenar la tabla de Facturas
        /// </summary>
        public void GetInvoices()
        {
            int result;
            //Define objeto a recibir
            IList<Account> listClosedAccount;
            //Invoca a comando del tipo deseado
            Command commandGetInvoicesByAccount;
            Command commandGetInvoicesByRestaurant;
            Command commandGetClosedOrderAccount;
            Command commandGetOrder;

            try
            {
                result = GetQueryParameter();
                _restaurantId = int.Parse(_view.SessionRestaurant);
                commandGetClosedOrderAccount = CommandFactory.GetCommandClosedOrders(_restaurantId);
                commandGetClosedOrderAccount.Execute();
                listClosedAccount = (IList<Account>)commandGetClosedOrderAccount.Receiver;
                int max = 0;
                for (int i = 0; i <= listClosedAccount.Count - 1; i++)
                {
                    if (listClosedAccount[i].Id > max)
                        max = listClosedAccount[i].Id;
                }

                if (result <= max && result != 0)
                {
                    //Obtiene la instancia del comando enviado el restaurante como parametro
                    commandGetInvoicesByAccount = CommandFactory.GetCommandFindInvoicesByAccount(result);
                    commandGetOrder = CommandFactory.GetCommandGetOrder(result);
                    _view.SessionAccountId = result.ToString();
                    //Ejecuta el comando deseado
                    commandGetInvoicesByAccount.Execute();
                    commandGetOrder.Execute();
                    //Se obtiene el resultado de la operacion
                    listInvoice = (IList<Invoice>)commandGetInvoicesByAccount.Receiver;
                    _account = (Account)commandGetOrder.Receiver;
                    //Habilita el Label del Numero de la Orden
                    _view.NumberAccount.Visible = true;
                    _view.NumberAccount.Text = "# Orden: " + _account.Number.ToString();

                }

                else if (result == 0)
                {
                    int restaurantId = int.Parse(_view.SessionRestaurant);
                    //Obtiene la instancia del comando enviado el restaurante como parametro
                    commandGetInvoicesByRestaurant = CommandFactory.GetCommandFindInvoicesByRestaurant(restaurantId);
                   //Ejecuta el comando deseado
                    commandGetInvoicesByRestaurant.Execute();
                    //Se obtiene el resultado de la operacion
                    listInvoice = (IList<Invoice>)commandGetInvoicesByRestaurant.Receiver;
                }


                //Revisa si la lista no esta vacia
                //Llama al metodo para el llenado de la tabla
                if (listInvoice != null) 
                    FillTable(listInvoice);
                else
                    throw new Exception();

            }
            catch (MVPExceptionOrderInvoicesTable ex)
            {
                MVPExceptionOrderInvoicesTable e = new MVPExceptionOrderInvoicesTable
                    (
                        OrderAccountResources.MVPExceptionOrderInvoicesTableCode,
                        OrderAccountResources.ClassNameOrderInvoicesPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        OrderAccountResources.MessageMVPExceptionOrderInvoicesTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                ErrorLabel(e.MessageException);
            }
            catch (FormatException ex)
            {
                MVPExceptionQuery e = new MVPExceptionQuery
                    (
                        OrderAccountResources.MVPExceptionQueryCode,
                        OrderAccountResources.ClassNameOrderInvoicesPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        OrderAccountResources.MessageMVPExceptionQuery,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                HttpContext.Current.Server.ClearError();
                HttpContext.Current.Response.Redirect(OrderAccountResources.allInvoicesURL);
            }
            catch (HttpRequestValidationException ex)
            {
                MVPExceptionOrderInvoicesTable e = new MVPExceptionOrderInvoicesTable
                    (
                        OrderAccountResources.MVPExceptionOrderInvoicesTableCode,
                        OrderAccountResources.ClassNameOrderInvoicesPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        OrderAccountResources.MessageMVPExceptionOrderInvoicesTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                HttpContext.Current.Server.ClearError();
                HttpContext.Current.Response.Redirect(OrderAccountResources.allInvoicesURL);
            }
            catch (Exception ex)
            {
                MVPExceptionOrderInvoicesTable e = new MVPExceptionOrderInvoicesTable
                    (
                        OrderAccountResources.MVPExceptionOrderInvoicesTableCode,
                        OrderAccountResources.ClassNameOrderInvoicesPresenter,
                        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        OrderAccountResources.MessageMVPExceptionOrderInvoicesTable,
                        ex
                    );
                Logger.WriteErrorLog(e.ClassName, e);
                FillTable(new List<Invoice>());
                ErrorLabel(e.MessageException);
            }


            Logger.WriteSuccessLog(OrderAccountResources.ClassNameOrderInvoicesPresenter
                                    , OrderAccountResources.SuccessMessageOrderInvoicesPresenter
                                    , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                                    );
        }



        /// <summary>
        /// Construye la tabla de Ordenes
        /// </summary>
        /// <param name="data">una lista de ordenes</param>
        private void FillTable(IList<Invoice> data)
        {

            HideMessageLabel();
            CleanTable(_view.OrderInvoicesTable);
            //Genero los objetos para la consulta
            //Genero la lista de la consulta

            int totalRows = data.Count; //tamano de la lista 
            StringBuilder status = new StringBuilder();
            StringBuilder dataId = new StringBuilder();

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {

                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                dataId.Append(data[i].Id.ToString());
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes[OrderAccountResources.dataId] =
                    data[i].Id.ToString();

                //Agrega la fila a la tabla existente
                _view.OrderInvoicesTable.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();

                    //Agrega el numero de factura
                    if (j.Equals(0))
                        tCell.Text = data[i].Number.ToString();

                    //Agrega la fecha de la factura
                    else if (j.Equals(1))
                        tCell.Text = data[i].Date.ToShortDateString();

                    //Agrega el total de la factura
                    else if (j.Equals(2))
                        tCell.Text = String.Format("{0} {1}",data[i].Currency.Symbol,data[i].Total.ToString());

                    //Agrega el status de la factura
                    else if (j.Equals(3))
                    {
                        if (data[i].Status.Equals(CanceledInvoiceStatus.Instance))
                            status.Append(OrderAccountResources.CanceledStatus);
                        else if(data[i].Status.Equals(GeneratedInvoiceStatus.Instance))
                            status.Append(OrderAccountResources.GeneratedStatus);

                        tCell.Text = status.ToString();
                        status.Clear();
                    }

                    //Agrega las acciones de la tabla
                    else if (j.Equals(4))
                    {
                        LinkButton actionInfo = new LinkButton();

                        actionInfo.Text += OrderAccountResources.ActionInfo;
                        actionInfo.Attributes[OrderAccountResources.href] =
                            OrderAccountResources.invoiceURL + dataId.ToString();
                        tCell.Controls.Add(actionInfo);

                    }
                    //Agrega la celda a la fila
                    tRow.Cells.Add(tCell);

                }
                dataId.Clear();
            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            _view.OrderInvoicesTable.Rows.AddAt(0, header);
        }

        /// <summary>
        /// Genera el encabezado de la tabla Ordenes
        /// </summary>
        /// <returns>Returna un objeto de tipo TableHeaderRow</returns>
        private TableHeaderRow GenerateTableHeader()
        {
            //Se crea la fila en donde se insertara el header
            TableHeaderRow header = new TableHeaderRow();

            //Se crean las columnas del header
            TableHeaderCell h1 = new TableHeaderCell();
            TableHeaderCell h2 = new TableHeaderCell();
            TableHeaderCell h3 = new TableHeaderCell();
            TableHeaderCell h4 = new TableHeaderCell();
            TableHeaderCell h5 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            //Esto tambien debo mejorarlo
            h1.Text = OrderAccountResources.InvoiceNumberColumn;
            h1.Scope = TableHeaderScope.Column;
            h2.Text = OrderAccountResources.DateColumn;
            h2.Scope = TableHeaderScope.Column;
            h3.Text = OrderAccountResources.TotalColumn;
            h3.Scope = TableHeaderScope.Column;
            h4.Text = OrderAccountResources.StatusColumn;
            h4.Scope = TableHeaderScope.Column;
            h5.Text = OrderAccountResources.ActionColumn;
            h5.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);
            header.Cells.Add(h5);

            return header;
        }

        private int GetQueryParameter()
        {
            int result = 0;
            string queryParameter =
                HttpContext.Current.Request.QueryString[OrderAccountResources.QueryParam];

                if (AntiXssEncoder.HtmlEncode(queryParameter, false) != null)
                    return int.Parse(queryParameter);

            return result;
        }

    }
}
