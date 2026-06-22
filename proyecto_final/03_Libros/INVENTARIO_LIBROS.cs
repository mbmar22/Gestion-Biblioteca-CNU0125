class INVENTARIO_LIBROS
{
    static String libros = ".//archivos//libros.csv";

    public static void MOSTRAR_INVENTARIO()
    {
        String[] lineas = File.ReadAllLines(libros);

        Decoraciones.ENCABEZADO();
        Decoraciones.TEXTO_CYAN("MOSTRANDO EL INVENTARIO DE LIBROS");

        Decoraciones.TEXTO_CYAN("\nID       TÍTULO                          AUTOR                  CATEGORÍA              ESTADO");
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