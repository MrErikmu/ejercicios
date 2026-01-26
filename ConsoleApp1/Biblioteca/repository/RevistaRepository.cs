using ConsoleApp1.Models;
using ConsoleApp1.Models.Lista;

namespace ConsoleApp1.repository;

public class RevistaRepository
{
    private readonly ILista<Revista> _lista = new Lista<Revista>();
    private static RevistaRepository? _instance;
    
    public Revista? Añadir(Revista entity)
    {
        var nuevo = entity;
        if (Existe(entity))
        {
            return null;
        }
        _lista.AgregarFinal(entity);
        return entity;
    }
    public int ObtenerTotal()
    {
        var total =_lista.Contar();
        return total;
    }
    public int ObtenerIndice(int id)
    {
        for (var i = 0; i < _lista.Contar(); i++)
            if (_lista.Obtener(i).Id == id)
                return i;
        return -1;
    }
    
    public Revista Obtener(int id)
    {
        var revista = _lista.Obtener(id);
        return revista;
    }
    
    public Revista? Eliminar(int id)
    {
        var indice = ObtenerIndice(id);
        if (indice == -1)
        {
            Console.WriteLine($"El Dvd con ID{id} no existe ");
            return null;
        }
        var eliminado = Obtener(indice);
        _lista.EliminarEn(indice);
        Console.WriteLine($"La revista con ID: {id} y nombre: {eliminado.Titulo} ha sido eliminado con exito");
        return eliminado;
    }

    public ILista<Revista> ObtenerListado()
    {
        return _lista;
    }
    
    private bool Existe(Revista dvd) {
        foreach (var disco in _lista)
            if (disco.Equals(dvd))
                return true;
        return false;
    }
    public static RevistaRepository GetInstance() {
        return _instance ??= new RevistaRepository();
    }
}