using Banking_App_Console.Entities;
using Banking_App_Console.Validators;

namespace Banking_App_Console
{
    internal class BankingApp
    {
        public enum WelcomOperations
        {
            Login = 1,
            Signup = 2,
        }

        public BankingApp()
        {
            Init();
        }

        public void Init()
        {
           
            Console.WriteLine("Welcome to NS Banking");

            var WelcomeOptionValidator = new OptionValidator
            {
                Choices = [
                    new Option { Id = 1, Msg = "Login", Value = "Login" },
                    new Option { Id = 2, Msg = "Signup", Value = "Signup" },
                ]
            };

            var WelcomeOption = (OptionValidator)Global.TakeInput("Option", "Select your option below:", WelcomeOptionValidator);

            switch (WelcomeOption.SelectedChoice.Value)
            {
                case "Login":
                    _ = new Login(this);
                    break;
                case "Signup":
                    _ = new Signup(this);
                    break;
            }

        }

    }
}
