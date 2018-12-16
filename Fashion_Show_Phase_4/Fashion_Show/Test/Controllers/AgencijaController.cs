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
    public class AgencijaController : ApiController
    {

        // AGENCIJA JE ENTITET KOJI SE KORISTI SAMO ZA IZVOĐENJE 
   /*  
        public IEnumerable<Agencija> Get()
        {
            DataProvider provider = new DataProvider();
            IEnumerable<Agencija> prostor = provider.GetAgencija();
            return prostor;
        }
        public Agencija Get(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.GetAgencija(id);
        }

        public int Post(Agencija agn)
        {
            DataProvider provider = new DataProvider();
            return provider.AddAgencija(agn);
        }

        public int Put(Agencija agn)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateAgencija(agn);
        }

        public int Delete(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveAgencija(id);
        }

        */
    }
}
