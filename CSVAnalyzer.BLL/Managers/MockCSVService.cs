using System;
using System.Collections.Generic;
using System.Text;
using CSVAnalyzer.Models;
using CSVAnalyzer.DAL.Repository;

namespace CSVAnalyzer.BLL.Managers
{
    public class MockCSVService : IFileService
    {
        private IFileRepository _csvRepository;

        public MockCSVService(IFileRepository csvRepository)
        {
            _csvRepository = csvRepository;
        }
        public IFile Add(IFile csvFile)
        {
            _csvRepository.Add(csvFile);
            return csvFile;
        }

        public ICollection<IFile> GetAllFiles()
        {
            return _csvRepository.GetAllFiles();
        }

        public IFile GetFile(int id)
        {
            return _csvRepository.GetFile(id);
        }
    }
}
