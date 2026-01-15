namespace GourmetOS.Models;

public class Estante
{
    public Estante(string letras, int tamaño, Ingrediente ingrediente)
    {
        Tamaño = tamaño;
        Ingrediente = ingrediente;
        this.Letras = letras;
    }

    public string Letras { get; set; }
    public int Tamaño { get; set; }
    Ingrediente Ingrediente{ get; set; }
}