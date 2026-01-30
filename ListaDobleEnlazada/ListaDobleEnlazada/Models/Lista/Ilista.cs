namespace ListaDobleEnlazada.Models.Lista;

public interface ILista<T>
{
   void ShowAll();
   T ShowItem(int id);
   void AddFist(T item);
   void AddLast(T item);
   void AddAt(T item, int index);
   void DeleteFist(int index);
   void DeleteLast();
   void DeleteAt(int id);
   void ClearAll();
   bool Exist(T item);
   bool IsEmpty();
   int Count();
}