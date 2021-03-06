﻿using System;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al modificar
    /// un Commensal en UpdateProfileCommand
    /// </summary>
    public class UpdateProfileCommandException : FondaBackendLogicException
    {
         public UpdateProfileCommandException  () : base() {	}

		public UpdateProfileCommandException (string message) : base(message) {	}

        public UpdateProfileCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
