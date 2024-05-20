using Banking_App_Console.Entities;

namespace Banking_App_Console.Helpers;

public sealed class Session
{
    private static Session? _instance;
    public static Session Instance => _instance ??= new Session();
    public User? User { get; set; }
    
}