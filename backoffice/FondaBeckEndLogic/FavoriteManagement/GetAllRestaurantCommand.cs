﻿using System;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.FondaBackEndLogic.Exceptions;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaBeckEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;


namespace com.ds201625.fonda.BackEndLogic.FavoriteManagement
{
    /// <summary>
    /// Get All Restaurant Command.
    /// </summary>
    class GetAllRestaurantCommand : BaseCommand
    {
        private IList<Restaurant> listRestaurant;
        private List<Restaurant> newListRestaurant;
        private IRestaurantDAO RestaurantDAO;
        /// <summary>
        /// constructor obtener todos los restaurant command
        /// </summary>
        public GetAllRestaurantCommand() : base() { }

        /// <summary>
        /// metodo que inicializa los parametros
        /// </summary>
        /// <returns>paramters</returns>
        protected override Parameter[] InitParameters()
        {
            // Requiere 0 Parametros
            Parameter[] paramters = new Parameter[0];
            return paramters;
        }

        /// <summary>
        /// metodo invoke que ejecuta la obtencion de todos los restaurantes
        /// </summary>
        protected override void Invoke()
        {
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                // Obtiene el dao que se requiere
                RestaurantDAO = FacDao.GetRestaurantDAO();
                // Ejecucion del obtener.	
                listRestaurant = (IList<Restaurant>)RestaurantDAO.GetAll();
                newListRestaurant = new List<Restaurant>();
                foreach (var restaurant in listRestaurant)
                {

                    if (restaurant.Status.StatusId == 1)
                    {

                        Console.Write("IDDD" + restaurant.Status.StatusId);
                        restaurant.RestaurantCategory = new RestaurantCategory
                        {
                            Name = restaurant.RestaurantCategory.Name,
                            Id = restaurant.RestaurantCategory.Id,

                        };
                        newListRestaurant.Add(restaurant);
                    }

                    Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                      ResourceMessages.Restaurant + restaurant.Name + ResourceMessages.Slash +
                      restaurant.RestaurantCategory, System.Reflection.MethodBase.GetCurrentMethod().Name);
                }


            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsCommandException(ResourceMessages.ParametersGetAllRestException, e);
            }
            catch (FindAllFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsCommandException(ResourceMessages.GetAllRestaurantException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsCommandException(ResourceMessages.GetAllRestaurantException, e);
            }

            // Guardar el resultado.
            Result = newListRestaurant;
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}