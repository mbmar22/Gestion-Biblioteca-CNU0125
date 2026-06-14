using System.Diagnostics.CodeAnalysis;

class ADMINISTRACION_USUARIOS
{
    static String usuarios = ".//archivos//usuarios.csv";
    public static void CREAR_USUARIO()
    {    
        Console.WriteLine("        ──────────────────────────────────────────────────────────────");
        Decoraciones.ENCABEZADO();  
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                        PANEL DE CREACIÓN DE USUARIOS");
        Console.ResetColor();
        Console.WriteLine("");

        Decoraciones.NOTA_NOMBRES();

        String NOMBRE;
        do
        {
            Console.Write("Digite el primer nombre del usuario: ");
            NOMBRE = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(NOMBRE))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!NOMBRE.All(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! No se aceptan caracteres especiales.");
                Console.ResetColor();
            }
        } while (String.IsNullOrWhiteSpace(NOMBRE) || !NOMBRE.All(char.IsLetter));

        String APELLIDO;
        do
        {
            Console.Write("Digite el primer apellido del usuario: ");
            APELLIDO = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(APELLIDO))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!APELLIDO.All(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! No se aceptan caracteres especiales.");
                Console.ResetColor();
            }
        } while (String.IsNullOrWhiteSpace(APELLIDO) || !APELLIDO.All(char.IsLetter));

        Decoraciones.NOTA_USERNAME();

        String USERNAME;
        bool usuario_existente;
        do
        {
            Console.Write("Digite el nuevo nombre de usuario: ");
            USERNAME = Console.ReadLine();
            usuario_existente = false;

            if (String.IsNullOrWhiteSpace(USERNAME))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!USERNAME.Any(char.IsLetter))
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

                        if (datos.Length >= 3 &&
                            datos[2].Equals(USERNAME, StringComparison.OrdinalIgnoreCase))
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

        } while (String.IsNullOrWhiteSpace(USERNAME) || !USERNAME.Any(char.IsLetter) || usuario_existente);

        Decoraciones.NOTA_CLAVE();

        String CLAVE;
        do
        {
            Console.Write("Contraseña: ");
            CLAVE = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(CLAVE))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(CLAVE));


        Decoraciones.NOTA_ROLYESTADO();
        int respuesta;
        String ROL = "";
        
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
                    ROL = "Administrador";
                    break;
                case 2:
                    ROL = "Usuario";
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡ ERROR ! Digite una opción válida (1 o 2).");
                    Console.ResetColor();
                    break;
            }
        } while (respuesta != 1 && respuesta != 2);

        Console.WriteLine("");
        String ESTADO = "";
        do
        {
            Console.WriteLine("¿Cuál será el ESTADO de este usuario?");
            Console.WriteLine("1. Activo  -  2. Inactivo");
            Console.WriteLine("");
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
                    ESTADO = "Activo";
                    break;
                case 2:
                    ESTADO = "Inactivo";
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡ ERROR ! Digite una opción válida (1 o 2).");
                    Console.ResetColor();
                    break;
            }
        } while (respuesta != 1 && respuesta != 2);

        String USUARIOS = NOMBRE + ";" + APELLIDO + ";" + USERNAME + ";" + CLAVE + ";" + ROL + ";" + ESTADO;

        File.AppendAllText(usuarios,USUARIOS + Environment.NewLine);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n¡Usuario registrado con éxito!");
        Console.ResetColor();
        Console.WriteLine("Regresará al Panel de Administración.");
    }
    public static void MANEJAR_USUARIO()
    {
        Console.WriteLine("        ──────────────────────────────────────────────────────────────");
        Decoraciones.ENCABEZADO();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                     PANEL DE MODIFICACIÓN DE USUARIOS ");
        Console.WriteLine("");
        Console.ResetColor();

        if (! (File.Exists(usuarios)))
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

        String [] lineas = File.ReadAllLines(usuarios);
        bool ENCONTRADO = false;
        int CAMBIO;
        String ROL = "";
        String ESTADO = "";

        for (int i = 0; i < lineas.Length; i++)
        {

            String[] datos = lineas[i].Split(';');
            if (datos[2].ToLower() == BUSCADO.ToLower())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("¡Usuario encontrado éxitosamente!");
                Console.ResetColor();
                Console.WriteLine(
                "Nombre: " + datos[0] + " " + datos[1] +
                "\nUsuario: " + datos[2] +
                "\nRol: " + datos[4] +
                "\nEstado: " + datos[5]
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
                    if (datos[4] == "Administrador")
                    {
                        ROL = "Usuario";
                    }
                    else if (datos[4] == "Usuario")
                    {
                        ROL = "Administrador";
                    }
                    lineas[i] = $"{datos[0]};{datos[1]};{datos[2]};{datos[3]};{ROL};{datos[5]}";
                }
                else
                {
                    if (datos[5] == "Activo")
                    {
                        ESTADO = "Inactivo";
                    }
                    else if (datos[5] == "Inactivo")
                    {
                        ESTADO = "Activo";
                    }
                    lineas[i] = $"{datos[0]};{datos[1]};{datos[2]};{datos[3]};{datos[4]};{ESTADO}";
                }

                ENCONTRADO = true;
                if (ENCONTRADO)
                {
                File.WriteAllLines(usuarios, lineas);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n¡Cambios guardados con éxito!");
                Console.ResetColor();
                Console.WriteLine("Regresará al Panel de Administración.");
                Console.WriteLine("");
                }
            }
        }

        if (ENCONTRADO == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("¡ ERROR ! No se ha encontrado el usuario.");
            Console.ResetColor();
            Console.WriteLine("Regresará al Panel de Administración.");
            Console.WriteLine("");
        }
    }
}