using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENG.CsvConverter.Application
{
    public class CsvConverterApplication
    {
        public byte[] Generate(Stream inputStream, string props, string objectName, char separator, enumConvertType type)
        {
            var converter = GetConverterByType(type);

            return converter.Generate(inputStream, props, objectName, separator);
        }

        private ICsvConverter GetConverterByType(enumConvertType type)
        {
            if (type == enumConvertType.SQL)
            {
                return new CsvToSqlApplication();
            }

            return null;
        }
    }
}
