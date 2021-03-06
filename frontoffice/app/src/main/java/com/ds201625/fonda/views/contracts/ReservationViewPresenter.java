package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetReservationFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.PostReservationFondaWebApiControllerException;
import com.ds201625.fonda.domains.Reservation;

import java.util.List;

/**
 * Created by Andreina on 22-06-2016.
 */
public interface ReservationViewPresenter {

    /**
     * Encuentra el comensal logueado
     */
    void findLoggedComensal();

    /**
     * Agrega una Reservacion
     * @param reservation
     */
    void addReservation(Reservation reservation);

    /**
     * Encuentra las reservaciones
     * @return
     */
    List<Reservation> AllReservation() throws PostReservationFondaWebApiControllerException, GetReservationFondaWebApiControllerException;

}
