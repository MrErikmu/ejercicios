namespace ConsoleApp1.Models;

public class Libro(string autor, string editorial, string titulo) : Ficha(titulo)

{
public string Autor { get; } = autor;
public string Editorial { get;} = editorial;
public override string ToString()
{
    return $"Titulo: {Titulo} Autor: {Autor} Editorial: {Editorial}";
}
}