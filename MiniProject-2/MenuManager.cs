
using Microsoft.EntityFrameworkCore;

namespace MiniProject_2
{
    internal static class MenuManager
    {
        public static void UseStartMenu(MyDbContext context)
        {   //Method that set actions in motion based on user input
            int menuChoice;
            do
            {
                menuChoice = StartMenuChooser();
                switch (menuChoice)
                {
                    case 1:  //View assets statistics
                        Utilities.ShowFullAssetsStatistics(context);
                        break;
                    case 2:  //View assets list
                        List<Asset> assetsSorted = context.Assets.OrderBy(a => a.OfficeId).ThenBy(a => a.PurchesDate).Include(a => a.Office).ToList();
                        Utilities.PrintAssetsFullDetails(assetsSorted);
                        break;
                    case 3:  //Enter a new asset
                        CreateAssetMenu(context);
                        break;
                    case 4:  //Edit or Delete existing asset
                        EditOrDeleteAssetMenu(context);
                        break;
                }
            } while (menuChoice != 0);  //Quit program
        }
        public static int StartMenuChooser()
        {   //Method that allows the user to choose a menu item and then returns a valid choice
            Utilities.WriteColoredText("\nWelcome to Asset Tracking!", ConsoleColor.Cyan);
            while (true)
            {
                Utilities.WriteColoredNumberInParanthese(1, ConsoleColor.Cyan);
                Utilities.WriteColoredText(" View assets statistics");
                Utilities.WriteColoredNumberInParanthese(2, ConsoleColor.Cyan);
                Utilities.WriteColoredText(" View assets list");
                Utilities.WriteColoredNumberInParanthese(3, ConsoleColor.Cyan);
                Utilities.WriteColoredText(" Enter a new asset");
                Utilities.WriteColoredNumberInParanthese(4, ConsoleColor.Cyan);
                Utilities.WriteColoredText(" Edit or Delete existing asset");
                Utilities.WriteColoredNumberInParanthese(0, ConsoleColor.Red);
                Utilities.WriteColoredText(" Quit program");

                string input = Utilities.GetChoice();
                if (input == "0" || input == "1" || input == "2" || input == "3" || input == "4")
                {
                    return int.Parse(input);
                }
                else
                {
                    Utilities.InvalidEntryMessage();
                }
            }
        }
        #region Create Asset Menu
        public static void CreateAssetMenu(MyDbContext context)
        {   //Method that asks the user for the necessary information to create a new asset and then adds it to the database
            Asset newAsset = new Asset();

            newAsset.Type = AddAssetInfo.ChooseAssetType();
            newAsset.Brand = AddAssetInfo.EnterWord("Enter a Brand: ");
            newAsset.Model = AddAssetInfo.EnterWord("Enter a Model: ");
            newAsset.PurchesDate = AddAssetInfo.EnterAssetPurchaseDate();
            newAsset.PriceUSD = AddAssetInfo.EnterAssetPriceUSD();
            newAsset.OfficeId = AddAssetInfo.ChooseAssetOffice();

            context.Assets.Add(newAsset);
            context.SaveChanges();

            Utilities.WriteColoredText("Asset has been added:", ConsoleColor.Green);
            Utilities.PrintAssetDetails(context, newAsset);
        }
        #endregion

        #region Edit or Delete Asset Menu
        public static void EditOrDeleteAssetMenu(MyDbContext context)
        {   //Method that asks the user to choose a asset to edit or to delete or to return to start menu
            List<Asset> assetsSorted = context.Assets.OrderBy(a => a.OfficeId).ThenBy(a => a.PurchesDate).Include(a => a.Office).ToList();

            while (true)
            {
                Utilities.WriteColoredText("\nChoose a Asset to Edit or Delete", ConsoleColor.Magenta);
                Utilities.PrintAssetsDetailsNumbered(assetsSorted);
                Utilities.WriteColoredNumberInParanthese(0, ConsoleColor.Red);
                Utilities.WriteColoredText("  Return to Start");

                string input = Utilities.GetChoice();
                if (input == "0")
                {
                    break;
                }
                if (int.TryParse(input, out int value))
                {
                    try
                    {
                        value--;  ////The printed numbers start at 1 and the list starts at 0
                        var asset = context.Assets.SingleOrDefault(a => a.Id == assetsSorted[value].Id);

                        ChooseEditOrDelete(context, asset);
                        break;
                    }
                    catch (Exception)
                    {
                        Utilities.InvalidEntryMessage();
                    }
                }
                else
                {
                    Utilities.InvalidEntryMessage();
                }
            }
        }
        private static void ChooseEditOrDelete(MyDbContext context, Asset asset)
        {   //Method that asks the user what they want to do with the choosen asset
            while (true)
            {
                Utilities.WriteColoredText("\nChoose if to Edit or to Delete Asset:", ConsoleColor.Magenta);
                Utilities.PrintAssetDetails(context, asset);
                Utilities.WriteColoredNumberInParanthese(1, ConsoleColor.Magenta);
                Utilities.WriteColoredText(" Edit");
                Utilities.WriteColoredNumberInParanthese(2, ConsoleColor.Magenta);
                Utilities.WriteColoredText(" Delete");
                Utilities.WriteColoredNumberInParanthese(0, ConsoleColor.Red);
                Utilities.WriteColoredText(" Return to Start");

                string input = Utilities.GetChoice();
                if (input == "0")
                {
                    break;
                }
                else if (input == "1")
                {
                    EditAsset(context, asset);
                    break;
                }
                else if (input == "2")
                {
                    if (ConfirmDeleteAsset(context, asset))
                    {
                        DeleteAsset(context, asset);
                        break;
                    }
                    continue;
                }
                else
                {
                    Utilities.InvalidEntryMessage();
                }
            }
        }
        private static void EditAsset(MyDbContext context, Asset asset)
        {   //Method that allows the user to edit a choosen asset and then prints the before and after details of the asset
            Asset oldAsset = new Asset() { Type = asset.Type, Brand = asset.Brand, Model = asset.Model, PurchesDate = asset.PurchesDate, PriceUSD = asset.PriceUSD, OfficeId = asset.OfficeId };  //In order to show the old asset a temporary asset needs to hold that information

            asset.Type = AddAssetInfo.ChooseAssetType(asset.Type);
            asset.Brand = AddAssetInfo.EnterWord("Enter a Brand: ", asset.Brand);
            asset.Model = AddAssetInfo.EnterWord("Enter a Model: ", asset.Model);
            asset.PurchesDate = AddAssetInfo.EnterAssetPurchaseDate(asset.PurchesDate.ToShortDateString());
            asset.PriceUSD = AddAssetInfo.EnterAssetPriceUSD(asset.PriceUSD.ToString());
            asset.OfficeId = AddAssetInfo.ChooseAssetOffice(asset.OfficeId, asset.Office.Country);
            context.SaveChanges();

            Utilities.WriteColoredText("Old asset:", ConsoleColor.Green);
            Utilities.PrintAssetDetails(context, oldAsset);
            Utilities.WriteColoredText("has been updated to:", ConsoleColor.Green);
            Utilities.PrintAssetDetails(context, asset);
        }
        private static bool ConfirmDeleteAsset(MyDbContext context, Asset asset)
        {   //Method that asks the user to confirm if they want to delete the choosen asset to make sure it isn't deleted by mistake
            //returns a boolean value to use in the edit or delete menu
            Utilities.WriteColoredText("\nAre you sure you want to Delete asset:", ConsoleColor.Red);
            Utilities.PrintAssetDetails(context, asset);

            Utilities.WriteColoredNumberInParanthese(1, ConsoleColor.Red);
            Utilities.WriteColoredText(" ------Yes");
            Utilities.WriteColoredText("(", ConsoleColor.White, false);
            Utilities.WriteColoredText("Any Key", ConsoleColor.Red, false);
            Utilities.WriteColoredText(")", ConsoleColor.White, false);
            Utilities.WriteColoredText(" No");

            string input = Utilities.GetChoice().ToLower();
            if (input == "1" || input == "y" || input == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void DeleteAsset(MyDbContext context, Asset asset)
        {   //Method that deletes a choosen asset from the database
            context.Assets.Remove(asset);
            context.SaveChanges();

            Utilities.WriteColoredText("\nAsset has been deleted:", ConsoleColor.Red);
            Utilities.PrintAssetDetails(context, asset);
        }
        #endregion
    }
}
