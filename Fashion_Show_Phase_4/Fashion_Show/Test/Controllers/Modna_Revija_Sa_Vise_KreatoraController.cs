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
    public class Modna_Revija_Sa_Vise_Kreatora_Sa_Vise_KreatoraController : ApiController
    {
        //
        // GET: /Modna_Revija_Sa_Vise_Kreatora_Sa_Vise_Kreatora/
        public IEnumerable<Modna_Revija_Sa_Vise_Kreatora> Get()
        {
            DataProvider provider = new DataProvider();
            IEnumerable<Modna_Revija_Sa_Vise_Kreatora> a = provider.GetModneRevijeSaViseKreatora();
            return a;
        }
        public Modna_Revija_Sa_Vise_Kreatora Get(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.GetModneRevijeSaViseKreatora(id);

        }

        public int Post(Modna_Revija_Sa_Vise_Kreatora mdr)
        {
            DataProvider provider = new DataProvider();
            return provider.AddModneRevijeSaViseKreatora(mdr);
        }

        public int Put(Modna_Revija_Sa_Vise_Kreatora mdr)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateModneRevijeSaViseKreatora(mdr);
        }

        public int Delete(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.RemoveModneRevijeSaViseKreatora(id);
        }

    }
}
