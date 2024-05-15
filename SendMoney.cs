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

            var sendByOptionsValidator = new OptionValidator
            {
                Choices = [
                    new Option { Id = 1, Msg = "Email", Value = "Email" },
                    new Option { Id = 2, Msg = "CNIC", Value = "CNIC" },
                ]
            };

            var sendByOption = (OptionValidator)Global.TakeInput("Option", "Send By:", sendByOptionsValidator);

            User? bfUser = null;

            switch (sendByOption.SelectedChoice?.Value)
            {
                case "Email":

                    var sendMoneyMailValidator = new SendMoneyMail
                    {
                        LoggedInUser = user
                    };

                    var emailObj = (SendMoneyMail)Global.TakeInput("Email", "Enter Email:", sendMoneyMailValidator);

                    bfUser = emailObj.User;

                    break;

                case "CNIC":

                    var sendMoneyCnicValidator = new SendMoneyCnic
                    {
                        LoggedInUser = user
                    };

                    var cnicObj = (SendMoneyCnic)Global.TakeInput("CNIC", "Enter CNIC:", sendMoneyCnicValidator);

                    bfUser = cnicObj.User;

                    break;
            }


            var loginPassValidator = new DeductBalance
            {
                User = user
            };

            var amountObj = Global.TakeInput("Amount", "Enter Amount:", loginPassValidator);
            var amount = amountObj.Input;

            var bfUserBalance = int.Parse(bfUser.Balance);

            var amountEntered = int.Parse(amount);

            bfUser.Balance = (bfUserBalance + amountEntered).ToString();

            FileSystem.UpdateUser(bfUser);

            var currentUserBalance = int.Parse(user.Balance);
            var newAmount = (currentUserBalance - amountEntered).ToString();
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
