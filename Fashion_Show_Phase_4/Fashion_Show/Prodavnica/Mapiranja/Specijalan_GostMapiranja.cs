using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodavnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Prodavnica.Mapiranja
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