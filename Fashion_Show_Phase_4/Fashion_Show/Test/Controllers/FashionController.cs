using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FashionShow;
using FashionShow.Entiteti;

namespace Test.Controllers
{
    public class FashionController : ApiController
    {
        // GET api/vojnik
        public IEnumerable<Agencija> Get()
        {
            DataProvider provider = new DataProvider();

            IEnumerable<Agencija> agencije = provider.GetAgencija();

            //return new [] {
            //    new Vojnik() {Naziv="test"}
            //};

            return agencije;
        }
    }
}
