package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.ServiceTests;

import android.test.MoreAsserts;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.domains.Restaurant;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Katherina Molina on 11/06/2016.
 */

/**
 * Clase De pruebas unitarias de AllRestaurantServiceTest
 */
public class AllRestaurantServiceTest extends TestCase {

    /*
        Variable de la clase AllRestaurantService
     */
    private AllRestaurantService allRestaurantService;

    /**
     * Variable lista de restaurantes
     */
    private List<Restaurant> restaurantList;

    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "AllRestaurantServiceTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        allRestaurantService = FondaServiceFactory.getInstance().getAllRestaurantsService();
    }


    /**
     *  Metodo para probar que la lista de restaurantes no es nula
     */
    public void testAllRestaurantServiceIsNotNull() {

        try {

            restaurantList = allRestaurantService.getAllRestaurant();

            assertNotNull(restaurantList.get(0).getName());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAllRestaurantServiceIsNotNull al listar los restaurantes",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAllRestaurantServiceIsNotNull al listar los restaurantes",e);
        }
    }


    /**
     *  Metodo para probar que la lista de restaurantes no esta vacia
     */
    public void testAllRestaurantServiceIsNotEmpty() {

        try {

            restaurantList = allRestaurantService.getAllRestaurant();

           MoreAsserts.assertNotEmpty(restaurantList);
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAllRestaurantServiceIsNotEmpty al listar los restaurantes",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAllRestaurantServiceIsNotEmpty al listar los restaurantes",e);
        }
    }

    /**
     *  Metodo para probar que los elementos de la lista no estan vacios
     */
    public void testAllRestaurantServiceElements() {

        try {

            restaurantList = allRestaurantService.getAllRestaurant();

            assertEquals("Pizza Familia", restaurantList.get(2).getName());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAllRestaurantServiceElements al listar los restaurantes",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAllRestaurantServiceElements al listar los restaurantes",e);
        }
    }



    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        allRestaurantService = null;
        restaurantList = null;
    }


}
