namespace ConsoleApp1.Models;

public class Nodo<T>(T valor)
{
    public T Valor { get; set; } = valor; 
    public Nodo<T>? Siguiente { get; set; } = null;
    //public Nodo<T>? Anterior { get; set; } = null;

    public override string ToString() 
    { 
        return $"Nodo({Valor})";
    }
}