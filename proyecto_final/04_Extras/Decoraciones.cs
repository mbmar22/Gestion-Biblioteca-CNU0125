using System.Text;
using System.Threading;
class Decoraciones
{
    // Decoraciones para la estética del programa
    public static void ENCABEZADO() 
    {
        Console.Clear();
        Console.WriteLine("                            ──  ⋆ ⋅ 📚 ⋅ ⋆  ──");
        Decoraciones.TEXTO_VERDE("                               MATH LIBRARY ");
    }

    public static void ENCABEZADO_INICIAL()
    {
        ENCABEZADO();
        Console.WriteLine("Gestor de la biblioteca del centro de entrenamiento matemático Math For All");
        Console.WriteLine("        ──────────────────────────────────────────────────────────────"); 

    }
    public static string ocultarClave() // para ocultar la clave en el inicio de sesión
    {
        StringBuilder claveO = new StringBuilder();
        ConsoleKeyInfo password;
        do
        {
            claveO.Clear();

            do
            {
                password = Console.ReadKey(true);

                if (password.Key == ConsoleKey.Backspace && claveO.Length > 0)
                {
                    claveO.Remove(claveO.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else if (password.Key != ConsoleKey.Enter &&
                        password.Key != ConsoleKey.Backspace)
                {
                    claveO.Append(password.KeyChar);
                    Console.Write("•");
                }

            } while (password.Key != ConsoleKey.Enter);

            if (claveO.Length == 0)
            {
                Console.WriteLine();
                ALERTAS.VACIO();
                Console.Write("Ingrese su contraseña: ");
            }

        } while (claveO.Length == 0);

        return claveO.ToString();
    }

    public static void despedida()
    {
        Decoraciones.TEXTO_VERDE("¡Hasta la próxima! Adiós.");
        Console.WriteLine("© Math Library 2026");
    }

    public static void cargando()
    {
        Console.WriteLine("");

        for (int i = 0; i < 6; i++) // 3 segundos
        {
            Thread.Sleep(500);
            Decoraciones.TEXTO_CYAN(" . ");
        }

        Console.WriteLine();
    }
    
    static String categorias = ".//archivos//categorias.csv";

    public static void mostrar_categorias()
    {
        if (!File.Exists(categorias))
        {
            ALERTAS.ARCHIVO_NO_ENCONTRADO();
            return;
        }

        string[] lineas = File.ReadAllLines(categorias);

        if (lineas.Length <= 1)
        {
            ALERTAS.ARCHIVO_NO_ENCONTRADO();
            return;
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n 𓂃🖋   CATEGORÍAS DISPONIBLES");
        Console.ResetColor();

        int contador = 0;

        for (int i = 1; i < lineas.Length; i++) // empieza en 1 para saltar el encabezado
        {
            string[] datos = lineas[i].Split(';');

            if (datos.Length > 1) // para evitar el out of index range
            {
                Console.Write(datos[1].PadRight(25));
                contador++;

                if (contador % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        if (contador % 3 != 0)
        {
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public static void OPCIONES_ADMIN()
    {
        Console.WriteLine("Como administrador, puede realizar las siguientes acciones en el sistema \n" +
            "                       de gestión de biblioteca: ");
        Console.WriteLine("");
        Console.WriteLine(
                "1. Ver todos los libros \n" +
                "2. Registrar libro nuevo \n" + 
                "3. Buscar libro \n" +
                "4. Administración de préstamos \n" +
                "5. Modificar información del libro \n" +
                "6. Registrar nuevo usuario \n" +
                "7. Administrar usuarios \n" +
                "8. Registrar nueva categoría \n" +
                "9. Cambiar contraseña\n" +
                "10. Salir\n");
    }

    public static void OPCIONES_USER()
    {
        Console.WriteLine("Como usuario estándar, puede realizar las siguientes acciones en el sistema \n" +
            "                       de gestión de biblioteca: ");
        Console.WriteLine("");
        Console.WriteLine(
                "1. Ver libros \n" +
                "2. Buscar libro\n" +
                "3. Prestar libro \n" +
                "4. Ver mi historial de préstamos \n" +
                "5. Cambiar contraseña \n" +
                "6. Salir");
        Console.WriteLine("");
    }

    public static void MOSTRAR_LIBRO(string[] datos)
    {
        Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");

        Console.Write("│ ");
        Console.WriteLine(("ID: " + datos[0]).PadRight(60) + " │");

        Console.Write("│ ");
        Console.WriteLine(("Título: " + datos[1]).PadRight(60) + " │");

        Console.Write("│ ");
        Console.WriteLine(("Autor: " + datos[2]).PadRight(60) + " │");

        Console.Write("│ ");
        Console.WriteLine(("Categoría: " + datos[3]).PadRight(60) + " │");

        // Corregir esto, lo puse así para mientras, como comentario.
        //Console.Write("│ ");
        //Console.WriteLine(("Disponibilidad: " + datos[5]).PadRight(60) + " │");

        //Console.Write("│ ");
        //Console.WriteLine(("Estado: " + datos[6]).PadRight(60) + " │");

        //Console.Write("│ ");
        //Console.WriteLine(("Registrado: " + datos[7]).PadRight(60) + " │");

        Console.Write("│ ");
        Console.WriteLine(("Descripción: " + datos[4]).PadRight(60) + " │");

        Console.WriteLine("└──────────────────────────────────────────────────────────────┘");
    }


    static string usuarios = ".//archivos//usuarios";

    public static void MOSTRAR_USUARIO(string[] datos)
    {
        string[] lineas = File.ReadAllLines(usuarios);

        Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");

        Console.Write("│ ");
        Console.WriteLine(("ID: " + datos[0]).PadRight(60) + " │");

        Console.Write("│ ");
        Console.WriteLine(("Nombre: " + datos[1]).PadRight(60) + " │");

        Console.Write("│ ");
        Console.WriteLine(("Apellido: " + datos[2]).PadRight(60) + " │");

        Console.WriteLine("└──────────────────────────────────────────────────────────────┘");
    }


    public static void SALIR_AL_PANEL()
    {
        Decoraciones.TEXTO_CYAN("Presione cualquier tecla para regresar al panel: ");
        Console.ReadKey();
    }

    public static void SEPARADOR()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────────");
        Console.ResetColor();
    }
    public static void TEXTO_CYAN(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }

    public static void TEXTO_ROJO(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }

    public static void TEXTO_VERDE(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
    public static void PRESTAR_LIBRO()
    {
        Decoraciones.ENCABEZADO();
        Decoraciones.TEXTO_CYAN("               PRESTAR LIBRO\n");
    }
}