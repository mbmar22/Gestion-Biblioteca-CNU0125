using System;
using System.IO;
using System.Text;
class INICIAR_SESION
{
    static String usuarios = ".//archivos//usuarios.csv";
    
    public static String INICIO_DE_SESION()
    {
        String usuario, clave;

        for (int i = 0; i < 3; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"INTENTO {i + 1} DE INICIO DE SESIÓN.");
            Console.ResetColor();

            // ENTRADAS DE INICIO DE SESIÓN (usuario y contraseña)
            usuario = VALIDAR.AL_MENOS_UNA_LETRA("Ingrese su usuario: ");
            
            Console.Write("Ingrese su contraseña: ");
            clave = Decoraciones.ocultarClave();
            Console.WriteLine();

            if (!File.Exists(usuarios))
            {
                ALERTAS.ARCHIVO_NO_ENCONTRADO();
                return "";
            }

            String[] lineas = File.ReadAllLines(usuarios); // proceso

            foreach (String linea in lineas)
            {
                if (String.IsNullOrWhiteSpace(linea))
                {
                    continue;
                }

                String[] datos = linea.Split(';');

                if (datos.Length < 7) // para evitar out of index range
                {
                    continue;
                }

                if (datos[3].Equals(usuario, StringComparison.OrdinalIgnoreCase)
                    && datos[4] == clave)
                {
                    if (datos[6] == "Activo") // SALIDAS
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"\n¡Bienvenido a Math Library, {datos[1]}!");
                        Console.ResetColor();
                        Decoraciones.cargando();

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