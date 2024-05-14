using Banking_App_Console.Entities;
using Banking_App_Console.Validators.Cnic;

namespace Banking_App_Console.Validators.Mail
{
    internal class SendMoneyCnic : BasicCnic
    {
        public User? LoggedInUser = null;
        public User? User = null;
        public override IValidator Valid(string name, string cnic)
        {
            base.Valid(name, cnic);

            if (Errors != "") return this;

            if (LoggedInUser.Cnic == cnic)
                Errors += "\n - You cannot transfer money to yourself.";

            User = FileSystem.FindAUser(cnic);

            if (User == null)
                Errors += "\n - The User with this CNIC doesn't Exists";

            return this;

        }
    }
}
