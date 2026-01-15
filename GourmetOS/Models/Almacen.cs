namespace GourmetOS.Models;

public class Almacen
{
    public Almacen(List<Estante> estante)
    {
        Estante = estante;
    }

    public List<Estante> Estante { get; set; }
}