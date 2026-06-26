class INVENTARIO_LIBROS
{
    static String libros = ".//archivos//libros.csv";

    public static void MOSTRAR_INVENTARIO()
    {
        string[] lineas = File.ReadAllLines(libros);

        Decoraciones.ENCABEZADO();
        Console.WriteLine("                                    MOSTRANDO EL INVENTARIO DE LIBROS");

        Console.WriteLine("\n+----------+----------------------------------+--------------------------+--------------------------+------------+");
        Console.Write("| ");
        Decoraciones.COLORES_TITULARES("ID", 8);
        Decoraciones.COLORES_TITULARES("Título", 32);
        Decoraciones.COLORES_TITULARES("Autor", 24);
        Decoraciones.COLORES_TITULARES("Categoría",24);
        Decoraciones.COLORES_TITULARES("Estado",10);
        Console.WriteLine("\n+----------+----------------------------------+--------------------------+--------------------------+------------+");

        foreach (string linea in lineas)
        {
            string[] datos = linea.Split(';');

            if (datos.Length < 6)
            {
                continue;
            }

            Console.WriteLine(
                $"| {datos[0],-8} | {datos[1],-32} | {datos[2],-24} | {datos[3],-24} | {datos[5],-10} |"
            );

            Console.WriteLine("+----------+----------------------------------+--------------------------+--------------------------+------------+");
        }

        Console.WriteLine();
        Decoraciones.SALIR_AL_PANEL();
    }
}