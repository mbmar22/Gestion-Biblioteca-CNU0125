class INVENTARIO_LIBROS
{
    static String libros = ".//archivos//libros.csv";

    public static void MOSTRAR_INVENTARIO()
    {
        String[] lineas = File.ReadAllLines(libros);

        Decoraciones.ENCABEZADO();
        Console.WriteLine("                           INVENTARIO DE LIBROS");

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("ID       TÍTULO                          AUTOR                  CATEGORÍA              ESTADO");
        Console.ResetColor();

        Decoraciones.SEPARADOR();

        for (int i = 0; i < lineas.Length; i++)
        {
            String[] datos = lineas[i].Split(';');

            if (datos.Length < 8)
            {
                continue;
            }
            Console.WriteLine("{0,-8}{1,-32}{2,-24}{3,-24}{4,-10}{5,-16}",
            datos[0],
            datos[1],
            datos[2],
            datos[3],
            datos[6],
            datos[5]);

            Decoraciones.SEPARADOR();
        }

        Console.WriteLine();
        Decoraciones.SALIR_AL_PANEL();
    }
}