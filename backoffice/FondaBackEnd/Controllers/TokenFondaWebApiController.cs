﻿using System;
using System.Web.Http;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEnd.Log;
using com.ds201625.fonda.BackEnd.Exceptions;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.Factory;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	/// <summary>
	/// Token fonda web API controller.
	/// </summary>
	public class TokenFondaWebApiController : FondaWebApi
	{
        /// <summary>
        /// Constructor de TokenFondaWebApiController
        /// </summary>
		public TokenFondaWebApiController () : base () {}

		[FondaAuthLogin]
		[Route("token")]
		[HttpPost]
		/// <summary>
		/// Gets the token.
		/// </summary>
		/// <returns>The token.</returns>
		public IHttpActionResult getToken()
		{
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            Token token;
            try
            {
                Commensal commensal = GetCommensal(Request.Headers);
                if (commensal == null)
                    return BadRequest();

                // Se obtiene el commando CreateCreateProfileCommand 
                ICommand command = FacCommand.GetTokenCommand();

                // Se agrega el commensal como parametro
                command.SetParameter(0, commensal);

                //se ejecuta el comando
                command.Run();

                token = (Token)command.Result;

                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.Token + commensal.Id, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetCommensalFondaWebApiException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                return InternalServerError(e);
            }
            catch (GetTokenCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                return InternalServerError(e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                return InternalServerError(e);
            }
            catch (InvalidTypeOfParameterException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                return InternalServerError(e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                return InternalServerError(e);
            }
            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(token);
		}

        [FondaAuthLogin]
        [Route("token/{id}")]
        [HttpDelete]
		/// <summary>
		/// Deletes the token.
		/// </summary>
		/// <returns>The token.</returns>
		/// <param name="id">Identifier.</param>
        public IHttpActionResult deleteToken(int id)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            Token token = EntityFactory.GetToken();
            token.Id = id;
            try
            {
                Commensal commensal = GetCommensal(Request.Headers);
                if (commensal == null)
                    return BadRequest();

                // Se obtiene el commando CreateCreateProfileCommand 
                ICommand command = FacCommand.DeleteTokenCommensalCommand();
                
                // Se agrega el commensal como parametro
                command.SetParameter(0, commensal);
                // Se agrega el Token como parametro
                command.SetParameter(1, token);

                //se ejecuta el comando
                command.Run();

                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.Token + commensal.Id, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetCommensalFondaWebApiException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                return InternalServerError(e);
            }
            catch (DeleteTokenCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                return InternalServerError(e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                return InternalServerError(e);
            }
            catch (InvalidTypeOfParameterException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                return InternalServerError(e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                return InternalServerError(e);
            }
            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(token);
        }
    }
}

