using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;


namespace Prodavnica.Mapiranja
{
    class KreatorMapiranja : SubclassMap<Kreator>
    {
        public KreatorMapiranja()
        {
            Table("KREATOR");


            KeyColumn("ID");

            Map(x => x.Zemlja_Porekla).Column("Zemlja_Porekla");
            Map(x => x.Naziv_Modne_Kuce).Column("Naziv_Modne_Kuce");

            HasMany(x => x.Prikazuje_NaMRevija).KeyColumn("ID_Kreatora").LazyLoad().Cascade.All().Inverse();

        }
    }
}
