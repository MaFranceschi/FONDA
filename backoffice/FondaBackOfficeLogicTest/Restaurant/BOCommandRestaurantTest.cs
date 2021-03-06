﻿using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FondaBackOfficeLogicTest.Restaurante
{
    class BOCommandRestaurantTest
    {
        private FactoryDAO _facDAO;
        private IRestaurantDAO _restaurantDAO;
        private Restaurant _restaurant;
        private Restaurant _restaurantE;
        private Object[] _addlist;
        private Object[] _modifylist;
        private Command _commandGenerateRestaurant;
        private Command _commandModifyRestaurant;
        private Command _commandSaveRestaurant;
        private Command _commandGetRestaurants;
        private Command _commandGetAllCategories;
        private Command _commandGetAllCurrencies;
        private Command _commandGetAllZones;
        private IList<RestaurantCategory> listCategories;
        private IList<Currency> listCurrencies;
        private IList<Zone> listZones;
        private IList<Restaurant> listRestaurants;

        #region Variables restaurante
        int idRestaurant;
        string name;
        string logo;
        char nationality;
        string rif;
        string address;
        string category;
        string currency;
        string zone;
        double _long;
        double _lat;
        TimeSpan openingTime;
        TimeSpan closingTime;
        bool[] days;
        #endregion

        [SetUp]
        public void init()
        {
            _facDAO = FactoryDAO.Intance;
            _restaurantDAO = _facDAO.GetRestaurantDAO();
            _restaurant = new Restaurant();
            idRestaurant = 3;
            name = "Salon Canton";
            logo = "C:/";
            nationality = 'V';
            rif = "326598";
            address = "Av. Paez";
            category = "China";
            currency = "Bolivar Fuerte";
            zone = "Montalban";
            _long = 10.6;
            _lat = 18.9;
            openingTime = TimeSpan.Parse("11:00:00");
            closingTime = TimeSpan.Parse("22:00:00");
            days = new bool[] { true, true, true, true, true, true, true };
            _addlist = new Object[13];
            _modifylist = new Object[2];
    }

        [TearDown]
        public void clean()
        {
            _facDAO = null;
            _addlist = null;
            _modifylist = null;
        }

        #region Commands Test

        [Test(Description = "Genera un objeto restaurante")]
        public void commandGenerateRestaurantTest()
        {
            _addlist[0] = name;
            _addlist[1] = logo;
            _addlist[2] = nationality;
            _addlist[3] = rif;
            _addlist[4] = address;
            _addlist[5] = category;
            _addlist[6] = currency;
            _addlist[7] = zone;
            _addlist[8] = _long;
            _addlist[9] = _lat;
            _addlist[10] = openingTime;
            _addlist[11] = closingTime;
            _addlist[12] = days;

            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
            _commandGenerateRestaurant.Execute();
            _restaurantE = (Restaurant)_commandGenerateRestaurant.Receiver;
            _restaurant.Name = "Salon Canton";
            Assert.AreEqual(_restaurant.Name, _restaurantE.Name);
        }

        [Test(Description = "Modifica un objeto restaurante")]
        public void commandModifyRestaurantTest()
        {
            _addlist[0] = name;
            _addlist[1] = logo;
            _addlist[2] = nationality;
            _addlist[3] = rif;
            _addlist[4] = address;
            _addlist[5] = category;
            _addlist[6] = currency;
            _addlist[7] = zone;
            _addlist[8] = _long;
            _addlist[9] = _lat;
            _addlist[10] = openingTime;
            _addlist[11] = closingTime;
            _addlist[12] = days;

            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
            _commandGenerateRestaurant.Execute();
            _restaurantE = (Restaurant)_commandGenerateRestaurant.Receiver;

            _modifylist[0] = _restaurantE;
            _modifylist[1] = idRestaurant;

            _commandModifyRestaurant = CommandFactory.GetCommandModifyRestaurant(_modifylist);
            _commandModifyRestaurant.Execute();
            _restaurant = (Restaurant)_commandModifyRestaurant.Receiver;
            Assert.AreEqual("Salon Canton", _restaurant.Name);

        }

        [Test(Description = "Guarda un objeto restaurante en la bd")]
        public void commandSaveRestaurantTest()
        {
            _restaurant = _restaurantDAO.FindById(2);

            _commandSaveRestaurant = CommandFactory.GetCommandSaveRestaurant(_restaurant);
            _commandSaveRestaurant.Execute();

            _restaurantE = _restaurantDAO.FindById(2);
            Assert.AreEqual(_restaurantE.Name, _restaurant.Name);
        }

        [Test(Description = "Devuelve todas las categorias")]
        public void commandGetAllCategories()
        {
            _commandGetAllCategories = CommandFactory.GetCommandGetAllCategories();
            _commandGetAllCategories.Execute();
            listCategories = (IList<RestaurantCategory>)_commandGetAllCategories.Receiver;

            Assert.AreEqual("China", listCategories[0].Name);
        }

        [Test(Description = "Devuelve todas las Monedas")]
        public void commandGetAllCurrencies()
        {
            _commandGetAllCurrencies = CommandFactory.GetCommandGetAllCurrencies();
            _commandGetAllCurrencies.Execute();
            listCurrencies = (IList<Currency>)_commandGetAllCurrencies.Receiver;

            Assert.AreEqual("Dolar", listCurrencies[0].Name);
        }

        [Test(Description = "Devuelve todas las zonas")]
        public void commandGetAllZones()
        {
            _commandGetAllZones = CommandFactory.GetCommandGetAllZones();
            _commandGetAllZones.Execute();
            listZones = (IList<Zone>)_commandGetAllZones.Receiver;

            Assert.AreEqual("Altamira", listZones[0].Name);
        }

        [Test(Description = "Devuelve todas las restaurantes")]
        public void commandGetRestaurants()
        {
            _commandGetRestaurants = CommandFactory.GetCommandGetRestaurants("null");
            _commandGetRestaurants.Execute();
            listRestaurants = (IList<Restaurant>)_commandGetRestaurants.Receiver;

            Assert.AreEqual("El Mundo del Pollo", listRestaurants[1].Name);
        }

        #endregion

        #region Exceptions Test

        [ExpectedException(typeof(NullReferenceException))]
        [Test(Description = "Excepción Nula al generar un objeto restaurante")]
        public void GenerateRestaurantNullExceptionTest()
        {
            
            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(null);
            _commandGenerateRestaurant.Execute();
        }
        [ExpectedException(typeof(InvalidCastException))]
        [Test(Description = "Excepción de casteo invalido al generar un objeto restaurante")]
        public void GenerateRestaurantInvalidExceptionTest()
        {
            _addlist[0] = 13546;
            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
            _commandGenerateRestaurant.Execute();
        }


        [ExpectedException(typeof(CommandExceptionModifyRestaurant))]
        [Test(Description = "Excepción al modificar un objeto restaurante")]
        public void ModifyRestauranteExceptionTest()
        {
            _addlist[0] = name;
            _addlist[1] = logo;
            _addlist[2] = nationality;
            _addlist[3] = rif;
            _addlist[4] = address;
            _addlist[5] = category;
            _addlist[6] = currency;
            _addlist[7] = zone;
            _addlist[8] = _long;
            _addlist[9] = _lat;
            _addlist[10] = openingTime;
            _addlist[11] = closingTime;
            _addlist[12] = days;

            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
            _commandGenerateRestaurant.Execute();
            _restaurantE = (Restaurant)_commandGenerateRestaurant.Receiver;

            _modifylist[0] = _restaurantE;

            _commandModifyRestaurant = CommandFactory.GetCommandModifyRestaurant(_modifylist);
            _commandModifyRestaurant.Execute();
            _restaurant = (Restaurant)_commandModifyRestaurant.Receiver;
        }
        [ExpectedException(typeof(NullReferenceException))]
        [Test(Description = "Excepción Nula al modificar un objeto restaurante")]
        public void ModifyRestauranteNullExceptionTest()
        {
            
            _commandModifyRestaurant = CommandFactory.GetCommandModifyRestaurant(null);
            _commandModifyRestaurant.Execute();
            _restaurant = (Restaurant)_commandModifyRestaurant.Receiver;
        }
        [ExpectedException(typeof(InvalidCastException))]
        [Test(Description = "Excepción de casteo invalido al modificar un objeto restaurante")]
        public void ModifyRestauranteInvalidExceptionTest()
        {
            /*_addlist[0] = 1234548;

            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
            _commandGenerateRestaurant.Execute();
            _restaurantE = (Restaurant)_commandGenerateRestaurant.Receiver;*/

            _modifylist[0] = _restaurantE;
            _modifylist[1] = "hola";

            _commandModifyRestaurant = CommandFactory.GetCommandModifyRestaurant(_modifylist);
            _commandModifyRestaurant.Execute();
            _restaurant = (Restaurant)_commandModifyRestaurant.Receiver;
        }


        [ExpectedException(typeof(CommandExceptionGetAllCategories))]
        [Test(Description = "Excepción al generar una lista de categorias")]
        public void commandGetAllCategoriesExceptionTest()
        {
            _commandGetAllCategories = CommandFactory.GetCommandGetAllCategories();
            _commandGetAllCategories.Execute();
        }
        [ExpectedException(typeof(NullReferenceException))]
        [Test(Description = "Excepción Nula al generar una lista de categorias (indica que la tabla RestaurantCategory esta vacia)")]
        public void commandGetAllCategoriesNullExceptionTest()
        {
            _commandGetAllCategories = CommandFactory.GetCommandGetAllCategories();
            _commandGetAllCategories.Execute();
        }

        [ExpectedException(typeof(CommandExceptionGetAllCurrencies))]
        [Test(Description = "Excepción al generar una lista de moneda")]
        public void commandGetAllCCurrenciesExceptionTest()
        {
            _commandGetAllCurrencies = CommandFactory.GetCommandGetAllCurrencies();
            _commandGetAllCurrencies.Execute();
        }
        [ExpectedException(typeof(NullReferenceException))]
        [Test(Description = "Excepción Nula al generar una lista de moneda (indica que la tabla Currency esta vacia)")]
        public void commandGetAllCCurrenciesNullExceptionTest()
        {
            _commandGetAllCurrencies = CommandFactory.GetCommandGetAllCurrencies();
            _commandGetAllCurrencies.Execute();
        }

        [ExpectedException(typeof(CommandExceptionGetAllZones))]
        [Test(Description = "Excepción al generar una lista de zonas")]
        public void commandGetAllZonesExceptionTest()
        {
            _commandGetAllZones = CommandFactory.GetCommandGetAllZones();
            _commandGetAllZones.Execute();
        }
        [ExpectedException(typeof(NullReferenceException))]
        [Test(Description = "Excepción Nula al generar una lista de zonas (indica que la tabla Zone esta vacia)")]
        public void commandGetAllZonesNullExceptionTest()
        {
            _commandGetAllZones = CommandFactory.GetCommandGetAllZones();
            _commandGetAllZones.Execute();
        }

        [ExpectedException(typeof(CommandExceptionGetRestaurants))]
        [Test(Description = "Excepción al generar una lista de restaurantes")]
        public void commandGetRestaurantsExceptionTest()
        {
            _commandGetRestaurants = CommandFactory.GetCommandGetRestaurants("null");
            _commandGetRestaurants.Execute();
            listRestaurants = (IList<Restaurant>)_commandGetRestaurants.Receiver;
        }
        [ExpectedException(typeof(NullReferenceException))]
        [Test(Description = "Excepción Nula al generar una lista de restaurantes (indica que la tabla Restaurant esta vacia)")]
        public void commandGetRestaurantsNullExceptionTest()
        {
            _commandGetRestaurants = CommandFactory.GetCommandGetRestaurants(null);
            _commandGetRestaurants.Execute();
            listRestaurants = (IList<Restaurant>)_commandGetRestaurants.Receiver;
        }
        [ExpectedException(typeof(Exception))]
        [Test(Description = "Excepción al generar una lista de restaurantes")]
        public void commandGetRestaurantsAllExceptionTest()
        {
            _commandGetRestaurants = CommandFactory.GetCommandGetRestaurants(name);
            _commandGetRestaurants.Execute();
            listRestaurants = (IList<Restaurant>)_commandGetRestaurants.Receiver;
        }
        #endregion

    }
}
