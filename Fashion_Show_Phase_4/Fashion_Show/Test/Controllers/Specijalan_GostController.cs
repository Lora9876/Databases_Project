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
    public class Specijalan_GostController :    ApiController
    {
        public IEnumerable<Specijalan_Gost> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetSpecijalaniGosti();
           
        }
        public Specijalan_Gost Get(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.GetSpecijalaniGosti(id);
        }

        public int Post(Specijalan_Gost am)
        {
            DataProvider provider = new DataProvider();
            return provider.AddSpecijalan_Gost(am);
        }

        public int Put(Specijalan_Gost am)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateSpecijalaniGost(am);
        }

        public int Delete(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveSpecijalaniGost(id);
        }

    }
}
