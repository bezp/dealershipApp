using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    public class Sedan
    {
        public int ID { get; set; }

        public string Model { get; set; }
        public int MSRP { get; set; }
        public int Horsepower { get; set; }
        public int MPG { get; set; }
    }
}