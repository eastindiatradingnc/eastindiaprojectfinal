using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        [HttpGet]
        public IEnumerable<String> Get(
            string custid,
            string name,
            int phone,
            string email,
            string country,
            int weight,
            string content,
            string type,
            int[] dimension,
            string fromcity,
            string tocity,
            bool askforprice
            )
        {


            /*
            if (false)
            {

                return new string[];
            }
            */


            string[] result = new string[3];


            string s0 = "City1,City2,33,600";
            string s1 = "City2,City3,34,10";
            string s2 = "City1,City3,13,90";


            result[0] = s0;
            result[1] = s1;
            result[2] = s2;

            return result;
        }



        /*

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {
            return "posted";
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

        */
    }
}
