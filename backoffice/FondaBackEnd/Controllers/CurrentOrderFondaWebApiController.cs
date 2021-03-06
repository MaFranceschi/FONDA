﻿using System;
using System.Web.Http;
using System.Linq;
using System.Collections;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using Newtonsoft.Json;
using com.ds201625.fonda.Factory;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    /// <summary>
    /// clase que controla la api del ws
    /// </summary>
    public class CurrentOrderFondaWebApiController : FondaWebApi
    {
        /// <summary>
        /// Metodo que controla la lista de platos de una orden 
        /// </summary>
        public CurrentOrderFondaWebApiController() : base() { }

        //[Route("listDishOrder")]
        //[HttpGet]
        ///// <summary>
        /////Metodo que obtiene la lista de platos de la orden
        ///// </summary>
        ///// <returns> lista de platos de la orden</returns>
        //  public IHttpActionResult getListDishOrder()
        //  {

        //    Account account = (Account)EntityFactory.GetInvoice();
                        
        //    Dish dish1 = new Dish();
        //    dish1.Name = "Pasta";
        //    dish1.Description = "Pasta Con Salmon";
        //    dish1.Cost = 1000;
        //    dish1.Image = "salmonpasta";

        //    Dish dish2 = new Dish();
        //    dish2.Name = "Refresco";
        //    dish2.Description = "Coca-Cola";
        //    dish2.Cost = 100;
        //    dish2.Image = "refresco";

        //    Dish dish3 = new Dish();
        //    dish3.Name = "Torta";
        //    dish3.Description = "Terciopelo Rojo";
        //    dish3.Cost = 500;
        //    dish3.Image = "redv2";

        //    DishOrder dishO1 = new DishOrder();
        //    dishO1.Dish = dish1;
        //    dishO1.Count = 1;

        //    DishOrder dishO2 = new DishOrder();
        //    dishO2.Dish = dish2;
        //    dishO2.Count = 1;

        //    DishOrder dishO3 = new DishOrder();
        //    dishO3.Dish = dish3;
        //    dishO3.Count = 1;

        //    account.AddDish(dishO1);
        //    account.AddDish(dishO2);
        //    account.AddDish(dishO3);
              
        //      return Ok(account.ListDish);
        //  }
    }
}
