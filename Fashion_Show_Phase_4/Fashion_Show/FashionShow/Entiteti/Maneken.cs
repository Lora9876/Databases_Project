using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionShow.Entiteti
{
    public class Maneken : Osoba
    {

        public virtual string Boja_Kose { get; set; }
        public virtual string Boja_Ociju { get; set; }
        public virtual int Visina { get; set; }
        public virtual int Tezina { get; set; }
        public virtual int Konfekcijski_Broj { get; set; }

        public virtual IList<Casopic> Casopisi { get; set; }
        public virtual IList<Nastupa> NastupaModna_Revija { get; set; }


        public Maneken()
        {
            Casopisi = new List<Casopic>();
            NastupaModna_Revija = new List<Nastupa>();

        }
    }
}
