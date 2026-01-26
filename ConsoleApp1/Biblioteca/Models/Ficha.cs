namespace ConsoleApp1.Models;

public abstract class Ficha
{
    public int Id { get; init; } = 0;
    public required string Titulo { get; init; }
    
}