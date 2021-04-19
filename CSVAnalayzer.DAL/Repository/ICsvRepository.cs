using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSVAnalyzer.Models;

namespace CSVAnalyzer.DAL
{
    public interface ICsvRepository
    {
        CSVFile GetCsvFile(int id);
        ICollection<CSVFile> GetAllCsvFiles();

        CSVFile Add(CSVFile csvFile);
    }
}
