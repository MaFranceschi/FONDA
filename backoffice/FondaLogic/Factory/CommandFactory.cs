﻿using com.ds201625.fonda;
using com.ds201625.fonda.Domain;
using FondaLogic.Commands.OrderAccount;
using FondaLogic.Commands.Login;
using System.Collections.Generic;

namespace FondaLogic.Factory
{
    /// <summary>
    /// Fabrica que genera los comandos del sistema
    /// </summary>
    public class CommandFactory
    {
        #region OrderAccount

        //Se obtienen los comandos a a utilizar

        /// <summary>
        /// Metodo de la fabrica para el Comando CommandGetOrders
        /// </summary>
        /// <returns>comando CommandGetOrders</returns>
        public static Command<IList<Account>> GetCommandGetOrders()
        {
            return new CommandGetOrders();
        }

        /// <summary>
        /// Metodo de la fabrica para el ComandoGetOrder
        /// </summary>
        /// <returns>comando CommandGetOrder</returns>
        public static Command<Entity> GetCommandGetOrder()
        {
            return new CommandGetOrder();
        }


        #endregion

        #region Restaurant

        //Defincion de los comandos a implementar del modulo Restaurante

        #endregion

        #region Menu

        //Defincion de los comandos a implementar del modulo Menu

        #endregion

        #region Login

        //Defincion de los comandos a implementar del modulo Login
        public static Command<Employee> GetCommandGetEmployeeByUser()
        {
            return new CommandGetEmployeeByUser();
        }

        public static Command<Restaurant> GetCommandGetRestaurantById()
        {
            return new CommandGetRestaurantById();
        }
        #endregion
    }
}
