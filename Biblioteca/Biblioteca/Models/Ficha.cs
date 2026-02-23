namespace ConsoleApp1.Models;

public abstract class Ficha(string titulo)
{
    private static int _id;
    public int Id { get; } = _id++;
    public string Titulo { get; init; } = titulo;

}