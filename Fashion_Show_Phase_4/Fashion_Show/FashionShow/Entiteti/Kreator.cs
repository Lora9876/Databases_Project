using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionShow.Entiteti
{ 
    public class Kreator : Osoba
    {
        
        public virtual string Zemlja_Porekla { get; set; }
        public virtual string Naziv_Modne_Kuce { get; set; }

        public virtual IList<Prikazuje_Na> Prikazuje_NaMRevija { get; set; }

         public Kreator()
        {
             Prikazuje_NaMRevija=new List<Prikazuje_Na>();
           
        }
    }
}
