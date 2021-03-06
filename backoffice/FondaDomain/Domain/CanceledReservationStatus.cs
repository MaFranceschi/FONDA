﻿using com.ds201625.fonda.Resources.FondaResources.Reservations;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// La reserva está cancelada
    /// </summary>
    public class CanceledReservationStatus : ReservationStatus
    {
        /// <summary>
        /// La intancia unica
        /// </summary>
        private static CanceledReservationStatus _instance;

        /// <summary>
		/// Constructor
		/// </summary>
		protected CanceledReservationStatus() : base()
        {
            StatusId = 7;
            Description = ReservationResources.CanceledReservationStatusDes;
        }

        /// <summary>
        /// Obtiene el Estado Cancelada de una entidad
        /// </summary>
        public static CanceledReservationStatus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CanceledReservationStatus();

                return _instance;
            }
        }

        /// <summary>
        /// Retorna una descripcion del estado
        /// </summary>
        /// <returns>Cancelada en String</returns>
        public override string ToString()
        {
            return ReservationResources.CanceledReservationStatus;
        }

    }
}
