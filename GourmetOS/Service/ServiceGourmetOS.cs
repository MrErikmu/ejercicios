using GourmetOS.Models;

namespace GourmetOS.Service;

public class ServiceGourmetOs
{
    public bool ComprobarChef(Chef cocinero, Plato orden)
    {
        Console.WriteLine("Comprobando si el chef puede hacer el plato");
            foreach (var receta in cocinero.Recetas)
            {
                if (orden.Nombre==receta.Nombre)
                {
                    return true;
                }
            }
            return false;
    }
}