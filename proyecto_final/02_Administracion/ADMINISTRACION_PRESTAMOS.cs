using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

// En administración de préstamos se pueden prestar libros, devolver libros, consultar préstamos activos, consultar historial de préstamos, etc.

class ADMINISTRACION_PRESTAMOS
{
    static String libros = ".//archivos//libros.csv";
    static String prestamos = ".//archivos//prestamos.csv";

    public static void MENU_PRESTAMOS()
    {
        Decoraciones.ENCABEZADO();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                ADMINISTRACIÓN DE PRÉSTAMOS Y DEVOLUCIONES");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine(
            "1. Ver historial de préstamos.\n" +
            "2. Prestar libro\n" +
            "3. Devolver libro.");

        Console.WriteLine("");

        int respuesta = VALIDAR.OPCION("Digite el número de la acción que desea realizar: ", 1, 3);

        switch (respuesta)
        {
            case 1:
            MOSTRAR_PRESTAMOS();
                break;
            case 2:
            PRESTAR_LIBRO();
                break;
            case 3:
            DEVOLVER_LIBRO();
                break;
        }

        Console.WriteLine();
    }


    static void MOSTRAR_PRESTAMOS()
    {
        
    }

    static void PRESTAR_LIBRO()
    {
        Decoraciones.ENCABEZADO();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("          PRESTAR LIBRO");
        Console.ResetColor();
        Console.WriteLine();

        String libro_buscado = VALIDAR.NO_VACIO("Ingrese el ID del libro: ");

        String[] lineas = File.ReadAllLines(libros);
        bool encontrado = false;
        int resultados = 0;

        for (int i = 0; i < lineas.Length; i++)
        {
            String[] datos = lineas[i].Split(';');

            if (datos.Length > 7)
            {
                if (datos[0].Contains(libro_buscado, StringComparison.OrdinalIgnoreCase))
                {
                    encontrado = true;
                    resultados++;

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\n¡Libro {encontrado}");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
        }
    }

    static void DEVOLVER_LIBRO()
    {
        
    }
}