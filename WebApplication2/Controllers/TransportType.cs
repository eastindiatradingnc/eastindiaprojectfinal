using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication2.Controllers
{
    public static class TransportType
    {
        public const string SEA = "sea";
        public const string AIR = "air";
        public const string LAND = "land";
    }

    

    public static class ContentType
    {
        public const string RECORDED = "RecordedDelivery";
        public const string WEAPONS = "Weapons";
        public const string ANIMALS = "LiveAnimals";
        public const string CAUTIOUS = "CautiousParcels";
        public const string REFRIGERATED = "RefrigeratedGoods";
    }
}