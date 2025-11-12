using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;


/*Constantes del sistema.
##########################################################################################
Expresiones regulares: */
var regexMENUOPTION = new Regex(@"^[0-9]{1}$");
var regexYes = new Regex(@"^[S]{1}$");
var regexNo = new Regex(@"^[N]{1}$");
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
const int showFreeSpot= 2;
const int newEntry = 3;
const int delEntry = 4;
const int updEntry= 5;
const int entranceVh= 6; 
const int exitVh= 7; 
const int exit = 8;

Console.Clear();
Console.OutputEncoding = Encoding.UTF8;
//Variables que necesitamos crear.
string[] parkingLetters = ["A","B"];
string menuoption= "";
int option = -1; 
int totalteacher = 0;
Teacher[]? teacherlist= new Teacher[START_SIZE];
Plaza [,] parkinglist = new Plaza[PARKING_ROWS,PARKING_COL];
var index = -1;
Plaza ps = new Plaza(){Row = " " , Col= -1, Status = false};
var nif= "";

do
{
    ShowMenu();
    menuoption= Console.ReadLine().Trim() ;
    if(!checkentry(regexMENUOPTION,menuoption)){
        Console.WriteLine("Por favor introduzca una opción del menu en formato de numero entero");        
    }
    else{
        //Casting seguro gracias a la expresion regular.
        option=int.Parse(menuoption);
        switch(option) {
            case showTeacher:
                listteacher(teacherlist);
                break;
            case showFreeSpot:
                listspot(parkinglist);
                break;
            case newEntry:
                Createentry(teacherlist);
                break;
            case delEntry:
                Delentry(teacherlist,ref totalteacher);
                break;
            case updEntry:
                Updentry(teacherlist, ref totalteacher, index=-1);
                break;
            case entranceVh:
                ps = Entrace( parkinglist, parkingLetters, ps);
                Console.WriteLine("Tu plaza es la:" +ps.Col+ " "+ps.Row);
                break;
            case exitVh:
                do {
                    Console.WriteLine("Introduzca NIF para efectuar salida:");
                    Console.WriteLine("___________________________________");
                    nif = Console.ReadLine().Trim();

                    if(!Checkentry(regexNif, nif))
                    {
                        Console.WriteLine("Nif no valido, Nif debe tener el formato LLLN");
                    } 
                }while(!Checkentry(regexNif,nif));
                var indext = findteachernif( nif,teacherlist );
                Exitparking(ref Plaza [,] parkinglist, teacherlist, indext);
                break;
            case exit:
                break;
        } while (option!= exit);
//------------------------------------------------------------------------------------------------------------------
//FUNCIONES Y PROCEDIMIENTOS
//------------------------------------------------------------------------------------------------------------------

        void ShowMenu(){
            Console.WriteLine("Gestion de parking del profesorado Luis Vives");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("Selecciona la opcion que desees introduciendo el numero correspondiente");
            Console.WriteLine(showTeacher+" Buscar profesor");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine(showFreeSpot+" Buscar plaza de aparcamiento libre");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine(newEntry+" Agregar nuevo profesor");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine(delEntry+" Eliminar profesor existente");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine(delEntry+" Eliminar profesor existente");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine(updEntry+" Eliminar profesor existente");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine(Exitparking+" salir");
        }
        //funcion para validar entrada de datos 
        bool Checkentry(Regex expresion, string data)
        {
            return expresion.IsMatch(data);
        }

        //Funcion auxiliar de busqueda para listar por nif 
        int findteachernif(string nif, Teacher[] teacherlist)
        {
            for (int i = 0; i < teacherlist.GetLength(0); i++)
            {
                if (teacherlist[i].Nif == nif)
                {
                    return i;

                }
            }
            return -1;
        }

        //Función auxiliar de busqueda para listar por matricula.
        int findteacherplate(string plate, Teacher?[] teacherlist ) 
        {  
            for (int i=0; i<teacherlist.Length;i++)
            {
                if(teacherlist[i]?.Vh.Plate==plate)
                {
                    return i;
                }
                
            } 
            return -1;
        }

        void listsport(int [,]parkingList)
        {
            
        }
        //Funcion de busqueda por NIF.
        void listteacher(Teacher?[] teacherlist) {
            //Realizamos la comprobacion de integridad del NIF usando su expresión regular.
            do { 
                Console.WriteLine("Listado de profesores:");
                Console.WriteLine("Introduzca el NIF del profesor:");
                Console.WriteLine("___________________________________");
                string nif = Console.ReadLine().Trim();

                if(!Checkentry(regexNif, nif))
                {
                    Console.WriteLine("Nif no valido, Nif debe tener el formato LLLN");
                }
            }while(!Checkentry(regexNif,nif));

            //Llamamos a la función de busqueda de profesor que nos devuelve el indice del array donde se encuentra 
            // o mostramos un aviso por pantalla en caso de que no exista la entrada. 
            int index = findteachernif(nif, teacherlist);
            if (index== -1){
                Console.WriteLine("No existe profesor con ese nif");
            }
            else{
                Console.WriteLine(teacherlist[index].Nif+" "+teacherlist[index].name+" "+teacherlist[index].Mail+".");
                Console.WriteLine("Vehiculo: "+teacherlist[index].vh.plate+" "+teacherlist[index].vh.model+" "+teacherlist[index].vh.brand);
            }
        }
        //Busqueda por matricula.
        void listteacherplate (int?[] teacherlist) {
            do {
                Console.WriteLine("Busqueda de profesor por matricula de vehiculo");
                Console.WriteLine("Introduzca la matricula:");
                Console.WriteLine("___________________________________");
                string plate = Console.ReadLine().Trim();

                if (!Checkentry(regexPlate, plate){
                    Console.WriteLine("Formato de matricula no valido.");
                }
            }while(!Checkentry(regexPlate,plate));

            int index = findteacherplate(plate, teacherlist);
            if (index== -1){
                Console.WriteLine("No existe profesor que tenga ese vehiculo");
            }
            else{
                Console.WriteLine(teacherlist[index].Nif+" "+teacherlist[index].name+" "+teacherlist[index].mail);
                Console.WriteLine("Vehiculo: "+teacherlist[index].vh.plate+" "+teacherlist[index].vh.model+" "+teacherlist[index].vh.brand);
            }
        }
    // Funcion para crear entradas de datos en el array de teacherlist al iniciar programa.
        void startteacher( ref Teacher[]? teacherlist, Plaza [,] parkinglist , int totalteacher)
        {
            teacherlist[0].Nif = "AAA1";
            teacherlist[0].Name = "JUAN LOPEZ LOPEZ";
            teacherlist[0].Nif = "JLL@gmal.com";
            teacherlist[0].Vh.Brand = "Merecedes";
            teacherlist[0].Vh.Model = "Cla";
            teacherlist[0].Vh.Plate = "BBB111";
            
            teacherlist[1].Nif = "BBB2";
            teacherlist[1].Name = "ALBERTO PIEDRA MORENO";
            teacherlist[1].Nif = "APM@gmal.com";
            teacherlist[1].Vh.Brand = "Ford";
            teacherlist[1].Vh.Model = "Fiesta";
            teacherlist[1].Vh.Plate = "CCC111";
            totalteacher += 2;
            
            for (var i = totalteacher; i < PARKING_ROWS; i++)
            {
                for (var j = 0; j < PARKING_COL; j++)
                {
                    parkinglist[i,j]= new Plaza { Row = parkingLetters[j], Col = i + 1, Status = false };
                }
            }
        } 

        //Funcion para redimensionar array profesores.
        void Resizedata(Teacher?[] teacherlist, int size){ 
            Teacher?[] teacherlistaux= new Teacher?[size]; 
            Cplist(teacherlist,teacherlistaux, totalteacher);
        }
        // Funcion auxiliar de copia para redimensionar el array.
        void Cplist(Teacher?[] teacherlist, Teacher?[] teacherlistaux,int totalteacher){ 
    
            var indexNew = 0;
  
            for (int i = 0; i<teacherlist.Length; i++) {
                if (teacherlist[i] != null) {
                    teacherlist[indexNew] = teacherlist[i];
                    indexNew = indexNew + 1; 
                }    
            }
            teacherlist=teacherlistaux; 

        }
        //Gestion de datos de profesores
        void Createentry(Teacher?[] teacherlist) 
        {
            bool yesno = false;
            string opt= "";
            string newnif="";
            string newname="";
            string newmail="";
            string newbrand= "";
            string newmodel="";
            string newplate="";
            int index= -1;
            bool nifok = false;
            string brand= "";
            string model="";
            string plate="";
            Teacher?[]teacherlistaux = new Teacher?[] { };
            Console.WriteLine("Introduzca los datos del  profesor:");
        
            do{
                Console.WriteLine("NIF: ");
                newnif=Console.ReadLine().Trim();
            }while(!Checkentry(regexNif,newnif));

            do
            {
                Console.WriteLine("Nombre completo: ");
                newname=Console.ReadLine().Trim();   
            }while(!Checkentry(regexName,newname));
            
            do
            {
                Console.WriteLine("Correo electronico: ");
                newmail=Console.ReadLine().Trim();
            }while(!Checkentry(regexMail,newmail));
        
            do{
                Console.WriteLine("¿Desea agregar los datos del vehiculo del profesor?");
                Console.WriteLine("Pulse S para aceptar o N para continuar");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.S)
                {
                   yesno=true;
                }
                else if (key.Key == ConsoleKey.N)
                {
                    break; 
                }
                else
                { 
                    Console.WriteLine("Tecla seleccionada no valida intentelo de nuevo");  
                }
            } while(!yesno);
            
            if (opt=="S"){
                Console.WriteLine("Introduzca los datos del Vehiculo:");    
                do{
                    Console.WriteLine("Matricula: ");
                    newplate=Console.ReadLine().Trim();
                }while(!Checkentry(regexPlate,newplate));

                do{
                    Console.WriteLine("Marca: ");
                    newbrand=Console.ReadLine().Trim();
                }while(!Checkentry(regexName,newbrand));
                do{
                    Console.WriteLine("Modelo: ");
                    newmodel=Console.ReadLine().Trim();
                }while(!Checkentry(regexName,newmodel));
            }
            var indexnull=-1;
            
            for (var i=0; i<teacherlist.Length;i++)
            {
                if(teacherlist[i]==null)
                {
                    indexnull=i;
                    break;
                }
            }
            
            if( indexnull!=-1)
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
                teacherlist[indexnull]=teacherlistaux[indexnull];
            }
            else
            {
                Resizedata(teacherlist,teacherlist.Length+1);
                teacherlist[teacherlist.Length-1]=teacherlistaux[indexnull];  
            }
            Console.WriteLine("Datos del profesor almacenados exitosamente.");           
       }
    
    void Delentry(Teacher?[] teacherlist, ref int totalteacher ){
     
        do {
            Console.WriteLine("Introduzca el NIF del profesor que desea eliminar:");
            Console.WriteLine("___________________________________");
            string nif = Console.ReadLine().Trim();

            if (!Checkentry(regexNif, nif){
                Console.WriteLine("Nif no valido, Nif debe tener el formato LLLN")
            }
        }while(!Checkentry(regexNif,nif));
        int index = findteachernif(nif, teacherlist);
        if (index== -1){
            Console.WriteLine("No existe profesor con ese nif");
        }
        else{
            Console.WriteLine(teacherlist[index].Nif+" "+teacherlist[index].name+" "+teacherlist[index].mail+);
            Console.WriteLine("Vehiculo: "+teacherlist[index].vh.plate+" "+teacherlist[index].vh.model+" "+teacherlist[index].vh.brand);
        }
        string opt = "";

        do{
            Console.WriteLine("Pulse S para borrar todos los datos del profesor o N para salir");
            opt= Console.ReadLine().Trim().ToUpper();
            Checkentry(opt,regexYes);
            Checkentry(opt,regexNo);
        } while(!Checkentry);

        if (opt=="N"){
            break;
        }
        else
        {
            teacherlist[index] = null;
            Resizedata(teacherlist, teacherlist.GetLength(0-1));
            Console.WriteLine("Datos de profesor eliminados");  
        }
    }

    void Updentry (Teacher?[] teacherlist){

        do {
            Console.WriteLine("Introduzca el NIF del profesor que desea modificar:");
            Console.WriteLine("___________________________________");
            string nif = Console.ReadLine().Trim();

            if (!checkentry(regexNif, nif){
                Console.WriteLine("Nif no valido, Nif debe tener el formato LLLN")
            }
        }while(!checkentry)

        for (i=0; i<teacherlist.lenght;i++){
            if(Teacher[i].nif==nif){
                index=i;
                createentry(ref totalteacher, i, teacherlist);
                return;
            }
            else{
                Console.WriteLine("Nif no encontrado.")
                return;
            }
        }
    }

void Entrace(int parkinglist, string[] parkingleters, Plaza plaza)
{
    for(var i=0; i<parkinglist.Getlenght();i++)
    {
        for (int j=0; j<parkinglist[i].lenght;j++)
        {
            if(parkinglist[i]==null)
            {
                freespot.col=parkingleters[i];
                freespot.row=j;
                freespot.status = true;
            }
        }
        return freespot;
    } 
}   
    void Exitparking(int parkinglist, Teacher[] teacherlist, int index) {

        for (int i=0; i<parkinglist.lenght;i++){
            for (int j=0; j<parkinglist[i].lenght;j++){
                if(parkinglist[i]==teacherlist[index].plaza.col){
                    teacherlist[index].plaza.status= true;
                }
            }
        }
    }

public struct Vh
{
    public string Brand;
    public string Model;
    public string Plate;
    public Plaza Plaza;
}

public struct Teacher{ 
    public string Nif;
    public string Name;
    public string Mail;
    public Vh Vh;
}
public struct Plaza{
    public string Row;
    public int Col;
    public bool Status;
}




