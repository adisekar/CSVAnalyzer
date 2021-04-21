using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSVAnalyzer.Utility;

namespace CSVAnalyzer.ViewModels
{
    public class FileUploadVM
    {

        [Required]
        [AllowedExtensions(new string[] { ".csv" })]       
        public IFormFile CsvFile { get; set; }
    }
}
