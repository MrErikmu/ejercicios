using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;
using cinecsharp.enums;
using cinecsharp.structs;
using Microsoft.CSharp.RuntimeBinder;

//Opciones del menu.
const int VerSala = 0;
const int Comprar_Entrada = 1;
const int DevolverEntrada = 2;
const int Recaudacion = 3;
const int Informe = 4;
const int Salir = 5;
// Precio entrada
const double Entrada = 6.50;

Console.Clear();
Console.OutputEncoding = Encoding.UTF8;
var regex = new Regex(@"^\d{1}$");
var regex_Entrada = new Regex(@"^[A-B]:[1-9]$");
//var tamañocine = args;
var random = new Random();
infosala[,] salacine = new infosala[4,5];
crearsala(salacine);
int opcion;
var numeroventa = 0;
do
{
    mostrarmenu();
    string input = Console.ReadLine()?.Trim() ?? "";
    if (!int.TryParse(input, out opcion))
    {
        opcion = -1;
    }
    if (opcion < 0 || opcion > 6)
    {
        Console.WriteLine("Por favor introduzca una opcion correcta"); 
    }
    else
    {
        opcion -= 1;
        switch (opcion)
        {
            case VerSala:
                mostrarsala(salacine);
                break;
           case Comprar_Entrada:
                comprar(salacine);
                break;
            case DevolverEntrada:
                devolver(salacine,regex_Entrada);
                break;
            case Recaudacion:
                var total=recaudado(numeroventa,Entrada);
                Console.WriteLine($"Las ganancias totales de hoy ascienden a {total} €");
                break;
            case Informe: 
                informe(salacine,numeroventa);
                break;
            case Salir:
                break;
        } 
    }
} while (opcion != Salir);
Console.Clear();

Console.WriteLine("Presiona una tecla para cerrar el programa");
Console.ReadKey();
return;

//fin del main
void mostrarmenu()
{
    Console.WriteLine("=============================================");
    Console.WriteLine("Bienvenido al cine DAW, selecciona 1 opcion del menu");
    Console.WriteLine("=============================================");
    Console.WriteLine("1. Ver salas.");
    Console.WriteLine("2. Compra de entrada.");
    Console.WriteLine("3 Devolucion de entrada.");
    Console.WriteLine("4 Consultar recaudación.");
    Console.WriteLine("5. Ver informe.");
    Console.WriteLine("6. Salir.");
    Console.WriteLine();
}

void crearsala(infosala[,] salacine)
{
    var butacand = random.Next(1,4);
    int r=-1;
    int c=-1;
    for ( var i = 0; i<salacine.GetLength(0); i++)
    {
        for (var j = 0; j < salacine.GetLength(1); j++)
        {
            salacine[i, j] = new infosala
            {
                Row = i,
                Col = j,
                ButacaEstado = butaca_estado.Libre
            };
        }
    }

    for (var n = 0; n < butacand; n++)
    {
        r = random.Next(0,salacine.GetLength(0));
        c = random.Next(0,salacine.GetLength(1));
    }
    salacine[r,c].ButacaEstado=butaca_estado.NoDisponible;
}
void mostrarsala(infosala[,] salacine)
{
    for ( var i = 0; i<salacine.GetLength(0); i++)
    {
        for (var j = 0; j < salacine.GetLength(1); j++)
        {
            var estado = salacine[i,j].ButacaEstado;
            
            if (estado==butaca_estado.Libre)
            {
                Console.WriteLine("[🟢]");
            }else if(estado==butaca_estado.Ocupada)
            {
                Console.WriteLine(" [🔴]"); 
            }
            else if(estado==butaca_estado.NoDisponible)
            {
                Console.WriteLine("[🚫]");   
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine("___________________________________");
}

void comprar(infosala[,] salacine)
{
    for ( var i = 0; i<salacine.GetLength(0); i++)
    {
        for (var j = 0; j < salacine.GetLength(1); j++)
        {
            if (salacine[i, j].ButacaEstado == butaca_estado.Libre)
            {
                salacine[i, j].ButacaEstado = butaca_estado.Ocupada;
                numeroventa += 1;
                if (i == 0)
                {
                    char fila = 'A';
                    Console.WriteLine("Gracias por su compra su butaca es la: "+ fila+":"+salacine[i, j].Col);
                }
                else
                {
                    char fila = 'B';
                    Console.WriteLine("Gracias por su compra su butaca es la: "+ fila+":"+salacine[i, j].Col);
                }
                return;
            }
        }
    }
}

void devolver(infosala[,] salacine, Regex regex_Entrada)
{
    string input = "";
    var indice = -1;
    char letra=' ';
    int num=-3;
    do
    {
        Console.WriteLine("Introduce tu butaca en formato: L:N por ejemplo A:1");
        input = Console.ReadLine()?.Trim() ?? "";
        if (regex_Entrada.IsMatch(input))
        { 
            letra=input[0];
            num = input[2];
        }
        else
        {
            Console.WriteLine("Por favor introduzca una opcion correcta");
            continue;
        }
    } while (!regex_Entrada.IsMatch(input));

    if (letra=='A')
    {
        indice = 0;
    }
    else
    {
        indice = 1;
    }

    if (indice<=salacine.GetLength(0)&&num>salacine.GetLength(1))
    {
        Console.WriteLine("No se ha encontrado la butaca introducida, por favor intentelo de nuevo");
        return;
    }
    else
    {
        salacine[indice,num].ButacaEstado=butaca_estado.Libre;
        numeroventa -= 1;
    }
}

double recaudado(int numeroventa, double precio)
{
    double ganancias = numeroventa * precio;
    return ganancias;
}

void informe(infosala[,] salacine, int numeroventa)
{
    double butacaocup = 0.0;
    double butacand = 0.0; 
    double butacalb = 0.0;
    var recaudacion=recaudado(numeroventa, Entrada);
    
    for (var i = 0; i < salacine.GetLength(0); i++)
    {
        for (var j = 0; j < salacine.GetLength(1); j++)
        {
            if (salacine[i, j].ButacaEstado == butaca_estado.Ocupada)
            {
                butacaocup++;
            }
            if (salacine[i, j].ButacaEstado == butaca_estado.NoDisponible)
            {
                butacand++;
            }
            if (salacine[i, j].ButacaEstado == butaca_estado.Libre)
            {
                butacalb++;
            }
        }
    }
    var total = butacaocup+butacand+butacalb;
    double ocupacion = (butacaocup/total)*100;
    Console.WriteLine("--- INFORME CINEDAW ---");
    Console.WriteLine("-----------------------");
    Console.WriteLine($"Total de entradas vendidas: {numeroventa}");
    Console.WriteLine($"Porcentaje de ocupacion: {ocupacion}%");
    Console.WriteLine($"Recaudacion total: {recaudacion}€");
}

