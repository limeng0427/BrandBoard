using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mofadeng.TechnicalTest.Utilities
{
    /// <summary>
    /// Read From CSV using CSVHelper
    /// </summary>
    public static class CSVHelper
    {
        public static IEnumerable<T> ReadFromCSV<T>(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = false;
                return csv.GetRecords<T>()
                    .ToList();
            }
        }
    }
}
