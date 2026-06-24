class INVENTARIO_LIBROS
{
    static String libros = ".//archivos//libros.csv";

    public static void MOSTRAR_INVENTARIO()
    {
        string[] lineas = File.ReadAllLines(libros);

        // Anchos mínimos para los encabezados
        int anchoID = 8;
        int anchoTitulo = 32;
        int anchoAutor = 24;
        int anchoCategoria = 24;
        int anchoEstado = 10;

        // PRIMER RECORRIDO: calcular anchos
        foreach (string linea in lineas)
        {
            string[] datos = linea.Split(';');

            if (datos.Length < 6)
                continue;

            if (datos[0].Length > anchoID)
                anchoID = datos[0].Length;

            if (datos[1].Length > anchoTitulo)
                anchoTitulo = datos[1].Length;

            if (datos[2].Length > anchoAutor)
                anchoAutor = datos[2].Length;

            if (datos[3].Length > anchoCategoria)
                anchoCategoria = datos[3].Length;

            if (datos[5].Length > anchoEstado)
                anchoEstado = datos[5].Length;
        }

        string separador =
            "+" + new string('-', anchoID + 2) +
            "+" + new string('-', anchoTitulo + 2) +
            "+" + new string('-', anchoAutor + 2) +
            "+" + new string('-', anchoCategoria + 2) +
            "+" + new string('-', anchoEstado + 2) + "+";

        Decoraciones.ENCABEZADO();
        Console.WriteLine("\nMOSTRANDO EL INVENTARIO DE LIBROS");
        Decoraciones.cargando();
        Console.WriteLine();
        Console.WriteLine(separador);

        Decoraciones.TEXTO_CYAN(
        "| " + "ID".PadRight(anchoID) +
        " | " + "Título".PadRight(anchoTitulo) +
        " | " + "Autor".PadRight(anchoAutor) +
        " | " + "Categoría".PadRight(anchoCategoria) +
        " | " + "Estado".PadRight(anchoEstado) + " |");

        Console.WriteLine(separador);

        // SEGUNDO RECORRIDO: para imprimir con formato
        foreach (string linea in lineas)
        {
            string[] datos = linea.Split(';');

            if (datos.Length < 6)
            {
                continue;
            }

            Console.WriteLine(
            "| " + datos[0].PadRight(anchoID) +
            " | " + datos[1].PadRight(anchoTitulo) +
            " | " + datos[2].PadRight(anchoAutor) +
            " | " + datos[3].PadRight(anchoCategoria) +
            " | " + datos[5].PadRight(anchoEstado) + " |"
        );
            Console.WriteLine(separador);
        }

        Console.WriteLine();
        Decoraciones.SALIR_AL_PANEL();
    }
}