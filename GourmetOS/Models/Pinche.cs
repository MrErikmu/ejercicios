namespace GourmetOS.Models;

public class Pinche:Persona
{
    public required string Nacimiento { get; set; }

    public void RetirarIngrediente(Ingrediente ingrediente,int cantidad)
    {
        Console.WriteLine($"Retiradas {cantidad} unidades de {ingrediente.Nombre}");
        ingrediente.Numero -= cantidad;
        Console.WriteLine($"Hay {ingrediente.Numero} unidades de ¨{ingrediente.Nombre}");
    }
}