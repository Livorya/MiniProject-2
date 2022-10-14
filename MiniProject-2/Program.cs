
//Mini Project #2 - Asset Tracking with Database
//Created by Malin Wirén

using MiniProject_2;

//Global variables
MyDbContext context = new MyDbContext();

//Main-method
MenuManager.UseStartMenu(context);

Utilities.WriteColoredText("\nThank you for using this application!", ConsoleColor.Green);

