using System.Runtime.InteropServices;

class MODIFICAR_LIBROS()
{
    static String libros = ".//archivos//libros.csv";
    public static void CAMBIAR_LIBROS()
    {
        string repetir = "";
        int respuesta;
        int indice_libro;

        do
        {
        Decoraciones.ENCABEZADO();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                         PANEL DE MODIFICACIÓN DE LIBROS");
        Console.ResetColor();

        indice_libro = BUSQUEDA_LIBROS.BUSQUEDA_ID();
        if (indice_libro == -1)
        {
            repetir = VALIDAR.SI_NO("¿Desea registrar otro libro? (S/N): ");
            if (repetir == "N")
            {
                return;
            }
            continue;
        }
        Console.WriteLine("");
        Console.WriteLine(
            "1. Editar descripción del libro \n" +
            "2. Editar el estado del libro \n");
        respuesta = VALIDAR.OPCION("Digite el número de la opción que desea realizar: ",1,2);

        switch (respuesta)
        {
            case 1:
                EDITAR_DESCRIPCION(indice_libro);
                repetir = VALIDAR.SI_NO("¿Desea modificar otro libro? (S/N): ");
                break;
            case 2:
                EDITAR_ESTADO(indice_libro);
                repetir = VALIDAR.SI_NO("¿Desea modificar otro libro? (S/N): ");
                break;
            default:
                break;
        }
        } while (repetir == "S");
    }

    static void EDITAR_DESCRIPCION(int indice)
    {
        string[] lineas = File.ReadAllLines(libros);

        string[] datos = lineas[indice].Split(';');

        Decoraciones.ENCABEZADO();
        Decoraciones.TEXTO_CYAN("                   EDITAR DESCRIPCIÓN DEL LIBRO");


        Console.WriteLine($"\n{datos[1]}  -  {datos[2]}");
        Console.WriteLine($"Descripción actual: {datos[4]}");
        Console.WriteLine();

        string nuevaDescripcion = VALIDAR.NO_VACIO("Ingrese la nueva descripción: ");

        datos[4] = nuevaDescripcion;

        lineas[indice] = string.Join(";", datos);

        File.WriteAllLines(libros, lineas);

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nDescripción modificada con éxito.");
        Console.ResetColor();
        
    }

    static void EDITAR_ESTADO(int indice)
    {
        string[] lineas = File.ReadAllLines(libros);

        string[] datos = lineas[indice].Split(';');

        Decoraciones.ENCABEZADO();
        Decoraciones.TEXTO_CYAN("                      EDITAR ESTADO DEL LIBRO");
        Console.WriteLine();

        Console.WriteLine($"{datos[1]}  -  {datos[2]}");
        Console.WriteLine($"Estado actual: {datos[6]}");

        Decoraciones.cargando();

        if (datos[6].Equals("Activo", StringComparison.OrdinalIgnoreCase))
        {
            datos[6] = "Inactivo";
        }
        else
        {
            datos[6] = "Activo";
        }

        lineas[indice] = string.Join(";", datos);

        File.WriteAllLines(libros, lineas);

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"\nEstado actualizado a: {datos[6]}");
        Console.ResetColor();
    }
}