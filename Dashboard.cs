using Banking_App_Console.Entities;
using Banking_App_Console.Validators;
using Banking_App_Console.Helpers;

namespace Banking_App_Console
{
    internal class Dashboard
    {
        private User? User { get; set; }
        public Dashboard()
        {
            User = Session.Instance.User;
            Init();
        }

        public void Init()
        {
            ShowWelcomeDetails();

            var dashboardOptionsValidator = new OptionValidator
            {
                Choices = [
                    new Option { Id = 1, Msg = "Deposit Money", Value = "DepositMoney" },
                    new Option { Id = 2, Msg = "Send Money", Value = "SendMoney" },
                    new Option { Id = 3, Msg = "Withdraw Money", Value = "WithdrawMoney" },
                    new Option { Id = 4, Msg = "Transactions", Value = "Transactions" },
                    new Option { Id = 5, Msg = "Logout", Value = "Logout" },
                ]
            };

            var dashboardOptions = (OptionValidator)Global.TakeInput("Option", "Select your option below:", dashboardOptionsValidator);

            switch (dashboardOptions.SelectedChoice?.Value)
            {
                case "DepositMoney":
                    _ = new DepositMoney(this);
                    break;
                case "SendMoney":
                    _ = new SendMoney(this);
                    break;
                case "WithdrawMoney":
                    _ = new WithdrawMoney(this);
                    break;
                case "Transactions":
                    _ = new Transactions(this);
                    break;
                case "Logout":
                    Console.Clear(); Console.WriteLine("\x1b[3J");
                    _ = new BankingApp();
                    break;
            }

        }

        private void ShowWelcomeDetails()
        {
            
            Console.WriteLine("\nWelcome\n");

            Console.WriteLine(User?.Fullname);

            var amountCr = double.Parse(User.Balance);

            Console.WriteLine($"Cnic: {User?.Cnic}");
            Console.WriteLine($"Balance: {amountCr:N0}");
            Console.WriteLine($"Card: {User?.Card}");
            Console.WriteLine($"Expire: {User?.Expiry}");
            Console.WriteLine($"CVC: {User?.Cvc}");
        }

    }
}
