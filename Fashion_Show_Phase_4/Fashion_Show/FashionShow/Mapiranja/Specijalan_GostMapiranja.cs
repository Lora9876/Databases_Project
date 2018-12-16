using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FashionShow.Entiteti;
using FluentNHibernate.Mapping;

namespace FashionShow.Mapiranja
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