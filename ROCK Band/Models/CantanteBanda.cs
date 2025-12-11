namespace ROCK_Band.Models;

public class CantanteBanda : Musico, ICantante
{
    public override void Afinarinstrumento()
    {
        Console.WriteLine($"{Nombre} prepara sus cuerdas vocales con ejercicios");   
    }
    public override void Ensayar()
    {
        Console.WriteLine($"{Nombre} ensaya entonando diferentes notas"); 
    }
    public void Cantar()
    {
        Console.WriteLine($"{Nombre} canta con unos agudos brutales");
    }
    public void TocarRitmo()
    {
        Console.WriteLine($"{Nombre} toca la guitarra ritmicamente");
    }
}