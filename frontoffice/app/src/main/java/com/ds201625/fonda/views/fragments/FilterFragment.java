package com.ds201625.fonda.views.fragments;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.widget.SwipeRefreshLayout;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.ListView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.views.contracts.RestaurantsFiltersContract;
import com.ds201625.fonda.views.presenters.RestaurantsFilterPresenter;

/**
 * Frament para la vista de busqueda de restaurantes
 */
public class FilterFragment extends BaseFragment
        implements SwipeRefreshLayout.OnRefreshListener,RestaurantsFiltersContract {

    /**
     * componentes de la vista
     */
    private ListView listView;
    private SwipeRefreshLayout swipeRefreshLayout;

    /**
     * presentador / controlador
     */
    private RestaurantsFilterPresenter presenter;

    /**
     * Para controlar la actualizacion de la lista con el scroll
     */
    private int lastfirstVisibleItem = 100;
    private int lastvisibleItemCount = 100;

    /**
     * Asignacion del presentador / controlador
     * @param presenter
     */
    public void setPresenter(RestaurantsFilterPresenter presenter) {
        this.presenter = presenter;
    }

    /**
     * Implementacion de contrato
     * @return
     */
    @Override
    public ListView getListView() {
        return this.listView;
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        //Obtencion de componentes
        View layout = inflater.inflate(R.layout.fragment_filter,container,false);
        swipeRefreshLayout = (SwipeRefreshLayout) layout.findViewById(R.id.srlUpdater);
        swipeRefreshLayout.setOnRefreshListener(this);
        if (this.listView == null)
            this.listView = (ListView)layout.findViewById(R.id.lvFilterList);

        // inicializacion de componetes y escuchas
        this.presenter.onCreateView();

        this.listView.setOnScrollListener(new AbsListView.OnScrollListener() {
            @Override
            public void onScrollStateChanged(AbsListView view, int scrollState) {

            }

            @Override
            public void onScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount) {

                if (totalItemCount > 0 && lastfirstVisibleItem !=firstVisibleItem
                        && lastvisibleItemCount != visibleItemCount) {
                    int lastInScreen = firstVisibleItem + visibleItemCount;
                    if(lastInScreen == totalItemCount) {
                        lastfirstVisibleItem =firstVisibleItem;
                        lastvisibleItemCount = visibleItemCount;
                        presenter.scrollOnBottom();
                    }
                }
            }
        });

        return layout;
    }

    @Override
    public void onRefresh() {
        this.swipeRefreshLayout.setRefreshing(true);
        this.presenter.onRefresh();
        this.swipeRefreshLayout.setRefreshing(false);
    }
}