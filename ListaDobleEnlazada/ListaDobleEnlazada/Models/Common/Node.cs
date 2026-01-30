namespace ListaDobleEnlazada.Models.Common;

public class Node<T>(T item)
{
    // Contenido dentro del nodo
    public T Item { get; set; } = item;
    //Puntero hacia el siguiente nodo -->[]
    public Node<T>? Next { get; set;}= null;
    //Puntero hacia el nodo anterior []<--
    public Node<T>? Last { get; set; } = null;
}
