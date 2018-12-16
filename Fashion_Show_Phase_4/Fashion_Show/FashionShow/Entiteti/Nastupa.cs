using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionShow.Entiteti
{
    public class Nastupa
    {
        public virtual int ID_Nastupa { get; set; }

        public virtual Modna_Revija NastupaModna_Revija { get; set; }

        public virtual Maneken NastupaManeken { get; set; }  


    }
}
