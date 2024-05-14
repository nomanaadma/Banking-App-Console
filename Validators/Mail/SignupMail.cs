namespace Banking_App_Console.Validators.Mail
{
    internal class SignupMail : BasicMail
    {
        public Dictionary<string, string> User = [];
        public override IValidator Valid(string name, string email)
        {
            base.Valid(name, email);

            if (Errors != "") return this;

            User = FileSystemCus.FindOne("users", email);

            if (User.Count == 0)
                Errors += "\n - The User with this email doesn't Exists";

            return this;

        }

    }
}