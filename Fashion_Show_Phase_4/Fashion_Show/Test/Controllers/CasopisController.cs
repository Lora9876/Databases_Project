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
    public class CasopisController : ApiController
    {
        public IEnumerable<Casopic> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetCasopisi();
        }
        public Casopic Get(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.GetCasopisi(id);
        }


        public int Post(Casopic g)
        {
            DataProvider provider = new DataProvider();
            return provider.AddCasopisi(g);
        }

        public int Put(int id, Casopic g)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateCasopisi(id, g);
        }

        public int Delete(Casopic g)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveCasopisi(g);
        }

    }
}
