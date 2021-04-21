﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVAnalyzer.Models
{
    public class CSVFile : IFile
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
