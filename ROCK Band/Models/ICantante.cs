namespace ROCK_Band.Models;

public interface ICantante
{
    public void Cantar()
    {
        Console.WriteLine("El Cantante canta con unos agudos brutales");
    }
    public void TocarRitmo()
    {
        Console.WriteLine("El Cantante toca la guitarra ritmicamente");
    }
}