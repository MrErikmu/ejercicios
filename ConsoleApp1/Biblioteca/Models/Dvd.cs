namespace ConsoleApp1.Models;

public class Dvd(string director, int año, string tipo) : Ficha
{
    public string Director { get; init; } = director;
    public int Año { get; init; } = año;
    public string Genero { get; init; } = tipo;
    
}