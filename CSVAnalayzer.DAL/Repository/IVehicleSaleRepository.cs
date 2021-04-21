using CSVAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSVAnalyzer.DAL.Repository
{
    public interface IVehicleSaleRepository
    {
        Task<ICollection<IVehicleSale>> GetAllSales(IFile file);

        //IVehicleSale GetSaleByDealNumber(int dealNumber);
    }
}
