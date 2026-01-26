using ConsoleApp1.Models;

namespace ConsoleApp1.repository.Common;

public interface ICrudRep<TKey, TEntity> where TEntity: class
{
    TEntity? Añadir(TEntity entity);
    int ObtenerIndice(TKey id);
    int ObtenerTotal();
    TEntity? Obtener(TKey id);
    TEntity? Eliminar(int id);
    ILista<TEntity> ObtenerListado();
}