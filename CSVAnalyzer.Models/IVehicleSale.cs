using System;
using System.Collections.Generic;
using System.Text;

namespace CSVAnalyzer.Models
{
    public interface IVehicleSale
    {
        int DealNumber { get; set; }
        string CustomerName { get; set; }

        string DealershipName { get; set; }

        string Vehicle { get; set; }

        string Price { get; set; }
        string Date { get; set; }
    }
}
