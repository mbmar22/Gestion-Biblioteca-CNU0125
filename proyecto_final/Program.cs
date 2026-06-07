using System;
using System.IO;

class Program
{
    static String usuarios = ".//archivos//usuarios.txt";

    public static void Main(String[] args)
    {
        String ROL = INICIAR_SESION();
        if (ROL == "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR, acceso denegado.");
            Console.ResetColor();
            return;
        }

        if (ROL == "Administrador")
        {
            MENUS.MENU_ADMIN();
        }
        else
        {
            MENUS.MENU_USUARIO();
        }
    }

    public static String INICIAR_SESION()
    {
        String usuario, clave;
        Console.Clear();
        Console.WriteLine("                            ──  ⋆ ⋅ 📚 ⋅ ⋆  ──");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("                               MATH LIBRARY ");
        Console.ResetColor();
        Console.WriteLine("Gestor de la biblioteca del centro de entrenamiento matemático Math For All");
        Console.WriteLine("        ──────────────────────────────────────────────────────────────");

        for (int i = 0; i < 3; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"INTENTO {i+1} DE INICIO DE SESIÓN.");
            Console.ResetColor();

            Console.Write("Ingresa tu usuario: ");
            while (string.IsNullOrWhiteSpace(usuario = Console.ReadLine()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
                Console.Write("Ingresa tu usuario: ");
            }
            Console.Write("Ingresa tu contraseña: ");
            while (string.IsNullOrWhiteSpace(clave = Console.ReadLine()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
                Console.Write("Ingresa tu contraseña: ");
            }

            if (!File.Exists(usuarios))
            {
                Console.WriteLine("Este usuario no existe en este momento.");
                return "";
            }

            string[] lineas = File.ReadAllLines(usuarios);
            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(',');

                if (datos[0] == usuario && datos[1] == clave && datos[3] == "Activo")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"¡Bienvenido a Math Library, {usuario}!");
                    Console.ResetColor();
                    return datos[2];
                }
                else if (datos[0] == usuario && datos[1] == clave && datos[3] == "Inactivo")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Querido/a {usuario}, tu usuario está inhabilitado, comunícate con el administrador.");
                    Console.ResetColor();
                }
            }
        }
        return "";
    }
}
