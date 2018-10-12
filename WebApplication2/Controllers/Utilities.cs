using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace WebApplication2.Controllers
{
    public static class Utilities
    {
        private static string _OAURL = "http://wa-oadk.azurewebsites.net/api/oceanPrice";
        private static string _TSURL = "http://wa-tldk.azurewebsites.net/api/routes";
        private static string _conString =
                 "Data Source=dbs-eitdk.database.windows.net;" +
                 "Initial Catalog=db-eitdk;" +
                 "User id=admin-eitdk;" +
                 "Password=Eastindia4thewin";
        
        public static List<Route> GetShippingData(int weight, string type)
        {
            var routes = new List<Route>();
            DateTime now = DateTime.Now;
            int month = now.Month;
            int packageWeightMultiplier = (int)Math.Ceiling((double)weight / 100.0);

            if (type == ContentType.RECORDED || type == ContentType.CAUTIOUS)
            {
                return routes;
            }

            using (var conn = new SqlConnection(_conString))
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Routetable WHERE Routetable.Available = 1 AND Routetable.Type = 'Ship'", conn))
                {
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var route = new Route();
                        route.From = (string)row["From"];
                        route.To = (string)row["To"];
                        route.Time = (int)row["Routing_Time"];
                        route.Price = (int)row["Price"];


                        if (month == 1 || month == 2 || month == 3 || month == 4 || month == 11 || month == 12)
                        {
                            route.Price = (int)((double)route.Price * (8.0/5.0));
                        }



                        if (type == ContentType.ANIMALS)
                        {
                            route.Price = (int)((double)route.Price * 1.25);
                        }
                        else if (type == ContentType.WEAPONS)
                        {
                            route.Price = (int)((double)route.Price * 1.2);
                        }
                        else if (type == ContentType.REFRIGERATED)
                        {
                            route.Price = (int)((double)route.Price * 1.1);
                        }

                        routes.Add(route);
                    }
                }
            }
            
            return routes;
        }

        public static List<Route> GetPricesFromTS(string urlSuffix)
        {
            var routes = new List<Route>();

            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(_TSURL + urlSuffix).Result;

                return JsonConvert.DeserializeObject<List<Route>>(result);
            }
        }

        public static List<Route> GetPricesFromOA(string urlSuffix)
        {
            var routes = new List<Route>();

            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(_OAURL + urlSuffix).Result;
                
                return JsonConvert.DeserializeObject<List<Route>>(result);
            }
        }

        
        public static int CalculateFastestPrice(List<Route> routes)
        {
            return 0;
        }

        public static int CalculateCheapestPrice(List<Route> routes)
        {
            return 0;
        }
        


            /*

        public static bool SendOrderToEIT() // Params???
        {
            Thread.Sleep(3000);
            return false;
        }

        public static bool SendOrderToTS() // Params???
        {
            return false;
        }

        public static bool SendOrderToOA() // Params???
        {
            return false;
        }

        */

    }
}
