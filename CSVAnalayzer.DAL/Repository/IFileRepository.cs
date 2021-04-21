using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSVAnalyzer.Models;

namespace CSVAnalyzer.DAL.Repository
{
    public interface IFileRepository
    {
        IFile GetFile(int id);
        ICollection<IFile> GetAllFiles();

        IFile Add(IFile csvFile);
    }
}
