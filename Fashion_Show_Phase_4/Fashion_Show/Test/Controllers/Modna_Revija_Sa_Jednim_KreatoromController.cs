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
    public class Modna_Revija_Sa_Jednim_Kreatorom_Sa_Jednim_KreatoromController : ApiController
    {
        public IEnumerable<Modna_Revija_Sa_Jednim_Kreatorom> Get()
        {
            DataProvider provider = new DataProvider();
            IEnumerable<Modna_Revija_Sa_Jednim_Kreatorom> a = provider.GetModneRevijeSaJednimKreatorom();
            return a;
        }
        public Modna_Revija_Sa_Jednim_Kreatorom Get(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.GetModneRevijeSaJednimKreatorom(id);

        }
        
        public int Post(Modna_Revija_Sa_Jednim_Kreatorom mdr)
        {
            DataProvider provider = new DataProvider();
            return provider.AddModneRevijeSaJednimKreatorom(mdr);
        }

        public int Put(Modna_Revija_Sa_Jednim_Kreatorom mdr)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateModneRevijeSaJednimKreatorom(mdr);
        }

        public int Delete(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveModneRevijeSaJednimKreatorom(id);
        }

    }
}
