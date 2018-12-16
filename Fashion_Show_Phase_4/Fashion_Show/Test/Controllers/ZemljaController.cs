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
    public class ZemljaController : ApiController
    {
        public IEnumerable<Zemlja> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetZemlje();
        }
        public Zemlja Get(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.GetZemlje(id);
        }


        public int Post(Zemlja g)
        {
            DataProvider provider = new DataProvider();
            return provider.AddZemlje(g);
        }

        public int Put(int id, Zemlja g)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateZemlje(id, g);
        }

        public int Delete(Zemlja g)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveZemlje(g);
        }        // GET: /Zemlja/

      

    }
}
