using Banking_App_Console.Entities;
using Banking_App_Console.Validators;
using Banking_App_Console.Validators.Mail;
using Banking_App_Console.Validators.Password;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Banking_App_Console
{
    internal class BankingApp
    {
        public enum WelcomOperations
        {
            Login = 1,
            Signup = 2,
        }

        private static Validator TakeInput(string name, string msg, Validator validator)
        {

            Console.WriteLine("\n" + msg);

            if (validator is OptionValidator optionValidator)
            {
                foreach (var choices in optionValidator.Choices)
                {
                    Console.WriteLine($"{choices.Id} {choices.Value}");
                }

            }

            var input = Console.ReadLine();

            validator.Valid(name, input);


            if (validator.Errors != "")
            {
                Console.WriteLine(validator.Errors);
                return TakeInput(name, msg, validator);
            } 

            return validator;
        }

        public BankingApp()
        {

            Console.WriteLine("working");

            Console.WriteLine("Welcome to NS Banking");

            Console.WriteLine("\nAt any step type 'Back' go to to previous step and type 'Exit' to close the application.");

            var WelcomeOptionValidator = new OptionValidator
            {
                Choices = [
                    new Option { Id = 1, Value = "Login" },
                    new Option { Id = 2, Value = "Signup" },
                ]    
            };

            var WelcomeOption = (OptionValidator)TakeInput("Option", "Select your option below:", WelcomeOptionValidator);

            GetInstance(WelcomeOption.SelectedChoice.Value);






            // var ChoiceClassType = Type.GetType(WelcomeOption.SelectedChoice.Value);

            // Console.WriteLine(ChoiceClassType.Name);

            // var ChoiceClass = Activator.CreateInstance(ChoiceClassType);



            //var choice = TakeInput("Choice", "Enter your Email:", new SignupMail());




            // var emailObj = (SignupMail)TakeInput("Email", "Enter your Email:", new SignupMail() );

            //Console.WriteLine(emailObj.matchingUser["password"]);

            // Console.WriteLine(emailObj.Input);

            // var passwordObjs = TakeInput("Password", "Enter your Password:", new SignupPassword());

            /*var loginPassValidator = new LoginPassword
            {
                UserPass = emailObj.User["password"]
            };*/

            // var passwordObj = TakeInput("Password", "Enter your Password:", loginPassValidator);



            // Console.WriteLine(passwordObj.Input);

            return;


            /* int choice;

            do
            {

                Welcome:

                Console.WriteLine("Welcome to NS Banking");
                Console.WriteLine("Select your option below:");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Signup");
                Console.WriteLine("3: Exit");

                choice = int.Parse(Console.ReadLine());

                Console.WriteLine();
                switch (choice)
                {

                    case 1:


                        string? mailValidation;

                        Dictionary<string, string> matchingUser;

                        do
                        {
                            mailValidation = "";

                            Console.WriteLine("Enter your Email:");
                            var email = Console.ReadLine();
                            
                            if (email.Contains('@') == false || email.Contains('.') == false)
                                mailValidation += "\n - The email must not be empty and in the correct format.";

                            matchingUser = FileSystemCus.FindOne("users", email);
                            
                            if (matchingUser.Count == 0)
                                mailValidation += "\n - The User with this email doesn't Exists";

                            Console.WriteLine(mailValidation);

                        } while (mailValidation != "");


                        string? passwordValidation;

                        do
                        {
                            passwordValidation = "";

                            Console.WriteLine("Enter your Password:");
                            var password = Console.ReadLine();

                            if(password == "back")
                            {
                                goto Welcome;
                            }

                            if (password.Length <= 0)
                                passwordValidation += "\n - The password must not be empty.";

                            if (matchingUser["password"] != password)
                                passwordValidation += "\n - Invalid Password for the user";

                            Console.WriteLine(passwordValidation);

                        } while (passwordValidation != "");


                        Console.WriteLine("Successfully Login");


                        break;
                    case 2:
                        Console.WriteLine("Enter Email");
                        break;
                    case 4:
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 4); */


        }

        public static object GetInstance(string strFullyQualifiedName)
        {
            var t = Type.GetType("Banking_App_Console." + strFullyQualifiedName);
            return Activator.CreateInstance(t);
        }

    }
}
