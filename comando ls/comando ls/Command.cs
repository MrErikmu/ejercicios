using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using System.Text;

namespace comando_ls;

public static class Command
{
    public static void ejecutar(string ruta)
    {
        if (!Path.Exists(ruta))
        {
            Console.WriteLine("La ruta introducida no existe");
        }
        else
        {
            Console.WriteLine($"{ruta}");
            Console.Write(ProcesarComando(ruta));
        }
    }

    public static string ProcesarComando(string ruta)
    {
        StringBuilder sb = new StringBuilder();
        var carpetacontenido = Directory.GetFiles(ruta);
        var carpetadirectorios = Directory.GetDirectories(ruta);
        
        string fecha;
        string nombre;
        string? carpetan;
        foreach (var contenido in carpetacontenido)
        {
            nombre = Path.GetFileName(contenido);
            fecha = File.GetLastWriteTime(contenido).ToString(CultureInfo.InvariantCulture);
            sb.AppendLine($"|-> {fecha} {nombre}");
        }
        foreach (var contenido in carpetadirectorios)
        {
            nombre = Path.GetFileName(contenido);
            fecha = File.GetLastWriteTime(contenido).ToString(CultureInfo.InvariantCulture);
            sb.AppendLine($"|-> {fecha} {nombre}");
        }
        return sb.ToString();
    }
}