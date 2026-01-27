using System.Collections;

namespace ConsoleApp1.Models.Lista;

public class Lista<T> : ILista<T>
{
    private Nodo<T>? _cabeza;
    private int _contador;
    
   public void AgregarInicio(T valor) {
        // Creamos un nuevo nodo
        var nuevoNodo = new Nodo<T>(valor);

        // Si la lista está vacía, el nuevo nodo será la cabeza
        if (_cabeza == null) {
            _cabeza = nuevoNodo;
        }
        // Si no está vacía, el nuevo nodo apunta a la cabeza actual y luego se actualiza la cabeza
        else {
            nuevoNodo.Siguiente = _cabeza;
            _cabeza = nuevoNodo;
        }

        // Incrementamos el contador
        _contador++;
    }

    public void AgregarFinal(T valor) {
        // Crear un nuevo nodo
        var nuevoNodo = new Nodo<T>(valor);

        // Si la lista está vacía, el nuevo nodo será la cabeza
        if (_cabeza == null) {
            _cabeza = nuevoNodo;
        }
        else {
            // Si no está vacía, recorremos hasta el final de la lista
            var actual = _cabeza;
            while (actual.Siguiente != null)
                actual = actual.Siguiente;
            // El último nodo apunta al nuevo nodo
            actual.Siguiente = nuevoNodo;
        }

        // Incrementamos el contador
        _contador++;
    }

    public void AgregarEn(T valor, int indice) {
        // Crear un nuevo nodo
        var nuevoNodo = new Nodo<T>(valor);
        // Validar el índice
        if (indice < 0 || indice > _contador)
            throw new ArgumentOutOfRangeException(nameof(indice), "Índice fuera de rango");
        // Si el índice es 0, agregamos al inicio
        if (indice == 0) {
            AgregarInicio(valor);
        }
        else {
            // Si el índice es mayor que 0, recorremos hasta el índice deseado
            var actual = _cabeza;
            for (var i = 0; i < indice - 1; i++)
                actual = actual?.Siguiente;
            // Creamos un nuevo nodo y lo conectamos con el actual y el siguiente
            nuevoNodo.Siguiente = actual?.Siguiente;
            actual?.Siguiente = nuevoNodo;
            // Incrementamos el contador
            _contador++;
        }
    }

    public void EliminarInicio() {
        // Verificamos si la lista está vacía
        if (_cabeza == null)
            throw new InvalidOperationException("La lista está vacía");
        // Actualizamos la cabeza para que apunte al siguiente nodo
        _cabeza = _cabeza.Siguiente;
        // Decrementamos el contador
        _contador--;
    }

    public void EliminarFinal() {
        // Verificamos si la lista está vacía
        if (_cabeza == null)
            throw new InvalidOperationException("La lista está vacía");
        // Si solo hay un nodo, eliminamos la cabeza
        if (_cabeza.Siguiente == null) {
            _cabeza = null;
        }
        else {
            // Recorremos hasta el penúltimo nodo
            var actual = _cabeza;
            
            for (var i = 0; i < _contador - 2; i++)
                actual = actual?.Siguiente;
            actual?.Siguiente = null;
        }
        _contador--;
    }

    public void EliminarEn(int indice) {
        // Validar el índice
        if (indice < 0 || indice >= _contador)
            throw new ArgumentOutOfRangeException(nameof(indice), "Índice fuera de rango");
        // Si el índice es 0, eliminamos el inicio
        if (indice == 0) {
            EliminarInicio();
        }
        else {
            var actual = _cabeza;
            for (var i = 0; i < indice - 1; i++)
                actual = actual?.Siguiente;
            actual?.Siguiente = actual.Siguiente?.Siguiente;
            _contador--;
        }
    }

    public T ObtenerPrimero() {
        if (_cabeza == null)
            throw new InvalidOperationException("La lista está vacía");
        return _cabeza.Valor;
    }

    public T ObtenerUltimo() {
        if (_cabeza == null)
            throw new InvalidOperationException("La lista está vacía");
        var actual = _cabeza;
        for (var i = 0; i < _contador - 1; i++)
            actual = actual?.Siguiente;
        return actual!.Valor;
    }

    public T Obtener(int indice) {
        if (indice < 0 || indice >= _contador)
            throw new ArgumentOutOfRangeException(nameof(indice), "Índice fuera de rango");
        var actual = _cabeza;
        for (var i = 0; i < indice; i++)
            actual = actual?.Siguiente;
        return actual!.Valor;
    }

    public bool Existe(T valor) {
        var actual = _cabeza;
        while (actual != null) {
            if (actual.Valor!.Equals(valor))
                return true;
            actual = actual.Siguiente;
        }
        return false;
    }
    public int Contar() {
        return _contador;
    }

    public bool EstaVacia() {
        return _contador == 0;
    }

    public void Limpiar() {
        _cabeza = null;
        _contador = 0;
    }

    public void Mostrar() {
        var actual = _cabeza;
        while (actual != null) {
            Console.Write(actual.Valor!.ToString());
            if (actual.Siguiente != null)
                Console.Write(" -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }

    public IEnumerator GetEnumerator()
    {
        var actual = _cabeza;
        while (actual != null) 
        {
            yield return actual.Valor;
            actual = actual.Siguiente;
        }
    }
}