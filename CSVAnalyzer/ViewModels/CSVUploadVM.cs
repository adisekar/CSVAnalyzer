﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVAnalyzer.ViewModels
{
    public class CSVUploadVM
    {
        public IFormFile CsvFile { get; set; }
    }
}