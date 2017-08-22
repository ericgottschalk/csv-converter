using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ENG.CSVToSQL.Core
{
    public class CSVReader
    {
        public static List<List<string>> Read(string path)
        {
            var result = new List<List<string>>();
            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                result.Add(line.Split(';').ToList());
            }

            return result;
        }

        public static List<List<string>> Read(Stream stream)
        {
            var result = new List<List<string>>();
            var lines = stream.ReadAllLines();
            foreach (var line in lines)
            {
                result.Add(line.Split(';').ToList());
            }

            return result;
        }
    }
}