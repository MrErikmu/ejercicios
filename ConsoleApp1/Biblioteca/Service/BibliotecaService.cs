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

    public void LlenarRepositorio()
    {
        foreach (Ficha item in Listatotal)
        {
            if (item is Dvd d)
            {
                AñadirDvd(d); 
            }

            if (item is Revista r)
            {
                 AñadirRevista(r);
            }
            if (item is Libro l)
            {
                AñadirLibro(l);
            }
        }
       
    }
    
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
    public void EliminarDvd(int id) { dvdRepository.Eliminar(id); }
    public void EliminarRevista(int id){revistaRepository.Eliminar(id);}
    public void EliminarLibro(int id){libroRepository.Eliminar(id);}
    public void ListarBiblioteca()
    {
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