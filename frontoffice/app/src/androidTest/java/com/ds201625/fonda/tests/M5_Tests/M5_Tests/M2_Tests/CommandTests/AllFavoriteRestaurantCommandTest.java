package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.CommandTests;

import android.test.MoreAsserts;
import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.BaseEntity;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Katherina Molina on 11/06/2016.
 */

/**
 * Clase De pruebas unitarias del comando AllFavoriteRestaurant
 */
public class AllFavoriteRestaurantCommandTest extends TestCase {

    /*
       fabrica de comandos
    */
    private FondaCommandFactory facCmd;

    /*
       Variable de tipo Command
    */
    private Command cmd;

    /**
     * comensal logueado
     */
    private Commensal logedCommensal;

    /**
     * Variable lista de restaurantes favoritos
     */
    private List<Restaurant> restaurantList;

    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "AllFavoriteRestaurantCommandTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        facCmd = FondaCommandFactory.getInstance();
        logedCommensal = FondaEntityFactory.getInstance().GetCommensal(13);
    }


    /**
     *  Metodo para probar que la lista de favoritos de un comensal no es nula
     */
    public void testAllFavoriteRestaurantCommandIsNotNull() {

        try {

            cmd = facCmd.allFavoriteRestaurantCommand();
            cmd.setParameter(0,logedCommensal);
            cmd.run();
            restaurantList = (List<Restaurant>) cmd.getResult();

            assertNotNull(restaurantList.get(0).getName());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantCommandIsNotNull al listar los favorito",
                    e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantCommandIsNotNull al listar los favorito",
                    e);
        }
    }


    /**
     *  Metodo para probar que la lista de favoritos de un comensal no esta vacia
     */
    public void testAllFavoriteRestaurantCommandIsNotEmpty() {

        try {

            cmd = facCmd.allFavoriteRestaurantCommand();
            cmd.setParameter(0,logedCommensal);
            cmd.run();
            restaurantList = (List<Restaurant>) cmd.getResult();

           MoreAsserts.assertNotEmpty(restaurantList);
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantCommandIsNotEmpty al listar los favorito",
                    e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantCommandIsNotEmpty al listar los favorito",
                    e);
        }
    }

    /**
     *  Metodo para probar que los elementos de la lista no estan vacios
     */
    public void testAllFavoriteRestaurantCommandElements() {

        try {

            cmd = facCmd.allFavoriteRestaurantCommand();
            cmd.setParameter(0,logedCommensal);
            cmd.run();
            restaurantList = (List<Restaurant>) cmd.getResult();

            assertEquals("Pizza Familia", restaurantList.get(2).getName());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantCommandElements al listar los favorito",
                    e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantCommandElements al listar los favorito",
                    e);
        }
    }

    /**
     *  Metodo para probar que la lista de restaurantes favoritos es nula
     */
    public void testAllFavoriteRestaurantIsNull() {
        try {
            Commensal prueba = FondaEntityFactory.getInstance().GetCommensal(14);
            cmd = facCmd.allFavoriteRestaurantCommand();
            cmd.setParameter(0,prueba);
            cmd.run();
            restaurantList = (List<Restaurant>) cmd.getResult();
            assertNull(restaurantList);

        } catch(RestClientException e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantIsNull al listar los favorito",e);
        }
        catch(NullPointerException e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantIsNull al listar los favorito",e);
        }catch (Exception e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantIsNull al listar los favorito",e);
        }

    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        facCmd = null;
        cmd = null;
        restaurantList = null;
        logedCommensal = null;
    }


}
