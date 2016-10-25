using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace website.Controllers
{
    [Route("api/[controller]")]
    public class ExportController : Controller
    {
        // GET: api/values
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var sb = new StringBuilder();

            sb.Append("Name,Phone,Email,Birth Date,Tickets\r\n");
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            result.Content = new StringContent(sb.ToString());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment"); //attachment will force download
            result.Content.Headers.ContentDisposition.FileName = "RecordExport.csv";
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
