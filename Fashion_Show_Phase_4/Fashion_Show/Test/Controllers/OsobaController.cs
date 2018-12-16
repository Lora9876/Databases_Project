using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using MvcApplication1;
using Prodavnica;
using Prodavnica.Entiteti;

namespace MvcApplication1.Controllers
{
    public class OsobaController : ApiController
    {
        // OSOBA JE ENTITET KOJI SE KORISTI SAMO ZA IZVOĐENJE 
        
       /* public Osoba Get(int id)
        {
            DataProvider provider = new DataProvider();
            Osoba a = provider.GetOsoba(id);
            return a;
        }

        public IEnumerable<Osoba> Get()
        {
            DataProvider provider = new DataProvider();
            IEnumerable<Osoba> a = provider.GetOsoba();
            return a;
        }

        public int Post(Osoba osb)
        {
            DataProvider provider = new DataProvider();
            return provider.AddOsoba(osb);
        }

        public int Put(Osoba osb)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateOsoba(osb);
        }

        public int Delete(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveOsoba(id);
        }*/
    }
}
