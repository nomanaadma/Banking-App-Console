using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App_Console.Validators.Password
{
    internal class LoginPassword : Validator
    {
        public required string UserPass { private get; set; }
        public override IValidator Valid(string name, string password)
        {
            base.Valid(name, password);

            if (Errors != "") return this;

            if(password != UserPass)
                Errors += "\n - Invalid Password for the user";

            return this;

        }

    }
}
