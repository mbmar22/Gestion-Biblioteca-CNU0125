class CrearUsuario
{
    static String usuarios = ".//archivos//usuarios.txt";
    public static void CREAR_USUARIO()
    {
        String NOMBRE;
        Console.WriteLine("        ──────────────────────────────────────────────────────────────");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                        PANEL DE CREACIÓN DE USUARIOS");
        Console.ResetColor();
        do
        {
            Console.Write("Nombre del nuevo usuario: ");
            NOMBRE = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(NOMBRE))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!NOMBRE.Any(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Debe contener al menos una letra.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(NOMBRE) || !NOMBRE.Any(char.IsLetter));

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
        do
        {
            Console.WriteLine("¿Qué función tendrá este usuario?");
            Console.WriteLine("1. Administrador - 2. Usuario regular");
            while (! int.TryParse(Console.ReadLine(), out respuesta))
            {
                Console.WriteLine("ERROR");
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

        String ESTADO = "";
        do
        {
            Console.WriteLine("¿Cuál será el estado de este usuario?");
            Console.WriteLine("1. Estado ACTIVO  - 2. Estado INACTIVO");
            while (! int.TryParse(Console.ReadLine(), out respuesta))
            {
                Console.WriteLine("ERROR");
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

        String USUARIOS = NOMBRE + "," + CLAVE + "," + ROL + "," + ESTADO;
        File.AppendAllText(usuarios,USUARIOS + Environment.NewLine);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n¡Usuario registrado con éxito!");
        Console.ResetColor();
        Console.WriteLine("Regresará al Panel de Administración.");
    }
}