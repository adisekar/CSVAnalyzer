using CSVAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSVAnalyzer.BLL.Managers
{
    public interface IVehicleSaleService
    {
        Task<ICollection<IVehicleSale>> GetAllSales(IFile file);

        //IVehicleSale GetSaleByDealNumber(int dealNumber);

        string GetMostSoldVehicle(IEnumerable<IVehicleSale> vehicleSales);
    }
}
