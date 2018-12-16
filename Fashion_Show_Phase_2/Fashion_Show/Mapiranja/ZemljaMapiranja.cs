using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fashion_Show.Entiteti;
using FluentNHibernate.Mapping;

namespace Fashion_Show.Mapiranja
{
    public class ZemljaMapiranja : ClassMap<Zemlja>
    {
        public ZemljaMapiranja()
        {
            Table("ZEMLJA");
            //mapiranje primarnog kljuca
            Id(x => x.ID_Zemlja).Column("ID_Zemlja").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv_Zemlje, "Zemlja");

            References(x => x.PripadaAgenciji, "ID_IAgencije").LazyLoad();

        }


    }
}
