using ConsoleApp1.Models;

namespace ConsoleApp1.Service;

public interface IBibliotecaService 
 
{
    //public AñadirItem(Tipo item, Ficha ficha);
    public void AñadirDvd(Dvd item);
    public void AñadirLibro(Libro item);
    public void AñadirRevista(Revista item);
    public void EliminarDvd(int id);
    public void EliminarRevista(int id);
    public void EliminarLibro(int id);
    public void ListarBiblioteca();
}