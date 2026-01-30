using ListaDobleEnlazada.Models.Common;

namespace ListaDobleEnlazada.Models.Lista;

public class Lista<T>:ILista<T>
{
    //Nuestro puntero para siguiente -->[]
    private Node<T>? _head;
    // Nuestro puntero para anterior  []<--
    private Node<T>? _tail;
    // Y el contador para movernos por la lista.
    private int _total; 
    public void ShowAll()
    {
       
    }

    public T ShowItem(int id)
    {
        throw new NotImplementedException();
    }

    public void AddFist(T item)
    {
        var node = new Node<T>(item);
        if (_head == null)
        {
            _head = node;
            _tail = null;
        }
        else
        {
            node.Last = _tail;
            _tail = node;
            node.Next = _head;
            _head = node;
        }
        _total++;
    }

    public void AddLast(T item)
    {
        var node = new Node<T>(item);
        if (_head == null)
        {
            _head = node;
            _tail = null;
        }
        else
        {
            var current = _head;
            while (current.Next != null)
                current = current.Next;
            current.Next = null;
        }
    }

    public void AddAt(T item, int index)
    {
        throw new NotImplementedException();
    }

    public void DeleteFist(int index)
    {
        throw new NotImplementedException();
    }

    public void DeleteLast()
    {
        throw new NotImplementedException();
    }

    public void DeleteAt(int id)
    {
        throw new NotImplementedException();
    }

    public void ClearAll()
    {
        throw new NotImplementedException();
    }

    public bool Exist(T item)
    {
        throw new NotImplementedException();
    }

    public bool IsEmpty()
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        throw new NotImplementedException();
    }
}