using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionShow.Entiteti
{
    public class Casopic
    {
        public virtual int ID_Casopis { get; set; }
        public virtual string Naziv_Casopisa { get; set; }

        public virtual Maneken PripadaManekenu { get; set; }
       


    }
}
