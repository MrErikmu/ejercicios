namespace ROCK_Band.Models;

public class GuitarristaBanda: Musico, IGuitarrista
{
    public override void Afinarinstrumento()
    {
        Console.WriteLine($"{Nombre} prepara las cuerdas de su guitarra");   
    }
    public override void Ensayar()
    {
        Console.WriteLine($"{Nombre} ensaya rasgando un par de acordes"); 
    }
    public void TocarGuitarra()
    {
        Console.WriteLine($"{Nombre} toca con tremendo estilo ");   
        Console.WriteLine("Las grupis se vuelven locas ");
    }
    public void Solo()
    {
        Console.WriteLine($"{Nombre} toca tremendo solo");
    }
    public void Corea()
    {
        Console.WriteLine($"{Nombre} hace unos coros brutales");
    }  
}