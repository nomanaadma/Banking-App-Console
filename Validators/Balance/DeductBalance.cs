using Banking_App_Console.Entities;

namespace Banking_App_Console.Validators.Balance
{
    internal class DeductBalance : BasicBalance
    {
        public required User User { private get; init; }

        public override IValidator Valid(string name, string amount)
        {
            base.Valid(name, amount);

            if (Errors != "") return this;

            var amountInt = int.Parse(amount);
            var userBalance = int.Parse(User.Balance);

            if (amountInt > userBalance)
                Errors += "The amount should not be more than the balance.";

            return this;

        }
    }
}
