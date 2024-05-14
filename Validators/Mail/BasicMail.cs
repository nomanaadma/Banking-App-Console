namespace Banking_App_Console.Validators.Mail
{
    internal class BasicMail : Validator
    {
        public override IValidator Valid(string name, string email)
        {
            base.Valid(name, email);

            if (Errors != "") return this;

            if (email.Contains('@') == false || email.Contains('.') == false)
                Errors += $"\n - {name} must be in the correct format.";

            return this;

        }

    }

}
