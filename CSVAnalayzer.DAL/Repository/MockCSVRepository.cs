using CSVAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVAnalyzer.DAL.Repository
{
    public class MockCSVRepository : IFileRepository
    {
        private List<IFile> _csvList;

        public MockCSVRepository()
        {
            _csvList = new List<IFile>();
        }

        public IFile Add(IFile csvFile)
        {
            csvFile.Id = _csvList.Count == 0 ? 1 : _csvList.Max(e => e.Id) + 1;
            _csvList.Add(csvFile);
            return csvFile;
        }

        public ICollection<IFile> GetAllFiles()
        {
            return _csvList;
        }

        public IFile GetFile(int id)
        {
            return _csvList.FirstOrDefault(file => file.Id == id);
        }
    }
}
