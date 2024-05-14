using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Banking_App_Console.Validators.Cnic
{
    internal class SignupCnic : BasicCnic
    {
        public override IValidator Valid(string name, string cnic)
        {
            base.Valid(name, cnic);

            if (Errors != "") return this;

            var getUserByCNIC = FileSystemCus.FindOne("users", cnic);

            Console.WriteLine(getUserByCNIC.Count);
            Console.WriteLine(cnic);

            if (getUserByCNIC.Count != 0)
                Errors += "\n - The User with this CNIC already Exists";

            return this;

        }
    }
}
