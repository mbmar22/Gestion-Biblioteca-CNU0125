class BUSQUEDA_LIBROS
{
    static String libros = ".//archivos//libros.csv";

    public static void BUSCAR_LIBROS()
    {
        Decoraciones.ENCABEZADO();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                         PANEL DE BÚSQUEDA DE LIBROS");
        Console.ResetColor();


        Console.WriteLine("");
        Console.WriteLine(
                "1. Buscar un libro por su ID \n" +
                "2. Buscar un libro  por su nombre\n" +
                "3. Buscar un libro por ID de categoría"
            );
        Console.WriteLine("");

        int respuesta;
        Console.Write("Digite el número de la acción que desea realizar: ");
        while ((!int.TryParse(Console.ReadLine(), out respuesta)) || (respuesta < 1 || respuesta > 3))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("¡ ERROR ! Debe ingresar una opción válida (1-3).");
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
            default:
                break;
        }
    }
}