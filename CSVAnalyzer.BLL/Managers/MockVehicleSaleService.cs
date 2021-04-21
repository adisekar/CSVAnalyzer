using CSVAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVAnalyzer.DAL.Repository;

namespace CSVAnalyzer.BLL.Managers
{
    public class MockVehicleSaleService : IVehicleSaleService
    {
        private IVehicleSaleRepository _vehicleSaleRepository;

        public MockVehicleSaleService(IVehicleSaleRepository vehicleSaleRepository)
        {
            _vehicleSaleRepository = vehicleSaleRepository;
        }
        public async Task<ICollection<IVehicleSale>> GetAllSales(IFile file)
        {
            return await _vehicleSaleRepository.GetAllSales(file);
        }

        public string GetMostSoldVehicle(IEnumerable<IVehicleSale> vehicleSales)
        {
            Dictionary<string, int> frequencyMap = new Dictionary<string, int>();
            foreach (var vehicleSale in vehicleSales)
            {
                // Add to frequency map to get the best car
                if (frequencyMap.ContainsKey(vehicleSale.Vehicle))
                {
                    frequencyMap[vehicleSale.Vehicle]++;
                }
                else
                {
                    frequencyMap[vehicleSale.Vehicle] = 1;
                }
            }

            return frequencyMap.OrderByDescending(kv => kv.Value).FirstOrDefault().Key;
        }
    }
}
