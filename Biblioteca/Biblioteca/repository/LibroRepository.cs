using ConsoleApp1.Models;
using ConsoleApp1.Models.Lista;

namespace ConsoleApp1.repository;

public class LibroRepository:ILibroRepository
{
    private readonly ILista<Libro> _lista = new Lista<Libro>();
    private static LibroRepository? _instance;
    
    public Libro? Añadir(Libro entity)
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
    
    public Libro Obtener(int id)//funcion auxiliar que solo se usa en eliminar
    {
        var dvd = _lista.Obtener(id);
        return dvd;
    }
    
    public Libro? Eliminar(int id)
    {
        var indice = ObtenerIndice(id);
        if (indice == -1)
        {
            Console.WriteLine($"El Dvd con ID{id} no existe ");
            return null;
        }
        var eliminado = Obtener(indice);
        _lista.EliminarEn(indice);
        Console.WriteLine($"El Libro con ID{id} y nombre {eliminado.Titulo} ha sido eliminado con exito");
        return eliminado;
    }

    public ILista<Libro> ObtenerListado()
    {
        return _lista;
    }
    public int ObtenerTotal()
    {
        var total =_lista.Contar();
        return total;
    }
    private bool Existe(Libro dvd) {
        foreach (var disco in _lista)
            if (disco.Equals(dvd))
                return true;
        return false;
    }
    public static LibroRepository GetInstance() {
        return _instance ??= new LibroRepository();
    }
}