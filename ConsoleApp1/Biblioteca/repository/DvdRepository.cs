using ConsoleApp1.Models;
using ConsoleApp1.Models.Lista;
using ConsoleApp1.repository.Common;

namespace ConsoleApp1.repository;

public class DvdRepository:IDvdRepository,ICrudRep<int, Dvd>
{
    private readonly ILista<Dvd> _lista = new Lista<Dvd>();
    private static DvdRepository? _instance;
    
    public Dvd? Añadir(Dvd entity)
    {
        var nuevo = entity;
        if (Existe(entity))
        {
            return null;
        }
        _lista.AgregarFinal(entity);
        return entity;
    }

    public int ObtenerIndice(int id)
    {
        for (var i = 0; i < _lista.Contar(); i++)
            if (_lista.Obtener(i).Id == id)
                return i;
        return -1;
    }
    
    public Dvd Obtener(int id)
    {
        var dvd = _lista.Obtener(id);
        return dvd;
    }


    public Dvd? Eliminar(int id)
    {
        var indice = ObtenerIndice(id);
        if (indice == -1)
        {
            Console.WriteLine($"El Dvd con ID{id} no existe ");
            return null;
        }
        var eliminado = Obtener(indice);
        _lista.EliminarEn(indice);
        Console.WriteLine($"El Dvd con ID{id} y nombre {eliminado.Titulo} ha sido eliminado con exito");
        return eliminado;
    }

    public ILista<Dvd> ObtenerListado()
    {
        return _lista;
    }

    public int ObtenerTotal()
    {
        var total =_lista.Contar();
        return total;
    }
    private bool Existe(Dvd dvd) {
        foreach (var disco in _lista)
            if (disco.Equals(dvd))
                return true;
        return false;
    }
    public static DvdRepository GetInstance() {
        return _instance ??= new DvdRepository();
    }
}