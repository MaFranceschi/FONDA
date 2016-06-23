package com.ds201625.fonda.logic.Commands.CommensalCommands;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

import java.util.Date;

/**
 * Comando para crear un Token
 */
public class CreateTokenFileCommand extends BaseCommand {

    private String TAG = "CreateTokenFileCommand";

    /**
     * Se asignan los parametros del commando
     * @return el parametro Context y commensal
     */

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[2];
        parameters[0] = new Parameter(Context.class, true);
        parameters[1] = new Parameter(Commensal.class, true);
        return parameters;
    }

    @Override
    protected void invoke() {

        Log.d(TAG, "Comando para eliminar un Token");
        Context context;
        Commensal commensal;
        Token tokenTest = null;

        try
        {
            context = (Context) getParameter(0);
            commensal = (Commensal) getParameter(1);
            TokenService tokenService = FondaServiceFactory.getTokenService(commensal);
            tokenTest = tokenService.createToken(context);
        }
        catch (RestClientException e)
        {
            Log.e(TAG, "Se ha generado error en invoke al crear un Token", e);
            e.printStackTrace();
        }
        catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al crear un Token", e);
            e.printStackTrace();
        }
        catch (Exception e)
        {
            Log.e(TAG, "Se ha generado error en invoke al crear un Token", e);
            e.printStackTrace();
        }

        setResult(tokenTest);
    }
}