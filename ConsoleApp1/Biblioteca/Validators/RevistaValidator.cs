using ConsoleApp1.Models;

namespace ConsoleApp1.Validators;

public class RevistaValidator : IRevistaValidator
{
    public Revista Validate(Revista item)
    {
        // --- 1. Validación del Título ---
        if (string.IsNullOrWhiteSpace(item.Titulo)) {
            throw new ArgumentException("El Titulo no puede estar vacío.", nameof(item.Titulo));
        }
            
        // --- 2. Validación del Año de publicacion ---
        if (item.AñoP<1663) {
            throw new ArgumentException("El año de publicacion no puede ser menor a 1663.", nameof(item.AñoP));
        }
        // --- 3. Validación del Número de Publicacion ---
        
        if (int.IsNegative(item.Numero)) {
            throw new ArgumentException("El Numero de Publicacion no puede ser negativo.", nameof(item.Numero));
        }
        return item;
    }
}
