using Banking_App_Console.Entities;

namespace Banking_App_Console.Validators.Password
{
    internal class LoginPassword : Validator
    {
        public required User User { private get; init; }
        public override IValidator Valid(string name, string password)
        {
            base.Valid(name, password);

            if (Errors != "") return this;

            if(password != User.Password)
                Errors += "\n - Invalid Password for the user";

            return this;

        }

    }
}
