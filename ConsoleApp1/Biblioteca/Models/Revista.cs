namespace ConsoleApp1.Models;

public class Revista: Ficha
{
    public Revista(int año, int numero)
    {
        AñoP = año;
        Numero = numero;
    }
    // Usar init porque son records
    public int AñoP { get; init; }
    public int Numero { get; init; }
}