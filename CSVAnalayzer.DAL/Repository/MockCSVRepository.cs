using CSVAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVAnalyzer.DAL
{
    public class MockCSVRepository : ICsvRepository
    {
        private List<CSVFile> _csvList;

        public MockCSVRepository()
        {
            _csvList = new List<CSVFile>();
        }

        public CSVFile Add(CSVFile csvFile)
        {
            csvFile.Id = _csvList.Count == 0 ? 1 : _csvList.Max(e => e.Id) + 1;
            _csvList.Add(csvFile);
            return csvFile;
        }

        public ICollection<CSVFile> GetAllCsvFiles()
        {
            return _csvList;
        }

        public CSVFile GetCsvFile(int id)
        {
            return _csvList.FirstOrDefault(file => file.Id == id);
        }
    }
}
