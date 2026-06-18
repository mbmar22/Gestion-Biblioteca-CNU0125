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
                "1. Buscar un libro por su nombre\n" +
                "2. Buscar un libro por categoría"
            );
        Console.WriteLine("");

        int respuesta;
        Console.Write("Digite el número de la acción que desea realizar: ");
        while ((!int.TryParse(Console.ReadLine(), out respuesta)) || (respuesta != 1 && respuesta != 2))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("¡ ERROR ! Debe ingresar una opción válida (1-2).");
            Console.ResetColor();
            Console.Write("Digite el número de la acción que desea realizar: ");
        }
        switch (respuesta)
        {
            case 1:
                BUSQUEDA_NOMBRE();
                break;
            case 2:
                BUSQUEDA_CATEGORIA();
                break;
            default:
                break;
        }
    }

    static void BUSQUEDA_NOMBRE()
    {
        String nombre_buscado;
        do
        {
            Console.Write("Ingrese el nombre del libro que desea consultar: ");
            nombre_buscado = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(nombre_buscado))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
        } while (String.IsNullOrWhiteSpace(nombre_buscado));

        String[] lineas = File.ReadAllLines(libros);
        bool encontrado = false;
        int resultados = 0;

        for (int i = 0; i < lineas.Length; i++)
        {
            String[] datos = lineas[i].Split(';');

            if (datos.Length > 7) // para evitar el out of index range
            {
                if (datos[1].Contains(nombre_buscado, StringComparison.OrdinalIgnoreCase))
                {
                    encontrado = true;
                    resultados++;

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\n¡Libro nº {resultados} encontrado con éxito!");
                    Console.WriteLine();
                    Console.ResetColor();


                    Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");

                    Console.Write("│ ");
                    Console.WriteLine(("ID: " + datos[0]).PadRight(60) + " │");

                    Console.Write("│ ");
                    Console.WriteLine(("Título: " + datos[1]).PadRight(60) + " │");

                    Console.Write("│ ");
                    Console.WriteLine(("Autor: " + datos[2]).PadRight(60) + " │");

                    Console.Write("│ ");
                    Console.WriteLine(("Categoría: " + datos[3]).PadRight(60) + " │");

                    Console.Write("│ ");
                    Console.WriteLine(("Estado: " + datos[6]).PadRight(60) + " │");

                    Console.Write("│ ");
                    Console.WriteLine(("Registrado: " + datos[7]).PadRight(60) +  " │");

                    Console.Write("│ ");
                    Console.WriteLine(("Descripción: " + datos[4]).PadRight(60) + " │");

                    Console.WriteLine("└──────────────────────────────────────────────────────────────┘");
                }

            }
        }

        if (!encontrado)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No se han encontrado libros que coincidan con tu búsqueda");
            Console.ResetColor();
            Console.WriteLine("Regresarás al menú principal");
            Console.WriteLine("");
        }

    }

    static void BUSQUEDA_CATEGORIA()
    {
        
    }
}