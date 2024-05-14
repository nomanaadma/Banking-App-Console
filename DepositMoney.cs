using Banking_App_Console.Entities;
using Banking_App_Console.Validators.Balance;

namespace Banking_App_Console
{
    internal class DepositMoney
    {
        public DepositMoney(User user, Dashboard dashboard)
        {

            var balanceObj = Global.TakeInput("Amount", "Enter Amount:", new BasicBalance());

            var amount = balanceObj.Input;

            var currentUserBalance = int.Parse(user.Balance);

            var moneyToAdd = int.Parse(amount);
            var newAmount = (currentUserBalance + moneyToAdd).ToString();

            user.Balance = newAmount;

            FileSystem.UpdateUser(user);

            Console.WriteLine("Money Successfully Deposited.");

            dashboard.Init();

        }
    }
}
