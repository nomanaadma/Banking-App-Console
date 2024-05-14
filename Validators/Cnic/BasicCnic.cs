namespace Banking_App_Console.Validators.Cnic
{
    internal class BasicCnic : Validator
    {
        public override IValidator Valid(string name, string cnic)
        {
            base.Valid(name, cnic);

            if (Errors != "") return this;

            if (
                cnic.Length > 13 ||
                cnic.Length < 13 ||
                cnic.All(char.IsDigit) == false
            )
                Errors += "\n - The CNIC must have a length of 13 characters.";

            return this;

        }

    }
}
