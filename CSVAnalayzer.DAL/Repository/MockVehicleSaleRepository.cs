using CSVAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVAnalyzer.DAL.Repository
{
    public class MockVehicleSaleRepository : IVehicleSaleRepository
    {
        private List<IVehicleSale> _vehicleSaleList;

        public MockVehicleSaleRepository()
        {
            _vehicleSaleList = new List<IVehicleSale>();
        }
        public async Task<ICollection<IVehicleSale>> GetAllSales(IFile file)
        {
            await ReadFileAndPopulateData(file, _vehicleSaleList);
            return _vehicleSaleList;
        }

        public async Task ReadFileAndPopulateData(IFile file, List<IVehicleSale> list)
        {
            using (FileStream fileStream = new FileStream(file.FilePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream, Encoding.GetEncoding("iso-8859-1")))
                {
                    string headerLine = await reader.ReadLineAsync();
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] cols = Parser.CustomParseColumnsFromLine(line);

                        IVehicleSale vehicleSale = new VehicleSale();
                        vehicleSale.DealNumber = Convert.ToInt32(cols[0]);
                        vehicleSale.CustomerName = cols[1];
                        vehicleSale.DealershipName = cols[2];
                        vehicleSale.Vehicle = cols[3];
                        vehicleSale.Price = cols[4];
                        vehicleSale.Date = cols[5];

                        list.Add(vehicleSale);
                    }
                }
            }
        }

    }
}
