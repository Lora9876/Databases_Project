using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FashionShow.Entiteti;
using FluentNHibernate.Mapping;

namespace FashionShow.Mapiranja
{
    class NastupaMapiranja : ClassMap<Nastupa>
    {
        public NastupaMapiranja()
        {
            //Mapiranje tabele
            Table("NASTUPA");

            //mapiranje primarnog kljuca
            Id(x => x.ID_Nastupa).Column("ID_Nastupa").GeneratedBy.TriggerIdentity();
            //Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S14909.NASTUPA_ID_SEQ");

            //mapiranje veza
            References(x => x.NastupaModna_Revija).Column("Rbr_Revije");
            References(x => x.NastupaManeken).Column("ID_Manekena");
        }
    }
}
