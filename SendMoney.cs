using Banking_App_Console.Entities;
using Banking_App_Console.Helpers;
using Banking_App_Console.Validators;
using Banking_App_Console.Validators.Balance;
using Banking_App_Console.Validators.Mail;

namespace Banking_App_Console
{
    internal class SendMoney
    {
        public SendMoney(Dashboard dashboard)
        {
            var user = Session.Instance.User;

            var SendByOptionsValidator = new OptionValidator
            {
                Choices = [
                    new Option { Id = 1, Msg = "Email", Value = "Email" },
                    new Option { Id = 2, Msg = "CNIC", Value = "CNIC" },
                ]
            };

            var SendByOption = (OptionValidator)Global.TakeInput("Option", "Send By:", SendByOptionsValidator);

            User? bfUser = null;

            switch (SendByOption.SelectedChoice.Value)
            {
                case "Email":

                    var SendMoneyMailValidator = new SendMoneyMail
                    {
                        LoggedInUser = user
                    };

                    var emailObj = (SendMoneyMail)Global.TakeInput("Email", "Enter Email:", SendMoneyMailValidator);

                    bfUser = emailObj.User;

                    break;

                case "CNIC":

                    var SendMoneyCnicValidator = new SendMoneyCnic
                    {
                        LoggedInUser = user
                    };

                    var CnicObj = (SendMoneyCnic)Global.TakeInput("CNIC", "Enter CNIC:", SendMoneyCnicValidator);

                    bfUser = CnicObj.User;

                    break;
            }


            var loginPassValidator = new DeductBalance
            {
                User = user
            };

            var amountObj = Global.TakeInput("Amount", "Enter Amount:", loginPassValidator);
            var amount = amountObj.Input;

            var bfUserBalance = int.Parse(bfUser.Balance);

            var amount_entered = int.Parse(amount);

            bfUser.Balance = (bfUserBalance + amount_entered).ToString();

            FileSystem.UpdateUser(bfUser);

            var currentUserBalance = int.Parse(user.Balance);
            var newAmount = (currentUserBalance - amount_entered).ToString();
            user.Balance = newAmount;

            FileSystem.UpdateUser(user);

            var data = new ETransaction
            {
                Id = Global.GenerateId(),
                From = user.Id,
                To = bfUser.Id,
                Amount = amount,
                Date = DateTime.Now.ToString(),
            };

            FileSystem.WriteData("Transactions", data);

            Console.Clear(); Console.WriteLine("\x1b[3J");
            Console.WriteLine("Amount Transferred Successfully.");

            dashboard.Init();

        }
    }
}
