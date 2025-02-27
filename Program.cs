using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Creacion de carpetas
        try
        {

            Directory.CreateDirectory(@"C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\Backup");
            Directory.CreateDirectory(@"C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\ArchivosClasificados");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al crear directorios: " + ex.Message);
        }

        int opcion;
        do
        //Interfas
        {
            Console.WriteLine("\n ***Bienvenido***");
            Console.WriteLine("1. Crear archivo");
            Console.WriteLine("2. Agregar invento");
            Console.WriteLine("3. Leer linea por linea");
            Console.WriteLine("4. Leer todo el texto");
            Console.WriteLine("5. Copiar archivo a backup");
            Console.WriteLine("6. Mover archivo a Archivos Clasificados");
            Console.WriteLine("7. Crear carpeta ProyecrtosSecretos");
            Console.WriteLine("8. Listar archivos");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                // LLamado a las funciones
                {
                    case 1: CrearArchivo(); break;
                    case 2: if (VerificarExistenciaArchivo()) AgregarInvento(Console.ReadLine()); break;
                    case 3: if (VerificarExistenciaArchivo()) LeerLineaPorLinea(); break;
                    case 4: if (VerificarExistenciaArchivo()) LeerTodoElTexto(); break;
                    case 5: if (VerificarExistenciaArchivo()) CopiarArchivo(); break;
                    case 6:  MoverArchivo(); break;
                    case 7: CrearCarpeta(); break;
                    case 8: ListadoDeArchivos(); break;
                }
            }
            else
            {
                Console.WriteLine("Al parecer no ingreso un numero. Intentelo de nuevo");
            }

        } while (opcion != 0);
    }

    static bool VerificarExistenciaArchivo()
    {
        //Verifica si la carpeta invnetos.txt existe, si el archivo no existe aparece un mensaje (Archivo no existe)
        string path = "C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\Inventos.txt";
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
            return false;
        }
    }

    static void CrearArchivo()
    {
        try
        {
            string path = "C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\Inventos.txt";
            string contenido = "Archivo plano creado";
            File.WriteAllText(path, contenido);//Crea el archivo en la ruta espesificada y agrega un mensaje dentro del archivo (Archivo creado)
            Console.WriteLine("Archivo creado");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al crear el archivo: " + ex.Message);
        }
    }

    static void AgregarInvento(string invento)
    {
        try
        {
            string path = "C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\Inventos.txt";//Ubicacion del archivo que deseo agregar contenido
            File.AppendAllText(path, "\n" + invento);//Agrega el invento que coloque en la variable invento
            Console.WriteLine("Se agrega contenido");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al agregar invento: " + ex.Message);
        }
    }

    static void LeerLineaPorLinea()
    {
        try
        {
            int cont = 0; //Inicio esta variable en 0 para utilizarla como contador de lineas
            string path = "C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\Inventos.txt";
            string[] lineas = File.ReadAllLines(path);
            foreach (string linea in lineas) //Recorre las lineas dentro del array string[] lineas 
            {
                cont++;
                Console.WriteLine("Linea Numero: " + cont + "\t" + linea);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer el archivo: " + ex.Message);
        }
    }

    static void LeerTodoElTexto()
    {
        try
        {
            string path = "C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\Inventos.txt"; //Ubicacion del texto que se va a leer
            string contenido = File.ReadAllText(path); //Lee todo el texto
            Console.WriteLine("\n--- Contenido del Archivo ---");
            Console.WriteLine(contenido);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer el archivo: " + ex.Message);
        }
    }

    static void CopiarArchivo()
    {
        try
        {
            string pathOrigen = "C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\Inventos.txt";
            string pathDestino = "C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\Backup\\Inventos.txt";
            File.Copy(pathOrigen, pathDestino, true);// Copia el archivo
            Console.WriteLine("Archivo copiado");
            EliminarArchivo(pathOrigen); //LLama a la funcion EliminarArchivo para eliminar el archivo  
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al copiar el archivo: " + ex.Message);
        }
    }

    static void EliminarArchivo(string ruta)
    {//Elimina el archivo Invnetos.txt de su origen 
        if (File.Exists(ruta))
        {
            File.Delete(ruta);
            Console.WriteLine("Archivo eliminado después de la copia.");
        }
    }


    static void MoverArchivo()
    {
        try
        {
            string pathOrigen = "C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\Backup\\Inventos.txt";//Ubicacion del archivo
            string pathDestino = "C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\ArchivosClasificados\\Inventos.txt";//Ubicacion a la cual quiero mover el archivo
            File.Move(pathOrigen, pathDestino);  //Mueve el archivo a la carpeta deseada
            Console.WriteLine("Archivo movido correctamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al mover el archivo: " + ex.Message);
        }
    }

    static void CrearCarpeta()
    {
        try
        {
            string nomcarpeta = "ProyectosSecretos"; //Nombre de la carpeta que se va a crear

            string path = Path.Combine(@"C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers\\", nomcarpeta); //Crea la carpeta en esta ubicacion
            Directory.CreateDirectory(path);
            Console.WriteLine("Carpeta creada exitosamente en: " + path);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al crear la carpeta: " + ex.Message);
        }
    }

    static void ListadoDeArchivos()
    {
        string path = "C:\\Users\\joseg\\OneDrive\\Escritorio\\LaboratorioAvengers";
        try
        {
            if (Directory.Exists(path))
            {
                //Muestra y enumera los archivos existentes
                Console.WriteLine("\nArchivos y carpetas en " + path + ":\n");
                string[] archivos = Directory.GetFiles(path);

                Console.WriteLine("Archivos:");
                foreach (string archivo in archivos)
                {
                    Console.WriteLine(Path.GetFileName(archivo));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al listar archivos: " + ex.Message);
        }

      

    }
}

