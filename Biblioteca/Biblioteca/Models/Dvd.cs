namespace ConsoleApp1.Models;

public class Dvd(string director, int año, string tipo, string titulo) : Ficha(titulo)

{
    public string Director { get;} = director;
    public int Año { get;} = año;
    public string Genero { get;} = tipo;
    public override string ToString()
    {

        return $"Titulo: {Titulo} Director: {Director} Año: {Año} Genero: {Genero}";
    }
}