class INVENTARIO_LIBROS
{
    static String libros = ".//archivos//libros.csv";

    public static void MOSTRAR_INVENTARIO()
    {
        String[] lineas = File.ReadAllLines(libros);

        Decoraciones.INVENTARIO_ENCABEZADO();
        
        for (int i = 0; i < lineas.Length; i++)
        {
            String[] datos = lineas[i].Split(';');

            if (datos.Length < 8)
                continue;

            if (datos[1].Length > 20)
                datos[1] = datos[1].Substring(0, 17) + "...";

            if (datos[2].Length > 20)
                datos[2] = datos[2].Substring(0, 17) + "...";

            if (datos[3].Length > 16)
                datos[3] = datos[3].Substring(0, 13) + "...";

            Console.WriteLine(
                "│ {0,-6} │ {1,-20} │ {2,-20} │ {3,-16} │ {4,-8} │",
                datos[0],
                datos[1],
                datos[2],
                datos[3],
                datos[6]
            );

            if (i < lineas.Length - 1)
            {
                Console.WriteLine("├────────┼──────────────────────┼──────────────────────┼──────────────────┼──────────┤");
            }
        }

        Console.WriteLine("└────────┴──────────────────────┴──────────────────────┴──────────────────┴──────────┘");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("Presione cualquier tecla para regresar al panel...");
        Console.ResetColor();
        Console.ReadKey();
    }
}