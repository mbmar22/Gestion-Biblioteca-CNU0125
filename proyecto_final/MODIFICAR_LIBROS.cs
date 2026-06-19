class MODIFICAR_LIBROS()
{
    public static void CAMBIAR_LIBROS()
    {
        string repetir;
        int respuesta;

        Decoraciones.ENCABEZADO();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                           PANEL DE MODIFICACIÓN DE LIBROS");
        Console.ResetColor();

        BUSQUEDA_LIBROS.BUSQUEDA_ID();
        Console.WriteLine("");
        Console.WriteLine(
            "1. Editar descripción del libro \n" +
            "2. Edita el estado del libro \n");
        respuesta = VALIDAR.OPCION("Digite el número de la opción que desea realizar: ",1,2);

        switch (respuesta)
        {
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
    }
}