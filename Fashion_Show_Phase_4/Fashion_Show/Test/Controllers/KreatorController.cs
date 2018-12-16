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
using System.Net.Http;
using System.Web.Http;
using Prodavnica;
using Prodavnica.Entiteti;

namespace MvcApplication1.Controllers
{
    public class KreatorController : ApiController
    {
        //
        // GET: /Kreator/
        public IEnumerable<Kreator> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetKreatori();
        }
        public Kreator Get(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.GetKreatori(id);
        }

        public int Post(Kreator kor)
        {
            DataProvider provider = new DataProvider();
            return provider.AddKreator(kor);
        }

        public int Put(Kreator kor)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateKreator(kor);
        }

        public int Delete(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveKreator(id);
        }
       

    }
}
