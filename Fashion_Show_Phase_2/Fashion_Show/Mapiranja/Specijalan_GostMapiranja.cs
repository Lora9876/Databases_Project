using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fashion_Show.Entiteti;
using FluentNHibernate.Mapping;

namespace Fashion_Show.Mapiranja
{
    class Specijalan_GostMapiranja : SubclassMap<Specijalan_Gost>
    {
        public Specijalan_GostMapiranja()
        {
            Table("SPECIJALAN_GOST");

            KeyColumn("ID");

            Map(x => x.Zanimanje).Column("Zanimanje");
           

        }
    }
}