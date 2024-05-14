namespace Banking_App_Console.Validators
{
    public interface IValidator
    {
        string Input { get; set; }
        IValidator Valid(string name, string input);
    }

}