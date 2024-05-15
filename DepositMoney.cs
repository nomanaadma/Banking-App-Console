using Banking_App_Console.Entities;
using Banking_App_Console.Helpers;
using Banking_App_Console.Validators.Balance;

namespace Banking_App_Console
{
    internal class DepositMoney
    {
        public DepositMoney(Dashboard dashboard)
        {
            var user = Session.Instance.User;
            
            var amountObj = Global.TakeInput("Amount", "Enter Amount:", new BasicBalance());

            var amount = amountObj.Input;

            var currentUserBalance = int.Parse(user.Balance);

            var moneyToAdd = int.Parse(amount);
            var newAmount = (currentUserBalance + moneyToAdd).ToString();

            user.Balance = newAmount;

            FileSystem.UpdateUser(user);

            var data = new ETransaction
            {
                Id = Global.GenerateId(),
                From = "none",
                To = user.Id,
                Amount = amount,
                Date = DateTime.Now.ToString(),
            };

            FileSystem.WriteData("Transactions", data);


            Console.Clear(); Console.WriteLine("\x1b[3J");
            Console.WriteLine("Money Deposited Successfully.");


            dashboard.Init();

        }
    }
}
