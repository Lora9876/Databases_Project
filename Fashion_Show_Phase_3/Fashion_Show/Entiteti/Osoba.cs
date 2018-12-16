using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fashion_Show.Entiteti
{
    public class Osoba
    {
        public virtual int ID { get; set; }
        public virtual long Maticni_Broj { get; set; }
        public virtual string Licno_Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime Datum_Rodjenja { get; set; }
        public virtual string Pol { get; set; } //u bazi podataka varchar(2) zbog velikog slova
       
    }
}
