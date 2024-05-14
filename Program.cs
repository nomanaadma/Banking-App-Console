

namespace Banking_App_Console
{
    public class Banking_App_Console
    {
        public static void Main()
        {

            var dataFolderPath = FileSystemCus.DataPath();

            // creating ./data directory to store data
            if (!Directory.Exists(dataFolderPath))
                Directory.CreateDirectory(dataFolderPath);

            // creating user file
            var userPath = FileSystemCus.FilePath("users");
            if (!File.Exists(userPath))
                File.WriteAllText(userPath, "id,full_name,email,password,cnic,balance,card_number,expiry,cvc,\r\n");

            // creating transactions file
            var transactionPath = FileSystemCus.FilePath("transactions");
            if (!File.Exists(transactionPath))
                File.WriteAllText(transactionPath, "id,from,to,amount,date,\r\n");

            new BankingApp();

        }

    }
}
