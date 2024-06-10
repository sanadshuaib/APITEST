using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace APITEST.Controllers
{
    public class ValuesController : ApiController
    {
        public static string myvalue = "";
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "This is GET : "+myvalue;
        }

        // POST api/values
        [HttpPost]
        public async Task<HttpResponseMessage> Post(MyValue value)
        {
            if (value != null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(value.value)
                };

                myvalue = await response.Content.ReadAsStringAsync();
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            //return Request.CreateResponse<string>(HttpStatusCode.OK, value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public class MyValue
        {
            public string value { get; set; } = "";
        }
    }
}
