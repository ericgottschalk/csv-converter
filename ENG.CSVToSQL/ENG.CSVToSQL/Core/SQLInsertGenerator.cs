using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ENG.CSVToSQL.Core
{
    public class SQLInsertGenerator
    {
        private static string GenerateInsert(List<List<string>> rows, string columns, string tableName)
        {
            var insert = $"INSERT INTO {tableName} ({columns}) VALUES ";
            var sb = new StringBuilder();
            foreach (var row in rows)
            {
                sb.Append(insert);
                var values = $"('{string.Join("','", row)}')".Replace("''", "NULL");
                sb.AppendLine(values);
            }
            return sb.ToString();
        }

        internal static byte[] Generate(Stream inputStream, string columns, string tableName)
        {
            var rows = CSVReader.Read(inputStream);
            columns = string.Join(",", columns.Split(',').Select(item => $"[{item}]"));
            var insert = GenerateInsert(rows, columns, tableName);

            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                streamWriter.WriteLine(insert);
                streamWriter.Flush();
                memoryStream.Flush();

                return memoryStream.ToArray();
            }
        }
    }
}