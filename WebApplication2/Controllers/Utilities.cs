using Newtonsoft.Json;
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
        private static string _conString =
                 "Data Source=dbs-eitdk.database.windows.net;" +
                 "Initial Catalog=db-eitdk;" +
                 "User id=admin-eitdk;" +
                 "Password=Eastindia4thewin";
        
        public static List<Route> GetShippingData()
        {
            var routes = new List<Route>();
            
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

                        routes.Add(route);
                    }
                }
            }
            
            return routes;
        }

        public static List<CityConnection> GetPricesFromTS(List<CityConnection> connections)
        {
            return new List<CityConnection>();
        }

        public static List<Route> GetPricesFromOA()
        {
            var routes = new List<Route>();

            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(_OAURL).Result;
                
                return JsonConvert.DeserializeObject<List<Route>>(result);
            }
        }

        
        public static int calculateFastestPrice()
        {
            return 0;
        }

        public static int calculateCheapestPrice()
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
