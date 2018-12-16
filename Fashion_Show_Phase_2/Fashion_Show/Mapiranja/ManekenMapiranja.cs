using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fashion_Show.Entiteti;
using FluentNHibernate.Mapping;


namespace Fashion_Show.Mapiranja
{
    class ManekenMapiranja : SubclassMap<Maneken>
    {
        public ManekenMapiranja()
        {
            Table("MANEKEN");


            KeyColumn("ID");

            Map(x => x.Boja_Kose).Column("Boja_Kose");
            Map(x => x.Boja_Ociju).Column("Boja_Ociju");
            Map(x => x.Visina).Column("Visina");
            Map(x => x.Tezina).Column("Tezina");
            Map(x => x.Konfekcijski_Broj).Column("Konfekcijski_Broj");

            HasMany(x => x.Casopisi).KeyColumn("ID_Manekena").LazyLoad().Inverse().Cascade.All();
            HasMany(x => x.NastupaModna_Revija).KeyColumn("ID_Manekena").LazyLoad().Cascade.All().Inverse();

        }
    }
}
