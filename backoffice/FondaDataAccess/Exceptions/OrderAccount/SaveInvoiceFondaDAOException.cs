﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class SaveInvoiceFondaDAOException : FondaDAOException
    {
        #region Constructors

        public SaveInvoiceFondaDAOException() : base() { }

        public SaveInvoiceFondaDAOException(string message) : base(message) { }

        public SaveInvoiceFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
