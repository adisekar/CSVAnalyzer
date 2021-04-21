using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSVAnalyzer.Utility
{
    public class AllowedExtensions : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensions(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file = null;
            string extension = null;
            if (value != null)
            {
                file = value as IFormFile;
                extension = Path.GetExtension(file.FileName);
            }

            if (file != null)
            {
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult($"The file extension is not allowed!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
