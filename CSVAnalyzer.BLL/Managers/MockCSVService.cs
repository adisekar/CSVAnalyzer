using System;
using System.Collections.Generic;
using System.Text;
using CSVAnalyzer.Models;
using CSVAnalyzer.DAL;

namespace CSVAnalyzer.BLL.Managers
{
    public class MockCSVService : ICsvService
    {
        private ICsvRepository _csvRepository;

        public MockCSVService(ICsvRepository csvRepository)
        {
            _csvRepository = csvRepository;
        }
        public CSVFile Add(CSVFile csvFile)
        {
            _csvRepository.Add(csvFile);
            return csvFile;
        }

        public ICollection<CSVFile> GetAllCsvFiles()
        {
            return _csvRepository.GetAllCsvFiles();
        }

        public CSVFile GetCsvFile(int id)
        {
            return _csvRepository.GetCsvFile(id);
        }
    }
}
