using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
class INICIAR_SESION
{
    static String usuarios = ".//archivos//usuarios.csv";
    
    public static String INICIO_DE_SESION()
    {
        String usuario, clave;

        for (int i = 0; i < 3; i++)
        {
            Decoraciones.TEXTO_CYAN($"INTENTO {i + 1} DE INICIO DE SESIÓN.");

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
                        Sesion.IdUsuario = datos[0];
                        Sesion.Rol = datos[5];

                        Decoraciones.TEXTO_VERDE($"\n¡Bienvenido a Math Library, {datos[1]}!");
                        Decoraciones.cargando();
                        return datos[5];
                    }
                    else
                    {
                        Decoraciones.TEXTO_ROJO($"Querido/a {datos[1]}, tu usuario está inhabilitado, comunícate con el administrador.");
                        return "";
                    }
                }
            }

            if (i < 2)
            {
                Decoraciones.TEXTO_ROJO("\n¡ ERROR ! Usuario o contraseña incorrectos.");
                Console.WriteLine($"Te quedan {2 - i} intento(s).\n");
            }
        }

        Decoraciones.TEXTO_ROJO("Has agotado los 3 intentos permitidos.");
        return "";
    }

    public static class Sesion
    {
        public static string IdUsuario { get; set; } = "";
        public static string Rol { get; set; } = "";
    }
}