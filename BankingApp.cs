using Banking_App_Console.Entities;
using Banking_App_Console.Helpers;
using Banking_App_Console.Validators;

namespace Banking_App_Console
{
    internal class BankingApp
    {
        public BankingApp()
        {
            Init();
        }

        public void Init()
        {
            Session.Instance.User = null;
            
            Console.WriteLine("Welcome to N~A Bank");
            
            Console.WriteLine("\n At any step type 'back' to go back and type 'exit' to close the app.");

            var welcomeOptionValidator = new OptionValidator
            {
                Choices = [
                    new Option { Id = 1, Msg = "Login", Value = "Login" },
                    new Option { Id = 2, Msg = "Signup", Value = "Signup" },
                ]
            };

            var welcomeOption = (OptionValidator)Global.TakeInput("Option", "Select your option below:", welcomeOptionValidator);
    
            switch (welcomeOption.SelectedChoice?.Value)
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
