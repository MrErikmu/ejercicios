namespace ROCK_Band.Models;

public interface IBajista
{
    public void TocarBajo()
    {
        Console.WriteLine("El bajista toca con tremendo estilo ");   
        Console.WriteLine("Fuck Yeah ");
    }
    public void Slap()
    {
        Console.WriteLine("El bajista golpea las cuerdas con soltura"); 
        Console.WriteLine("Tremendo Slap Bro");   
    }
}