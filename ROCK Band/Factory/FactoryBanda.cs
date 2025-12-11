using ROCK_Band.Models;

namespace ROCK_Band.Factory;

public class FactoryBanda
{
    private static string[] _nombres = { "Jonny Melabo", "Giorno Giovanna ", "Jonathan Joestar", "Eren Jagger","Mona Megistus","Juan Profundo", "Ezio Auditore" };
    

    /*public static Musico CrearMusicoRandom(TipoBanda banda)
    {
        var indice = Random.Shared.Next(0, 7);
        var tiempo = Random.Shared.Next(1, 10);
        switch (banda)
        {
            case TipoBanda.Cantante:
            {
                var randomCantante = new Musico() { Nombre = _nombres[indice], Tiempobanda = tiempo };
                return randomCantante;
            }
            case TipoBanda.Bateria:
            {
                var randomBateria = new Musico() { Nombre = _nombres[indice], Tiempobanda = tiempo };
                return randomBateria;
            }
            case TipoBanda.Guitarrista:
            {
                var randomGuitarra = new Musico() { Nombre = _nombres[indice], Tiempobanda = tiempo };
                return randomGuitarra;
            }
            case TipoBanda.Bajista:
                var randomcbajista = new Musico() { Nombre = _nombres[indice], Tiempobanda = tiempo };
                return randomcbajista;
                break;
        }
        throw new InvalidOperationException("No existe ese tipo de Musico");
    }*/
    
    public static BajistaBanda CrearBajistaRandom()
    {
        var indice = Random.Shared.Next(0, 7);
        var tiempo = Random.Shared.Next(1, 10);
        var randommiembro = new BajistaBanda() { Nombre = _nombres[indice], Tiempobanda = tiempo };
        return randommiembro;
    }
    public static BateriaBanda CrearBateriaRandom()
    {
        var indice = Random.Shared.Next(0, 7);
        var tiempo = Random.Shared.Next(1, 10);
        var randommiembro = new BateriaBanda() { Nombre = _nombres[indice], Tiempobanda = tiempo };
        return randommiembro;
    }

    public static CantanteBanda CrearCantanteRandom()
    {
        var indice = Random.Shared.Next(0, 7);
        var tiempo = Random.Shared.Next(1, 10);
        var randommiembro = new CantanteBanda() { Nombre = _nombres[indice], Tiempobanda = tiempo };
        return randommiembro;
    }
    public static GuitarristaBanda CrearGuitarristaRandom()
    {
        var indice = Random.Shared.Next(0, 7);
        var tiempo = Random.Shared.Next(1, 10);
        var randommiembro = new GuitarristaBanda() { Nombre = _nombres[indice], Tiempobanda = tiempo };
        return randommiembro;
    }
    
}
public enum TipoBanda
    {
        Bajista, Cantante ,Bateria,Guitarrista 
    }
