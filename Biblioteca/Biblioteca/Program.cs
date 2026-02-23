
using System.Text;
using System.Text.RegularExpressions;
using ConsoleApp1.Models;
using ConsoleApp1.repository;
using ConsoleApp1.Service;
using ConsoleApp1.Validators;

Console.OutputEncoding = Encoding.UTF8;
Console.Clear();
Main();
Console.WriteLine("\n⌨️ Presiona una tecla para salir...");
Console.ReadKey();
return;

void Main ()
{
    IBibliotecaService service = new BibliotecaService(
        DvdRepository.GetInstance(),
        new DvdValidator(),
        RevistaRepository.GetInstance(),
        new RevistaValidator(),
        LibroRepository.GetInstance(),
        new LibroValidator()
    );
    const string regexOpcionMenu = "^[0-8]$";

    Console.WriteLine("Sistema de Gestión de Biblioteca");
    Console.WriteLine("==================================");
    int opcion;
    do {
        MostrarMenu();
        // Validación de la opción de menú con Regex
        string opcionStr;
        do {
            Console.Write("Seleccione una opción: ");
            opcionStr = Console.ReadLine()?.Trim() ?? "";
            if (!ValidarEntrada(regexOpcionMenu, opcionStr))
                Console.WriteLine("⚠️ Opción no válida. Intente de nuevo.");
        } while (!ValidarEntrada(regexOpcionMenu, opcionStr));

        opcion = int.Parse(opcionStr);
        OpcionMenu opcionMenu = (OpcionMenu)int.Parse(opcionStr);

        // El bucle principal delega la lógica a los métodos locales
        switch (opcionMenu) {
            case OpcionMenu.Añadir:
                AñadirItem(service);
                break;
            case OpcionMenu.Buscar:
                BuscarItem(service);
                break;
            case OpcionMenu.Eliminar:
                EliminarItem(service);
                break;
            case OpcionMenu.ListadoBiblioteca:
                ListarBiblioteca(service);
                break;
            case OpcionMenu.Salir:
                Console.WriteLine("Saliendo del programa.");
                break;
            default:
                // Este caso ya no debería ocurrir si la validación es correcta.
                Console.WriteLine("La opción no existe. Intentelo de nuevo.");
                break;
        }
    } while (opcion != (int)OpcionMenu.Salir);
    void MostrarMenu()
    {
        Console.WriteLine("\n--- Operaciones de Gestion ---");
        Console.WriteLine($"{(int)OpcionMenu.Añadir}. Añadir articulo nuevo");
        Console.WriteLine($"{(int)OpcionMenu.Buscar}. Buscar articulo por id");
        Console.WriteLine($"{(int)OpcionMenu.Eliminar}. Eliminar articulo");
        Console.WriteLine($"{(int)OpcionMenu.ListadoBiblioteca}. Listado con todos los articulos ");
        Console.WriteLine($"{(int)OpcionMenu.Salir}. Salir");
        Console.WriteLine("---------------------------");
    }
    bool ValidarEntrada(string patron, string entrada) {
        return Regex.IsMatch(entrada, patron);
    }
    string EntradaDato(string prompt, string regexPattern, string errorMsg) {
        string input;
        var valido = false;
        do {
            Console.Write(prompt);
            input = (Console.ReadLine() ?? "").Trim();
            if (ValidarEntrada(regexPattern, input))
                valido = true;
            else
                Console.WriteLine($"{errorMsg}");
        } while (!valido);
        return input;
    }
    
    void AñadirItem(IBibliotecaService bibliotecaService)
    {
        const string regexTipo = "^[1-3]$";
        var numtipo = EntradaDato("Introduzca la opcion del tipo de articulo que desea introducir: 1:DVD,2:Revista,3:Libro", regexTipo,
            "El numero debe ser 1, 2 o 3");
        TipoItem item=(TipoItem)int.Parse(numtipo)-1;
        switch (item)
        {
            case TipoItem.Dvd:
                var articulo = PedirDvd();
                
                bibliotecaService.AñadirDvd(articulo);
                break;
            case TipoItem.Revista:
                 var revista = PedirRevista();
                bibliotecaService.AñadirRevista(revista);
                break;
            case TipoItem.Libro:
                 var libro = PedirLibro();
                bibliotecaService.AñadirLibro(libro);
                break;
        }
    }
    void BuscarItem(IBibliotecaService bibliotecaService)
    {
        const string regexId = @"^\d+$";
        const string regexTipo = "^[1-3]$";
        var numtipo = EntradaDato("Introduzca la opcion del tipo de articulo que desea introducir: 1:DVD,2:Revista,3:Libro", regexTipo,
            "El numero debe ser 1, 2 o 3");
        var idstr = EntradaDato("Introduzca el id del articulo que desea buscar", regexId,
            "El id introducido no es valido");
        TipoItem item=(TipoItem)int.Parse(numtipo)-1;
        var id = int.Parse(idstr);
        switch (item)
        {
            case TipoItem.Dvd:
                bibliotecaService.BuscarDvd(id);
                break;
            case TipoItem.Revista:
                bibliotecaService.BuscarRevista(id);
                break;
            case TipoItem.Libro:
                bibliotecaService.BuscarLibro(id);
                break;
        }
        
    }
    void EliminarItem(IBibliotecaService bibliotecaService)
    {
        const string regexId = @"^\d+$";
        const string regexTipo = "^[1-3]$";
        var numtipo = EntradaDato("Introduzca la opcion del tipo de articulo que desea introducir: 1:DVD,2:Revista,3:Libro", regexTipo,
            "El numero debe ser 1, 2 o 3");
        var idstring = EntradaDato("Introduzca el id del articulo que desea buscar", regexId,
            "El id introducido no es valido");
        int id = int.Parse(idstring);
        TipoItem item=(TipoItem)int.Parse(numtipo)-1;
        switch (item)
        {
            case TipoItem.Dvd:
                bibliotecaService.EliminarDvd(id);
                break;
            case TipoItem.Revista:
                bibliotecaService.EliminarRevista(id);
                break;
            case TipoItem.Libro:
                bibliotecaService.EliminarLibro(id);
                break;
        }
    }
    void ListarBiblioteca(IBibliotecaService bibliotecaService)
    {
        bibliotecaService.ListarBiblioteca();
    }
    Dvd PedirDvd()
    {
        Console.Write("Introduzca el nombre del dvd");
        var nombre = Console.ReadLine()?.Trim() ?? "";
        bool esvalido;
        int año;
        do
        {
            Console.Write("Introduzca el año de salida del dvd");
             esvalido = int.TryParse(Console.ReadLine(), out año);
        } while (!esvalido);
        Console.Write("Introduzca el nombre del director del dvd");
        var director = Console.ReadLine()?.Trim() ?? "";
        Console.Write("Introduzca el genero del dvd");
        var genero = Console.ReadLine()?.Trim() ?? "";
        Dvd nuevo = new Dvd(director, año, genero,nombre);
        return nuevo;
    }
    Revista PedirRevista()
    {
        Console.Write("Introduzca el nombre de la revista");
        var nombre = Console.ReadLine()?.Trim() ?? "";
        bool esvalido;
        int añosalida;
        int npublic;
        do
        {
            Console.Write("Introduzca el año de salida de la revista");
            esvalido = int.TryParse(Console.ReadLine(), out añosalida);
        } while (!esvalido);
        do
        {
            Console.Write("Introduzca el numero de publicacion de la revista");
            esvalido = int.TryParse(Console.ReadLine(), out npublic);
        } while (!esvalido);

        Revista nuevo = new Revista(npublic, añosalida, nombre);
        return nuevo;
    }
    Libro PedirLibro()
    {
        Console.Write("Introduzca el Titulo del Libro");
        var nombre = Console.ReadLine()?.Trim() ?? "";
        Console.Write("Introduzca el autor del libro");
        var autor = Console.ReadLine()?.Trim() ?? "";
        Console.Write("Introduzca el nombre de la editorial");
        var editorial = Console.ReadLine()?.Trim() ?? "";
        Libro nuevo = new Libro(autor, editorial, nombre);
        return nuevo;
    }
}