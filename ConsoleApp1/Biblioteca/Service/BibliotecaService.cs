using ConsoleApp1.Models;
using ConsoleApp1.Models.Lista;
using ConsoleApp1.repository;
using ConsoleApp1.Validators;

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
    public int Totaldvd { get; } = dvdRepository.ObtenerTotal();
    public int Totallibros { get; } = libroRepository.ObtenerTotal();
    public int Totalrevsta { get; } = revistaRepository.ObtenerTotal();
    
    public void AñadirDvd(Dvd item)
    {
        dvdRepository.Añadir(item);
    }

    public void AñadirLibro(Libro item)
    {
        libroRepository.Añadir(item);
    }

    public void AñadirRevista(Revista item)
    {
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
      var listatotal = new Lista<Ficha>();
      foreach (Ficha item in revistaRepository.ObtenerListado())
      {
          listatotal.AgregarInicio(item);
      }
      foreach (Ficha item in dvdRepository.ObtenerListado())
      {
          listatotal.AgregarInicio(item);
      }
      foreach (Ficha item in libroRepository.ObtenerListado())
      {
          listatotal.AgregarInicio(item);
      }
      listatotal.Mostrar();
    }
}