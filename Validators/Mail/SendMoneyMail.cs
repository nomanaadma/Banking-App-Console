using Banking_App_Console.Entities;

namespace Banking_App_Console.Validators.Mail
{
    internal class SendMoneyMail : NotExistsMail
    {
        public User? LoggedInUser = null;
        public override IValidator Valid(string name, string email)
        {
            base.Valid(name, email);

            if (Errors != "") return this;

            if (LoggedInUser.Email == email)
                Errors += "\n - You cannot transfer money to yourself.";

            return this;

        }
    }
}
