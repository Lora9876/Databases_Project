using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionShow.Entiteti
{
    public abstract class Agencija
    {
        public virtual int ID { get; set; }
        public virtual int PIB { get; set; }
        public virtual string Naziv { get; set; }
        public virtual DateTime Datum_Osnivanja { get; set; }
        public virtual string Sediste { get; set; }
        public virtual string Tip { get; set; }

        public virtual IList<Agencijski_Maneken> AManekeni { get; set; }
      

        public Agencija()
        {
            AManekeni=new List<Agencijski_Maneken>();

        }
    }
    public class Internacionalna_Agencija : Agencija
    {
        public virtual IList<Zemlja> Zemlje { get; set; }
        public Internacionalna_Agencija()
        {
            Zemlje = new List<Zemlja>();

        }
    }

    public class Domaca_Agencija : Agencija
    {
    }

   
}
