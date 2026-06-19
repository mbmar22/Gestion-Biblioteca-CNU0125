using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

class ADMINISTRACION_USUARIOS
{
static String usuarios = ".//archivos//usuarios.csv";
struct USUARIO
{
    public int ID;
    public string nombre;
    public string apellido;
    public string username;
    public string clave;
    public string rol;
    public string estado;
}
    public static void CREAR_USUARIO()
    {    
        string repetir;
        do
        {
            Decoraciones.ENCABEZADO();  
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                        PANEL DE CREACIÓN DE USUARIOS");
            Console.ResetColor();
            Console.WriteLine("");

            USUARIO user = new USUARIO();
            if (File.Exists(usuarios))
            {
                user.ID = File.ReadAllLines(usuarios).Length + 1;
            }
            else
            {
                user.ID = 1;
            }

            Decoraciones.NOTA_NOMBRES();

            
            user.nombre = VALIDAR.SOLO_LETRAS("Digite el primer nombre del usuario: ");
            user.apellido = VALIDAR.SOLO_LETRAS("Digite el primer apellido del usuario: ");

            Decoraciones.NOTA_USERNAME();

            user.username = VALIDAR.USERNAME_VALIDO("Digite el nuevo nombre de usuario: ");

            Decoraciones.NOTA_CLAVE();

            
            user.clave = VALIDAR.NO_VACIO("Contraseña: ");
        

            Decoraciones.NOTA_ROLYESTADO();
            int respuesta;
            
            do
            {
                respuesta = VALIDAR.OPCION("¿Qué ROL tendrá este usuario?" +
                "\n1. Administrador - 2. Usuario regular", 1,2);

                switch (respuesta)
                {
                    case 1:
                        user.rol = "Administrador";
                        break;
                    case 2:
                        user.rol = "Usuario";
                        break;
                    default:
                        break;
                }
            } while (respuesta != 1 && respuesta != 2);

            // estado activo por defecto
            user.estado = "Activo";

            String USUARIOS = user.ID + ";" + user.nombre + ";" + user.apellido + ";" +
            user.username + ";" + user.clave + ";" + user.rol + ";" + user.estado;

            File.AppendAllText(usuarios,USUARIOS + Environment.NewLine);
            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n¡Usuario guardado con éxito!");
            Console.ResetColor();

            repetir = VALIDAR.SI_NO("\n¿Desea registrar otro usuario? (S/N): ");

        } while (repetir == "S");

        Console.WriteLine("Regresará al Panel de Administración.");
        Decoraciones.cargando();
    }
    public static void MANEJAR_USUARIO()
    {
        string repetir;
        
        do
        {
            Decoraciones.ENCABEZADO();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                     PANEL DE MODIFICACIÓN DE USUARIOS ");
            Console.WriteLine("");
            Console.ResetColor();

            if (!(File.Exists(usuarios)))
            {
                ALERTAS.ARCHIVO_NO_ENCONTRADO();
                return;
            }

            String BUSCADO;
            BUSCADO = VALIDAR.AL_MENOS_UNA_LETRA("Ingrese el nombre del usuario al que desea acceder: ");

            String[] lineas = File.ReadAllLines(usuarios);

            bool ENCONTRADO = false;
            int CAMBIO;
            String ROL = "";
            String ESTADO = "";

            for (int i = 0; i < lineas.Length; i++)
            {
                String[] datos = lineas[i].Split(';');

                if (datos[3].Equals(BUSCADO, StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n¡Usuario encontrado exitosamente!");
                    Console.WriteLine();
                    Console.ResetColor();

                    Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");

                    Console.Write("│ ");
                    Console.WriteLine(("Nombre: " + datos[1] + " " + datos[2]).PadRight(60) + " │");

                    Console.Write("│ ");
                    Console.WriteLine(("Usuario: " + datos[3]).PadRight(60) + " │");

                    Console.Write("│ ");
                    Console.WriteLine(("Rol: " + datos[5]).PadRight(60) + " │");

                    Console.Write("│ ");
                    Console.WriteLine(("Estado: " + datos[6]).PadRight(60) + " │");

                    Console.WriteLine("└──────────────────────────────────────────────────────────────┘");

                    Console.WriteLine("");
                    Console.WriteLine("Puedes realizar las siguientes acciones: ");
                    Console.WriteLine("1. Cambiar rol  - 2. Cambiar estado");

                    CAMBIO = VALIDAR.OPCION("Digite el número de la acción que desea realizar: ",1,2);

                    if (CAMBIO == 1)
                    {
                        if (datos[5] == "Administrador")
                        {
                            ROL = "Usuario";
                        }
                        else if (datos[5] == "Usuario")
                        {
                            ROL = "Administrador";
                        }

                        lineas[i] = $"{datos[0]};{datos[1]};{datos[2]};{datos[3]};{datos[4]};{ROL};{datos[6]}";
                    }
                    else
                    {
                        if (datos[6] == "Activo")
                        {
                            ESTADO = "Inactivo";
                        }
                        else if (datos[6] == "Inactivo")
                        {
                            ESTADO = "Activo";
                        }

                        lineas[i] = $"{datos[0]};{datos[1]};{datos[2]};{datos[3]};{datos[4]};{datos[5]};{ESTADO}";
                    }

                    ENCONTRADO = true;

                    File.WriteAllLines(usuarios, lineas);

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n¡Cambios guardados con éxito!");
                    Console.ResetColor();
                    Console.WriteLine("");

                    break;
                }
            }

            if (ENCONTRADO == false)
            {
                ALERTAS.RESULTADO_NO_ENCONTRADO();
                Console.WriteLine("");
            }
        Console.WriteLine();
        repetir = VALIDAR.SI_NO("¿Desea modificar otro usuario? (S/N): ");

    } while (repetir == "S");

    Console.WriteLine("Regresará al Panel de Administración.");
    Decoraciones.cargando();
    }
}