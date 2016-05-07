﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    class TableMap: ClassMap<com.ds201625.fonda.Domain.Table>
    {
        public TableMap()
        {
            Table("TABLE");

            Id(x => x.Number)
              .Column("cat_menu_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Status)
              .Column("cat_menu_name")
              .Not.Nullable();

            References(x => x.Status)
                .Column("fk_cat_status")
                .Not.Nullable();

            References(x => x.RecordStatus)
              .Column("fk_cat_record")
              .Not.Nullable();
/*
            HasMany(x => x.ListDish)
                .KeyColumn("fk_menu_dish")
                .Inverse()
                .Cascade.Persist();
                */
            //TOdavia no falta que restarant cree su mappa
            /*References(x => x.Restaurant)
             .Column("fk_id_restaurant")
             .Not.Nullable();*/

        }
    }
}
