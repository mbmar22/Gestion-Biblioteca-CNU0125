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
    }

    static void BUSQUEDA_NOMBRE()
    {
        Decoraciones.ENCABEZADO();
        Decoraciones.TEXTO_CYAN("                  PANEL DE BÚSQUEDA DE LIBROS POR NOMBRE");
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

                    Decoraciones.MOSTRAR_LIBRO(datos);
                }

            }
        }

        if (!encontrado)
        {
            ALERTAS.RESULTADO_NO_ENCONTRADO();

        }

    }

    static String categorias = ".//archivos//categorias.csv";
    static void BUSQUEDA_CATEGORIA()
    {
        Decoraciones.ENCABEZADO();
        Decoraciones.TEXTO_CYAN("                  PANEL DE BÚSQUEDA DE LIBROS POR CATEGORÍA");
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

                    Decoraciones.MOSTRAR_LIBRO(datos);
                }

            }
        }

        if (!encontrado)
        {
            ALERTAS.RESULTADO_NO_ENCONTRADO();
        }
    }

    public static int BUSQUEDA_ID()
    {
        
        string id_buscado = VALIDAR.NO_VACIO("\nIngrese el ID del libro que desea modificar: ");

        string[] lineas = File.ReadAllLines(libros);
        bool encontrado = false;

        for (int i = 0; i < lineas.Length; i++)
        {
            string[] datos = lineas[i].Split(';');

            if (datos.Length > 7)
            {
                if (datos[0].Equals(id_buscado, StringComparison.OrdinalIgnoreCase))
                {
                    encontrado = true;

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n¡Libro encontrado con éxito!");
                    Console.ResetColor();
                    Console.WriteLine();

                    Decoraciones.MOSTRAR_LIBRO(datos);
                    return i;
                }
            }
        }

        if (!encontrado)
        {
            ALERTAS.RESULTADO_NO_ENCONTRADO();
        }
        return -1;
    }
}