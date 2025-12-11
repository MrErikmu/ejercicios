namespace ROCK_Band.Models;

public class Musico
{
   public required string Nombre { get; init; }
   public required int Tiempobanda { get; init; } 
   
   public virtual void Ensayar()
   {
      Console.WriteLine("Musico ensaya con muchas ganas");   
   }
   public virtual void Afinarinstrumento()
   {
      Console.WriteLine("El musico afina su instrumento");   
   }
   
} 
