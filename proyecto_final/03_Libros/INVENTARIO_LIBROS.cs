class INVENTARIO_LIBROS
{
    static String libros = ".//archivos//libros.csv";

    public static void MOSTRAR_INVENTARIO()
    {
        String[] lineas = File.ReadAllLines(libros);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("ID           TÍTULO                    AUTOR                CATEGORÍA          ESTADO           ");
        Console.ResetColor();

        Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────");

        for (int i = 0; i < lineas.Length; i++)
        {
            String[] datos = lineas[i].Split(';');

            if (datos.Length < 8)
            {
                continue;
            }
            Console.WriteLine("{0,-12}{1,-25}{2,-22}{3,-20}{4,-10}",
            datos[0],
            datos[1],
            datos[2],
            datos[3],
            datos[6]);

            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────");
        }

        Console.WriteLine();
        Decoraciones.SALIR_AL_PANEL();
    }
}