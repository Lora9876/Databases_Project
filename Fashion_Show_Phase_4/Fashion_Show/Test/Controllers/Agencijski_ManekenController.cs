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
    public class Agencijski_ManekenController : ApiController
    {
        
        public IEnumerable<Agencijski_Maneken> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetAgencijski_Manekeni();
        }
        public Agencijski_Maneken Get(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.GetAgencijski_Manekeni(id);
        }

        public int Post(Agencijski_Maneken am)
        {
            DataProvider provider = new DataProvider();
            return provider.AddAgencijski_Maneken(am);
        }

        public int Put(int id,Agencijski_Maneken am)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateAgencijski_Maneken(id,am);
        }

        public int Delete(int id, Agencijski_Maneken am)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveAgencijski_Maneken(id,am);
        }
       
    }
}
