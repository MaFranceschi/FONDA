﻿using System;
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
    /// Create Favorite Restaurant Command.
    /// </summary>
    class CreateFavoriteRestaurantCommand : BaseCommand 
    {

        private Commensal commensal;
        private Restaurant restaurant;
        private ICommensalDAO commensalDAO;
        private IRestaurantDAO restaurantDAO;

        /// <summary>
        /// constructor create Favorite restaurant command
        /// </summary>
         public CreateFavoriteRestaurantCommand() : base() { }
         
         /// <summary>
         /// metodo que inicializa los parametros
         /// </summary>
         /// <returns>paramters</returns>
		protected override Parameter[] InitParameters ()
		{
            // Requiere 2 Parametros
            Parameter[] paramters = new Parameter[2];

            // [0] el Commensal
            paramters[0] = new Parameter(typeof(Commensal), true);

            // [1] El Restaurant
            paramters[1] = new Parameter(typeof(Restaurant), true);
            return paramters;
        }

        /// <summary>
        /// metodo invoke que ejecuta el agregar restaurant favorito
        /// </summary>
		protected override void Invoke()
		{
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.BeginLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);
           
            // Obtencion de parametros
            Commensal  idCommensal = (Commensal)GetParameter(0);
            Restaurant idRestaurant = (Restaurant)GetParameter(1);
            // Obtiene el DAO que se requiere
            commensalDAO = FacDao.GetCommensalDAO();
            restaurantDAO = FacDao.GetRestaurantDAO();

            if ((idCommensal.Id <= 0) || (idRestaurant.Id <= 0))
                throw new Exception(ResourceMessages.InvalidInformation);
           
            // Ejecucion del agregar.		
			try
			{
                commensal  = (Commensal)commensalDAO.FindById(idCommensal.Id);
                restaurant = (Restaurant)restaurantDAO.FindById(idRestaurant.Id);
                commensal.RemoveFavoriteRestaurant(restaurant);
                commensal.AddFavoriteRestaurant(restaurant);
                commensalDAO.Save(commensal);
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                    ResourceMessages.RestAddedToFav + commensal.Id + ResourceMessages.Slash + restaurant.Name,
                   System.Reflection.MethodBase.GetCurrentMethod().Name);
               
            }
            catch (InvalidTypeOfParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateFavoriteRestaurantCommandException(ResourceMessages.ParametersAddFavRestException, e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateFavoriteRestaurantCommandException(ResourceMessages.ParametersAddFavRestException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateFavoriteRestaurantCommandException(ResourceMessages.ParametersAddFavRestException, e);
            }
			catch (SaveEntityFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new CreateFavoriteRestaurantCommandException(ResourceMessages.AddFavRestException, e);
               
			}
			catch (Exception e)
			{
               Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               throw new CreateFavoriteRestaurantCommandException(ResourceMessages.AddFavRestException, e);
			}
            // Guarda el resultado.
            Result = commensal;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                Result.ToString(),System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                ResourceMessages.EndLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);
		}
	}
}
  