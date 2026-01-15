namespace GourmetOS.Models;

public class Plato
{
    public Plato(string nombre, double precio, TipoPlato tipo, Ingrediente ingrediente, string cantidadIngrediente)
    {
        Nombre = nombre;
        Precio = precio;
        Tipo = tipo;
        Ingrediente = ingrediente;
        CantidadIngrediente = cantidadIngrediente;
    }
    
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public TipoPlato Tipo { get; set; }
    Ingrediente Ingrediente{ get; set; }
    public string CantidadIngrediente { get; set; }
}