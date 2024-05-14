using Banking_App_Console.Validators;

namespace Banking_App_Console
{
    public class Global
    {
        public static string GenerateNumber(int count)
        {

            var random = new Random();
            var randomIntegers = new int[count];

            for (int i = 0; i < randomIntegers.Length; i++)
                randomIntegers[i] = random.Next(0, 10);

            return string.Join("", randomIntegers);

        }

        public static string GenerateId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var charArr = chars.ToCharArray();
            var random = new Random();
            random.Shuffle(charArr);

            return  string.Join("", charArr)[..6];

        }
        public static Validator TakeInput(string name, string msg, Validator validator)
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

    }
    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                (array[k], array[n]) = (array[n], array[k]);
            }
        }
    }

}
