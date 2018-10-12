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
        public List<Route> Get(
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
                // get prices from TS and OA
                // return cheapest and fastest price

                List<Route> oaPrices = Utilities.GetPricesFromOA("/" + fromcity + "/" + tocity + "/" + type + "/" + weight + "/" + height + "/" + depth + "/" + width + "/" + custid);
                List<Route> tsPrices = Utilities.GetPricesFromTS("/" + width + "/" + height + "/" + depth + "/" + weight + "/" + type + "/" + type);
                List<Route> eitPrices = Utilities.GetShippingData();

                
                foreach (Route element in oaPrices)
                {
                    eitPrices.Add(element);
                }

                foreach (Route element in tsPrices)
                {
                    eitPrices.Add(element);
                }


                int fastestPrice = Utilities.CalculateFastestPrice(eitPrices);
                int cheapestPrice = Utilities.CalculateCheapestPrice(eitPrices);



            }
            else
            {
                

                // Calc/get our own price
                // Send invoice to system
                // get prices from TS and OA
                // 

                //bool sendOrderResult = Utilities.sendOrderTo();


            }
            

            //return Utilities.GetShippingData();

            return Utilities.GetPricesFromOA();
        }


        /*
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


        */

        // POST api/values
        [HttpPost]
        public string Post([FromForm]int customerIdInput, [FromForm]string nameInput)
        {

            var sendOrderResult = Utilities.SendOrderToEIT();

            return $"{customerIdInput} - {nameInput}";
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
