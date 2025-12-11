namespace ROCK_Band.Models;

public interface IGuitarrista
{
    
    public void TocarGuitarra()
    {
        Console.WriteLine("El guitarrista toca con tremendo estilo ");   
        Console.WriteLine("Las grupis se vuelven locas ");
    }
    public void Solo()
    {
        Console.WriteLine("El guitarrista toca tremendo solo");
    }
    public void Corea()
    {
        Console.WriteLine("El guitarrista hace unos coros brutales");
    }
}