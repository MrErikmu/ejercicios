namespace ROCK_Band.Models;

public class BajistaBanda: Musico, IBajista
{
    public override void Afinarinstrumento()
    {
        Console.WriteLine($" {Nombre} afina su bajo");   
    }
    public override void Ensayar()
    {
        Console.WriteLine($" {Nombre} ensaya como un demonio "); 
    }

    public void TocarBajo()
    {
        Console.WriteLine($" {Nombre} toca con tremendo estilo ");   
        Console.WriteLine("Fuck Yeah ");
    }
    public void Slap()
    {
        Console.WriteLine($" {Nombre} golpea las cuerdas con soltura"); 
        Console.WriteLine("Tremendo Slap Bro");   
    }
}