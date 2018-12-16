using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using Prodavnica;
using Prodavnica.Entiteti;

namespace MvcApplication1.Controllers
{
    public class ManekenController : ApiController
    {

        // MANEKEN JE ENTITET KOJI SE KORISTI SAMO ZA IZVOĐENJE 
     
   /*     public IEnumerable<Maneken> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetManekeni();
        }
        public Maneken Get(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.GetManekeni(id);
        }

        public int Post(Maneken mnk)
        {
            DataProvider provider = new DataProvider();
            return provider.AddManeken(mnk);
        }

        public int Put(Maneken mnk)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateManeken(mnk);
        }

        public int Delete(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveManeken(id);
        }
       */
    }
}
