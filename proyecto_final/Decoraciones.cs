using System.Text;
using System.Threading;
class Decoraciones
{
    public static void ENCABEZADO()
    {
        Console.Clear();
        Console.WriteLine("                            ──  ⋆ ⋅ 📚 ⋅ ⋆  ──");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("                               MATH LIBRARY ");
        Console.ResetColor();
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
            password = Console.ReadKey(true);
            if (password.Key == ConsoleKey.Backspace && claveO.Length > 0)
            {
                claveO.Remove(claveO.Length - 1, 1);
                Console.Write("\b \b");
            }
            else if (password.Key != ConsoleKey.Enter && password.Key != ConsoleKey.Backspace)
            {
                claveO.Append(password.KeyChar);
                Console.Write("•");
            }
        } while (password.Key != ConsoleKey.Enter);

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
    


}
