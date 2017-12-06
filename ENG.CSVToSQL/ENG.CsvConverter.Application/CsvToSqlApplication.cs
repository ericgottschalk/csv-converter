using ENG.CsvConverter.Infra.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ENG.CsvConverter.Application
{
    internal class CsvToSqlApplication : CsvConverter
    {
        private string GenerateInsert(List<List<string>> rows, string columns, string tableName)
        {
            columns = !string.IsNullOrWhiteSpace(columns) ? "(" + columns + ")" : "";
            var insertInit = $"INSERT INTO {tableName} {columns} VALUES ";
            var stringBuidser = new StringBuilder();

            foreach (var row in rows)
            {
                var insert = insertInit + $"('{string.Join("','", row)}')".Replace("''", "NULL");
                stringBuidser.AppendLine(insert);
            }

            return stringBuidser.ToString();
        }

        public override byte[] Generate(Stream inputStream, string props, string objectName, char separator)
        {
            var insert = string.Empty;

            using (var csv = new CSV(inputStream, separator))
            {
                props = string.Join(",", props.Split(',').Select(item => string.IsNullOrWhiteSpace(item) ? "" : $"[{item}]")).TrimEnd(',');
                insert = GenerateInsert(csv.Rows, props, objectName);
            }

            return this.GetFileBytes(insert);
        }
    }
}