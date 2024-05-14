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

            var user = new User
            {
                Id = "YBBR4h",
                Fullname = "Noman Shoukat",
                Email = "nomanaadma@gmail.com",
                Password = "Super123",
                Cnic = "4230148518495",
                Balance = "1200",
                Card = "7412844963938986",
                Expiry = "15",
                Cvc = "123",
            };

            new Dashboard(user);


            return;


            Console.WriteLine("Welcome to NS Banking");

            Console.WriteLine("\nAt any step type 'Back' go to to previous step and type 'Exit' to close the application.");

            var WelcomeOptionValidator = new OptionValidator
            {
                Choices = [
                    new Option { Id = 1, Msg = "Login", Value = "Login" },
                    new Option { Id = 2, Msg = "Signup", Value = "Signup" },
                ]    
            };

            var WelcomeOption = (OptionValidator)Global.TakeInput("Option", "Select your option below:", WelcomeOptionValidator);

            Global.GetInstance(WelcomeOption.SelectedChoice.Value);

        }

    }
}
