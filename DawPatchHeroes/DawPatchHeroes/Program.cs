

using System.Text;
using DawPatchHeroes.Models;
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
    OptionMenu opcion;
    const string regexOpcionMenu = @"^([1-8])$";
    WriteLine("Dawspatch Heroes Managing system ");
    WriteLine(new string('━', 45));
    do {
        ShowMenu();
        var opcionStr = LeerCadenaValidada("👉 Seleccione una opción: ", regexOpcionMenu, "Opción no válida (0-13).");
        var opcionValue = int.Parse(opcionStr);
        opcion = (OptionMenu)opcionValue;

        switch (opcion) {
            OptionMenu.ListAll => Listall();
            OptionMenu.ShowRanking => ShowRanking();
            OptionMenu.FindHero => 
            OptionMenu.AssingHeroe => 
            OptionMenu.SimulateMission => 
            OptionMenu.CreateHeroe => 
            OptionMenu.CreateMission =>
            OptionMenu.Exit => WriteLine("\n👋 Cerrando el sistema. ¡Hasta pronto!"); break;
        }
        if (opcion != OptionMenu.Exit) {
            WriteLine("\n⌨️  Presione una tecla para continuar...");
            ReadKey();
        }
    } while (opcion != OptionMenu.Exit);
}
void ShowMenu() {
    WriteLine("\n📋 --- 1. Main Operations---");
    WriteLine(new string('─', 45));
    WriteLine($"  {(int)OptionMenu.ListAll}. View Registered Heroes");
    WriteLine($"  {(int)OptionMenu.ShowRanking}.  Display Hero Rankings");
    WriteLine($"  {(int)OptionMenu.FindHero}.   Find Heroes ");
    WriteLine($"  {(int)OptionMenu.AssingHeroe}.  Assign Heroes to Mission");
    WriteLine($"  {(int)OptionMenu.SimulateMission}.   Simulate Mission Progress");
    WriteLine($"  {(int)OptionMenu.CreateHeroe}. Create New Heroes");
    WriteLine($"  {(int)OptionMenu.CreateMission}.  Create New Missions");
    WriteLine("\n🚪 --- 0. Exit ---");
    WriteLine(new string('━', 45));
}






