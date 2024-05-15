namespace Banking_App_Console.Entities
{
    public class ETransaction
    {
        public string? Id { get; set; }
        public string? From { get; init; }
        public string? To { get; init; }
        public string? Amount { get; init; }
        public string? Date { get; init; }
    }
}
