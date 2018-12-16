using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionShow.Entiteti
{
    public class Prikazuje_Na
    {
        public virtual int ID_Prikazuje { get; set; }

        public virtual Modna_Revija PrikazujeModna_Revija { get; set; }

        public virtual Kreator PrikazujeKreator { get; set; }  


    }
}
