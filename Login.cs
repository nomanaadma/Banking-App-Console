using Banking_App_Console.Helpers;
using Banking_App_Console.Validators.Mail;
using Banking_App_Console.Validators.Password;

namespace Banking_App_Console
{
    internal class Login
    {
        public Login(BankingApp home)
        {
            var emailObj = (NotExistsMail)Global.TakeInput("Email", "Enter your Email:", new NotExistsMail() );

            var loginPassValidator = new LoginPassword
            {
                User = emailObj.User
            };

            var passwordObj = Global.TakeInput("Password", "Enter your Password:", loginPassValidator);

            Console.Clear(); Console.WriteLine("\x1b[3J");
            Console.WriteLine("Successfuly Logged In.");

            Session.Instance.User = emailObj.User;

            _ = new Dashboard(emailObj.User);

        }
    }
}
