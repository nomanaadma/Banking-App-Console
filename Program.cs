

namespace Banking_App_Console
{
    public class Banking_App_Console
    {
        public static void Main()
        {

            var dataFolderPath = FileSystem.DataPath();

            // creating ./data directory to store data
            if (!Directory.Exists(dataFolderPath))
                Directory.CreateDirectory(dataFolderPath);

            // creating user file
            var userPath = FileSystem.FilePath("users");
            if (!File.Exists(userPath))
                File.WriteAllText(userPath, "Id,Fullname,Email,Password,Cnic,Calance,Card,Expiry,Cvc,\r\n");

            // creating transactions file
            var transactionPath = FileSystem.FilePath("transactions");
            if (!File.Exists(transactionPath))
                File.WriteAllText(transactionPath, "id,from,to,amount,date,\r\n");

            _ = new BankingApp();

        }

    }
}
