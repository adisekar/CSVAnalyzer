using System;
using System.Collections.Generic;
using System.Text;
using CSVAnalyzer.Models;

namespace CSVAnalyzer.BLL.Managers
{
    public interface IFileService
    {
        IFile GetFile(int id);
        ICollection<IFile> GetAllFiles();
        IFile Add(IFile file);
    }
}
