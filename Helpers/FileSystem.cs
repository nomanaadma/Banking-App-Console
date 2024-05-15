using System.Text;
using Banking_App_Console.Entities;

namespace Banking_App_Console
{
    public static class FileSystem
    {
        private const string Extension = ".txt";

        public static string DataPath()
        {
            return Path.Combine(Path.GetFullPath(@"..\..\..\"), "Data");
        }

        public static string FilePath(string file)
        {
            return Path.Combine(DataPath(), file) + Extension;
        }

        private static string GetValues(object obj)
        {
            var properties = obj.GetType().GetProperties();
            return string.Join(',', properties.Select(prop => prop.GetValue(obj)))+",\n";
        }

        public static void WriteData(string file, object data)
        {
            file = FilePath(file);
            var dataRow = GetValues(data);
            File.AppendAllText(file, dataRow);
        }

        private static string[] ReadData(string file)
        {
            file = FilePath(file);
            return File.ReadAllLines(file, Encoding.UTF8);
        }

        private static List<Dictionary<string, string>> FindAll(string file, string data, bool single = false)
        {
            var rows = ReadData(file);

            var titles = rows[0].Split(",");

            var foundRows = new List<Dictionary<string, string>>();

            var dataWithQoma = data + ',';

            foreach (var row in rows)
            {
                if (!row.Contains(dataWithQoma)) continue;
                
                var dRow = new Dictionary<string, string>();
                var dataColumns = row.Split(",");

                for (var i = 0; i < dataColumns.Length; i++)
                {
                    dRow[titles[i]] = dataColumns[i];
                }

                foundRows.Add(dRow);

                if (single) 
                    return foundRows;

            }

            return foundRows;
        }

        public static List<ETransaction> FindAllTransactions(string data)
        {
            var foundRowsD = FindAll("Transactions", data);

            var foundRowsT = new List<ETransaction>();

            foreach (var row in foundRowsD)
            {
                var eTransaction = new ETransaction();
                SetEntityPropertiesFromDictionary(eTransaction, row);
                foundRowsT.Add(eTransaction);
            }

            return foundRowsT;
        }


        public static Dictionary<string, string> FindOne(string file, string data)
        {
            var result = FindAll(file, data, true);
            return result.Count == 0 ? [] : result[0];
        }

        public static User? FindAUser(string data)
        {
            var result = FindAll("Users", data, true);

            if (result.Count == 0) return null;

            var user = new User();
            SetEntityPropertiesFromDictionary(user, result[0]);

            return user;

        }

        private static void SetEntityPropertiesFromDictionary(object entity, Dictionary<string, string> data)
        {
            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
            {
                if (data.TryGetValue(prop.Name, out string? value))
                {
                    prop.SetValue(entity, value);
                }
            }
        }
        public static void UpdateUser(User user)
        {
            var dataRow = GetValues(user);
            UpdateRow("Users", dataRow);
        }

        private static void UpdateRow(string file, string rowData)
        {

            var fileData = ReadData(file);
            var newData = "";

            var rowId = rowData.Split(',')[0] + ',';

            foreach (var row in fileData)
            {
                if (row.Contains(rowId))
                    newData += rowData;
                else
                    newData += row + "\r\n";
            }

            file = FilePath(file);
            File.WriteAllText(file, string.Empty);
            File.AppendAllText(file, newData);

        }

    }
}
