using System.Diagnostics.CodeAnalysis;

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
        Console.WriteLine("        ──────────────────────────────────────────────────────────────");
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

        do
        {
            Console.Write("Digite el primer nombre del usuario: ");
            user.nombre = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(user.nombre))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!user.nombre.All(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! No se aceptan caracteres especiales.");
                Console.ResetColor();
            }
        } while (String.IsNullOrWhiteSpace(user.nombre) || !user.nombre.All(char.IsLetter));

        do
        {
            Console.Write("Digite el primer apellido del usuario: ");
            user.apellido = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(user.apellido))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!user.apellido.All(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! No se aceptan caracteres especiales.");
                Console.ResetColor();
            }
        } while (String.IsNullOrWhiteSpace(user.apellido) || !user.apellido.All(char.IsLetter));

        Decoraciones.NOTA_USERNAME();

        bool usuario_existente;
        do
        {
            Console.Write("Digite el nuevo nombre de usuario: ");
            user.username = Console.ReadLine();
            usuario_existente = false;

            if (String.IsNullOrWhiteSpace(user.username))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!user.username.Any(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Debe contener al menos una letra.");
                Console.ResetColor();
            }
            else
            {
                if (File.Exists(usuarios))
                {
                    string[] lineas = File.ReadAllLines(usuarios);

                    foreach (string linea in lineas)
                    {
                        string[] datos = linea.Split(';');

                        if (datos.Length >= 4 &&
                            datos[3].Equals(user.username, StringComparison.OrdinalIgnoreCase))
                        {
                            usuario_existente = true;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("¡ ERROR ! Ese nombre de usuario ya existe.");
                            Console.ResetColor();

                            break;
                        }
                    }
                }
            }

        } while (String.IsNullOrWhiteSpace(user.username) || !user.username.Any(char.IsLetter) || usuario_existente);

        Decoraciones.NOTA_CLAVE();

        do
        {
            Console.Write("Contraseña: ");
            user.clave = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(user.clave))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(user.clave));


        Decoraciones.NOTA_ROLYESTADO();
        int respuesta;
        
        do
        {
            Console.WriteLine("¿Qué ROL tendrá este usuario?");
            Console.WriteLine("1. Administrador - 2. Usuario regular");
            Console.WriteLine();
            Console.Write("Digite el número de la opción: ");
            while (! int.TryParse(Console.ReadLine(), out respuesta))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Digite una opción válida (1 o 2).");
                Console.ResetColor();
            }
            switch (respuesta)
            {
                case 1:
                    user.rol = "Administrador";
                    break;
                case 2:
                    user.rol = "Usuario";
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡ ERROR ! Digite una opción válida (1 o 2).");
                    Console.ResetColor();
                    break;
            }
        } while (respuesta != 1 && respuesta != 2);

        // estado activo por defecto
        user.estado = "Activo";

        String USUARIOS = user.ID + ";" + user.nombre + ";" + user.apellido + ";" +
        user.username + ";" + user.clave + ";" + user.rol + ";" + user.estado;

        File.AppendAllText(usuarios,USUARIOS + Environment.NewLine);
        
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n¡Usuario registrado con éxito!");
        Console.ResetColor();
        Console.WriteLine("Regresará al Panel de Administración.");
        Decoraciones.cargando();
    }
        public static void MANEJAR_USUARIO()
    {
        Console.WriteLine("        ──────────────────────────────────────────────────────────────");
        Decoraciones.ENCABEZADO();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                     PANEL DE MODIFICACIÓN DE USUARIOS ");
        Console.WriteLine("");
        Console.ResetColor();

        if (!(File.Exists(usuarios)))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Archivo no encontrado.");
            Console.ResetColor();
            return;
        }

        String BUSCADO;

        do
        {
            Console.Write("Ingrese el nombre del usuario al que desea acceder: ");
            BUSCADO = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(BUSCADO))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!BUSCADO.Any(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Debe contener al menos una letra.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(BUSCADO) || !BUSCADO.Any(char.IsLetter));

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
                Console.WriteLine("¡Usuario encontrado éxitosamente!");
                Console.ResetColor();

                Console.WriteLine(
                "Nombre: " + datos[1] + " " + datos[2] +
                "\nUsuario: " + datos[3] +
                "\nRol: " + datos[5] +
                "\nEstado: " + datos[6]
                );

                Console.WriteLine("");
                Console.WriteLine("Puedes realizar las siguientes acciones: ");
                Console.WriteLine("1. Cambiar rol  - 2. Cambiar estado");
                Console.Write("Digite el número de la acción que desea realizar: ");

                while ((!int.TryParse(Console.ReadLine(), out CAMBIO)) || (CAMBIO != 1 && CAMBIO != 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡ ERROR ! Debe ingresar una opción válida (1 o 2).");
                    Console.ResetColor();
                    Console.Write("Digite el número de la acción que desea realizar: ");
                }

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
                Console.WriteLine("Regresará al Panel de Administración.");
                Decoraciones.cargando();
                Console.WriteLine("");

                break;
            }
        }

        if (ENCONTRADO == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("¡ ERROR ! No se ha encontrado el usuario.");
            Console.ResetColor();
            Console.WriteLine("Regresará al Panel de Administración.");
            Decoraciones.cargando();
            Console.WriteLine("");
        }
    }
}