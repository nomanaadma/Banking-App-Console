using Banking_App_Console.Entities;
namespace Banking_App_Console.Validators
{
    internal class OptionValidator : Validator
    {
        public required List<Option> Choices { get; init; }
        public Option? SelectedChoice;

        public override IValidator Valid(string name, string choice)
        {
            base.Valid(name, choice);

            if (Errors != "") return this;

            SelectedChoice = Choices.FirstOrDefault(c => c.Id.ToString() == choice);

            if (SelectedChoice == null)
                Errors += "Invalid Option Selected. Please try again";

            return this;

        }
    }
}
