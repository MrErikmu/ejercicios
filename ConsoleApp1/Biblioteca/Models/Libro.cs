namespace ConsoleApp1.Models;

public class Libro:Ficha
{
    public Libro(string autor, string editorial) 
    {
        Autor = autor;
        Editorial = editorial;
    }
    
    public string Autor { get; init; }
    public string Editorial { get; init; }
}