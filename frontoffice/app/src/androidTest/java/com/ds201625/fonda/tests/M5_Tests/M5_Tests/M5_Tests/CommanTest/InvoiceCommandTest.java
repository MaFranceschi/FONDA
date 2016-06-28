package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M5_Tests.CommanTest;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.logic.Commands.OrderCommands.LogicInvoiceCommand;

import junit.framework.TestCase;
import com.ds201625.fonda.logic.FondaCommandFactory;
import android.util.Log;

/**
 * Created by vickinsua on 6/28/2016.
 */
public class InvoiceCommandTest extends TestCase {
    /*
       fabrica de comandos
    */
    private FondaCommandFactory facCmd;

    /*
     Variable de tipo Command
  */
    private Command cmd;

    /*
         Objeto Invoice que contiene el pago de la cuenta
     */
    private Invoice invoice;

    /**
     * variable de la clase InvoiceService
     */

    private LogicInvoice invoiceLogic;

    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "InvoiceCommandTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        facCmd = FondaCommandFactory.getInstance();
        invoiceLogic = new LogicInvoiceCommand();
    }


    /*
     *  Metodo que prueba que la factura no es nula cuando  se conecta con el WS
     */
    public void testInvoiceIsNotNull() {

        try {
            cmd = facCmd.LogicInvoiceCommand();
            cmd.run();
            invoice = (invoiceLogic) cmd.getResult();
            //invoice = invoiceLogic.getInvoiceSW();
            assertNotNull(invoice);
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
            Log.e(TAG,"Error en testInvoiceIsNotNull no esta conectado al WS",e);
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceIsNotNull ",e);
        }
    }


    /*
     *  Metodo que prueba que existan elementos en la factura
     */
    public void testInvoiceElements() {

        try {
            cmd = facCmd.LogicInvoiceCommand();
            cmd.run();
            invoice = (invoiceLogic) cmd.getResult();
            //invoice = invoiceLogic.getInvoiceSW();
            assertNotNull(invoice);
            assertEquals("The dining room", invoice.getRestaurant().getName());
            assertEquals("Adriana", invoice.getProfile().getProfileName());
        }
        catch (NullPointerException e){
            //fail("No esta conectado al WS");
            Log.e(TAG,"Error entestInvoiceIsNotNull no esta conectado alWS ",e);
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testInvoiceElements ",e);
        }
    }

    /**
     * Metodo que prueba que el objeto Restaurant de la factura no este vacio
     */
    public void testRestaurantInvoiceIsNotEmpty() {
        try {
            cmd = facCmd.LogicInvoiceCommand();
            cmd.run();
            String nameRestaurant = "The dining room";
            invoice = (invoiceLogic) cmd.getResult();
            //invoice = invoiceLogic.getInvoiceSW();
            assertEquals(nameRestaurant, invoice.getRestaurant().getName());
        } catch (RestClientException e) {
            // e.printStackTrace();
            Log.e(TAG,"Error en testRestaurantInvoiceIsNotEmpty ",e);
        }
    }

    /**
     * Metodo que prueba que el objeto Restaurant de la factura no es nulo
     */
    public void testRestaurantInvoiceIsNotNull() {
        try {
            cmd = facCmd.LogicInvoiceCommand();
            cmd.run();
            invoice = (invoiceLogic) cmd.getResult();
            //invoice = invoiceLogic.getInvoiceSW();
            assertNotNull(invoice.getRestaurant());
        } catch (RestClientException e) {
            // e.printStackTrace();
            Log.e(TAG,"Error en testRestaurantInvoiceIsNotEmpty ",e);
        }
    }

    /**
     * Metodo que prueba que el objeto Profile de la factura no este vacio
     */
    public void testProfileInvoiceIsNotEmpty() {
        try {
            cmd = facCmd.LogicInvoiceCommand();
            cmd.run();
            String nameProfile = "Adriana";
            invoice = (invoiceLogic) cmd.getResult();
            //invoice = invoiceLogic.getInvoiceSW();
            assertEquals(nameProfile, invoice.getProfile().getProfileName());
        } catch (RestClientException e) {
            // e.printStackTrace();
            Log.e(TAG,"Error en testProfileInvoiceIsNotEmpty ",e);
        }
    }

    /**
     * Metodo que prueba que el objeto Profile de la factura no es nulo
     */
    public void testProfileInvoiceIsNotNull() {
        try {
            cmd = facCmd.LogicInvoiceCommand();
            cmd.run();
            invoice = (invoiceLogic) cmd.getResult();
            //invoice = invoiceLogic.getInvoiceSW();
            assertNotNull(invoice.getProfile());
        } catch (RestClientException e) {
            //e.printStackTrace
            Log.e(TAG,"Error en testProfileInvoiceIsNotNull ",e);
        }
    }


    /**
     * Metodo que prueba que el objeto Account de la factura no este vacio
     */
    public void testAccountInvoiceIsNotEmpty() {

        try {
            cmd = facCmd.LogicInvoiceCommand();
            cmd.run();
            invoice = (invoiceLogic) cmd.getResult();
            //invoice = invoiceLogic.getInvoiceSW();
            assertEquals(3, invoice.getAccount().getListDish().size());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testAccountInvoiceIsNotEmpty ",e);
        }
    }

    /**
     * Metodo que prueba que el objeto Account de la factura no es nulo
     */
    public void testAccountInvoiceIsNotNull() {
        try {
            cmd = facCmd.LogicInvoiceCommand();
            cmd.run();
            invoice = (invoiceLogic) cmd.getResult();
            //invoice = invoiceLogic.getInvoiceSW();
            assertNotNull(invoice.getAccount());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testAccountInvoiceIsNotNull ",e);
        }
    }

    /**
     * Metodo que prueba que el objeto Currency de la factura no este vacio
     */
    public void testCurrencyInvoiceIsNotEmpty() {
        try {
            cmd = facCmd.LogicInvoiceCommand();
            cmd.run();
            invoice = (invoiceLogic) cmd.getResult();
            //invoice = invoiceLogic.getInvoiceSW();
            assertEquals("Bolivar", invoice.getCurrency().getName());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testCurrencyInvoiceIsNotEmpty ",e);
        }

    }

    /**
     * Metodo que prueba que el objeto Currency de la factura no es nulo
     */
    public void testCurrencyInvoiceIsNotNull() {
        try {
            cmd = facCmd.LogicInvoiceCommand();
            cmd.run();
            invoice = (invoiceLogic) cmd.getResult();
            //invoice = invoiceLogic.getInvoiceSW();
            assertNotNull(invoice.getCurrency());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testCurrencyInvoiceIsNotNull ",e);
        }

    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        invoice = null;
        invoiceLogic = null;
        facCmd = null;
        cmd = null;
    }
}
