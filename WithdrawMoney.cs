using Banking_App_Console.Entities;
using Banking_App_Console.Validators.Balance;
using Banking_App_Console.Validators.Password;

namespace Banking_App_Console
{
    internal class WithdrawMoney
    {
        public WithdrawMoney(User user, Dashboard dashboard)
        {

            var loginPassValidator = new DeductBalance
            {
                User = user
            };

            var amountObj = Global.TakeInput("Amount", "Enter Amount:", loginPassValidator);
            var amount = amountObj.Input;

            var amountInt = int.Parse(amount);
            var userBalance = int.Parse(user.Balance);

            var newAmount = (userBalance - amountInt).ToString();
            user.Balance = newAmount;

            FileSystem.UpdateUser(user);

            var data = new ETransaction
            {
                Id = Global.GenerateId(),
                From = user.Id,
                To = "none",
                Amount = amount,
                Date = DateTime.Now.ToString(),
            };

            FileSystem.WriteData("Transactions", data);

            Console.WriteLine("Money Successfully Withdrewed.");

            dashboard.Init();

        }
    }
}
