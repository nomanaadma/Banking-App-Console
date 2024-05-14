

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
            var userPath = FileSystem.FilePath("Users");
            if (!File.Exists(userPath))
                File.WriteAllText(userPath, "Id,Fullname,Email,Password,Cnic,Balance,Card,Expiry,Cvc,\r\n");

            // creating transactions file
            var transactionPath = FileSystem.FilePath("Transactions");
            if (!File.Exists(transactionPath))
                File.WriteAllText(transactionPath, "Id,From,To,Amount,Date,\r\n");

            _ = new BankingApp();

        }

    }
}
