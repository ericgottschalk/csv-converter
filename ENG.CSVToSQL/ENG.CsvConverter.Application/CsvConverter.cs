using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENG.CsvConverter.Application
{
    internal abstract class CsvConverter : ICsvConverter
    {

        public abstract byte[] Generate(Stream inputStream, string props, string objectName, char separator);

        protected virtual byte[] GetFileBytes(string converted)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                streamWriter.WriteLine(converted);
                streamWriter.Flush();
                memoryStream.Flush();

                return memoryStream.ToArray();
            }
        }
    }
}
