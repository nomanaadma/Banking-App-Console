namespace Banking_App_Console.Validators.Mail
{
    internal class ExistsMail : BasicMail
    {
        public override IValidator Valid(string name, string email)
        {
            base.Valid(name, email);

            if (Errors != "") return this;

            var matchingUser = FileSystem.FindAUser(email);

            if (matchingUser != null)
                Errors += "\n - The User with this email already Exists";

            return this;

        }

    }

}