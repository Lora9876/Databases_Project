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
    public class Modna_RevijaController : ApiController
    {


        // MODNA REVIJA JE ENTITET KOJI SE KORISTI SAMO ZA IZVOĐENJE 
     
     /*   public IEnumerable<Modna_Revija> Get()
        {
            DataProvider provider = new DataProvider();
            IEnumerable<Modna_Revija> a = provider.GetModneRevije();
            return a;
        }
        public Modna_Revija Get(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.GetModneRevije(id);

        }

        public int Post(Modna_Revija mdr)
        {
            DataProvider provider = new DataProvider();
            return provider.AddModneRevije(mdr);
        }

        public int Put(Modna_Revija mdr)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateModneRevije(mdr);
        }

        public int Delete(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveModneRevije(id);
        }
        */
    }
}
