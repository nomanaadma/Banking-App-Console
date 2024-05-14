using Banking_App_Console.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App_Console.Validators.Mail
{
    internal class NotExistsMail : BasicMail
    {
        public User? User = null;
        public override IValidator Valid(string name, string email)
        {
            base.Valid(name, email);

            if (Errors != "") return this;

            User = FileSystem.FindAUser(email);

            if (User == null)
                Errors += "\n - The User with this email doesn't Exists";

            return this;

        }
    }
}
