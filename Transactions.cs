using Banking_App_Console.Entities;
using Banking_App_Console.Helpers;
using ConsoleTables;

namespace Banking_App_Console
{
    internal class Transactions
    {
        public Transactions(Dashboard dashboard)
        {
            var user = Session.Instance.User;

            Console.WriteLine();
            var table = new ConsoleTable("Reference", "Amount", "Date");

            var userTransRows = FileSystem.FindAllTransactions(user.Id);

            foreach (var rowData in userTransRows)
            {
                var transAmount = rowData.Amount;

                var transferred_by_crUser = false;
                if (rowData.From == user.Id)
                {
                    transAmount = "-" + transAmount;
                    transferred_by_crUser = true;
                }

                string? reference;

                if (rowData.From == "none")
                    reference = "Money Deposited";
                else if (rowData.To == "none")
                    reference = "Money Withdrew";
                else
                {

                    string? otherUserCond;

                    // if the transaction is done by current loggedin user to some other user
                    if (transferred_by_crUser)
                    {
                        otherUserCond = rowData.To;
                        reference = "Money Tranfered to: ";
                    }
                    else
                    {
                        otherUserCond = rowData.From;
                        reference = "Money Deposited by: ";
                    }

                    var userTransdata = FileSystem.FindAUser(otherUserCond);

                    reference += userTransdata.Email + " - " + userTransdata.Cnic;
                }

                table.AddRow(reference, transAmount, rowData.Date);
            }

            Console.Clear(); Console.WriteLine("\x1b[3J");
            table.Write();

            dashboard.Init();

        }
    }
}
