using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVAnalyzer.Models
{
    public class VehicleSale : IVehicleSale
    {
        public int DealNumber { get; set; }
        public string CustomerName { get; set; }

        public string DealershipName { get; set; }

        public string Vehicle { get; set; }

        public string Price { get; set; }
        public string Date { get; set; }
    }
}
