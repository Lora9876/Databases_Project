using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FashionShow.Entiteti;
using FluentNHibernate.Mapping;


namespace FashionShow.Mapiranja
{
    class Agencijski_ManekenMapiranja : SubclassMap<Agencijski_Maneken>
    {
        public Agencijski_ManekenMapiranja()
        {
            Table("AGENCIJSKI_MANEKEN");

            KeyColumn("ID");

            References(x => x.PripadaAgeciji).Column("ID_Agencije").Not.LazyLoad();
           

        }
    }
}
