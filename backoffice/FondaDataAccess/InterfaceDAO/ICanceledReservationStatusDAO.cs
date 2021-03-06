﻿using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface ICanceledReservationStatusDAO : IStatusDAO<CanceledReservationStatus>
    {
        CanceledReservationStatus getCanceledReservationStatus();

    }
}