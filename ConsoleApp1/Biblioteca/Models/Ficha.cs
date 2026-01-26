namespace ConsoleApp1.Models;

public abstract class Ficha(string titulo)
{
    private static int _id = 0;
    public int Id { get; } = _id++;
    public required string Titulo { get; init; } = titulo;

}