using Banking_App_Console.Validators.Mail;
using Banking_App_Console.Validators.Password;

namespace Banking_App_Console
{
    internal class Login
    {
        public Login()
        {

            var emailObj = (LoginMail)GlobalCus.TakeInput("Email", "Enter your Email:", new LoginMail() );

            var loginPassValidator = new LoginPassword
            {
               UserPass = emailObj.User["password"]
            };

            var passwordObj = GlobalCus.TakeInput("Password", "Enter your Password:", loginPassValidator);
            


        }
    }
}
