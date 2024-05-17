namespace Banking_App_Console.Validators.Balance
{
    internal class BasicBalance : Validator
    {
        public override IValidator Valid(string name, string amount)
        {
            base.Valid(name, amount);

            if (Errors != "") return this;

            if (amount.All(char.IsDigit) == false || amount == "0")

                Errors += "The amount must not be empty and in numbers only.";

            return this;

        }
    }
}
