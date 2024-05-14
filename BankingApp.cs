using Banking_App_Console.Validators;
using Banking_App_Console.Validators.Mail;
using Banking_App_Console.Validators.Password;

namespace Banking_App_Console
{
    internal class BankingApp
    {
        private static Validator TakeInput(string name, string msg, Validator validator)
        {
            Console.WriteLine( "\n"+ msg);

            var input = Console.ReadLine();
            validator.Valid(name, input);
            
            if(validator.Errors != "")
            {
                Console.WriteLine(validator.Errors);
                return TakeInput(name, msg, validator);
            } 

            return validator;
        }

        public BankingApp()
        {

            var emailObj = (SignupMail)TakeInput("Email", "Enter your Email:", new SignupMail() );

            //Console.WriteLine(emailObj.matchingUser["password"]);

            // Console.WriteLine(emailObj.Input);

            // var passwordObjs = TakeInput("Password", "Enter your Password:", new SignupPassword());

            var loginPassValidator = new LoginPassword
            {
                UserPass = emailObj.User["password"]
            };

            var passwordObj = TakeInput("Password", "Enter your Password:", loginPassValidator);



            Console.WriteLine(passwordObj.Input);

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

    }
}
