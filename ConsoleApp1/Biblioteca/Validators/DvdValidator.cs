using ConsoleApp1.Models;

namespace ConsoleApp1.Validators;

public class DvdValidator : IDvdValidator
{
    public Dvd Validate(Dvd item)
    {
        // --- 1. Validación del Título ---
        if (string.IsNullOrWhiteSpace(item.Titulo)) {
            throw new ArgumentException("El Titulo no puede estar vacío.", nameof(item.Titulo));
        }
        // --- 2. Validación del año---
        if (item.Año<1895) {
            throw new ArgumentException("El año no puede ser menor a 1895.", nameof(item.Año));
        }

        // --- 3. Validación del Director ---
        if (string.IsNullOrWhiteSpace(item.Director)) {
            throw new ArgumentException("El Director no puede estar vacío.", nameof(item.Director));
        }
        // --- 3. Validación del Género ---
        if (string.IsNullOrWhiteSpace(item.Genero)) {
            throw new ArgumentException("El Genero no puede estar vacío.", nameof(item.Genero));
        }
        return item;
    }
    
}
