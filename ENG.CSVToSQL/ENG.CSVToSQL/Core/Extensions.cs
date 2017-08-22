using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ENG.CSVToSQL.Core
{
    public static partial class Extensions
    {
        public  static IEnumerable<string> ReadAllLines(this Stream stream)
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