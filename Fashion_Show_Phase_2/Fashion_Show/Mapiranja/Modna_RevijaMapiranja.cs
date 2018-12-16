using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fashion_Show.Entiteti;
using FluentNHibernate.Mapping;

namespace Fashion_Show.Mapiranja
{
    class Modna_RevijaMapiranja: ClassMap<Modna_Revija>
    {
        public Modna_RevijaMapiranja()//samo konstruktor
        {
            Table("MODNA_REVIJA");

            Id(x => x.Redni_Broj, "Redni_Broj").GeneratedBy.SequenceIdentity("S14909.MODNA_REVIJA_ID_SEQ");
           // Id(x => x.Redni_Broj).Column("Redni_Broj").GeneratedBy.TriggerIdentity();

            //mapiranje podklasa
            DiscriminateSubClassesOnColumn("Tip");

            Map(x => x.Naziv).Column("Naziv");
            Map(x => x.Mesto_Odrzavanja).Column("Mesto_Odrzavanja");
            Map(x => x.Datum_Vreme_Odrzavanja).Column("Datum_Vreme_Odrzavanja");
            Map(x => x.Tip).Column("Tip");
         

            HasMany(x => x.NastupaManekeni).KeyColumn("Rbr_Revije").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Prikazuje_NaKreator).KeyColumn("Rbr_Revije").LazyLoad().Cascade.All().Inverse();
        }

    }
    class Modna_Revija_Sa_Jednim_KreatoromMapiranja  : SubclassMap<Modna_Revija_Sa_Jednim_Kreatorom>
    {
        public Modna_Revija_Sa_Jednim_KreatoromMapiranja()
        {
            DiscriminatorValue("jedan");
        }
    }

    class Modna_Revija_Sa_Vise_KreatoraMapiranja : SubclassMap<Modna_Revija_Sa_Vise_Kreatora>
    {
        public Modna_Revija_Sa_Vise_KreatoraMapiranja()
        {
            DiscriminatorValue("vise");
            Map(x => x.Ranije_Nastupali_Zajedno).Column("Ranije_Nastupali_Zajedno");
        }
    }


}
