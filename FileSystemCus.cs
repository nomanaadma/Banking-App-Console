using System.Text;
namespace Banking_App_Console
{
    public class FileSystemCus
    {
        private static readonly string extension = ".txt";
        
        public static string DataPath()
        {
            return Path.Combine(Path.GetFullPath(@"..\..\..\"), "data");
        }

        public static string FilePath(string file)
        {
            return Path.Combine(DataPath(), file) + extension;
        }

        private static string ToValueString(Dictionary<string, string> data)
        {
            return string.Join(",", data.Select(v => v.Value) .ToArray());
        }

        public static void WriteData(string file, Dictionary<string, string> data)
        {
            file = FilePath(file);
            string dataRow = GlobalCus.GenerateId() + "," + ToValueString(data) + ",\r\n";
            File.AppendAllText(file, dataRow);
        }

        private static string[] ReadData(string file)
        {
            file = FilePath(file);
            return File.ReadAllLines(file, Encoding.UTF8);
        }

        public static List<Dictionary<string, string>> FindAll(string file, string data, bool single = false)
        {
            var rows = ReadData(file);

            var titles = rows[0].Split(",");

            var foundRows = new List<Dictionary<string, string>>();

            var dataWithQoma = data + ',';

            foreach (var row in rows)
            {
                if (row.Contains(dataWithQoma))
                {
                    var dRow = new Dictionary<string, string>();
                    var dataColumns = row.Split(",");

                    for (var i = 0; i < dataColumns.Length; i++)
                    {
                        dRow[titles[i]] = dataColumns[i];
                    }

                    foundRows.Add(dRow);

                    if (single == true) 
                        return foundRows;

                }

            }

            return foundRows;
        }

        public static Dictionary<string, string> FindOne(string file, string data)
        {
            var result = FindAll(file, data, true);
            return result.Count == 0 ? [] : result[0];
        }

        public static void UpdateRow(string file, Dictionary<string, string> rowData)
        {

            var fileData = ReadData(file);
            var newData = "";

            var rowId = rowData.First().Value + ',';

            foreach (var row in fileData)
            {
                if (row.Contains(rowId))
                    newData += ToValueString(rowData) + "\r\n"; // updated row
                else
                    newData += row + "\r\n";
            }

            file = FilePath(file);
            File.WriteAllText(file, string.Empty);
            File.AppendAllText(file, newData);

        }

    }
}
