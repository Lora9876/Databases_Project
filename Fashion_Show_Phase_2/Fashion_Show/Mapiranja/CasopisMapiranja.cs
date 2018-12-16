using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fashion_Show.Entiteti;
using FluentNHibernate.Mapping;

namespace Fashion_Show.Mapiranja
{

    public class CasopisMapiranja : ClassMap<Casopic>
    {
        public CasopisMapiranja()
        {
            Table("CASOPIS");

            //mapiranje primarnog kljuca
            Id(x => x.ID_Casopis).Column("ID_Casopis").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv_Casopisa, "Casopis");
            References(x => x.PripadaManekenu, "ID_Manekena").LazyLoad();
        }
    }




}
