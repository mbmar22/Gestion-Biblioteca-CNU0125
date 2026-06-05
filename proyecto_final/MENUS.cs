class MENUS
{
    static String usuarios = ".//archivos//usuarios.txt";
    public static void MENU_ADMIN()
    {
        int respuesta;
        do
        {
        
            Console.WriteLine("        ──────────────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                           PANEL DE ADMINISTRACIÓN");
            Console.ResetColor();
            Console.WriteLine("Como administrador, puede realizar las siguientes acciones en el sistema \n" +
            "                       de gestión de biblioteca: ");
            Console.WriteLine("");
            Console.WriteLine(
                "1. Ver todos los libros \n" +
                "2. Registrar libros nuevos \n" +
                "3. Cambiar status de los libros \n" +
                "4. Prestar libros disponibles \n" +
                "5. Devolver libros \n" +
                "6. Buscar libros \n" +
                "7. Crear Usuario \n" +
                "8. Manejar usuarios \n" +
                "9. Salir"
            );
            Console.WriteLine("");
            Console.Write("Digite el número de la acción que desea realizar: ");
            while (!int.TryParse(Console.ReadLine(), out respuesta))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Debe ingresar una opción válida (1-9).");
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
                    CrearUsuario.CREAR_USUARIO();
                    break;
                case 8:
                    break;
                case 9:
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


        } while (respuesta != 9);
    }
    public static void MENU_USUARIO()
    {
        int respuesta;
        do
        {
            Console.WriteLine("        ──────────────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                               PANEL DE USUARIO");
            Console.ResetColor();
            Console.WriteLine("Como usuario estándar, puede realizar las siguientes acciones en el sistema \n" +
                "                       de gestión de biblioteca: ");
            Console.WriteLine("");
            Console.WriteLine(
                    "1. Ver libros disponibles \n" +
                    "2. Prestar libros disponibles \n" +
                    "3. Devolver libros \n" +
                    "4. Buscar libros \n" +
                    "5. Salir"
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
        } while (respuesta != 5);
    }
}