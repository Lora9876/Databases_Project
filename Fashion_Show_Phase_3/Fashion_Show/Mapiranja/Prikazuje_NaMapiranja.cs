using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fashion_Show.Entiteti;
using FluentNHibernate.Mapping;

namespace Fashion_Show.Mapiranja
{
    class Prikazuje_NaMapiranja : ClassMap<Prikazuje_Na>
    {
        public Prikazuje_NaMapiranja()
        {
            //Mapiranje tabele
            Table("PRIKAZUJE_NA");

            //mapiranje primarnog kljuca
            Id(x => x.ID_Prikazuje).Column("ID_Prikazuje").GeneratedBy.TriggerIdentity();

            //mapiranje veza
            References(x => x.PrikazujeModna_Revija).Column("Rbr_Revije");
            References(x => x.PrikazujeKreator).Column("ID_Kreatora");
        }
    }
}