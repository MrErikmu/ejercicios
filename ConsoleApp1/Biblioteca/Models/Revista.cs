namespace ConsoleApp1.Models;

public class Revista(int año, int numero,String titulo): Ficha(titulo)
{
    // Usar init porque son records
    public int AñoP { get; init; } = año;
    public int Numero { get; init; } = numero;
}