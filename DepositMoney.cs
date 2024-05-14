using Banking_App_Console.Entities;
using Banking_App_Console.Validators.Balance;

namespace Banking_App_Console
{
    internal class DepositMoney
    {
        public DepositMoney(User user, Dashboard dashboard)
        {

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

            Console.WriteLine("Money Successfully Deposited.");

            dashboard.Init();

        }
    }
}
