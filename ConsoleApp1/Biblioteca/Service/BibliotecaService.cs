using ConsoleApp1.Models;
using ConsoleApp1.Models.Lista;
using ConsoleApp1.repository;
using ConsoleApp1.Validators;
using ConsoleApp1.Factory;
namespace ConsoleApp1.Service;

public class BibliotecaService
( 
    IDvdRepository dvdRepository, 
    IDvdValidator dvdValidator,
    IRevistaRepository revistaRepository,
    IRevistaValidator revistaValidator,
    ILibroRepository libroRepository,
    ILibroValidator libroValidator
    ): IBibliotecaService
{
    /* variables para obtener el total de cada item
    public int Totaldvd { get; } = dvdRepository.ObtenerTotal();
    public int Totallibros { get; } = libroRepository.ObtenerTotal();
    public int Totalrevsta { get; } = revistaRepository.ObtenerTotal();
    */
    public Lista<Ficha> Listatotal = Factory.Factory.LLenarLista();
    
    public void AñadirDvd(Dvd item)
    {
        dvdValidator.Validate(item);
        dvdRepository.Añadir(item);
    }

    public void AñadirLibro(Libro item)
    {
        libroValidator.Validate(item);
        libroRepository.Añadir(item);
    }

    public void AñadirRevista(Revista item)
    {
        revistaValidator.Validate(item);
        revistaRepository.Añadir(item);
    }
    
    /*public void AñadirItem(Tipo item, Ficha ficha) Intento de implementar el agregar en 1 sola funcion
    {
        if (item==Tipo.Dvd)
        {
            dvdRepository.Añadir(dvd);
        }
        if (item==Tipo.Revista)
        {
            revistaRepository.Añadir(id);
        }
        if (item==Tipo.Libro)
        {
            libroRepository.Añadir(id);
        } 
    }*/
   
    public void EliminarDvd(int id) { dvdRepository.Eliminar(id); }
    public void EliminarRevista(int id){revistaRepository.Eliminar(id);}
    public void EliminarLibro(int id){libroRepository.Eliminar(id);}
    public void ListarBiblioteca()
    {
        foreach (Ficha item in revistaRepository.ObtenerListado())
        {
            Listatotal.AgregarInicio(item);
        }
        foreach (Ficha item in dvdRepository.ObtenerListado())
        {
            Listatotal.AgregarInicio(item);
        }
        foreach (Ficha item in libroRepository.ObtenerListado())
        {
            Listatotal.AgregarInicio(item);
        }
        Listatotal.Mostrar();
    }

    public Dvd? BuscarDvd(int id)
    {
        var buscado = dvdRepository.Obtener(id);
        if (buscado==null)
        {
          Console.WriteLine("Dvd no encontrado");
          return null;
        }
        return buscado;
    }

    public Libro? BuscarLibro(int id)
    {
        var buscado = libroRepository.Obtener(id);
        if (buscado==null)
        {
            Console.WriteLine("Libro no encontrado");
            return null;
        }
        return buscado;
    }

    public Revista? BuscarRevista(int id)
    {
        var buscado = revistaRepository.Obtener(id);
        if (buscado==null)
        {
            Console.WriteLine("revista no encontrada");
            return null;
        }
        return buscado;
    }
}