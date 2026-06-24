using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

class ADMINISTRACION_USUARIOS
{
static String usuarios = ".//archivos//usuarios.csv";
public class USUARIO
{
    public string ID = "-";
    public string nombre = "-";
    public string apellido = "-";
    public string username = "-";
    public string clave = "-";
    public string rol = "-";
    public string estado = "-";
}
    public static void CREAR_USUARIO()
    {    
        string repetir;
        do
        {
            Decoraciones.ENCABEZADO();  
            Decoraciones.TEXTO_CYAN("                        PANEL DE CREACIÓN DE USUARIOS\n");

            USUARIO user = new USUARIO();
            // ENTRADAS
            INSTRUCCIONES.NOTA_NOMBRES(); // nombre y apellido del usuario
            
            user.nombre = VALIDAR.SOLO_LETRAS("Digite el primer nombre del usuario: ");
            user.apellido = VALIDAR.SOLO_LETRAS("Digite el primer apellido del usuario: ");

            INSTRUCCIONES.NOTA_USERNAME(); // username

            user.username = VALIDAR.USERNAME_VALIDO("Digite el nuevo nombre de usuario: ");

            INSTRUCCIONES.NOTA_CLAVE(); // contraseña
            
            user.clave = VALIDAR.NO_VACIO("Contraseña: ");
        
            INSTRUCCIONES.NOTA_ROLYESTADO(); // rol y estado

            user.estado = "Activo";

            int respuesta = VALIDAR.OPCION("¿Qué ROL tendrá este usuario?" +
            "\n1. Administrador - 2. Usuario regular: ", 1,2);

            if (respuesta == 1)
            {
                user.rol = "Administrador";
            }
            else
            {
                user.rol = "Usuario";
            }

            user.ID = GENERAR_ID(usuarios, user.rol); // asignación del ID por el sistema

            // guardar datos

            String USUARIOS = user.ID + ";" + user.nombre + ";" + user.apellido + ";" +
            user.username + ";" + user.clave + ";" + user.rol + ";" + user.estado;

            File.AppendAllText(usuarios,USUARIOS + Environment.NewLine);
            
            Decoraciones.TEXTO_VERDE("\n¡Usuario guardado con éxito!");

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
            Decoraciones.TEXTO_CYAN("                     PANEL DE MODIFICACIÓN DE USUARIOS \n");

            if (!(File.Exists(usuarios)))
            {
                ALERTAS.ARCHIVO_NO_ENCONTRADO();
                return;
            }

            String BUSCADO = VALIDAR.AL_MENOS_UNA_LETRA("Ingrese el nombre del usuario al que desea acceder: ");

            String[] lineas = File.ReadAllLines(usuarios);

            bool ENCONTRADO = false;
            int CAMBIO;
            String ROL = "";
            String ESTADO = "";

            for (int i = 0; i < lineas.Length; i++)
            {
                String[] datos = lineas[i].Split(';');

                if (datos.Length > 3 && datos[3].Equals(BUSCADO, StringComparison.OrdinalIgnoreCase))
                {
                    Decoraciones.TEXTO_VERDE("\n¡Usuario encontrado exitosamente!\n");

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

                    Console.WriteLine("\nPuedes realizar las siguientes acciones: ");
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

                    Decoraciones.TEXTO_VERDE("\n¡Cambios guardados con éxito!\n");
                    break;
                }
            }

            if (ENCONTRADO == false)
            {
                ALERTAS.RESULTADO_NO_ENCONTRADO();
            }

            repetir = VALIDAR.SI_NO("\n¿Desea modificar otro usuario? (S/N): ");

        } while (repetir == "S");

        Console.WriteLine("Regresará al Panel de Administración.");
        Decoraciones.cargando();
    }

    static string GENERAR_ID(string usuarios, string rol)
    {
        int contadorTotal = 0;
        int contadorRol = 0;
        char sufijo;

        if (rol == "Administrador")
        {
            sufijo = 'A';
        }
        else
        {
            sufijo = 'U';
        }

        if (File.Exists(usuarios))
        {
            string[] lineas = File.ReadAllLines(usuarios);

            foreach (string linea in lineas)
            {
                if (string.IsNullOrWhiteSpace(linea))
                    continue;

                if (linea.StartsWith("ID"))
                    continue;

                contadorTotal++;

                string id = linea.Split(';')[0];

                if (id.EndsWith(sufijo))
                {
                    string numeroTexto = id.Substring(id.Length - 4, 3);
                    int numero;

                    if (int.TryParse(numeroTexto, out numero))
                    {
                        if (numero > contadorRol)
                        {
                            contadorRol = numero;
                        }
                    }
                }
            }
        }

        contadorTotal++;
        contadorRol++;

        return $"{contadorTotal:D3}I{contadorRol:D3}{sufijo}";
    }
}