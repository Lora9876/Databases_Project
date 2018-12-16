using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionShow.Entiteti
{
    public abstract class Modna_Revija
    {
        public virtual int Redni_Broj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Mesto_Odrzavanja { get; set; }
        public virtual DateTime Datum_Vreme_Odrzavanja {get; set;}
        public virtual string Tip { get; set; }
       

        public virtual IList<Nastupa> NastupaManekeni {get; set;}
        public virtual IList<Prikazuje_Na> Prikazuje_NaKreator {get; set;}

     

        public Modna_Revija()
        {
            NastupaManekeni = new List<Nastupa>();
            Prikazuje_NaKreator = new List<Prikazuje_Na>();
        }

    }

    public class Modna_Revija_Sa_Jednim_Kreatorom : Modna_Revija
    {
    }

    public class Modna_Revija_Sa_Vise_Kreatora : Modna_Revija
    {
       public virtual string Ranije_Nastupali_Zajedno { get; set; }
    }

}
