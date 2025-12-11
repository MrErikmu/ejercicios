using ROCK_Band.Factory;
using ROCK_Band.Models;

Musico bateria = FactoryBanda.CrearBateriaRandom();
Musico bajista = FactoryBanda.CrearBajistaRandom();
Musico guitarrista1 = FactoryBanda.CrearGuitarristaRandom();
Musico guitarrista2 = FactoryBanda.CrearGuitarristaRandom();
Musico cantante = FactoryBanda.CrearCantanteRandom();
//Musico cantante = FactoryBanda.CrearMusicoRandom(FactoryBanda.TipoBanda.Cantante);
Musico[] bandaRock= {bateria,bajista, guitarrista1,guitarrista2,cantante };
EmpezarEnsayo(bandaRock);
ListarMiembros(bandaRock);

void ListarMiembros(Musico[] musicos)
{
    foreach (Musico m in musicos)
    {
        Console.WriteLine($"{m.Nombre} lleva {m.Tiempobanda} años en la banda");  
    }
}

Console.ReadKey();


void EmpezarEnsayo(Musico[] banda)
{
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

