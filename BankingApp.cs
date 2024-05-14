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

            var test = FileSystem.FindAUser("jPlChM");
           
            // Console.WriteLine(test.Fullname);


            return; 
            Console.WriteLine("Welcome to NS Banking");

            Console.WriteLine("\nAt any step type 'Back' go to to previous step and type 'Exit' to close the application.");

            var WelcomeOptionValidator = new OptionValidator
            {
                Choices = [
                    new Option { Id = 1, Value = "Login" },
                    new Option { Id = 2, Value = "Signup" },
                ]    
            };

            var WelcomeOption = (OptionValidator)Global.TakeInput("Option", "Select your option below:", WelcomeOptionValidator);

            GetInstance(WelcomeOption.SelectedChoice.Value);

        }

        public static object GetInstance(string strFullyQualifiedName)
        {
            var t = Type.GetType("Banking_App_Console." + strFullyQualifiedName);
            return Activator.CreateInstance(t);
        }

    }
}
