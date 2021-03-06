﻿using System;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al buscar
    /// un Perfil de un Commensal en GetProfileCommand
    /// </summary>
    public class GetProfileCommandException : FondaBackendLogicException
    {
         public GetProfileCommandException  () : base() {	}

		public GetProfileCommandException (string message) : base(message) {	}

        public GetProfileCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
