using Banking_App_Console.Entities;
using Banking_App_Console.Validators;
using Banking_App_Console.Validators.Cnic;
using Banking_App_Console.Validators.Mail;
using Banking_App_Console.Validators.Password;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Banking_App_Console
{
    internal class Signup
    {
        public Signup(BankingApp home) {

            var emailObj = Global.TakeInput("Email", "Enter your Email:", new ExistsMail());

            var cnicObj = Global.TakeInput("CNIC", "Enter your CNIC:", new SignupCnic());

            var passwordObj = Global.TakeInput("Password", "Enter your Password:", new SignupPassword());

            var fullnameObj = Global.TakeInput("Full Name", "Enter your Full Name:", new Validator());

            var data = new User
            {
                Id = Global.GenerateId(),
                Fullname = fullnameObj.Input,
                Email = emailObj.Input,
                Password = passwordObj.Input,
                Cnic = cnicObj.Input,
                Balance = "0",
                Card = Global.GenerateNumber(16),
                Expiry = Global.GenerateNumber(2),
                Cvc = Global.GenerateNumber(3),
            };

            FileSystem.WriteData("Users", data);

            Console.Clear(); Console.WriteLine("\x1b[3J");

            Console.WriteLine("Successfully Signed Up\n");

            home.Init();

        }
    }
}
