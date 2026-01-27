using ConsoleApp1.Models;
using ConsoleApp1.Models.Lista;

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