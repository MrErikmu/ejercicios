namespace GourmetOS.Models;

public class Chef:Persona
{
    public required int Experiencia { get; set; }
    public required List<Plato> Recetas { get; set; }

    public void Cocinar(Plato plato)
    {
        Console.WriteLine($"Marchando 1 {plato.Nombre}");
    }
}