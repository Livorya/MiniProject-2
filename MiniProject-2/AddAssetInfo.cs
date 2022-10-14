
namespace MiniProject_2
{
    internal static class AddAssetInfo
    {
        public static string ChooseAssetType(string oldInput = "")
        {   //Metod that asks the user to choose a type of asset and then returns a string that represent the choice
            //when editing a asset an old input can be passed on and the method will give the user the option to use it 
            Console.WriteLine();
            while (true)
            {
                Utilities.WriteColoredText("Choose a Type of Asset to Add", ConsoleColor.Green);
                UseOldInputMessage(oldInput);

                Utilities.WriteColoredNumberInParanthese(1, ConsoleColor.Magenta);
                Utilities.WriteColoredText(" Computer");
                Utilities.WriteColoredNumberInParanthese(2, ConsoleColor.Magenta);
                Utilities.WriteColoredText(" Phone");

                string input = Utilities.GetChoice().ToLower();

                if (UseOldInput(input, oldInput))
                {
                    return oldInput;
                }
                else if (input == "1" || input == "computer")
                {
                    return "Computer";
                }
                else if (input == "2" || input == "phone")
                {
                    return "Phone";
                }
                else
                {
                    Utilities.InvalidEntryMessage();
                }
            }
        }
        public static int ChooseAssetOffice(int oldId = 0, string oldInput = "")
        {   //Method that asks the user to choose an office and then returns the office id
            //when editing a asset an old input can be passed on and the method will give the user the option to use it 
            while (true)
            {
                Utilities.WriteColoredText("Choose a Office", ConsoleColor.Green);
                UseOldInputMessage(oldInput);

                Utilities.WriteColoredNumberInParanthese(1, ConsoleColor.Magenta);
                Utilities.WriteColoredText(" England");
                Utilities.WriteColoredNumberInParanthese(2, ConsoleColor.Magenta);
                Utilities.WriteColoredText(" Sweden");
                Utilities.WriteColoredNumberInParanthese(3, ConsoleColor.Magenta);
                Utilities.WriteColoredText(" USA");

                string input = Utilities.GetChoice();

                if (UseOldInput(input, oldInput))
                {
                    return oldId;
                }
                else if (input == "1" || input == "2" || input == "3")
                {
                    return int.Parse(input);
                }
                else
                {
                    Utilities.InvalidEntryMessage();
                }
            }
        }
        public static string EnterWord(string message, string oldInput = "")
        {   //Method that asks the user for a word and makes sure its not empty and then returns it
            //when editing a asset an old input can be passed on and the method will give the user the option to use it 
            while (true)
            {
                UseOldInputMessage(oldInput);
                Utilities.WriteColoredText(message, ConsoleColor.White, false);
                string input = Utilities.GetTrimInput();

                if (UseOldInput(input, oldInput))
                {
                    return oldInput;
                }
                else if (NotEmptyString(input))
                {
                    return input;
                }
                else
                {
                    Utilities.InvalidEntryMessage();
                }
            }
        }
        public static DateTime EnterAssetPurchaseDate(string oldInput = "")
        {   //Method that asks the user for a purchase date and makes sure it is in a correct format and then returns the date
            //when editing a asset an old input can be passed on and the method will give the user the option to use it 
            while (true)
            {
                UseOldInputMessage(oldInput);
                Utilities.WriteColoredText("Enter a Purchase Date: ", ConsoleColor.White, false);
                string input = Utilities.GetTrimInput();

                if (UseOldInput(input, oldInput))
                {
                    return DateTime.Parse(oldInput);
                }
                else if (DateTime.TryParse(input, out DateTime date))
                {
                    return date;
                }
                else
                {
                    Utilities.InvalidEntryMessage();
                    Console.WriteLine("A valid date format is YYYY-MM-DD");
                }
            }
        }
        public static int EnterAssetPriceUSD(string oldInput = "")
        {   //Method that asks the user for a price input and ensures that the entry is valid and then returns the price
            //when editing a asset an old input can be passed on and the method will give the user the option to use it 
            while (true)
            {
                UseOldInputMessage(oldInput);
                Utilities.WriteColoredText("Enter a Price in USD: ", ConsoleColor.White, false);
                string input = Utilities.GetTrimInput();

                if (UseOldInput(input, oldInput))
                {
                    return int.Parse(oldInput);
                }
                else if (int.TryParse(input, out int value))
                {
                    return value;
                }
                else
                {
                    Utilities.InvalidEntryMessage();
                }
            }
        }
        private static void UseOldInputMessage(string oldInput)
        {   //Method that checks if there is an old input and if there is it prints a message
            if (NotEmptyString(oldInput))
            {
                Utilities.WriteColoredText($"To keep '{oldInput}' enter Empty field", ConsoleColor.Yellow);
            }
        }
        private static bool UseOldInput(string input, string oldInput)
        {   //Method that checks if there is an old input and if the user has enter a empty field and returns a boolean value
            if (NotEmptyString(oldInput) && !NotEmptyString(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool NotEmptyString(string input)
        {   //Method that checks if the input is empty or not and returns a boolean value
            if (input == "" || input == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
