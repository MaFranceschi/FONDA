package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.entities.Commensal;
import com.ds201625.fonda.domains.entities.Restaurant;

import java.util.List;


/**
 * Interfaz para el servicio de Favoritos
 */
public interface FavoriteRestaurantService {

    Commensal AddFavoriteRestaurant(int idCommensal, int idRestaurant)  throws RestClientException;;
    Commensal deleteFavoriteRestaurant(int idCommensal, int idRestaurant)  throws RestClientException;;
    List<Restaurant> getAllFavoriteRestaurant(int idCommensal)  throws RestClientException;;

}