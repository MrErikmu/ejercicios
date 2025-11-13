using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using Gestion_de_Parking_LV.structs;
using Serilog;

/*Constantes del sistema.
##########################################################################################
Expresiones regulares: */
var regexMenuoption = new Regex(@"^[0-9]{1}$");
var regexNif = new Regex(@"^[A-Z]{3}[1-9]$");
var regexName = new Regex(@"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]{3,}[A-Za-zñÑáéíóúÁÉÍÓÚ\s]$");
var regexMail = new Regex(@"^[a-zA-Z0-9]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
// FORMATO DE MATRICULA ESPAÑOL LLLLNNN IGNORANDO LA A 
var regexPlate = new Regex(@"^[B-Z]{4}[1-9]{3}$");

const int PARKING_ROWS = 5;
const int PARKING_COL= 2; 
const int START_SIZE= 10;

//Opciones del menu
const int showTeacher = 1;
const int showParkingStatus= 2;
const int showTeacherByPlate = 3;
const int newEntry = 4;
const int delEntry = 5;
const int updEntry= 6;
const int entranceVh= 7; 
const int exitVh= 8; 
const int exit =9;

Console.Clear();
Console.OutputEncoding = Encoding.UTF8;
Console.Title = "Gestion de Parking LV";

Main();
Console.WriteLine("Pulsa una tecla para cerrar el programa");
Console.ReadKey();
return;

void Main()
{
    /* Configuracion de serilog (Pedir aclaraciones)
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug() // Permitir mensajes Debug y superiores
        .WriteTo.Console() // Salida a consola
        .CreateLogger(); // Utilizamos Serilog para el logging*/
    
    string[] parkingLetters = ["A", "B"];
    int option = -1;
    int totalteacher = 0;
    Teacher?[] teacherlist = new Teacher?[START_SIZE];
    Plaza[,] parkinglist = new Plaza[PARKING_ROWS, PARKING_COL];
    var index = -1;
    Plaza ps = new Plaza() { Row = 'A', Col = -1, Status = false };
    var nif = "";
        startteacher(teacherlist, parkinglist, ref totalteacher);
        
        do
        {
            ShowMenu();
            var menuoption = Console.ReadLine().Trim();
            if (!Checkentry(regexMenuoption, menuoption))
            {
                Console.WriteLine("Por favor introduzca una opción del menu en formato de numero entero");
            }
            else
            {
                //Casting seguro gracias a la expresion regular.
                option = int.Parse(menuoption);
                switch (option)
                {
                    case showTeacher:
                        listteacher(teacherlist);
                        break;
                    case showTeacherByPlate:
                        listteacherplate(teacherlist);
                        break;
                    case showParkingStatus:
                        listspot(parkinglist);
                        break;
                    case newEntry:
                        Createentry(teacherlist,ref totalteacher);
                        break;
                    case delEntry:
                        Delentry(teacherlist, ref totalteacher);
                        break;
                    case updEntry:
                        Updentry(teacherlist, index = -1);
                        break;
                    case entranceVh:
                        do
                        {
                            Console.WriteLine("Introduzca NIF para efectuar entrada:");
                            Console.WriteLine("___________________________________");
                            nif = Console.ReadLine().Trim().ToUpper();

                            if (!Checkentry(regexNif, nif))
                            {
                                Console.WriteLine("Nif no valido, Nif debe tener el formato LLLN");
                            }
                        } while (!Checkentry(regexNif, nif));
                        var indexentry = findteachernif(nif, teacherlist);
                        Entrace(parkinglist, teacherlist,indexentry);
                        break;
                    case exitVh:
                        do
                        {
                            Console.WriteLine("Introduzca NIF para efectuar salida:");
                            Console.WriteLine("___________________________________");
                            nif = Console.ReadLine().Trim().ToUpper();

                            if (!Checkentry(regexNif, nif))
                            {
                                Console.WriteLine("Nif no valido, Nif debe tener el formato LLLN");
                            }
                        } while (!Checkentry(regexNif, nif));

                        var indexexit = findteachernif(nif, teacherlist);
                        Exitparking( parkinglist, teacherlist, indexexit);
                        break;
                    case exit:
                        break;
                }
            }
        } while (option != exit);
} 

//------------------------------------------------------------------------------------------------------------------
//FUNCIONES Y PROCEDIMIENTOS
//------------------------------------------------------------------------------------------------------------------

            void ShowMenu()
            {
                Console.WriteLine();
                Console.WriteLine("Gestion de parking del profesorado Luis Vives");
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("Selecciona la opcion que desees introduciendo el numero correspondiente");
                Console.WriteLine();
                Console.WriteLine(showTeacher + " Buscar profesor por NIF");
                Console.WriteLine();
                Console.WriteLine(showParkingStatus + " Mostrar estado del aparcamiento");
                Console.WriteLine();
                Console.WriteLine(showTeacherByPlate + " Buscar profesor por Matricula");
                Console.WriteLine();
                Console.WriteLine(newEntry + " Agregar nuevo profesor");
                Console.WriteLine();
                Console.WriteLine(delEntry + " Eliminar profesor existente");
                Console.WriteLine();
                Console.WriteLine(updEntry + " Eliminar profesor existente");
                Console.WriteLine();
                Console.WriteLine(entranceVh + " Entrada de Vehiculo");
                Console.WriteLine();
                Console.WriteLine(exitVh + " Salida de Vehiculo");
                Console.WriteLine();
                Console.WriteLine(exit + " salir");
                Console.WriteLine("_____________________________________________");
            }

            //funcion para validar entrada de datos 
            bool Checkentry(Regex expresion, string data)
            {
                return expresion.IsMatch(data);
            }

            //Funcion auxiliar de busqueda para listar por nif 
            int findteachernif(string nif, Teacher?[] teacherlist)
            {
                for (var i = 0; i < teacherlist.GetLength(0); i++)
                {
                    if ( teacherlist[i]!.Value.Nif == nif)
                    {
                        return i;

                    }
                }
                return -1;
            }

            //Función auxiliar de busqueda para listar por matrícula.
            int findteacherplate(string plate, Teacher?[] teacherlist)
            {
                for (var i = 0; i < teacherlist.Length; i++)
                {
                    if (teacherlist[i]!.Value.Vh.Plate == plate)
                    {
                        return i;
                    }
                }
                return -1;
            }
            //Funcion para mostrar el parking viendo que huecos estan ocupados y cuales libres
            void listspot(Plaza[,] parkingList)
            {
                for (var i = 0; i < PARKING_ROWS; i++)
                {
                    for (var j = 0; j < PARKING_COL; j++)
                    {
                        var status = parkingList[i, j].Status;
                        if (status)
                        {   
                            Console.Write("[🟢]");
                        }
                        else
                        { 
                            Console.Write("[🔴]"); 
                        }
                    }
                }
                Console.WriteLine();
            }

            //Funcion de busqueda por NIF.
            void listteacher(Teacher?[] list)
            {
                var nif="";
                //Realizamos la comprobacion de integridad del NIF usando su expresión regular.
                do
                {
                    Console.WriteLine("Listado de profesores:");
                    Console.WriteLine("Introduzca el NIF del profesor:");
                    Console.WriteLine("___________________________________");
                    //Hago el casting ignorando nulos porque hasta que no coincida con la expresion regular 
                    // no saldra del bucle. 
                    nif = Console.ReadLine()!.Trim();

                    if (!Checkentry(regexNif, nif))
                    {
                        Console.WriteLine("Nif no valido, Nif debe tener el formato LLLN");
                    }
                } while (!Checkentry(regexNif, nif));

                //Llamamos a la función de busqueda de profesor que nos devuelve el indice del array donde se encuentra 
                // o mostramos un aviso por pantalla en caso de que no exista la entrada. 
                var index = findteachernif(nif, list);
                if (index == -1)
                {
                    Console.WriteLine("No existe profesor con ese nif");
                }
                else
                {
                    Console.WriteLine($"Nif: {list[index]!.Value.Nif}");
                    Console.WriteLine($"Nombre: {list[index]!.Value.Name}");
                    Console.WriteLine($"Mail: {list[index]!.Value.Mail}");
                    Console.WriteLine($"Vehiculo : {list[index]!.Value.Vh.Plate} {list[index]!.Value.Vh.Model}{list[index]!.Value.Vh.Brand}");
                }
            }
            //Busqueda por matricula.

            void listteacherplate(Teacher?[] list)
            {
                var plate = "";
                do
                {
                    Console.WriteLine("Busqueda de profesor por matricula de vehiculo");
                    Console.WriteLine("Introduzca la matricula:");
                    Console.WriteLine("___________________________________");
                    plate = Console.ReadLine()!.Trim();
                } while (!Checkentry(regexPlate, plate));

                var index = findteacherplate(plate, list);
                if (index == -1)
                {
                    Console.WriteLine("No existe profesor que tenga ese vehiculo");
                }
                else
                {
                    Console.WriteLine($"El vehiculo: {list[index]!.Value.Vh.Brand}, {list[index]!.Value.Vh.Model}");
                    Console.WriteLine($"Con matricula : {list[index]!.Value.Vh.Plate}");
                    Console.WriteLine($"Pertenece a : {list[index]!.Value.Name}");
                }
            }

            // Funcion para crear entradas de datos en el array de teacherlist al iniciar programa.
            void startteacher( Teacher?[] teacherlist, Plaza[,] parkinglist, ref int totalteacher)
            {
               
                //Crear estructuras desde plaza hasta profesor (plaza --> Vehiculo--> Profesor) y rellenar los datos
                // porque por el momento teacherlist es null en todas sus posiciones.
                Plaza plaza1 = new Plaza {Col = 0, Row = 0, Status = false};
                    Vh vh1 = new Vh {Brand ="Merecedes",Model = "Cla",Plate ="BBBB111", Plaza =plaza1 };
                teacherlist[0] = new Teacher { Nif = "AAA1",Name ="Juan Lopez Lopez",Mail ="JLL@gmal.com",Vh=vh1};
                
                
                Plaza plaza2 = new Plaza {Col = 1, Row = 1, Status = false};
                Vh vh2 = new Vh {Brand ="Ford",Model = "Fiesta",Plate ="CCCC111", Plaza = plaza2};
                teacherlist[1] = new Teacher { Nif = "BBB1",Name ="ALBERTO PIEDRA MORENO",Mail ="APM@gmal.com",Vh=vh2};
                totalteacher += 2;
                
                //Bucle para que recorra una cantidad de veces igual a la entrada manual y rellene la matriz parking 
                // con la struct de plaza .
                Plaza plaza = new Plaza();
                // Usamos las constantes porque es de tamaño fijo: 
                //[A1][A2][A3][A4][A5]
                //[B1][B2][B3][B4]B5]
                
                // Creamos la estructura del Parking poniendo su estatus a true excepto los 2 primeros que deben ser
                //false porque hay 2 coches 
                for (var i = totalteacher; i < PARKING_ROWS; i++)
                {
                    for (var j = 0; j < PARKING_COL; j++)
                    {
                        
                        parkinglist[i, j] = new Plaza { Row = j, Col = i, Status = true };
                    }
                }
                parkinglist[0, 0].Status = true;
                parkinglist[1, 0].Status = true;
            }

            //Funcion para redimensionar array profesores.
            void Resizedata( ref Teacher?[] list, int size, ref int totalteacher)
            {
                Teacher?[] teacherlistaux = new Teacher?[size];
                Cplist(list, teacherlistaux, totalteacher);
            }

            // Funcion auxiliar de copia para redimensionar el array.
            void Cplist(Teacher?[] teacherlist, Teacher?[] teacherlistaux, int totalteacher)
            {

                var indexNew = 0;

                for (int i = 0; i < teacherlist.Length; i++)
                {
                    if (teacherlist[i] != null)
                    {
                        teacherlist[indexNew] = teacherlist[i];
                        indexNew = indexNew + 1;
                    }
                }

                teacherlist = teacherlistaux;

            }

            //Gestion de datos de profesores
            void Createentry(Teacher?[] teacherlist, ref int totalteacher)
            {
                bool yesno = false;
                string opt = "";
                string newnif = "";
                string newname = "";
                string newmail = "";
                string newbrand = "";
                string newmodel = "";
                string newplate = "";
                int index = -1;
                bool nifok = false;
                string brand = "";
                string model = "";
                string plate = "";
                Teacher?[] teacherlistaux = new Teacher?[] { };
                Console.WriteLine("Introduzca los datos del  profesor:");

                do
                {
                    Console.WriteLine("NIF: ");
                    newnif = Console.ReadLine().Trim();
                } while (!Checkentry(regexNif, newnif));

                do
                {
                    Console.WriteLine("Nombre completo: ");
                    newname = Console.ReadLine().Trim();
                } while (!Checkentry(regexName, newname));

                do
                {
                    Console.WriteLine("Correo electronico: ");
                    newmail = Console.ReadLine().Trim();
                } while (!Checkentry(regexMail, newmail));

                do
                {
                    Console.WriteLine("¿Desea agregar los datos del vehiculo del profesor?");
                    Console.WriteLine("Pulse S para aceptar o N para continuar");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.S)
                    {
                        yesno = true;
                    }
                    else if (key.Key == ConsoleKey.N)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tecla seleccionada no valida intentelo de nuevo");
                    }
                } while (!yesno);

                if (opt == "S")
                {
                    Console.WriteLine("Introduzca los datos del Vehiculo:");
                    do
                    {
                        Console.WriteLine("Matricula: ");
                        newplate = Console.ReadLine().Trim();
                    } while (!Checkentry(regexPlate, newplate));

                    do
                    {
                        Console.WriteLine("Marca: ");
                        newbrand = Console.ReadLine().Trim();
                    } while (!Checkentry(regexName, newbrand));

                    do
                    {
                        Console.WriteLine("Modelo: ");
                        newmodel = Console.ReadLine().Trim();
                    } while (!Checkentry(regexName, newmodel));
                }

                var indexnull = -1;

                for (var i = 0; i < teacherlist.Length; i++)
                {
                    if (teacherlist[i] == null)
                    {
                        indexnull = i;
                        break;
                    }
                }

                if (indexnull != -1)
                {
                    teacherlistaux[indexnull] = new Teacher()
                    {
                        Nif = newnif,
                        Name = newname,
                        Mail = newmail,
                        Vh = new Vh()
                        {
                            Plate = newplate,
                            Brand = newbrand,
                            Model = newmodel,
                        }
                    };
                    teacherlist[indexnull] = teacherlistaux[indexnull];
                }
                else
                {
                    Resizedata(ref teacherlist, teacherlist.Length + 1, ref totalteacher);
                    teacherlist[teacherlist.Length - 1] = teacherlistaux[indexnull];
                }

                Console.WriteLine("Datos del profesor almacenados exitosamente.");
            }

            void Delentry(Teacher?[] teacherlist, ref int totalteacher)
            {
                string nif = "";
                do
                {
                    Console.WriteLine("Introduzca el NIF del profesor que desea eliminar:");
                    Console.WriteLine("___________________________________");
                    nif = Console.ReadLine().Trim();

                    if (!Checkentry(regexNif, nif))
                    {
                        Console.WriteLine("Nif no valido, Nif debe tener el formato LLLN");
                    }
                } while (!Checkentry(regexNif, nif));

                int index = findteachernif(nif, teacherlist);
                if (index == -1)
                {
                    Console.WriteLine("No existe profesor con ese nif");
                }
                else
                {
                    Console.WriteLine($"Nif: {teacherlist[index]!.Value.Nif}");
                    Console.WriteLine($"Nombre: {teacherlist[index]!.Value.Name}");
                    Console.WriteLine($"Mail: {teacherlist[index]!.Value.Mail}");
                    Console.WriteLine($"Vehiculo : {teacherlist[index]!.Value.Vh.Plate} {teacherlist[index]!.Value.Vh.Model}{teacherlist[index]!.Value.Vh.Brand}");
                    Console.WriteLine($"");
                }
                Console.WriteLine("Pulse S para confirmaro N para salir");
                
                var input=Console.ReadKey(true).KeyChar;
                if (input == 's')
                {
                    teacherlist[index] = null;
                    Resizedata(ref teacherlist, teacherlist.GetLength(0 - 1), ref totalteacher);
                    Console.WriteLine("Datos de profesor eliminados correctamente");
                }
                else if  (input == 'n')
                {
                    return;
                }
                
                /* Idea inicial poco optima usando expresiones regulares de 1 sola letra. 
                string opt = "";
                do
                {
                    Console.WriteLine("Pulse S para borrar todos los datos del profesor o N para salir");
                    opt = Console.ReadLine().Trim().ToUpper();
                    Checkentry(opt, regexYes);
                    Checkentry(opt, regexNo);
                } while (!Checkentry);

                if (opt == "N")
                {
                    return;
                }
                else
                {
                    teacherlist[index] = null;
                    Resizedata(teacherlist, teacherlist.GetLength(0 - 1));
                    Console.WriteLine("Datos de profesor eliminados");
                }*/
            }

            void Updentry(Teacher?[] teacherlist, int index)
            {
                string nif = "";
                do
                {
                    Console.WriteLine("Introduzca el NIF del profesor que desea modificar:");
                    Console.WriteLine("__________________________________________________");
                    nif = Console.ReadLine().Trim();
                    if (!Checkentry(regexNif, nif))
                    {
                        Console.WriteLine("Nif no valido, Nif debe tener el formato LLLN");
                    }
                } while (!Checkentry(regexNif, nif));

                for (var i = 0; i < teacherlist.Length; i++)
                {
                    if (teacherlist[i].Value.Nif == nif)
                    {
                        index = i;
                    }
                    else
                    {
                        Console.WriteLine("Nif no encontrado.");
                        return;
                    }
                }
                
            }

            void Entrace (Plaza[,] parkinglist, Teacher?[] teacherlist, int  index)
            {
                var plaza = new Plaza();
                for (var i = 0; i < PARKING_ROWS; i++)
                {
                    for (var j = 0; j < PARKING_COL; j++)
                    {
                        if (parkinglist[i, j].Status)
                        {
                            plaza = new Plaza { Row = j, Col = i , Status = false };
                            parkinglist[i, j]= plaza;
                        }
                        else
                        {
                            Console.WriteLine("Lo sentimos el parking no tiene plazas disponibles");
                        }
                    }
                }
                if (teacherlist[index] is Teacher teacher)
                {
                    teacher.Vh.Plaza = plaza;
                    teacherlist[index]= teacher;
                    Console.WriteLine($" Tu plaza es la: {teacher.Vh.Plaza.Row}  {teacher.Vh.Plaza.Col}" );
                    return;
                }
            }

            void Exitparking(Plaza[,] parkinglist, Teacher?[] teacherlist, int  index)
            {
                // Revisar si funciona
                            if (teacherlist[index] is { } teacher)
                            {
                                var r = teacher.Vh.Plaza.Row;
                                var c=  teacher.Vh.Plaza.Col;
                                parkinglist[r, c].Status=true;
                                Plaza plaza = new Plaza { Row = -1, Col = -1, Status = true };
                                teacher.Vh.Plaza = plaza;
                                teacherlist[index]= teacher;
                                Console.WriteLine("Salida realizada");
                            }
            }
                        
    



    

            
 



    
    









