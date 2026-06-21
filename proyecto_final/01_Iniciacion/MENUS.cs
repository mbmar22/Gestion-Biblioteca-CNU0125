using System.Formats.Asn1;

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
            

            respuesta = VALIDAR.OPCION("Digite el número de la acción que desea realizar: ", 1,10);

            switch (respuesta)
            {
                case 1:
                    INVENTARIO_LIBROS.MOSTRAR_INVENTARIO();
                    break;
                case 2:
                    if (VALIDAR.CONFIRMAR(confirmacion))
                    {
                        REGISTRO_LIBROS.REGISTRAR();
                    }
                    break;
                case 3:
                    string repetir;
                    do
                    {
                        BUSQUEDA_LIBROS.BUSCAR_LIBROS();
                        repetir = VALIDAR.SI_NO("¿Desea realizar otra búsqueda? (S/N): ");
                    }  while (repetir == "S");
                    break;
                case 4:
                    do
                    {
                        ADMINISTRACION_PRESTAMOS.MENU_PRESTAMOS();
                        repetir = VALIDAR.SI_NO("¿Desea realizar algún préstamo, devolución o visualizar el registro de préstamos? (S/N): ");
                    } while (repetir == "S");
                    break;
                case 5:
                    if (VALIDAR.CONFIRMAR(confirmacion))
                    {
                        MODIFICAR_LIBROS.CAMBIAR_LIBROS();
                    }
                    break;
                case 6:
                    if (VALIDAR.CONFIRMAR(confirmacion))
                    {
                        ADMINISTRACION_USUARIOS.CREAR_USUARIO();
                    }
                    break;
                case 7:
                    if (VALIDAR.CONFIRMAR(confirmacion))
                    {
                        ADMINISTRACION_USUARIOS.MANEJAR_USUARIO();
                    }
                    break;
                case 8:
                    if (VALIDAR.CONFIRMAR(confirmacion))
                    {
                        ADMINISTRACION_CATEGORIAS.CREAR_CATEGORIA();
                    }
                    break;
                case 9:
                    if (VALIDAR.CONFIRMAR(confirmacion))
                    {
                        bool cerrar_sesion = CAMBIO_CLAVE.MODIFICAR_CLAVE();
                        if (cerrar_sesion)
                        {
                            return;
                        }
                    }
                    break;
                case 10:
                    Decoraciones.despedida();
                    break;
                default:
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
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                               PANEL DE USUARIO");
            Console.ResetColor();
            
            Decoraciones.OPCIONES_USER();
            string confirmacion = "\n¿Está seguro de que desea realizar esta acción? (S/N): ";
            respuesta = VALIDAR.OPCION("Digite el número de la acción que desea realizar: ", 1,6);

            switch (respuesta)
            {
                case 1:
                    INVENTARIO_LIBROS.MOSTRAR_INVENTARIO();
                    break;
                case 2:
                    string repetir;
                    do
                    {
                        BUSQUEDA_LIBROS.BUSCAR_LIBROS();
                        repetir = VALIDAR.SI_NO("¿Desea realizar otra búsqueda? (S/N): ");
                    }  while (repetir == "S");
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    if (VALIDAR.CONFIRMAR(confirmacion))
                    {
                        bool cerrar_sesion = CAMBIO_CLAVE.MODIFICAR_CLAVE();
                        if (cerrar_sesion)
                        {
                            return;
                        }
                    }
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