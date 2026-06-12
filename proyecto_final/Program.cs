using System;
using System.IO;
// hola
class Program
{
    static String usuarios = ".//archivos//usuarios.csv";

    public static void Main(String[] args)
    {
        Console.Clear();
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
                string[] datos = linea.Split(';');
                /* PARA EL MANEJO DE LAS LINEAS EN LOS ARREGLOS
                datos[0] = nombre    datos[1] = apellido
                datos[2] = usuario   datos[3] = contraseña
                datos[4] = rol       datos[5] = estado */

                if (datos[2] == usuario && datos[3] == clave && datos[5] == "Activo")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"¡Bienvenido a Math Library, {datos[0]}!");
                    Console.ResetColor();
                    return datos[4];
                }
                else if (datos[2] == usuario && datos[3] == clave && datos[5] == "Inactivo")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Querido/a {datos[0]}, tu usuario está inhabilitado, comunícate con el administrador.");
                    Console.ResetColor();
                    return "";
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
        return "";
    }
}
