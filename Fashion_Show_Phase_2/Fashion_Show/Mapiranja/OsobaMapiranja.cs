using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fashion_Show.Entiteti;
using FluentNHibernate.Mapping;

namespace Fashion_Show.Mapiranja
{
    class OsobaMapiranja : ClassMap<Osoba>
    {
        public OsobaMapiranja()//samo konstruktor
        {
            Table("OSOBA");

            Id(x => x.ID, "ID").GeneratedBy.SequenceIdentity("S14909.OSOBA_ID_SEQ");
            //Id(x => x.ID).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Maticni_Broj).Column("Maticni_Broj");
            Map(x => x.Licno_Ime).Column("Licno_Ime");
            Map(x => x.Prezime).Column("Prezime");
            Map(x => x.Datum_Rodjenja).Column("Datum_Rodjenja");
            Map(x => x.Pol).Column("Pol");

         
        }

    }
}

