using Breeze.WebApi;
using GetIntoBreezeJS.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetIntoBreezeJS.Controllers
{
    [BreezeController]
    public class GetIntoBreezeController : ApiController
    {
        readonly EFContextProvider<GetIntoBreezeContext> _contextProvider =
            new EFContextProvider<GetIntoBreezeContext>();

        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<City> Cities()
        {
            return _contextProvider.Context.Cities;
        }
    }
}