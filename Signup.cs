using Banking_App_Console.Validators;
using Banking_App_Console.Validators.Cnic;
using Banking_App_Console.Validators.Mail;
using Banking_App_Console.Validators.Password;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Banking_App_Console
{
    internal class Signup
    {
        public Signup() {

            var emailObj = GlobalCus.TakeInput("Email", "Enter your Email:", new SignupMail());

            var cnicObj = GlobalCus.TakeInput("CNIC", "Enter your CNIC:", new SignupCnic());

            var passwordObj = GlobalCus.TakeInput("Password", "Enter your Password:", new SignupPassword());

            var fullnameObj = GlobalCus.TakeInput("Full Name", "Enter your Full Name:", new Validator());

            Dictionary<string, string> data = [];

            data["fullname"] = fullnameObj.Input;
            data["email"] = emailObj.Input;
            data["password"] = passwordObj.Input;
            data["cnic"] = cnicObj.Input;
            data["balance"] = "0";
            data["card"] = GlobalCus.GenerateNumber(16);
            data["expiry"] = GlobalCus.GenerateNumber(2);
            data["cvc"] = GlobalCus.GenerateNumber(3);

            FileSystemCus.WriteData("users", data);

            Console.WriteLine("Successfully Signed Up");

        }
    }
}
