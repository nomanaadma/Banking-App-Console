namespace Banking_App_Console.Validators
{
    internal class Validator : IValidator
    {
        public string Input { get; set; }

        public string Errors = "";
        public virtual IValidator Valid(string name, string input)
        {
            input = input.Trim();

            Input = input;

            Errors = "";

            if (input == null || input.Length == 0 || string.IsNullOrEmpty(input) || input.Length < 5)
                Errors = $"\n - {name} must not be empty and should be more than 5 characters";

            return this;
        
        }

    }
}



