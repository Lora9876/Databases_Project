using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fashion_Show.Entiteti
{
    public class Agencijski_Maneken : Maneken
    {

        public virtual Agencija PripadaAgeciji { get; set; }
        
    }
}
