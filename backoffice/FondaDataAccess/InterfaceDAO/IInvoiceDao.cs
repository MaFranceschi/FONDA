﻿using System;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IInvoiceDao : IBaseEntityDAO <Invoice>
    {
        IList<Invoice> findAllInvoice(Profile profile);
        IList<Invoice> FindGenerateInvoiceByAccount(Account _account);
        IList<Invoice> FindInvoiceByRestaurant(Restaurant _restaurant);
        int GenerateNumberInvoice(Restaurant _restaurant);
    }
}
