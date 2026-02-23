using ConsoleApp1.Models;

namespace ConsoleApp1.Validators;

public class LibroValidator : ILibroValidator
{
    public Libro Validate(Libro item)
    {
            // --- 1. Validación del Título ---
            if (string.IsNullOrWhiteSpace(item.Titulo)) {
                throw new ArgumentException("El Titulo no puede estar vacío.", nameof(item.Titulo));
            }
            
            // --- 2. Validación del Autor ---
            if (string.IsNullOrWhiteSpace(item.Autor)) {
                throw new ArgumentException("El Director no puede estar vacío.", nameof(item.Autor));
            }
            // --- 3. Validación de la Editorial ---
            if (string.IsNullOrWhiteSpace(item.Editorial)) {
                throw new ArgumentException("El Genero no puede estar vacío.", nameof(item.Editorial));
            }
            return item;
    }
    
}
