using System;
using System.Collections.Generic;
using System.Text;
using CSVAnalyzer.Models;

namespace CSVAnalyzer.BLL.Managers
{
    public interface ICsvService
    {
        CSVFile GetCsvFile(int id);
        ICollection<CSVFile> GetAllCsvFiles();
        CSVFile Add(CSVFile csvFile);
    }
}
