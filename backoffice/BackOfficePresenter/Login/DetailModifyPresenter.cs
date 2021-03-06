﻿using com.ds201625.fonda.View.BackOfficeModel.Login;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.login;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Login;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficePresenter.Login
{
    public class DetailModifyPresenter : Presenter
    {
        private IDetailModifyModel _view;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="viewDefault">Interfaz</param>
        public DetailModifyPresenter(IDetailModifyModel viewDetailModify)
            : base(viewDetailModify)
        {
            //Se genera el enlace entre el modelo y la vista
            _view = viewDetailModify;

        }
        /// <summary>
        /// funcion que me da el id del usuario a modificar
        /// </summary>
        /// <returns></returns>
        private int GetQueryParameter()
        {
            int result = 0;
            //peticion por url
            string queryParameter =
                HttpContext.Current.Request.QueryString["user"];

            //pregunta porsia en vacio
            if (queryParameter != null && queryParameter != string.Empty)
            {
                return int.Parse(queryParameter);
            }
            System.Diagnostics.Debug.WriteLine(result.ToString(), "clave");
            //retorno
            return result;
        }
        /// <summary>
        /// metodo que carga el usuarios en los elementos
        /// </summary>
        public void cargarUser()
        {
            //Cargo Restaurantes
            ChangeRestaurant();
            //Cargo Roles
            ChangeRole();
            // id del empleado
            int userId = GetQueryParameter();
            //objeto del empleado
            Employee _employee = getEmployee(userId);
            System.Diagnostics.Debug.WriteLine(_employee.Name, "nombre");
            //nombre del empleado
            _view.textBoxNameUser.Text = _employee.Name;
            //apellido del empleado
            _view.textBoxlastNameUser.Text = _employee.LastName;
            //nacionalidad del empleado
            _view.dropDownListNss1.Text = _employee.Ssn.Substring(0, 1);
            _view.dropDownListNss1.Enabled = false;
            
            // ssn del empleado
            int _length = (_employee.Ssn.Length) - 2;
            _view.textBoxNss2.Text = _employee.Ssn.Substring(2, _length);
            _view.textBoxNss2.Enabled = false;
            //genero del empleado
            _view.DropDownListGender.Text = _employee.Gender.ToString();
            //fecha del empleado
            _view.textBoxBirtDate.Value = _employee.BirthDate.ToString("yyyy-MM-dd");
            //nombre de usuario del empleado
            _view.textBoxUserNameU.Text = _employee.Username;
            _view.textBoxUserNameU.Enabled = false;
            //rol del empleado
            _view.DropDownListRole.Text = _employee.Role.Id.ToString();
            //email del empleado
            _view.textBoxEmail.Text = _employee.UserAccount.Email;
            _view.textBoxEmail.Enabled = false;
            //inahabilitacion de las claves
            _view.textBoxPaswword.Enabled = false;
            _view.textBoxRepitPaswword.Enabled = false;
            _view.buttonButtonAddModify.Text = "Modificar";
            //direccion del empleado
            _view.textBoxAddress.Text = _employee.Address;
            //numero del telefono del empleado
            _view.textBoxPhoneNumber.Text = _employee.PhoneNumber;
        }
        /// <summary>
        /// funcion que retorna empleado por medio de un comando
        /// </summary>
        /// <returns></returns>
        public Employee getEmployee(int id)
        {
            //empleado resultante
            Employee _employeeResult = null;

            try
            {
                //Comando que busca el empleado
                Command CommandGetEmployeeById = CommandFactory.GetCommandGetEmployeeById(id);
                //ejecuta comando
                CommandGetEmployeeById.Execute();
                //obtengo resultado
                _employeeResult = (Employee)CommandGetEmployeeById.Receiver;
            }
            //capturo excepciones que se pudieron generar en la capa de acceso a datos y/o capa logica
            catch (InvalidTypeOfParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(Errors.ClassNameInvalidParameter, e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(Errors.ClassNameIndexParameter, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetEmployee(Errors.ClassNameParameterNotFound, e);
            }
            catch (Exception e)
            {

            }
            // Guarda el resultado.
            Object Result = _employeeResult;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return _employeeResult;

        }
        /// <summary>
        /// metodo que carga los roles en el DropDown
        /// </summary>
        protected void ChangeRole()
        {
            //lista donde estaran resultados
            IList<Role> _roleList;
            //rol del usuario que ha iniciado session
            string _role1 = (string)(HttpContext.Current.Session[ResourceLogin.sessionRol]);
            //comando de traer todos los roles
            Command CommandGetAllRoles;
            //lo fabrico
            CommandGetAllRoles = CommandFactory.GetCommandGetAllRoles("null");
            //execute del comando
            try
            {
                //obtencion de resultado
                CommandGetAllRoles.Execute();
                _roleList = (IList<Role>)CommandGetAllRoles.Receiver;
            }
            //captura excepciones que se pudieron generar en la capa de acceso a datos y/o capa logica
            catch (InvalidTypeOfParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRol(Errors.ClassNameInvalidParameter, e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRol(Errors.ClassNameIndexParameter, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRol(Errors.ClassNameParameterNotFound, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CommandExceptionGetRol(Errors.ClassNameGetRoles, e);
            }
            // Guarda el resultado.
            Object Result = _roleList;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


            if (_roleList != null)
            {
                foreach (Role _role in _roleList)
                {
                    if ((_role1 != "Restaurante") && (_role.Id.ToString() == "3"))
                        _view.DropDownListRole.Items.Add(new ListItem(_role.Name, _role.Id.ToString()));
                    if (_role.Id.ToString() != "3")
                        _view.DropDownListRole.Items.Add(new ListItem(_role.Name, _role.Id.ToString()));
                }
            }
        }

        /// <summary>
        /// metodo que carga restaurantes en el dropdown
        /// </summary>
        protected void ChangeRestaurant()
        {   // comando que se trae todos los restaurantes del sistema
            Command CommandGetAllRestaurants;
            CommandGetAllRestaurants = CommandFactory.GetCommandGetAllRestaurants("null");
            try
            {
                //ejecuto
                CommandGetAllRestaurants.Execute();
            }
            catch (NullReferenceException ex)
            {
                
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException(ex.Message);

            }
            //recibo mi resultado
            IList<Restaurant> _restList = (IList<Restaurant>)CommandGetAllRestaurants.Receiver;
            //pregunto si es vacio el resultado
            if (_restList != null)
            {
                foreach (Restaurant _rest in _restList)
                {
                    //llego el dropdown de la vista
                    _view.dropDownListRestaurant.Items.Add(new ListItem(_rest.Name, _rest.Id.ToString()));
                }
            }
        }
        /// <summary>
        /// metodo que se activa al dar click en el boton de modificar
        /// </summary>
        /// <returns></returns>
        public bool Modify_Click()
        {
             FactoryDAO _facDAO;
            _facDAO = FactoryDAO.Intance;
            bool _emailValid = false, _ssnValid = false, _userNameValid =  false;
            System.Diagnostics.Debug.WriteLine("entre a modificar");
            _view.textBoxEmail.Attributes.Add("value", _view.textBoxEmail.Text);
            bool valideCamps = ValidarCampo();
            if (valideCamps)
            {
                int userId = GetQueryParameter();
                Employee _employee = getEmployee(userId);
                string _ssn = _view.dropDownListNss1.Text + "-" + _view.textBoxNss2.Text;
                //carga campo email con valor del usario a modificar
                if (_view.textBoxEmail.Text == _employee.UserAccount.Email)
                {
                    _emailValid = true;
                    _view.HtmlGenericControlemenssageEmail.Attributes.Clear();
                    _view.HtmlGenericControlemenssageEmail.InnerHtml = "";
                }
                //carga campo ssn con valor del usario a modificar
                if (_ssn == _employee.Ssn)
                {
                    _ssnValid = true;
                    _view.HtmlGenericControlemenssageSsn.Attributes.Clear();
                    _view.HtmlGenericControlemenssageSsn.InnerHtml = "";
                }
                //carga username email con valor del usario a modificar
                if (_view.textBoxUserNameU.Text == _employee.Username)
                {
                    _userNameValid = true;
                    _view.HtmlGenericControlemenssageUsername.Attributes.Clear();
                    _view.HtmlGenericControlemenssageUsername.InnerHtml = "";
                }
                //pregunta sobre validacion sobre existencia de valores en la bd
                if (_emailValid && _ssnValid && _userNameValid)
                {
                    System.Diagnostics.Debug.WriteLine("despues de if de boleeanos");
                    // se le da los valores al empleado creado
                    _employee = SetEmployee(_employee);
                    // se le da valor de activo

                    // Seguarda usuario
                    if (_employee.UserAccount.Id.ToString() == "0")
                    {
                        // Comando para guardar userAccount

                        Command CommandSaveUserAccount = CommandFactory.GetCommandSaveEntity(_employee.UserAccount);
                        try
                        {
                            //se ejecuta comando
                            CommandSaveUserAccount.Execute();
                        }
                        //capturo excepciones que se pudieron generar en la capa de acceso a datos y/o capa logica
                        catch (SaveEntityFondaDAOException e)
                        {
                            Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                            throw new CommandExceptionSaveUserAccount(Errors.ClassNameSaveEmployee, e);

                        }
                        catch (InvalidTypeOfParameterException e)
                        {
                            Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                            throw new CommandExceptionSaveUserAccount(Errors.ClassNameInvalidParameter, e);
                        }
                        catch (ParameterIndexOutOfRangeException e)
                        {
                            Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                            throw new CommandExceptionSaveUserAccount(Errors.ClassNameIndexParameter, e);
                        }
                        catch (RequieredParameterNotFoundException e)
                        {
                            Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                            throw new CommandExceptionSaveUserAccount(Errors.ClassNameParameterNotFound, e);
                        }
                        catch (Exception e)
                        {
                            Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                            throw new CommandExceptionSaveUserAccount(Errors.ClassNameSaveEmployee, e);
                        }
                        // Guarda el resultado.
                    }
                    //comando para guardar empleado
                    System.Diagnostics.Debug.WriteLine("Guarde en la bd");
                    Command CommandSaveEmployee = CommandFactory.GetCommandSaveEmployee(_employee);
                    try
                    {
                        CommandSaveEmployee.Execute();
                    }
                    //capturo excepciones que se pudieron generar en la capa de acceso a datos y/o capa logica
                    catch (SaveEntityFondaDAOException e)
                    {
                        Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                        throw new CommandExceptionSaveUserAccount(Errors.ClassNameSaveEmployee, e);

                    }
                    catch (InvalidTypeOfParameterException e)
                    {
                        Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                        throw new CommandExceptionSaveUserAccount(Errors.ClassNameInvalidParameter, e);
                    }
                    catch (ParameterIndexOutOfRangeException e)
                    {
                        Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                        throw new CommandExceptionSaveUserAccount(Errors.ClassNameIndexParameter, e);
                    }
                    catch (RequieredParameterNotFoundException e)
                    {
                        Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                        throw new CommandExceptionSaveUserAccount(Errors.ClassNameParameterNotFound, e);
                    }
                    catch (Exception e)
                    {
                        Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                        throw new CommandExceptionSaveUserAccount(Errors.ClassNameSaveEmployee, e);
                    }
                    //_employeeDAO.Save(_employee);
                    //alerta de exito de guardado
                    if (_view.buttonButtonAddModify.Text == "Modificar")
                    {
                        Alerts("Modify");
                    }

                    return true;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// metodo que valida los campos que estan en el modal
        /// </summary>
        /// <returns></returns>
        public bool ValidarCampo()
        {
            int good = 0;
            int bad = 0;
            //rol
            string _role = (string)(HttpContext.Current.Session[ResourceLogin.sessionRol]);
            //patron de numero del 0 al 9
            string patronNumero = "^[0-9]*$";
            //patron de solo letras
            string patronTexto = "^[A-Z a-z]*$";
            //patrones alphanumericos
            string patronAlphaNumerico1 = "^[A-Z0-9(.) a-z]*$";
            string patronAlphaNumerico2 = "^[A-Z0-9a-z]*$";
            //patron de fechas
            string patronFecha = @"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d";
            //patron de email
            string patronEmail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            //valor de los elementos en el modal
            string Name = _view.textBoxNameUser.Text;
            string LastName = _view.textBoxlastNameUser.Text;
            string Nacionalidad = Convert.ToString(_view.dropDownListNss1.Text);
            string Identity = _view.dropDownListNss1.Text;
            string Dni = _view.textBoxNss2.Text;
            string Birthdate = _view.textBoxBirtDate.Value;
            if (Birthdate != "")
            {
                String[] substrings = Birthdate.Split('-');
                Birthdate = substrings[2] + '/' + substrings[1] + '/' + substrings[0];
            }
           
            string Phone = _view.textBoxPhoneNumber.Text;
            string Gender = Convert.ToString(_view.DropDownListGender.Text);
            string Address = _view.textBoxAddress.Text;
            string Role = _view.DropDownListRole.Text;
            string UserName = _view.textBoxUserNameU.Text;
            string Email = _view.textBoxEmail.Text;
            string Password1 = _view.textBoxPaswword.Text;
            string Password2 = _view.textBoxRepitPaswword.Text;
            string Restaurant = _view.dropDownListRestaurant.Text;
            //validacion de accion si se quiere validar y campos vacios
            //validacion de campos vacios
            
            if (Name == "" | LastName == "" | Identity == "" | Phone == "" | Role == ""
                    | UserName == "" | Email == ""  | Gender == "" | Nacionalidad == ""
                    | Dni == "" | Birthdate == "" | Address == "")
            {
                        System.Diagnostics.Debug.WriteLine("error de recarga ssn");
                        Alerts("Empty");
                        bad = ++bad;
                        return false;
                    }
                    else
                    {
                        //validacion de campos vacios
                        _view.HtmlGenericControlemessageEmpty.Attributes.Clear();
                        _view.HtmlGenericControlemessageEmpty.InnerHtml = "";
                    }

                //Validacion de patron con respecto a nombre
                if ((!Regex.IsMatch(Name, patronTexto)))
                {
                    Alerts("InvalidFormatName");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlmessageNameUser.Attributes.Clear();
                    _view.HtmlGenericControlmessageNameUser.InnerHtml = "";
                }
                //Validacion de patron con respecto a apellido
                if ((!Regex.IsMatch(LastName, patronTexto)))
                {
                    Alerts("InvalidFormatLastName");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlemessageLastName.Attributes.Clear();
                    _view.HtmlGenericControlemessageLastName.InnerHtml = "";
                }
                //Validacion de patron con respecto a dni
                if ((!Regex.IsMatch(Dni, patronNumero)))
                {
                    Alerts("InvalidFormatDni");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlemessageDni.Attributes.Clear();
                    _view.HtmlGenericControlemessageDni.InnerHtml = "";
                }
                //Validacion de patron con respecto a fecha de nacimiento
                if ((!Regex.IsMatch(Birthdate, patronFecha)))
                {
                    Alerts("InvalidFormatBirthdate");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlemessageBirthdate.Attributes.Clear();
                    _view.HtmlGenericControlemessageBirthdate.InnerHtml = "";
                }
                //Validacion de patron con respecto a numero telefonico
                if ((!Regex.IsMatch(Phone, patronNumero)))
                {
                    Alerts("InvalidFormatPhone");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlemessagePhone.Attributes.Clear();
                    _view.HtmlGenericControlemessagePhone.InnerHtml = "";
                }
                //Validacion de patron con respecto a nombre
                if ((!Regex.IsMatch(Address, patronAlphaNumerico1)))
                {
                    Alerts("InvalidFormatAddress");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlemessageAddress.Attributes.Clear();
                    _view.HtmlGenericControlemessageAddress.InnerHtml = "";
                }


                //Validacion de patron con respecto a nombre de usuario
                if ((!Regex.IsMatch(UserName, patronAlphaNumerico2)))
                {
                    Alerts("InvalidFormatUser");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlemessageUser.Attributes.Clear();
                    _view.HtmlGenericControlemessageUser.InnerHtml = "";
                }
                //Validacion de patron con respecto a correo
                if ((!Regex.IsMatch(Email, patronEmail)))
                {
                    Alerts("InvalidFormatEmail");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlemenssageEmail.Attributes.Clear();
                    _view.HtmlGenericControlemenssageEmail.InnerHtml = "";
                }
                //Validacion de patron con respecto a contrase;a
                if ((!Regex.IsMatch(Password1, patronAlphaNumerico2)))
                {
                    Alerts("InvalidFormatPassword1");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlemessagePassword1.Attributes.Clear();
                    _view.HtmlGenericControlemessagePassword1.InnerHtml = "";
                }
                //Validacion de patron con respecto a validacion de contrase;a
                if ((!Regex.IsMatch(Password2, patronAlphaNumerico2)))
                {
                    Alerts("InvalidFormatPassword2");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlemessagePassword2.Attributes.Clear();
                    _view.HtmlGenericControlemessagePassword2.InnerHtml = "";
                }
                //Validacion de claves iguales
                if (!(Password1 == Password2))
                {
                    Alerts("InvalidFormatPasswordEqual");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlemessagePasswordEqual.Attributes.Clear();
                    _view.HtmlGenericControlemessagePasswordEqual.InnerHtml = "";
                }
                //Validacion de que fecha no sea mayor que la de hoy
                string Birthdate2 = _view.textBoxBirtDate.Value;
                String[] substring = Birthdate2.Split('-');
                Birthdate2 = substring[0] + '-' + substring[1] + '-' + substring[2];
                if (validaFechaNac(Convert.ToDateTime(Birthdate2)))
                {
                    Alerts("InvalidBirthdate");
                    bad = ++bad;
                }
                else
                {
                    good = ++good;
                    _view.HtmlGenericControlemessageBirthdate.Attributes.Clear();
                    _view.HtmlGenericControlemessageBirthdate.InnerHtml = "";
                }

            //si no hubo errores true , sino false
            if (bad == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            


        }
        /// <summary>
        /// metodo encargado de dar alerts sobre resultados de operaciones en la vista
        /// </summary>
        /// <param name="_success">tipo de alerta</param>
        public void Alerts(string _success)
        {
            switch (_success)
            {
                //case en caso del tipo de alert
                case "Add":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.success;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconSuccess + "El Empleado ha sido" + G1RecursosInterfaz.strongAdd;
                    break;

                case "Modify":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.success;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconSuccess + "El Empleado ha sido" + G1RecursosInterfaz.strongModify;
                    break;

                case "Status":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.success;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconSuccess + "El Status del Empleado ha sido" + G1RecursosInterfaz.strongModify;
                    break;

                case "DangerAdd":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongError + "al agregar el Empleado";
                    break;

                case "DangerModify":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongError + "al modificar el Empleado";
                    break;

                case "DangerStatus":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongError + "al modificar Status del Empleado";
                    break;

                case "Exception":
                    break;

                case "Cancel":
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertClase] = G1RecursosInterfaz.danger;
                    _view.HtmlGenericControlAlert.Attributes[G1RecursosInterfaz.alertRole] = "alert";
                    _view.HtmlGenericControlAlert.InnerHtml = G1RecursosInterfaz.buttonAlert + "La acción ha sido" + G1RecursosInterfaz.strogCancel;
                    break;

                case "DangerEmail":
                    _view.HtmlGenericControlemenssageEmail.InnerHtml = G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongNot + "Disponible!";
                    break;

                case "DangerUsername":
                    _view.HtmlGenericControlemenssageUsername.InnerHtml = G1RecursosInterfaz.iconDanger + G1RecursosInterfaz.strongNot + "Disponible!";
                    break;

                case "DangerSsn":
                    _view.HtmlGenericControlemenssageSsn.InnerHtml = G1RecursosInterfaz.iconDanger + " Ya Existe!";
                    break;

                case "InvalidFormatName":
                    _view.HtmlGenericControlmessageNameUser.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo letras y espacios";
                    break;

                case "InvalidFormatLastName":
                    _view.HtmlGenericControlemessageLastName.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo letras y espacios";
                    break;

                case "InvalidFormatDni":
                    _view.HtmlGenericControlemessageDni.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo números";
                    break;

                case "InvalidFormatPhone":
                    _view.HtmlGenericControlemessagePhone.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo";
                    break;

                case "InvalidFormatAddress":
                    _view.HtmlGenericControlemessageAddress.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico con espacios";
                    break;

                case "InvalidFormatUser":
                    _view.HtmlGenericControlemessageUser.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico y sin espacios";
                    break;

                case "InvalidFormatEmail":
                    System.Diagnostics.Debug.WriteLine("error de recarga");
                    _view.HtmlGenericControlemessageEmail.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato de Correo Inválido!";
                    break;

                case "InvalidFormatPassword1":
                    _view.HtmlGenericControlemessagePassword1.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico y sin espacios";
                    break;

                case "InvalidFormatPassword2":
                    _view.HtmlGenericControlemessagePassword2.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato Inválido! Sólo Alfanumérico y sin espacios";
                    break;

                case "InvalidFormatPasswordEqual":
                    _view.HtmlGenericControlemessagePasswordEqual.InnerHtml = G1RecursosInterfaz.iconDanger + " Las contraseñas no coinciden";
                    break;

                case "InvalidFormatBirthdate":
                    _view.HtmlGenericControlemessageBirthdate.InnerHtml = G1RecursosInterfaz.iconDanger + " Formato de fecha inválido (DD/MM/YYYY)";
                    break;
                case "InvalidBirthdate":
                    _view.HtmlGenericControlemessageBirthdate.InnerHtml = G1RecursosInterfaz.iconDanger + " Fecha igual o mayor que la actual";
                    break;

                case "Empty":
                    _view.HtmlGenericControlemessageEmpty.InnerHtml = G1RecursosInterfaz.iconExclamation + " Uno o mas Campos Obligatorios Vacíos";
                    break;

            }
        }
        /// <summary>
        /// metodo que le da valor a los atributos del objeto de empleado a modificar
        /// </summary>
        /// <param name="_employee">objeto de empleado a darle valores</param>
        /// <returns>empleado con valores</returns>
        protected Employee SetEmployee(Employee _employee)
        {
            // fabrica de dao 
            FactoryDAO _facDAO;
            IRoleDAO _roleDAO;
            _facDAO = FactoryDAO.Intance;
            _roleDAO = _facDAO.GetRoleDAO();
            _facDAO = FactoryDAO.Intance;
            //tipo de usuario logueado
            string _roleUser = (string)HttpContext.Current.Session[ResourceLogin.sessionRol];
            Role _role;
            //Restaurante a utilizar
            com.ds201625.fonda.DataAccess.InterfaceDAO.IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            Restaurant _restaurant;
            // se le da todos los valores de los atributos del tipo empleado
            //_employee = new Employee();
            //validacion de campos vacios
            if (_view.textBoxNameUser.Text != "")
                _employee.Name = _view.textBoxNameUser.Text;
            if (_view.textBoxlastNameUser.Text != "")
                _employee.LastName = _view.textBoxlastNameUser.Text;
            if (_view.textBoxAddress.Text != "")
                _employee.Address = _view.textBoxAddress.Text;
            if (_view.textBoxPhoneNumber.Text != "")
                _employee.PhoneNumber = _view.textBoxPhoneNumber.Text;
            if (_view.dropDownListNss1.Text != "" && _view.textBoxNss2.Text != "")
            {
               
                string _ssn = _view.dropDownListNss1.Text + "-" + _view.textBoxNss2.Text;
                _employee.Ssn = _ssn;
            }
            if (_view.DropDownListGender.Text != "")
                _employee.Gender = char.Parse(_view.DropDownListGender.SelectedValue);
            //se le da formato al string de fecha de nacimiento
            if (_view.textBoxBirtDate.Value != "")
            {
                string Birthdate = _view.textBoxBirtDate.Value;
                String[] substrings = Birthdate.Split('-');
                Birthdate = substrings[2] + '/' + substrings[1] + '/' + substrings[0];
                _employee.BirthDate = DateTime.Parse(Birthdate);
            }

            if (_view.textBoxUserNameU.Text != "")
                _employee.Username = _view.textBoxUserNameU.Text;
            if (_view.DropDownListRole.Text != "")
            {
                _role = _roleDAO.FindById(int.Parse(_view.DropDownListRole.SelectedValue));
                _employee.Role = _role;
            }


                if (_view.buttonButtonAddModify.Text == "Modificar")
                {//se le agrega cuenta del sistema al usuario
                    if (_view.textBoxEmail.Text != "")
                        _employee.UserAccount.Email = _view.textBoxEmail.Text;

                }

            //solo empleado sistema puede agregar a sistema
            if (_roleUser == "Sistema")
            {
                if (_employee.Role.Name != "Sistema")
                {
                    // se le agrega restaurante al empleado
                    if (_view.dropDownListRestaurant.Text != "")
                    {
                        // se busca restaurante para ponerselo al empleado
                        Restaurant _restaurantParam = (Restaurant)EntityFactory.GetRestaurant();
                        _restaurantParam.Id = int.Parse(_view.dropDownListRestaurant.SelectedValue);
                        Command CommandGetRestaurantById = CommandFactory.GetCommandGetRestaurantById(_restaurantParam);
                        try
                        {
                            CommandGetRestaurantById.Execute();
                            _restaurant = (Restaurant)CommandGetRestaurantById.Receiver;
                        }
                        //capturo excepciones que se pudieron generar en la capa de acceso a datos y/o capa logica
                        catch (InvalidTypeOfParameterException e)
                        {
                            Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                            throw new CommandExceptionGetRestaurant(Errors.ClassNameInvalidParameter, e);
                        }
                        catch (ParameterIndexOutOfRangeException e)
                        {
                            Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                            throw new CommandExceptionGetRestaurant(Errors.ClassNameIndexParameter, e);
                        }
                        catch (RequieredParameterNotFoundException e)
                        {
                            Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                            throw new CommandExceptionGetRestaurant(Errors.ClassNameParameterNotFound, e);
                        }
                        catch (Exception e)
                        {
                            Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                            throw new CommandExceptionGetRestaurant(Errors.ClassNameGetRestaurantId, e);
                        }
                        // Guarda el resultado.

                        Object Result = _restaurant;
                        //logger
                        Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                            Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                        Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                            Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                        _employee.Restaurant = _restaurant;


                        _employee.Restaurant = _restaurant;
                    }
                }
                else
                    _employee.Restaurant = null;

            }
            else
            {
                //solo rol restaurante puede agregar empleado de restaurant
                string _idrest = (string)(HttpContext.Current.Session[ResourceLogin.sessionRestaurantID]);
                Restaurant _restaurantParam = (Restaurant)EntityFactory.GetRestaurant();
                _restaurantParam.Id = int.Parse(_idrest);
                Command CommandGetRestaurantById = CommandFactory.GetCommandGetRestaurantById(_restaurantParam);
                try
                {
                    CommandGetRestaurantById.Execute();
                    _restaurant = (Restaurant)CommandGetRestaurantById.Receiver;
                    _employee.Restaurant = _restaurant;
                }
                //capturo excepciones que se pudieron generar en la capa de acceso a datos y/o capa logica
                catch (InvalidTypeOfParameterException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionGetRestaurant(Errors.ClassNameInvalidParameter, e);
                }
                catch (ParameterIndexOutOfRangeException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionGetRestaurant(Errors.ClassNameIndexParameter, e);
                }
                catch (RequieredParameterNotFoundException e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionGetRestaurant(Errors.ClassNameParameterNotFound, e);
                }
                catch (Exception e)
                {
                    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new CommandExceptionGetRestaurant(Errors.ClassNameGetRestaurantId, e);
                }
                // Guarda el resultado.
                Object Result = _restaurant;
                //logger
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    Errors.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            return _employee;
        }

        /// <summary>
        /// metodo que cargar los labels
        /// </summary>
        public void cargarUserDetail()
        {
            try
            {
                // id del empleado
                int userId = GetQueryParameter();
                //objeto del empleado
                Employee _employee = getEmployee(userId);
                System.Diagnostics.Debug.WriteLine(_employee.Name, "nombre");
                //nombre del empleado
                _view.labelNombre.Text = _employee.Name;
                //apellido del empleado
                _view.labelapellido.Text = _employee.LastName;
                //nacionalidad del empleado
                _view.labelcedulaemp.Text = _employee.Ssn;
                //genero del empleado
                _view.labelgeneroemp.Text = _employee.Gender.ToString();
                //fecha del empleado
                _view.labelfechanacemp.Text = _employee.BirthDate.ToString("yyyy-MM-dd");
                //nombre de usuario del empleado
                _view.labelusuarioemp.Text = _employee.Username;
                //rol del empleado
                //_view.labelrolemp.Text = _employee.Role.Id.ToString();
                //email del empleado
                _view.labelemailemp.Text = _employee.UserAccount.Email;
                //direccion del empleado
                _view.labeldireccionemp.Text = _employee.Address;
                //numero del telefono del empleado
                _view.labeltelefonoemp.Text = _employee.PhoneNumber;
                Role _roleResult = EntityFactory.GetRole();
                //comando para obtener informacion del rol
                Command CommangGetRolById = CommandFactory.CommandGetRolById(Int32.Parse((_employee.Role.Id.ToString())));
                try
                {
                    CommangGetRolById.Execute();
                    _roleResult = (Role)CommangGetRolById.Receiver;

                }
                catch (Exception)
                {

                }
                _view.labelrolemp.Text = _roleResult.Name;
                _view.labelrestauranteemp.Text = _employee.Restaurant.Name;
            }
            catch (Exception)
            {
            }

        }

    }
}
