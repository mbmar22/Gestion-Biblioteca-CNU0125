class MENUS
{
    static String usuarios = ".//archivos//usuarios.csv";
    public static void MENU_ADMIN()
    {
        int respuesta;
        do
        {
            Console.WriteLine("        ──────────────────────────────────────────────────────────────");
            Decoraciones.ENCABEZADO();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                           PANEL DE ADMINISTRACIÓN");
            Console.ResetColor();
            Console.WriteLine("Como administrador, puede realizar las siguientes acciones en el sistema \n" +
            "                       de gestión de biblioteca: ");
            Console.WriteLine("");
            Console.WriteLine(
                "1. Ver todos los libros \n" +
                "2. Registrar libro nuevo \n" +
                "3. Buscar libro \n" +
                "4. Prestar un libro disponible \n" +
                "5. Devolver libro prestado \n" +
                "6. Modificar información del libro \n" +
                "7. Registrar nuevo usuario \n" +
                "8. Administrar usuarios \n" +
                "9. Registrar nueva categoría \n" +
                "10. Salir"
            );
            Console.WriteLine("");
            Console.Write("Digite el número de la acción que desea realizar: ");
            while (!int.TryParse(Console.ReadLine(), out respuesta))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Debe ingresar una opción válida (1-10).");
                Console.ResetColor();
                Console.Write("Digite el número de la acción que desea realizar: ");
            }

            switch (respuesta)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    ADMINISTRACION_USUARIOS.CREAR_USUARIO();
                    break;
                case 8:
                    ADMINISTRACION_USUARIOS.MANEJAR_USUARIO();
                    break;
                case 9:
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("¡Hasta la próxima! Adiós.");
                    Console.ResetColor();
                    Console.WriteLine("© Math Library 2026");
                    break;
                default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Debe ingresar una opción válida (1-9).");
                Console.ResetColor();
                    break;
            }
        } while (respuesta != 10);
    }
    public static void MENU_USUARIO()
    {
        int respuesta;
        do
        {
            Decoraciones.ENCABEZADO();
            Console.WriteLine("        ──────────────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                               PANEL DE USUARIO");
            Console.ResetColor();
            Console.WriteLine("Como usuario estándar, puede realizar las siguientes acciones en el sistema \n" +
                "                       de gestión de biblioteca: ");
            Console.WriteLine("");
            Console.WriteLine(
                    "1. Ver libros \n" +
                    "2. Buscar libro\n" +
                    "3. Prestar libro \n" +
                    "4. Ver mi historial de préstamos \n" +
                    "5. Cambiar contraseña \n" +
                    "6. Salir"
                );
            Console.WriteLine("");
            Console.Write("Digite el número de la acción que desea realizar: ");
            while (!int.TryParse(Console.ReadLine(), out respuesta))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Debe ingresar una opción válida (1-5).");
                Console.ResetColor();
                Console.Write("Digite el número de la acción que desea realizar: ");
            }

            switch (respuesta)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("¡Hasta la próxima! Adiós.");
                    Console.ResetColor();
                    Console.WriteLine("© Math Library 2026");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡ ERROR ! Debe ingresar una opción válida (1-5).");
                    Console.ResetColor();
                    break;
            }
        } while (respuesta != 6);
    }
}