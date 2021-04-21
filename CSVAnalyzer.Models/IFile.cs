using System;
using System.Collections.Generic;
using System.Text;

namespace CSVAnalyzer.Models
{
    public interface IFile
    {
        int Id { get; set; }
        string FilePath { get; set; }
        string FileName { get; set; }
    }
}
