using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
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
