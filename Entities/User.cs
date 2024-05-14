namespace Banking_App_Console.Entities
{
    public class User : Entry
    {
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Cnic { get; set; }
        public string? Balance { get; set; }
        public string? Card { get; set; }
        public string? Expiry { get; set; }
        public string? Cvc { get; set; }

    }
}
