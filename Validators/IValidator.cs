namespace Banking_App_Console.Validators
{
    internal interface IValidator
    {
        string Input { get; set; }
        IValidator Valid(string name, string input);
    }

}