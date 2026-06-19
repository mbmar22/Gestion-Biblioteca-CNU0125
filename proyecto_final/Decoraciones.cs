using System.Text;
using System.Threading;
class Decoraciones
{
    public static void ENCABEZADO()
    {
        Console.Clear();
        ENCABEZADO2();
    }

    public static void ENCABEZADO_INICIAL()
    {
        ENCABEZADO();
        Console.WriteLine("Gestor de la biblioteca del centro de entrenamiento matemático Math For All");
        Console.WriteLine("        ──────────────────────────────────────────────────────────────"); 

    }

    public static void ENCABEZADO2()
    {
        Console.WriteLine("                            ──  ⋆ ⋅ 📚 ⋅ ⋆  ──");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("                               MATH LIBRARY ");
        Console.ResetColor();
    }
    public static void NOTA_NOMBRES()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("SECCIÓN DE REGISTRO DE DATOS: ");
        Console.ResetColor();
        Console.WriteLine("El nombre y el apellido del usuario son datos " +
        "\npermanentes y no podrán modificarse tras registrar al usuario.");
        Console.WriteLine("");
    }

    public static void NOTA_USERNAME()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\nCREACIÓN DEL NOMBRE DE USUARIO: ");
        Console.ResetColor();
        Console.WriteLine("Este es único y permanente. Puede contener");
        Console.WriteLine("letras, números y caracteres especiales.");
        Console.WriteLine("");
    }

    public static void NOTA_CLAVE()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\nCONFIGURACIÓN DE SEGURIDAD: ");
        Console.ResetColor();
        Console.WriteLine("Utilice una contraseña para proteger su usuario.");
        Console.WriteLine("Puede combinar letras, números y caracteres especiales.");
        Console.WriteLine("");
    }

    public static void NOTA_ROLYESTADO()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\nASIGNACIÓN DE ROLES: ");
        Console.ResetColor();
        Console.WriteLine("El rol determina los permisos del usuario" +
        "\ndentro del sistema. El estado define si podrá acceder a él. Ambos datos");
        Console.WriteLine("podrán modificarse posteriormente desde el Panel de Administración.");
        Console.WriteLine("");
    }
    public static void NOTA_LIBRO()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\nREGISTRO DEL LIBRO: ");
        Console.ResetColor();
        Console.WriteLine("El título y el autor son datos permanentes.");
        Console.WriteLine("Verifique cuidadosamente la ortografía antes de continuar.");
        Console.WriteLine("");
    }

    public static void NOTA_DESCRIPCION()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\nDESCRIPCIÓN DEL LIBRO: ");
        Console.ResetColor();
        Console.WriteLine("La descripción permite identificar mejor el contenido");
        Console.WriteLine("de la obra y podrá modificarse posteriormente si es necesario.");
        Console.WriteLine("");
    }

    public static void NOTA_CATEGORIAS()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\nREGISTRO DE CATEGORÍA: ");
        Console.ResetColor();
        Console.WriteLine("La categoría permitirá agrupar los libros por tema.\n");
    }

    public static string ocultarClave()
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! La contraseña no puede estar vacía.");
                Console.ResetColor();
                Console.Write("Ingrese su contraseña: ");
            }

        } while (claveO.Length == 0);

        return claveO.ToString();
    }

    public static void despedida()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("¡Hasta la próxima! Adiós.");
        Console.ResetColor();
        Console.WriteLine("© Math Library 2026");
    }

    public static void cargando()
    {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;

        for (int i = 0; i < 6; i++) // 3 segundos
        {
            Thread.Sleep(500);
            Console.Write(" . ");
        }

        Console.WriteLine();
        Console.ResetColor();
    }
    
    static String categorias = ".//archivos//categorias.csv";

    public static void mostrar_categorias()
    {
        if (!File.Exists(categorias))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No hay categorías registradas.");
            Console.ResetColor();
            return;
        }

        string[] lineas = File.ReadAllLines(categorias);

        if (lineas.Length <= 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No hay categorías registradas.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n 𓂃🖋   CATEGORÍAS DISPONIBLES");
        Console.ResetColor();

        int contador = 0;

        for (int i = 1; i < lineas.Length; i++) // empieza en 1 para saltar el encabezado
        {
            string[] datos = lineas[i].Split(';');

            if (datos.Length > 1)
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
                "4. Prestar un libro disponible \n" +
                "5. Devolver libro prestado \n" +
                "6. Modificar información del libro \n" +
                "7. Registrar nuevo usuario \n" +
                "8. Administrar usuarios \n" +
                "9. Registrar nueva categoría \n" +
                "10. Cambiar contraseña\n" +
                "11. Salir");
        Console.WriteLine("");
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

}
