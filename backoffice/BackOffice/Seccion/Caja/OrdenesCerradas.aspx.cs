﻿using System;
using System.Web.UI.WebControls;
using BackOfficeModel.OrderAccount;
using BackOffice.Seccion.Restaurant;
using FondaResources.Login;
using System.Web.UI.HtmlControls;
using BackOfficeModel;
using FondaResources.OrderAccount;

namespace BackOffice.Seccion.Caja
{
    public partial class OrdenesCerradas : System.Web.UI.Page, IClosedOrdersModel
    {
        #region Presenter

        private com.ds201625.fonda.BackOffice.Presenter.OrderAccount.ClosedOrdersPresenter _presenter;

        #endregion

        #region Model

        public System.Web.UI.WebControls.Table ClosedOrdersTable
        {
            get { return closedOrders; }

            set { closedOrders = value; }
        }

        Label IModel.ErrorLabelMessage
        {
            get { return this.ErrorLabelMessage; }

            set { this.ErrorLabelMessage = value; }

        }

        Label IModel.SuccessLabelMessage
        {
            get { return this.SuccessLabelMessage; }

            set { this.SuccessLabelMessage = value; }
        }

        public string SessionRestaurant
        {
            get { return Session[ResourceLogin.sessionRestaurantID].ToString(); }

            set { Session[ResourceLogin.sessionRestaurantID] = value; }
        }

        public string SessionNumberAccount
        {
            get { return Session[OrderAccountResources.SessionNumberAccount].ToString(); }

            set { Session[OrderAccountResources.SessionNumberAccount] = value; }
        }

        HtmlGenericControl IModel.SuccessLabel
        {
            get { return this.SuccessLabel; }

        }

        HtmlGenericControl IModel.ErrorLabel
        {
            get { return this.ErrorLabel; }

        }

        /// <summary>
        /// Recurso de Session para el ID de la orden
        /// </summary>
        string IClosedOrdersModel.Session
        {
            get { return Session[OrderAccountResources.SessionIdAccount].ToString(); }

            set { Session[OrderAccountResources.SessionIdAccount] = value; }
        }

        #endregion

        #region Constructor

        public OrdenesCerradas()
        {
            _presenter = new com.ds201625.fonda.BackOffice.Presenter.OrderAccount.ClosedOrdersPresenter(this);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (Session["RestaurantID"] != null)
            {   //Llama al presentador para llenar la tabla de ordenes
                _presenter.GetClosedOrders(Session[RestaurantResource.SessionRestaurant].ToString());
            }
        }



    }
}