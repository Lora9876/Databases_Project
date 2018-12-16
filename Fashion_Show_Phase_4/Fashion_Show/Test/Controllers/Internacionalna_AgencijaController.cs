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
    public class Internacionalna_AgencijaController : ApiController
    {
        public Internacionalna_Agencija Get(int id)
        {
            DataProvider provider = new DataProvider();
            Internacionalna_Agencija a = provider.GetInternacionalneAgencije(id);
            return a;
        }

        public IEnumerable<Internacionalna_Agencija> Get()
        {
            DataProvider provider = new DataProvider();
            IEnumerable<Internacionalna_Agencija> a = provider.GetInternacionalneAgencije();
            return a;
        }

        public int Post(Internacionalna_Agencija agn)
        {
            DataProvider provider = new DataProvider();
            return provider.AddInternacionalneAgencije(agn);
        }

        public int Put(Internacionalna_Agencija agn)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateInternacionalneAgencije(agn);
        }

        public int Delete(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveInternacionalneAgencije(id);
        }

    }
}
