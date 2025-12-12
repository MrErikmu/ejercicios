using System.Text;
using ROCK_Band.Factory;
using ROCK_Band.Models;

Console.Title = "Banda de Rock";
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

Musico bateria = FactoryBanda.CrearMusicoRandom(TipoMusico.Bateria);
Musico bajista = FactoryBanda.CrearMusicoRandom(TipoMusico.Bajista);
Musico guitarrista1 = FactoryBanda.CrearMusicoRandom(TipoMusico.Guitarrista);
Musico guitarrista2 = FactoryBanda.CrearMusicoRandom(TipoMusico.Guitarrista);
Musico cantante = FactoryBanda.CrearMusicoRandom(TipoMusico.Cantante);
Musico[] bandaRock= {bateria,bajista, guitarrista1,guitarrista2,cantante };

EmpezarEnsayo(bandaRock);
ListarMiembros(bandaRock);

Console.ReadKey();

void ListarMiembros(Musico[] musicos)
{
    Console.WriteLine("Mostrando a los musicos de la banda");
    foreach (Musico m in musicos)
    {
        Console.WriteLine($"{m.Nombre} lleva {m.Tiempobanda} años en la banda");  
    }
}
void EmpezarEnsayo(Musico[] banda)
{
    Console.WriteLine("Empezando ensayo de la banda");
    foreach (Musico m in banda)
    {
        switch (m)
        {
            case BajistaBanda bajistaBanda:
            {
                var baj = bajistaBanda;
                baj.Afinarinstrumento();
                break;
            }
            case GuitarristaBanda guitarristaBanda:
            {
                var guit = guitarristaBanda;
                guit.Afinarinstrumento();
                Console.WriteLine("");
                guit.Ensayar();
                Console.WriteLine("");
                guit.Corea();
                Console.WriteLine("");
                guit.Solo();
                Console.WriteLine("");
                break;
            }
            case BateriaBanda bateriaBanda:
            {
                var bat = bateriaBanda;
                bat.Afinarinstrumento();
                Console.WriteLine("");
                bat.Ensayar();
                Console.WriteLine("");
                bat.Aporrear();
                Console.WriteLine("");
                break;
            }
            case CantanteBanda cantanteBanda:
            {
                var cant = cantanteBanda;
                cant.Afinarinstrumento();
                Console.WriteLine("");
                cant.Ensayar();
                Console.WriteLine("");
                cant.Cantar();
                Console.WriteLine("");
                cant.TocarRitmo();
                Console.WriteLine("");
                break;
            }
        }
    }
}

