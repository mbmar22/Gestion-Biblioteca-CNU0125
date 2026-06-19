class BUSQUEDA_LIBROS
{
    static String libros = ".//archivos//libros.csv";

    public static void BUSCAR_LIBROS()
    {
        string repetir;

        do
        {
            Decoraciones.ENCABEZADO();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                         PANEL DE BÚSQUEDA DE LIBROS");
            Console.ResetColor();

            Console.WriteLine("");
            Console.WriteLine(
                "1. Buscar un libro por su nombre\n" +
                "2. Buscar un libro por categoría");
            Console.WriteLine("");

            int respuesta = VALIDAR.OPCION("Digite el número de la acción que desea realizar: ", 1, 2);

            switch (respuesta)
            {
                case 1:
                    BUSQUEDA_NOMBRE();
                    break;

                case 2:
                    BUSQUEDA_CATEGORIA();
                    break;
            }

            Console.WriteLine();
            repetir = VALIDAR.SI_NO("¿Desea realizar otra búsqueda? (S/N): ");

        } while (repetir == "S");
    }

    static void BUSQUEDA_NOMBRE()
    {
        Decoraciones.ENCABEZADO();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                    PANEL DE BÚSQUEDA DE LIBROS POR NOMBRE");
        Console.ResetColor();
        Console.WriteLine();

        String nombre_buscado = VALIDAR.NO_VACIO("Ingrese el nombre del libro que desea buscar: ");
        

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
            Console.WriteLine("No se han encontrado libros que coincidan con su búsqueda");
            Console.ResetColor();

        }

    }

    static String categorias = ".//archivos//categorias.csv";
    static void BUSQUEDA_CATEGORIA()
    {
        Decoraciones.ENCABEZADO();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                  PANEL DE BÚSQUEDA DE LIBROS POR CATEGORÍA");
        Console.ResetColor();
        Console.WriteLine();

        Decoraciones.mostrar_categorias();
        string categoria_buscada = VALIDAR.NO_VACIO("Ingrese el nombre de la categoría que desea buscar: ");
        

        String[] lineas = File.ReadAllLines(libros);
        bool encontrado = false;

        for (int i = 0; i < lineas.Length; i++)
        {
            String[] datos = lineas[i].Split(';');

            if (datos.Length > 7) // para evitar el out of index range
            {
                if (datos[3].Contains(categoria_buscada, StringComparison.OrdinalIgnoreCase))
                {
                    encontrado = true;
                    Console.WriteLine();


                    Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");

                    Console.Write("│ ");
                    Console.WriteLine(("ID: " + datos[0]).PadRight(60) + " │");

                    Console.Write("│ ");
                    Console.WriteLine(("Título: " + datos[1]).PadRight(60) + " │");

                    Console.Write("│ ");
                    Console.WriteLine(("Autor: " + datos[2]).PadRight(60) + " │");

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
            Console.WriteLine("No se han encontrado libros que coincidan con su búsqueda");
            Console.ResetColor();
        }
    }
}