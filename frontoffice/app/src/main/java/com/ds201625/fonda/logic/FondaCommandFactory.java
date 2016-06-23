package com.ds201625.fonda.logic;

import com.ds201625.fonda.logic.Commands.CommensalCommands.CreateCommensalCommand;
import com.ds201625.fonda.logic.Commands.CommensalCommands.DeleteCommensalCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.AddFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.AllFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.CreateProfileCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.AllRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.DeleteFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.RequireLogedCommensalCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.DeleteProfileCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.GetProfilesCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.UpdateProfileCommand;
import com.ds201625.fonda.logic.Commands.OrderCommands.*;

/**
 * Fabrica de comandos
 */
public class FondaCommandFactory {

    /**
     * Instancia Singelton de la fabrica
     */
    private static FondaCommandFactory instance;

    /**
     * Obtiene la instancio singelton de la fabrica
     * @return instancio singelton de la fabrica
     */
    public static FondaCommandFactory getInstance() {
        if (instance == null)
            instance = new FondaCommandFactory();

        return instance;
    }

    public FondaCommandFactory() {  }

    /**
     * Crea un CreateProfileCommand
     * @return comando CreateProfileCommand
     */
    public static Command createCreateProfileCommand() {
        return  new CreateProfileCommand();
    }

    /**
     * Crea un AddFavoriteRestaurantCommand
     * @return comando AddFavoriteRestaurantCommand
     */
    public static Command addFavoriteRestaurantCommand() {
        return  new AddFavoriteRestaurantCommand();
    }

    /**
     * Crea un DeleteFavoriteRestaurantCommand
     * @return comando DeleteFavoriteRestaurantCommand
     */
    public static Command deleteFavoriteRestaurantCommand() {
        return  new DeleteFavoriteRestaurantCommand();
    }

    /**
     * Crea un AllFavoriteRestaurantCommand
     * @return comando AllFavoriteRestaurantCommand
     */
    public static Command allFavoriteRestaurantCommand() {
        return  new AllFavoriteRestaurantCommand();
    }

    /**
     * Crea un AllRestaurantCommand
     * @return comando AllRestaurantCommand
     */
    public static Command allRestaurantCommand() {
        return  new AllRestaurantCommand();
    }

    /**
     * Crea un RequireLogedCommensalCommand
     * @return comando RequireLogedCommensalCommand
     */
    public static Command requireLogedCommensalCommand() {
        return  new RequireLogedCommensalCommand();
    }

    /**
     * Crea un updateProfileCommand
     * @return comando updateProfileCommand
     */
    public static Command updateProfileCommand() {
        return  new UpdateProfileCommand();
    }

    /**
     * Crea un deleteProfileCommand
     * @return comando deleteProfileCommand
     */
    public static Command deleteProfileCommand() {
        return  new DeleteProfileCommand();
    }

    /**
     * Crea un getProfilesCommand
     * @return comando getProfilesCommand
     */
    public static Command getProfilesCommand() { return  new GetProfilesCommand(); }

    /**
     * Crea un createCommensalCommand
     * @return comando createCommensalCommand
     */
    public static Command createCommensalCommand() { return  new CreateCommensalCommand(); }

    /**
     * Crea un deleteCommensalCommand
     * @return comando deleteCommensalCommand
     */
    public static Command deleteCommensalCommand() { return  new DeleteCommensalCommand(); }

    /**
     * Crea un LogicCurrentOrderCommand
     * @return comando LogicCurrentOrderCommand
     */
    public static Command logicCurrentOrderCommand() {
        return  new LogicCurrentOrderCommand();
    }

    /**
     * Crea un LogicHistoryVisitsCommand
     * @return comando LogicHistoryVisitsCommand
     */
    public static Command logicHistoryVisitsCommand() {
        return  new LogicHistoryVisitsCommand();
    }

    /**
     * Crea un LogicInvoiceCommand
     * @return comando LogicInvoiceCommand
     */
    public static Command logicInvoiceCommand() {
        return  new LogicInvoiceCommand();
    }
}

