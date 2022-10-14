
namespace MiniProject_2
{
    internal static class Utilities
    {
        #region Assets Statistics
        public static void ShowFullAssetsStatistics(MyDbContext context)
        {   //Method that prints all the statistics 
            List<string> types = context.Assets.Select(a => a.Type).Distinct().ToList();

            ShowGlobalAssetsStatistics(context, types);
            ShowAllOfficesAssetsStatistics(context, types);
        }
        public static void ShowGlobalAssetsStatistics(MyDbContext context, List<string> types)
        {   //Method that prints all global statistics
            Console.WriteLine();
            ShowGlobalStatistics(context, ConsoleColor.Yellow);

            foreach (string type in types)
            {
                ShowGlobalStatistics(context, ConsoleColor.White, type);
            }
        }
        public static void ShowAllOfficesAssetsStatistics(MyDbContext context, List<string> types)
        {   //Method that prints all local statistics for all offices
            List<Office> offices = context.Offices.ToList();

            foreach (Office office in offices)
            {
                ShowOfficeStatistics(context, office, ConsoleColor.Green);

                foreach (string type in types)
                {
                    ShowOfficeStatistics(context, office, ConsoleColor.White, type);
                }
            }
        }
        private static void ShowGlobalStatistics(MyDbContext context, ConsoleColor color = ConsoleColor.White, string type = "Asset")
        {   //Method that prints global statistics based on the type given, no type will give combined results
            int nrAssets;
            double totalUSD;
            int nrOffices = context.Offices.Count();

            if (type == "Asset")
            {
                nrAssets = context.Assets.Count();
                totalUSD = context.Assets.Sum(a => a.PriceUSD);
            }
            else
            {
                nrAssets = context.Assets.Where(a => a.Type == type).Count();
                totalUSD = context.Assets.Where(a => a.Type == type).Sum(a => a.PriceUSD);
            }
            WriteColoredText($"Global total: {nrOffices} offices - {nrAssets} {type}s - {totalUSD} USD", color);
        }
        private static void ShowOfficeStatistics(MyDbContext context, Office office, ConsoleColor color = ConsoleColor.White, string type = "Asset")
        {   //Method that prints local statistics based on the office and type given, no type will give combined results
            int nrAssets;
            double totalUSD;
            if (type == "Asset")
            {
                nrAssets = context.Assets.Where(a => a.OfficeId == office.Id).Count();
                totalUSD = context.Assets.Where(a => a.OfficeId == office.Id).Sum(a => a.PriceUSD);
            }
            else
            {
                nrAssets = context.Assets.Where(a => a.OfficeId == office.Id && a.Type == type).Count();
                totalUSD = context.Assets.Where(a => a.OfficeId == office.Id && a.Type == type).Sum(a => a.PriceUSD);
            }

            double totalConvertPrice = Math.Round(totalUSD * office.ConvertPriceFromUSD, 2);

            WriteColoredText($"{office.Country} total: {nrAssets} {type}s - {totalUSD} USD", color, false);
            if (office.Currency == "USD")
            {
                Console.WriteLine();
            }
            else
            {
                WriteColoredText($" - {totalConvertPrice} {office.Currency}", color);
            }
        }
        #endregion

        #region Print Assets
        public static void PrintAssetDetails(MyDbContext context, Asset asset)
        {   //Method that writes the details of a single asset
            Office office = context.Offices.SingleOrDefault(o => o.Id == asset.OfficeId);
            WriteColoredText($"{asset.Type} : {asset.Brand} : {asset.Model} : {asset.PurchesDate.ToShortDateString()} : {asset.PriceUSD} USD : {office.Country}", ConsoleColor.Gray);
        }
        public static void PrintAssetsFullDetails(List<Asset> assetsSorted)
        {   //Method that writes the detail head and all items in the given asset list
            int padding = 13;

            Console.WriteLine();
            PrintAssetsFullDetailsDivider();
            WriteColoredText("Type".PadRight(padding) + "Brand".PadRight(padding) + "Model".PadRight(padding) + "Office".ToString().PadRight(padding) + "Purches".PadRight(padding) + "Price USD".PadRight(padding) + "Currency".PadRight(padding) + "Local Price");
            WriteColoredText("----".PadRight(padding) + "-----".PadRight(padding) + "-----".PadRight(padding) + "------".ToString().PadRight(padding) + "-------".PadRight(padding) + "---------".PadRight(padding) + "--------".PadRight(padding) + "-----------", ConsoleColor.Gray);

            foreach (var asset in assetsSorted)
            {
                double assetLocalPrice = Math.Round(asset.PriceUSD * asset.Office.ConvertPriceFromUSD, 2);

                WriteColoredText(asset.Type.PadRight(padding) + asset.Brand.PadRight(padding) + asset.Model.PadRight(padding) + asset.Office.Country.PadRight(padding) + asset.PurchesDate.ToShortDateString().PadRight(padding) + asset.PriceUSD.ToString().PadRight(padding) + asset.Office.Currency.PadRight(padding) + assetLocalPrice, CloseToEndDateColorMark(asset.PurchesDate));
            }
            PrintAssetsFullDetailsDivider();
        }
        private static void PrintAssetsFullDetailsDivider()
        {   //Method that writes a divider for the PrintAssetsFullDetails method
            WriteColoredText("------------------------------------------------------------------------------------------------------", ConsoleColor.Gray);
        }
        public static void PrintAssetsDetailsNumbered(List<Asset> assetsSorted)
        {   //Method that writes all items in the given asset list beginning with a number starting from one
            int padding = 13;

            for (int i = 0; i < assetsSorted.Count; i++)
            {
                WriteColoredNumberInParanthese(i + 1, ConsoleColor.Magenta);  //The list starts at 0 and the printed numbers start at 1
                if (i + 1 < 10)
                {
                    Console.Write("  ");
                }
                else
                {
                    Console.Write(" ");
                }
                string assetPriceUSD = assetsSorted[i].PriceUSD.ToString() + " USD";
                WriteColoredText(assetsSorted[i].Type.PadRight(padding) + assetsSorted[i].Brand.PadRight(padding) + assetsSorted[i].Model.PadRight(padding), ConsoleColor.White, false);
                WriteColoredText(assetsSorted[i].PurchesDate.ToShortDateString().PadRight(padding), CloseToEndDateColorMark(assetsSorted[i].PurchesDate), false);
                WriteColoredText(assetPriceUSD.PadRight(padding) + assetsSorted[i].Office.Country.PadRight(padding));
            }
        }
        private static ConsoleColor CloseToEndDateColorMark(DateTime purchaseDate)
        {   //Method that checks how close a date is to three years and returns a color based on the result
            TimeSpan time = DateTime.Now - purchaseDate;  //The time span between the purchase date and today

            int ThreeYears = 365 * 3;
            int ThreeMonthsBeforeThreeYears = ThreeYears - 30 * 3;
            int SixMonthsBeforeThreeYeras = ThreeYears - 30 * 6;

            if (time.Days > ThreeYears)
            {
                return ConsoleColor.DarkRed;
            }
            else if (time.Days > ThreeMonthsBeforeThreeYears)
            {
                return ConsoleColor.Red;
            }
            else if (time.Days > SixMonthsBeforeThreeYeras)
            {
                return ConsoleColor.Yellow;
            }
            else
            {
                return ConsoleColor.White;
            }
        }
        #endregion

        public static void WriteColoredText(string text, ConsoleColor color = ConsoleColor.White, bool newLine = true)
        {   //Method that writes a given text in a given color
            Console.ForegroundColor = color;
            if (newLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
            Console.ResetColor();
        }
        public static void WriteColoredNumberInParanthese(int number, ConsoleColor color)
        {   //Method that takes a number and a color and then writes the number colored inside parantheses
            WriteColoredText("(", ConsoleColor.White, false);
            WriteColoredText(number.ToString(), color, false);
            WriteColoredText(")", ConsoleColor.White, false);
        }
        public static string GetTrimInput()
        {   //Method that trimms and returns the input
            string input = Console.ReadLine();
            return input.Trim();
        }
        public static string GetChoice()
        {   //Method that askes the user for a input and returns it trimmed
            WriteColoredText("Your choice: ", ConsoleColor.White, false);
            return GetTrimInput();
        }
        public static void InvalidEntryMessage()
        {   //Method that writes an error message
            WriteColoredText("Invalid entry, please try again", ConsoleColor.Red);
        }
    }
}
