using GourmetOS.Models;
using GourmetOS.Service;

var service= new ServiceGourmetOs();
var merluza = new Ingrediente { Nombre = "Merluza", Descripcion = "Lomo de merluza fresco", Numero = 10 };
var pollo = new Ingrediente { Nombre = "Pollo", Descripcion = "Pechugas de pollo marinadas", Numero = 10 };
var chocolate= new Ingrediente { Nombre = "Chocolate", Descripcion = "Chocolate negro para cocinar", Numero = 30 };
var salmon = new Ingrediente() { Nombre = "Salmon", Descripcion = "Lomo de salmon", Numero = 50 };
var platomerluza = new Plato("Merluza en salsa verde", 18.50, TipoPlato.Primero,ingrediente:merluza,"4 unidades");
var platopollo = new Plato("pollo al curry", 14.60, TipoPlato.Segundo,ingrediente:pollo,"2 unidades");
var platomousse = new Plato("Mousse de Chocolate", 7.50, TipoPlato.Postre,ingrediente:chocolate,"1 unidad");
var platosalmon = new Plato("Salmon al horno", 22, TipoPlato.Primero,ingrediente:salmon,"2 unidades");
var estantea = new Estante("aa", 100, salmon);
var estanteb = new Estante("bb", 50, merluza);
var estantec = new Estante("cc", 20, chocolate);
var estanted = new Estante("dd", 150, pollo);
List<Estante> estantes = new List<Estante> { estantea,estanteb,estantec,estanted };
var almacen= new Almacen(estantes);
List<Plato> platosLucas = new List<Plato> { platopollo, platosalmon};
List<Plato> platosPablo = new List<Plato> { platomerluza, platomousse};
var chef1 = new Chef()
{
    Experiencia = 10, Dni = "571696S", Ss = "330500117939", Nombre = "Lucas Marín Perez",
    Recetas = platosLucas
};
var chef2= new Chef()
{
    Experiencia = 10, Dni = "581696S", Ss = "331191550377", Nombre = "Pablo Delgado Gutiérrez",
    Recetas = platosPablo
};
var pinche1 = new Pinche()
{
    Nacimiento = "17-10-1996", Dni = "561696S", Ss = "188312758846", Nombre = "Álvaro Núñez García",Movil = 701346190
};
Console.WriteLine($"Hay {merluza.Numero} unidades de ¨{merluza.Nombre}");
if (service.ComprobarChef(chef2, platomerluza))
{
    chef2.Cocinar(platomerluza);
    pinche1.RetirarIngrediente(merluza,4);
}else Console.Write("El cocinero no puede preparar ese plato");
