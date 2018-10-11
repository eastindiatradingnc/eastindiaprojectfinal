using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // Get all the shiping data
        // Put in a last value that indicates that it is send from us
        [HttpGet]
        public IEnumerable<String> Get(
            string custid, // Identify the sender
            string name,
            int phone,
            string email,
            string country,
            int weight,
            string type,
            int width,
            int height,
            int depth,
            string fromcity,
            string tocity,
            bool askforprice
            )
        {



            if (askforprice)
            {
                if (custid == "TS-ID")
                {
                    // Only return our price
                    // The list of shipping fares for the requested type
                }
                else if (custid == "OA_ID")
                {
                    // Only return our price
                    // The list of shipping fares for the requested type

                }
                else
                {
                    // get prices from TS and OA
                    // return cheapest and fastest price
                    

                }
            }
            else
            {
                if (custid == "TS-ID")
                {
                    // Calc/get our own price
                    // Send invoice to system
                }
                else if (custid == "OA_ID")
                {
                    // Calc/get our own price
                    // Send invoice to system

                }
                else
                {
                    // get prices from TS and OA
                    // 

                }

                //bool sendOrderResult = Utilities.sendOrderTo();


            }



            string[] result = new string[3];


            string s0 = "City1,City2,33,600";
            string s1 = "City2,City3,34,10";
            string s2 = "City1,City3,13,90";


            result[0] = s0;
            result[1] = s1;
            result[2] = s2;

            return result;
        }


        
        [HttpGet]
        public void Get(int id, int seconds)
        {
            //List<CityConnention> shippingData = Utilities::getShippingData();





            

            return;
        }




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

        
    }
}
