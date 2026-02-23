using System.Text;
using System.Text.RegularExpressions;
using DawPatchHeroes.Factory;
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
    const string regexOpcionSubMenu = "^([0-6])$";
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
            case OptionMenu.ListAll: service.GetHeroeByOrder(TypeOrder.Heroebyname); break;
            case OptionMenu.ShowRanking: service.GetHeroeByOrder(type: TypeOrder.Heroebypowerlvl); break;
            case OptionMenu.FindHero : GetInfoFiltered(); break;
            case OptionMenu.AssingHeroe: AssingHeroe(); break;
            case OptionMenu.SimulateMission: SimulateMission(); break;
            case OptionMenu.CreateHeroe: CreateHeroe(); break;
            case OptionMenu.CreateMission: CreateMision(); break;
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
        WriteLine($"  {(int)OptionMenu.FindHero}. Filter and rank heroes or mission by attributes ");
        WriteLine($"  {(int)OptionMenu.AssingHeroe}. Assign Heroes to Mission");
        WriteLine($"  {(int)OptionMenu.SimulateMission}. Simulate Mission Progress");
        WriteLine($"  {(int)OptionMenu.CreateHeroe}. Create New Heroes");
        WriteLine($"  {(int)OptionMenu.CreateMission}. Create New Missions");
        WriteLine("\n🚪 --- 8. Exit ---");
        WriteLine(new string('━', 45));
    }

    void ShowSubMenu()
    {
        WriteLine("\n📋 --- 1. Filter Options---");
        WriteLine(new string('─', 45));
        WriteLine($"  {(int)TypeOrder.Heroebyminlvl}. Heroe by lvl ");
        WriteLine($"  {(int)TypeOrder.Heroebyexp}. Heroe by exp ");
        WriteLine($"  {(int)TypeOrder.Missionpending}. Mission Ongoing ");
        WriteLine($"  {(int)TypeOrder.Missionbycollabrequired}. Collab missions ");
        WriteLine($"  {(int)TypeOrder.Heroebypowerlvl}. Ranking of heroes ");
        WriteLine(new string('━', 45));
        WriteLine("\n🚪 --- 0. Exit ---");
        WriteLine(new string('━', 45));
    }

    void GetInfoFiltered()
    {
        TypeOrder opcionsubmenu;
        do {
            ShowSubMenu();
            string input;
            while (true)
            {
                WriteLine("Select an option");
                input = ReadLine() ?? string.Empty;
                if (ValidateEntry(input, regexOpcionSubMenu)) break;
                WriteLine("Please select a valid option");
            } 
            opcionsubmenu = (TypeOrder)int.Parse(input);
            switch (opcionsubmenu) 
            {
                case TypeOrder.Heroebyminlvl: service.GetHeroeByOrder(opcionsubmenu); break;
                case TypeOrder.Heroebyexp: service.GetHeroeByOrder(opcionsubmenu); break;
                case TypeOrder.Heroebypowerlvl : service.GetHeroeByOrder(opcionsubmenu); break;
                case TypeOrder.Missionpending: service.GetMissionByOrder(opcionsubmenu); break;
                case TypeOrder.Missionbycollabrequired: service.GetMissionByOrder(opcionsubmenu); break;
                case 0: WriteLine("\n Returning..."); break;
            }
        } while (opcionsubmenu!=0);
    }

    void  CreateMision()
    {
        
        service.CreateMission();
    }

    void CreateHeroe()
    {
        var input = string.Empty;
        var classtype = string.Empty;
        var name = string.Empty;
        var hp = string.Empty;
        var exp = string.Empty;
        var lvl = string.Empty;
        var power = string.Empty;
        Heroe newheroe = null;
        do
        {
            WriteLine("Register a new heroe");
            WriteLine("Enter Class: Rogue, StrongMan, MasterMind");
            classtype = ReadLine() ?? string.Empty;
            WriteLine("Enter name");
            name = ReadLine() ?? string.Empty;
            WriteLine("Enter hp value");
             hp = ReadLine() ?? "0";
            WriteLine("Enter exp value");
             exp = ReadLine() ?? "0";
            WriteLine("Enter lvl value");
             lvl = ReadLine() ?? "0";
            WriteLine("Enter powerlvl");
             power = ReadLine() ?? "0";
            WriteLine($"New heroe data:Class: {classtype} Name: {name}, HP: {hp}, Exp: {exp}, Lvl: {lvl}, Powerlvl: {power}");
            WriteLine("Is this correct Y/N");
            input = ReadLine();
        } while (input != "Y");
        
        switch (classtype.ToUpper())
        {
            case "ROGUE": 
                newheroe = new Rogue();
                break;
                case "STRONGMAN":
                newheroe = new StrongMan();
                break;
                case "MASTERMIND":
                newheroe = new MasterMind();
                        break;
        }

        if (newheroe != null)
        {
            newheroe.Name = name;
            newheroe.Hp = int.Parse(hp);
            newheroe.Exp = int.Parse(exp);
            newheroe.Lvl = int.Parse(lvl);
            newheroe.PowerLvl = int.Parse(power);
            service.CreateHeroe(newheroe);
        }
        
    }

    void SimulateMission()
    {
        WriteLine("Register a new mission");
        var mission = new Mission()
        {

        };
    }

    void AssingHeroe()
    {
        
    }
    bool ValidateEntry( string entry, string? pattern)
    {
        return Regex.IsMatch(entry, pattern ?? string.Empty);
    }
}







