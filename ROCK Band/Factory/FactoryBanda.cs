using ROCK_Band.Models;

namespace ROCK_Band.Factory;

public class FactoryBanda
{
    private static readonly string[] Nombres = { "Jonny Melabo", "Giorno Giovanna ", "Jonathan Joestar", "Eren Jagger","Mona Megistus","Juan Profundo", "Ezio Auditore" };
    

    public static Musico CrearMusicoRandom(TipoMusico banda)
    {
        var indice = Random.Shared.Next(0, 7);
        var tiempo = Random.Shared.Next(1, 10);
        switch (banda)
        {
            case TipoMusico.Cantante:
            {
                var randomCantante = new CantanteBanda() { Nombre = Nombres[indice], Tiempobanda = tiempo };
                return randomCantante;
            }
            case TipoMusico.Bateria:
            {
                var randomBateria = new BateriaBanda() { Nombre = Nombres[indice], Tiempobanda = tiempo };
                return randomBateria;
            }
            case TipoMusico.Guitarrista:
            {
                var randomGuitarra = new GuitarristaBanda() { Nombre = Nombres[indice], Tiempobanda = tiempo };
                return randomGuitarra;
            }
                default: 
                var randomcbajista = new BajistaBanda() { Nombre = Nombres[indice], Tiempobanda = tiempo };
                return randomcbajista;
        }
    }
    
    public static BajistaBanda CrearBajistaRandom()
    {
        var indice = Random.Shared.Next(0, 7);
        var tiempo = Random.Shared.Next(1, 10);
        var randommiembro = new BajistaBanda() { Nombre = Nombres[indice], Tiempobanda = tiempo };
        return randommiembro;
    }
    public static BateriaBanda CrearBateriaRandom()
    {
        var indice = Random.Shared.Next(0, 7);
        var tiempo = Random.Shared.Next(1, 10);
        var randommiembro = new BateriaBanda() { Nombre = Nombres[indice], Tiempobanda = tiempo };
        return randommiembro;
    }

    public static CantanteBanda CrearCantanteRandom()
    {
        var indice = Random.Shared.Next(0, 7);
        var tiempo = Random.Shared.Next(1, 10);
        var randommiembro = new CantanteBanda() { Nombre = Nombres[indice], Tiempobanda = tiempo };
        return randommiembro;
    }
    public static GuitarristaBanda CrearGuitarristaRandom()
    {
        var indice = Random.Shared.Next(0, 7);
        var tiempo = Random.Shared.Next(1, 10);
        var randommiembro = new GuitarristaBanda() { Nombre = Nombres[indice], Tiempobanda = tiempo };
        return randommiembro;
    }
    
}
public enum TipoMusico
    {
        Bajista, Cantante ,Bateria,Guitarrista 
    }
