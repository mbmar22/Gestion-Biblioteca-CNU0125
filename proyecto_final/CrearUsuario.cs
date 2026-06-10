class CrearUsuario
{
    static String usuarios = ".//archivos//usuarios.csv";
    public static void CREAR_USUARIO()
    {
        Console.WriteLine("        ──────────────────────────────────────────────────────────────");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                        PANEL DE CREACIÓN DE USUARIOS");
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("SECCIÓN DE REGISTRO DE DATOS: ");
        Console.ResetColor();
        Console.WriteLine("El nombre y el apellido del usuario son datos " +
        "\npermanentes y no podrán modificarse tras registrar al usuario.");
        Console.WriteLine("");

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

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\nCREACIÓN DEL NOMBRE DE USUARIO: ");
        Console.ResetColor();
        Console.WriteLine("Este es único y permanente. Puede contener");
        Console.WriteLine("letras, números y caracteres especiales.");
        Console.WriteLine("");
        // validacion de nombre de usuario 
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

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\nCONFIGURACIÓN DE SEGURIDAD: ");
        Console.ResetColor();
        Console.WriteLine("Utilice una contraseña para proteger su usuario.");
        Console.WriteLine("Puede combinar letras, números y caracteres especiales.");
        Console.WriteLine("");
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

        int respuesta;
        String ROL = "";
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\nASIGNACIÓN DE ROLES Y ESTADO: ");
        Console.ResetColor();
        Console.WriteLine("El rol determina los permisos del usuario" +
        "\ndentro del sistema. El estado define si podrá acceder a él. Ambos datos");
        Console.WriteLine("podrán modificarse posteriormente desde el Panel de Administración.");
        Console.WriteLine("");
        do
        {
            Console.WriteLine("¿Qué ROL tendrá este usuario?");
            Console.WriteLine("1. Administrador - 2. Usuario regular");
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
        /* PARA EL MANEJO DE LAS LINEAS EN LOS ARREGLOS
        datos[0] = nombre
        datos[1] = apellido
        datos[2] = usuario
        datos[3] = contraseña
        datos[4] = rol
        datos[5] = estado
        */
        File.AppendAllText(usuarios,USUARIOS + Environment.NewLine);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n¡Usuario registrado con éxito!");
        Console.ResetColor();
        Console.WriteLine("Regresará al Panel de Administración.");
    }
}