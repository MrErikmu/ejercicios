namespace ROCK_Band.Models;

public class BateriaBanda: Musico, IBateria
{
    public override void Afinarinstrumento()
    {
        Console.WriteLine($"{Nombre} afloja los tornillos para tener la tension correcta");   
    }
    public override void Ensayar()
    {
        Console.WriteLine($"{Nombre} ensaya golpeando los platos con rapidez"); 
    }
    public void Aporrear()
    {
        Console.WriteLine($"El bateria aporrea los timbales con estilo");   
    }
}