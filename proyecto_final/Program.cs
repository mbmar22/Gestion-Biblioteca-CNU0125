using System;
using System.IO;
using System.Text;


class Program
{
    static String usuarios = ".//archivos//usuarios.csv";

    public static void Main(String[] args)
    {
        Decoraciones.ENCABEZADO();
        Console.WriteLine("Gestor de la biblioteca del centro de entrenamiento matemático Math For All");
        Console.WriteLine("        ──────────────────────────────────────────────────────────────"); 
        String ROL = INICIAR_SESION();
        if (ROL == "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR. ACCESO DENEGADO.");
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

        for (int i = 0; i < 3; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"INTENTO {i + 1} DE INICIO DE SESIÓN.");
            Console.ResetColor();

            Console.Write("Ingresa tu usuario: ");
            while (String.IsNullOrWhiteSpace(usuario = Console.ReadLine()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
                Console.Write("Ingresa tu usuario: ");
            }

            Console.Write("Ingresa tu contraseña: ");
            while (String.IsNullOrWhiteSpace(clave = Decoraciones.ocultarClave()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
                Console.Write("Ingresa tu contraseña: ");
            }

            if (!File.Exists(usuarios))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No existen usuarios registrados.");
                Console.ResetColor();
                return "";
            }

            String[] lineas = File.ReadAllLines(usuarios);

            foreach (String linea in lineas)
            {
                if (String.IsNullOrWhiteSpace(linea))
                {
                    continue;
                }

                String[] datos = linea.Split(';');

                if (datos.Length < 7)
                {
                    continue;
                }

                if (datos[3].Equals(usuario, StringComparison.OrdinalIgnoreCase)
                    && datos[4] == clave)
                {
                    if (datos[6] == "Activo")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"¡Bienvenido a Math Library, {datos[1]}!");
                        Console.ResetColor();

                        return datos[5];
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Querido/a {datos[1]}, tu usuario está inhabilitado, comunícate con el administrador.");
                        Console.ResetColor();

                        return "";
                    }
                }
            }

            if (i < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n¡ERROR! Usuario o contraseña incorrectos.");
                Console.ResetColor();

                Console.WriteLine($"Te quedan {2 - i} intento(s).");
                Console.WriteLine("");
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Has agotado los 3 intentos permitidos.");
        Console.ResetColor();

        return "";
    }

}
