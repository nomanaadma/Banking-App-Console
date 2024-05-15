namespace Banking_App_Console.Entities
{
    public class User
    {
        public string? Id { get; init; }
        public string? Fullname { get; init; }
        public string? Email { get; init; }
        public string? Password { get; init; }
        public string? Cnic { get; init; }
        public string? Balance { get; set; }
        public string? Card { get; init; }
        public string? Expiry { get; init; }
        public string? Cvc { get; init; }

    }
}
