using ENG.CsvConverter.Infra.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENG.CsvConverter.Infra.CSV
{
    public class CSV : IDisposable
    {
        public List<List<string>> Rows { get; private set; }

        public string Path { get; private set; }

        public char Separator { get; set; }

        public Stream Stream { get; private set; }

        public CSV(string path, char separator)
        {
            this.Path = path;
            this.Separator = separator;
            Read(this.Path);
        }

        public CSV(Stream stream, char separator)
        {
            this.Stream = stream;
            this.Separator = separator;
            Read(stream);
        }

        private void Read(string path)
        {
            var lines = File.ReadAllLines(path);
            this.Rows = GetRows(lines);
        }

        private void Read(Stream stream)
        {
            var lines = stream.ReadAllLines();
            this.Rows = GetRows(lines);          
        }

        private List<List<string>> GetRows(IEnumerable<string> source)
        {
            var result = new List<List<string>>();

            foreach (var line in source)
            {
                result.Add(line.Split(this.Separator).ToList());
            }

            return result;
        }

        public void Dispose()
        {
            if (this.Stream != null)
            {
                this.Stream.Dispose();
            }
        }
    }
}
