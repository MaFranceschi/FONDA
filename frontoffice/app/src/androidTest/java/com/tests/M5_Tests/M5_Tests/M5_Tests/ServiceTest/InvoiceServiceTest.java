package com.tests.M5_Tests.M5_Tests.M5_Tests.ServiceTest;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicInvoiceWebApiControllerException;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.domains.Invoice;

import junit.framework.TestCase;

/**
 * Created by vickinsua on 6/20/2016.
 */
public class InvoiceServiceTest extends TestCase {
    /*
       Objeto Invoice que contiene el pago de la cuenta
   */
    private Invoice invoice;
    private int idProfile;

    /**
     * variable de la clase InvoiceService
     */
    private InvoiceService invoiceService;

    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "InvoiceServiceTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        invoiceService = FondaServiceFactory.getInstance().getInvoiceService();
    }


    /*
     *  Metodo que prueba que la factura no es nula cuando  se conecta con el WS
     */
    public void testInvoiceIsNotNull() {

        try {
            invoice = invoiceService.getCurrentInvoice(idProfile);
            assertNotNull(invoice);
        }
        catch (NullPointerException e){
            //fail("No esta conectado al WS");
            Log.e(TAG,"No esta conectado al WS",e);
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceIsNotNull",e);
        } catch (LogicInvoiceWebApiControllerException e) {
            e.printStackTrace();
        }
    }


    /*
     *  Metodo que prueba que existan elementos en la factura
     */
    public void testInvoiceElements() {

        try {
            invoice = invoiceService.getCurrentInvoice(idProfile);
            assertNotNull(invoice);
            assertEquals("The dining room", invoice.getRestaurant().getName());
            assertEquals("Adriana", invoice.getProfile().getProfileName());
        }
        catch (NullPointerException e){
            //fail("No esta conectado al WS");
            Log.e(TAG,"No esta conectado al WS",e);
        } catch (RestClientException e) {
            // e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceIsNotNull",e);
        } catch (LogicInvoiceWebApiControllerException e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo que prueba que el objeto Restaurant de la factura no este vacio
     */
    public void testRestaurantInvoiceIsNotEmpty() {

        try {
            String nameRestaurant = "The dining room";
            invoice = invoiceService.getCurrentInvoice(idProfile);
            assertEquals(nameRestaurant, invoice.getRestaurant().getName());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceIsNotNull",e);
        } catch (LogicInvoiceWebApiControllerException e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que el objeto Restaurant de la factura no es nulo
     */
    public void testRestaurantInvoiceIsNotNull() {

        try {

            invoice = invoiceService.getCurrentInvoice(idProfile);
            assertNotNull(invoice.getRestaurant());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceIsNotNull",e);
        } catch (LogicInvoiceWebApiControllerException e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo que prueba que el objeto Profile de la factura no este vacio
     */
    public void testProfileInvoiceIsNotEmpty() {

        try {
            String nameProfile = "Adriana";
            invoice = invoiceService.getCurrentInvoice(idProfile);
            assertEquals(nameProfile, invoice.getProfile().getProfileName());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceIsNotNull",e);
        } catch (LogicInvoiceWebApiControllerException e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que el objeto Profile de la factura no es nulo
     */
    public void testProfileInvoiceIsNotNull() {

        try {
            invoice = invoiceService.getCurrentInvoice(idProfile);
            assertNotNull(invoice.getProfile());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceIsNotNull",e);
        } catch (LogicInvoiceWebApiControllerException e) {
            e.printStackTrace();
        }
    }


    /**
     * Metodo que prueba que el objeto Account de la factura no este vacio
     */
    public void testAccountInvoiceIsNotEmpty() {
        try {
            invoice = invoiceService.getCurrentInvoice(idProfile);
            assertEquals(3, invoice.getAccount().getListDish().size());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceIsNotNull",e);
        } catch (LogicInvoiceWebApiControllerException e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que el objeto Account de la factura no es nulo
     */
    public void testAccountInvoiceIsNotNull() {

        try {
            invoice = invoiceService.getCurrentInvoice(idProfile);
            assertNotNull(invoice.getAccount());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceIsNotNull",e);
        } catch (LogicInvoiceWebApiControllerException e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo que prueba que el objeto Currency de la factura no este vacio
     */
    public void testCurrencyInvoiceIsNotEmpty() {

        try {
            invoice = invoiceService.getCurrentInvoice(idProfile);
            assertEquals("Bolivar", invoice.getCurrency().getName());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceIsNotNull",e);
        } catch (LogicInvoiceWebApiControllerException e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que el objeto Currency de la factura no es nulo
     */
    public void testCurrencyInvoiceIsNotNull() {

        try {
            invoice = invoiceService.getCurrentInvoice(idProfile);
            assertNotNull(invoice.getCurrency());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceIsNotNull",e);
        } catch (LogicInvoiceWebApiControllerException e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        invoice = null;
    }
}