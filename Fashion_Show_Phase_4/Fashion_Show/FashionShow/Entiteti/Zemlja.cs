using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionShow.Entiteti
{
    public class Zemlja
    {
        public virtual string Naziv_Zemlje { get; set; }
        public virtual int ID_Zemlja { get; set; }


        public virtual Internacionalna_Agencija PripadaAgenciji { get; set; }
        



    }


}
