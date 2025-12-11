namespace ROCK_Band.Models;

public interface IBateria
{
    void Afinarinstrumento()
    {
        Console.WriteLine("El Bateria afloja los tornillos para tener la tension correcta");   
    }
    public void Aporrear()
    {
        Console.WriteLine("El bateria aporrea los timbales con estilo");   
    }
}