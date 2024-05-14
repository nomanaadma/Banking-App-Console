using Banking_App_Console.Entities;
using Banking_App_Console.Validators;

namespace Banking_App_Console
{
    internal class Dashboard
    {
        public User User { get; set; }
        public Dashboard(User user)
        {

            User = user;
            Init();

        }

        public void Init()
        {
            ShowWelcomeDetails();

            var DashboardOptionsValidator = new OptionValidator
            {
                Choices = [
                    new Option { Id = 1, Msg = "Deposit Money", Value = "DepositMoney" },
                    new Option { Id = 2, Msg = "Send Money", Value = "SendMoney" },
                    new Option { Id = 3, Msg = "Withdraw Money", Value = "WithdrawMoney" },
                    new Option { Id = 4, Msg = "Transactions", Value = "Transactions" },
                ]
            };
            var DashboardOptions = (OptionValidator)Global.TakeInput("Option", "Select your option below:", DashboardOptionsValidator);

            switch (DashboardOptions.SelectedChoice.Value)
            {
                case "DepositMoney":
                    _ = new DepositMoney(User, this);
                    break;
                case "WithdrawMoney":
                    _ = new WithdrawMoney(User, this);
                    break;

            }

            // var instance = Global.GetInstance(DashboardOptions.SelectedChoice.Value);
        }

        public void ShowWelcomeDetails()
        {
            Console.WriteLine("\nWelcome\n");

            Console.WriteLine(User.Fullname);

            var amountCr = double.Parse(User.Balance);

            Console.WriteLine($"Cnic: {User.Cnic}");
            Console.WriteLine($"Balance: {amountCr:N0}");
            Console.WriteLine($"Card: {User.Card}");
            Console.WriteLine($"Expire: {User.Expiry}");
            Console.WriteLine($"CVC: {User.Cvc}");
        }


    }
}
