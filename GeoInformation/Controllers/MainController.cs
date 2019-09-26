using GeoInformation.Models;
using GeoInformation.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeoInformationHw.Controllers
{
    [RoutePrefix("api")]
    public class MainController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();
        private NaiveCache _cache;
        public MainController()
        {
            _cache = new NaiveCache();
        }

        [Route("Pictures"), HttpGet]
        public async Task<IHttpActionResult> Pictures()
        {
            //check if cache is not empty
            // if not get from cache
            if (_cache.Empty())
            {
                var responseString = await client.GetStringAsync("https://picsum.photos/v2/list?page=1&limit=100");
                var items = JsonConvert.DeserializeObject<Picture[]>(responseString);
                _cache.InsertMany(items, items.Select(x => x.Id).ToArray());
            }

            var res = _cache.GetItems(5);
            //save to cache
            return Ok(res);
        }
    }
}
