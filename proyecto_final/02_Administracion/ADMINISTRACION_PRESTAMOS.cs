class ADMINISTRACION_PRESTAMOS
{
    public static void MENU_ADMIN_PRESTAMOS()
    {
        int respuesta;

        do
        {
            Decoraciones.ENCABEZADO();
            Decoraciones.TEXTO_CYAN("           PANEL DE ADMINISTRACIÓN DE PRÉSTAMOS\n");

            Console.WriteLine(
                "1. Ver historial de préstamos\n" +
                "2. Prestar libro\n" +
                "3. Gestionar la devolución de libros\n" +
                "4. Regresar\n");

            respuesta = VALIDAR.OPCION("Seleccione una opción: ", 1, 4);

            switch (respuesta)
            {
                case 1:
                    PRESTAMOS.MOSTRAR_PRESTAMOS_ADMIN();
                    break;

                case 2:
                    PRESTAMOS.PRESTAR_LIBRO(true);
                    break;

                case 3:
                    PRESTAMOS.DEVOLVER_LIBRO();
                    break;

                case 4:
                    return;
            }

        } while (true);
    }
    public static void MENU_USUARIO_PRESTAMOS()
    {
        int respuesta;
        do
        {
            Decoraciones.ENCABEZADO();
            Decoraciones.TEXTO_CYAN("            PANEL DE GESTIÓN DE PRÉSTAMOS\n");

            Console.WriteLine(
                "1. Ver préstamos realizados\n" +
                "2. Prestar libro\n" +
                "3. Regresar\n");
            respuesta = VALIDAR.OPCION("Seleccione una opción: ", 1, 3);

            switch (respuesta)
            {
                case 1:
                    PRESTAMOS.MOSTRAR_PRESTAMOS_USER();
                    break;

                    case 2:
                    PRESTAMOS.PRESTAR_LIBRO(false);
                    break;

                    case 3:
                    return;
                }
            } while (respuesta != 3);
        }
    }