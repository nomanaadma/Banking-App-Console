namespace Banking_App_Console.Validators.Mail
{
    internal class SignupMail : BasicMail
    {
        public override IValidator Valid(string name, string email)
        {
            base.Valid(name, email);

            if (Errors != "") return this;

            var matchingUser = FileSystemCus.FindOne("users", email);

            if (matchingUser.Count != 0)
                Errors += "\n - The User with this email already Exists";

            return this;

        }

    }

}