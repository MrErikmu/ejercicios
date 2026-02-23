

using System.Text;
using System.Text.RegularExpressions;
using DawPatchHeroes.Models;
using DawPatchHeroes.Repository;
using DawPatchHeroes.Service;
using DawPatchHeroes.Validators;
using static System.Console;

Title = "DawsPatch Heores";
OutputEncoding = Encoding.UTF8;
Clear();
Main();
WriteLine("\n⌨️  Presiona una tecla para salir...");
ReadKey();
return;


void Main()
{
    IService service = new Service(HeroeRepository.GetInstance(), new Validator()); 
    OptionMenu opcion;
    const string regexOpcionMenu = @"^([1-8])$";
    WriteLine(" Wellcome to Dawspatch Heroes Managing system ");
    WriteLine(new string('━', 45));
    do {
        ShowMenu();
        string input;
        while (true)
        {
            WriteLine("Select an option");
            input = ReadLine() ?? string.Empty;
            if (ValidateEntry(input, regexOpcionMenu)) break;
            WriteLine("Please select a valid option");
        }
        opcion = (OptionMenu)int.Parse(input);
        switch (opcion) 
        {
            case OptionMenu.ListAll: 
            case OptionMenu.ShowRanking:
            case OptionMenu.FindHero : 
            case OptionMenu.AssingHeroe: 
            case OptionMenu.SimulateMission: 
            case OptionMenu.CreateHeroe:
            case OptionMenu.CreateMission:
            case OptionMenu.Exit: WriteLine("\n Closing System Goodbye"); break;
        }
        if (opcion != OptionMenu.Exit) {
            WriteLine("\n⌨️  Press any key to continue...");
            ReadKey();
        }
    } while (opcion != OptionMenu.Exit);
    void ShowMenu() 
    {
        WriteLine("\n📋 --- 1. Main Operations---");
        WriteLine(new string('─', 45));
        WriteLine($"  {(int)OptionMenu.ListAll}. View Registered Heroes");
        WriteLine($"  {(int)OptionMenu.ShowRanking}. Display Hero Rankings");
        WriteLine($"  {(int)OptionMenu.FindHero}. Find Heroes ");
        WriteLine($"  {(int)OptionMenu.AssingHeroe}. Assign Heroes to Mission");
        WriteLine($"  {(int)OptionMenu.SimulateMission}. Simulate Mission Progress");
        WriteLine($"  {(int)OptionMenu.CreateHeroe}. Create New Heroes");
        WriteLine($"  {(int)OptionMenu.CreateMission}. Create New Missions");
        WriteLine("\n🚪 --- 0. Exit ---");
        WriteLine(new string('━', 45));
    }

    bool ValidateEntry(string? pattern, string entry)
    {
        return Regex.IsMatch(entry, pattern ?? string.Empty);
    }
}







