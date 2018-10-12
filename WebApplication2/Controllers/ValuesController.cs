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

            return Utilities.GetShippingData(weight, type);
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
        public string Post([FromForm]int customerIdInput, [FromForm]string nameInput)

        */

        // POST api/values
        [HttpPost]
        public string Post(
            [FromForm]string custid, // Identify the sender
            [FromForm]string name,
            [FromForm]int phone,
            [FromForm]string email,
            [FromForm]string country,
            [FromForm]int weight,
            [FromForm]string type,
            [FromForm]int width,
            [FromForm]int height,
            [FromForm]int depth,
            [FromForm]string fromcity,
            [FromForm]string tocity,
            [FromForm]bool askforprice
            )
        {
            List<Route> eitPrices;

            if (true)
            {
                // get prices from TS and OA
                // return cheapest and fastest price

                List<Route> oaPrices = Utilities.GetPricesFromOA("/" + fromcity + "/" + tocity + "/" + type + "/" + weight + "/" + height + "/" + depth + "/" + width + "/" + custid);
                List<Route> tsPrices = Utilities.GetPricesFromTS("/" + width + "/" + height + "/" + depth + "/" + weight + "/" + type + "/" + type);
                eitPrices = Utilities.GetShippingData(weight, type);


                foreach (Route element in oaPrices)
                {
                    eitPrices.Add(element);
                }

                foreach (Route element in tsPrices)
                {
                    eitPrices.Add(element);
                }


            //    int fastestPrice = Utilities.CalculateFastestPrice(eitPrices);
            //    int cheapestPrice = Utilities.CalculateCheapestPrice(eitPrices);



            }
            else
            {


                // Calc/get our own price
                // Send invoice to system
                // get prices from TS and OA
                // 

                //bool sendOrderResult = Utilities.sendOrderTo();


            }

            int fastPrice = Utilities.CalculateFastestPrice(eitPrices, fromcity, tocity);


            //return Utilities.GetShippingData();

            //return Utilities.GetPricesFromOA();

            //var sendOrderResult = Utilities.SendOrderToEIT();

            //return $"{custid} - {name} - {country} - {phone} - {email} - {fromcity} - {tocity} - {type} - {weight} - {width} - {height} - {depth}";
            // return "YOYOYYO";

            //  return eitPrices.Count.ToString();
            return "Price between " + fromcity + " and " + tocity + " is: " + "15 $"; //fastPrice;  
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
