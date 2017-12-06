using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENG.CsvConverter.Infra.Extensions
{
    public static partial class Extensions
    {
        public static IEnumerable<string> ReadAllLines(this Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
