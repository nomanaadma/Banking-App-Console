using Banking_App_Console.Validators.Mail;
using Banking_App_Console.Validators.Password;

namespace Banking_App_Console
{
    internal class Login
    {
        public Login()
        {

            var emailObj = (LoginMail)Global.TakeInput("Email", "Enter your Email:", new LoginMail() );

            var loginPassValidator = new LoginPassword
            {
                User = emailObj.User
            };

            var passwordObj = Global.TakeInput("Password", "Enter your Password:", loginPassValidator);

            new Dashboard(emailObj.User);

        }
    }
}
