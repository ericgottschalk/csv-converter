using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENG.CsvConverter.Application
{
    public interface ICsvConverter
    {
        byte[] Generate(Stream inputStream, string props, string objectName, char separator);
    }
}
