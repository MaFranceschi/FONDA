package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListView;
import android.widget.Toast;
import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.ExpandableListAdapter;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class HistoryVisitFragment extends BaseFragment {
    List<String> groupList;
    List<String> childList;
    Map<String, List<String>> coleccionDevisitas;
    ExpandableListView expListView;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) { createGroupList();
      View layout =  (inflater.inflate(R.layout.fragment_historial_visitas,container,false));
        createCollection();

        expListView = (ExpandableListView) layout.findViewById(R.id.laptop_list);
        final ExpandableListAdapter expListAdapter = new ExpandableListAdapter(
                getContext(), groupList, coleccionDevisitas);
        expListView.setAdapter(expListAdapter);

        //setGroupIndicatorToRight();

        expListView.setOnChildClickListener(new ExpandableListView.OnChildClickListener() {

            public boolean onChildClick(ExpandableListView parent, View v,
                                        int groupPosition, int childPosition, long id) {
                final String selected = (String) expListAdapter.getChild(
                        groupPosition, childPosition);
                Toast.makeText(getContext(), selected, Toast.LENGTH_LONG)
                        .show();

                return true;
            }
        });
        return layout;

    }

    private void createGroupList() {
        groupList = new ArrayList<String>();
        groupList.add("RESTAURANTE: El tinajero                                12/10/15");
        groupList.add("RESTAURANTE: La Castanuela                              12/10/15");
        groupList.add("RESTAURANTE: Moute Grill                                12/10/15");
        groupList.add("RESTAURANTE: Chino                                      12/10/15");
        groupList.add("RESTAURANTE: Loreto                                     12/10/15");
    }

    private void createCollection() {
        // preparing laptops collection(child)
        String[] data1 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data2 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data3 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data4 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data5 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };


        coleccionDevisitas = new LinkedHashMap<String, List<String>>();

        for (String laptop : groupList) {
            if (laptop.equals("RESTAURANTE: El tinajero                                12/10/15")) {
                loadChild(data1);
            } else if (laptop.equals("RESTAURANTE: La Castanuela                              12/10/15"))
                loadChild(data2);
            else if (laptop.equals("RESTAURANTE: Moute Grill                                12/10/15"))
                loadChild(data3);
            else if (laptop.equals("RESTAURANTE: Chino                                      12/10/15"))
                loadChild(data4);
            else  if (laptop.equals("RESTAURANTE: Loreto                                     12/10/15"))
                loadChild(data5);

            coleccionDevisitas.put(laptop, childList);
        }
    }

    private void loadChild(String[] laptopModels) {
        childList = new ArrayList<String>();
        for (String model : laptopModels)
            childList.add(model);
    }


    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }

}