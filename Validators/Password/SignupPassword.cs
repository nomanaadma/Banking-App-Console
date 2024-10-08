﻿namespace Banking_App_Console.Validators.Password
{
    internal class SignupPassword : Validator
    {
        public override IValidator Valid(string name, string password)
        {
            base.Valid(name, password);

            if (Errors != "") return this;

            if (ValidatePassword(password) == false)
                Errors += "\n - The password must be between 5 and 10 characters in length, include at least one lowercase and one uppercase character, and must not contain any white spaces.";

            return this;

        }

        private static bool ValidatePassword(string passwd)
        {

            if (passwd.Length is < 5 or > 10)
                return false;

            if (!passwd.Any(char.IsUpper))
                return false;

            if (!passwd.Any(char.IsLower))
                return false;

            if (passwd.Contains(' '))
                return false;

            return true;
        }

    }
}
