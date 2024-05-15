using Banking_App_Console.Entities;
using Banking_App_Console.Helpers;

namespace Banking_App_Console.Validators
{
    public class Validator : IValidator
    {
        public User? User = null;
        public string Input { get; set; }

        public string Errors = "";
        public virtual IValidator Valid(string name, string input)
        {
            input = input.Trim();

            Input = input;

            Errors = "";

            if (input == null || input.Length == 0 || string.IsNullOrEmpty(input))
                Errors = $"\n - {name} must not be empty.";

            switch (input)
            {
                case "exit":
                    Environment.Exit(0);
                    break;
                case "back":
                {
                    Console.Clear(); Console.WriteLine("\x1b[3J");
                    
                    if(Session.Instance.User == null)
                        _ = new BankingApp();
                    else 
                        _ = new Dashboard();
                    
                    break;
                }
            }

            return this;
        
        }

    }
}



