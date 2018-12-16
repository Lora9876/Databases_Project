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
    public class Domaca_AgencijaController : ApiController
    {
        public Domaca_Agencija Get(int id)
        {
            DataProvider provider = new DataProvider();
            Domaca_Agencija a = provider.GetDomaceAgencije(id);
            return a;
        }

        public IEnumerable<Domaca_Agencija> Get()
        {
            DataProvider provider = new DataProvider();
            IEnumerable<Domaca_Agencija> a = provider.GetDomaceAgencije();
            return a;
        }

        public int Post(Domaca_Agencija agn)
        {
            DataProvider provider = new DataProvider();
            return provider.AddDomaceAgencije(agn);
        }

        public int Put(Domaca_Agencija agn)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateDomaceAgencije(agn);
        }

        public int Delete(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveDomaceAgencije(id);
        }

    }
}
