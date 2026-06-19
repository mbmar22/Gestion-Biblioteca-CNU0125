class MENUS
{
    static String usuarios = ".//archivos//usuarios.csv";
    public static void MENU_ADMIN()
    {
        string confirmacion = "\n¿Está seguro de que desea realizar esta acción? (S/N): ";
        int respuesta;
        do
        {
            Decoraciones.ENCABEZADO();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                           PANEL DE ADMINISTRACIÓN");
            Console.ResetColor();
            
            Decoraciones.OPCIONES_ADMIN();
            

            respuesta = VALIDAR.OPCION("Digite el número de la acción que desea realizar: ", 1,11);

            switch (respuesta)
            {
                case 1:
                    break;
                case 2:
                    if (VALIDAR.CONFIRMAR(confirmacion))
                    {
                        REGISTRO_LIBROS.REGISTRAR();
                    }
                    break;
                case 3:
                    BUSQUEDA_LIBROS.BUSCAR_LIBROS();  
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    if (VALIDAR.CONFIRMAR(confirmacion))
                    {
                        ADMINISTRACION_USUARIOS.CREAR_USUARIO();
                    }
                    break;
                case 8:
                    if (VALIDAR.CONFIRMAR(confirmacion))
                    {
                        ADMINISTRACION_USUARIOS.MANEJAR_USUARIO();
                    }
                    break;
                case 9:
                    if (VALIDAR.CONFIRMAR(confirmacion))
                    {
                        ADMINISTRACION_CATEGORIAS.CREAR_CATEGORIA();
                    }
                    break;
                case 10:
                    break;
                case 11:
                    Decoraciones.despedida();
                    break;
                default:
                    break;
            }
        } while (respuesta != 11);
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
            
            Decoraciones.OPCIONES_USER();

            respuesta = VALIDAR.OPCION("Digite el número de la acción que desea realizar: ", 1,6);

            switch (respuesta)
            {
                case 1:
                    break;
                case 2:
                    BUSQUEDA_LIBROS.BUSCAR_LIBROS();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    Decoraciones.despedida();
                    break;
                default:
                    break;
            }
        } while (respuesta != 6);
    }
}