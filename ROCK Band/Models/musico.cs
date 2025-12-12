namespace ROCK_Band.Models;

public abstract class Musico
{
   public required string Nombre { get; init; }
   public required int Tiempobanda { get; init; } 
   
   public abstract void Ensayar();

   public abstract void Afinarinstrumento();
} 
