using ENG.CsvConverter.Application;
using ENG.CsvConverter.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ENG.CsvConverter.Models
{
    public class ConvertRequestModel
    {
        public string Props { get; set; }

        [Required]
        public string ObjectName { get; set; }

        [Required]
        public char Separator { get; set; }

        [Required]
        public enumConvertType Type { get; set; }

        [Required]
        [MaxFileSize(8 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is {0} bytes")]
        public HttpPostedFileBase File { get; set; }
    }
}