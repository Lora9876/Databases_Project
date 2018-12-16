using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
{
    class AgencijaMapiranja : ClassMap<Agencija>
    {
        public AgencijaMapiranja()
        {
            Table("AGENCIJA");

            //mapiranje primarnog kljuca
             Id(x => x.ID, "ID").GeneratedBy.SequenceIdentity("S14909.AGENCIJA_ID_SEQ");
           // Id(x =>x.ID ).Column("ID").GeneratedBy.TriggerIdentity();

            //mapiranje podklasa
            DiscriminateSubClassesOnColumn("Tip");

            //mapiranje svojstava
            //Map(x => x.Tip, "TIP");
            Map(x => x.PIB).Column("PIB");
            Map(x => x.Naziv).Column("Naziv");
            Map(x => x.Datum_Osnivanja).Column("Datum_Osnivanja");
            Map(x => x.Sediste).Column("Sediste");
           
            
          
            HasMany(x => x.AManekeni).KeyColumn("ID_Agencije").LazyLoad().Cascade.All().Inverse();

        }
    }

    class Internacionalna_AgencijaMapiranja : SubclassMap<Internacionalna_Agencija>
    {
        public Internacionalna_AgencijaMapiranja()
        {
            DiscriminatorValue("internacionalna");
            HasMany(x => x.Zemlje).KeyColumn("ID_IAgencije").Inverse().Cascade.All();
        }
    }

    class Domaca_AgencijaMapiranja: SubclassMap<Domaca_Agencija>
    {
        public Domaca_AgencijaMapiranja()
        {
            DiscriminatorValue("domaca");
        }
    }

}
