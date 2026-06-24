using System.Linq;

class PRESTAMOS
{
    public static void PRESTAR_LIBRO(bool es_administrador)
    {
        string repetir = "";

        CREAR_ARCHIVO_PRESTAMOS();

        do
        {
            Decoraciones.PRESTAR_LIBRO();

            string[]? libro = BUSCAR_LIBRO();

            if (libro == null)
            {
                ALERTAS.RESULTADO_NO_ENCONTRADO();
                continue;
            }

            // estado del catálogo (NO del préstamo)
            string estadoCatalogo = libro[5].Trim(); // Activo / Inactivo

            if (!estadoCatalogo.Equals("Activo", StringComparison.OrdinalIgnoreCase))
            {
                ALERTAS.LIBRO_NO_DISPONIBLE();
                continue;
            }

            // estado real de disponibilidad (según préstamos)
            string estadoPrestamo = libro[^1].Trim();

            if (!estadoPrestamo.Equals("Disponible", StringComparison.OrdinalIgnoreCase))
            {
                ALERTAS.LIBRO_NO_DISPONIBLE();
                continue;
            }

            Decoraciones.MOSTRAR_LIBRO(libro);

            string resp = VALIDAR.SI_NO($"\n¿Es '{libro[1]}' el libro que desea prestar? (S/N): ");

            if (resp == "S")
            {
                string usuario = OBTENER_USUARIO(es_administrador);
                GUARDAR_PRESTAMO(libro[0], usuario);
                Decoraciones.TEXTO_VERDE("¡Préstamo realizado con éxito!");
            }

            repetir = VALIDAR.SI_NO("\n¿Desea prestar otro libro? (S/N): ");

        } while (repetir == "S");
    }

    static void CREAR_ARCHIVO_PRESTAMOS()
    {
        string prestamos = ".//archivos//prestamos.csv";

        if (!File.Exists(prestamos) || new FileInfo(prestamos).Length == 0)
        {
            using (StreamWriter sw = new StreamWriter(prestamos, true))
            {
                sw.WriteLine("IdPrestamo;IdLibro;UsuarioId;Disponibilidad;FechaPrestamo;FechaDevolucion");
            }
        }
    }


    static string[]? BUSCAR_LIBRO()
    {
        string libros = ".//archivos//libros.csv";
        string prestamos = ".//archivos//prestamos.csv";

        string libroBuscado = VALIDAR.NO_VACIO("Ingrese el ID del libro: ");
        
        if (VALIDAR.SALIR(libroBuscado))
        {
            return null;
        }

        string[] lineasLibros = File.ReadAllLines(libros);

        string[]? libroEncontrado = null;

        string estadoCatalogo = "";

        // 1. Buscar en libros.csv
        foreach (string linea in lineasLibros)
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;

            string[] datos = linea.Split(';');

            if (datos.Length >= 6 &&
                datos[0].Trim().Equals(libroBuscado, StringComparison.OrdinalIgnoreCase))
            {
                libroEncontrado = datos;
                estadoCatalogo = datos[5].Trim(); // Estado del catálogo: Activo/Inactivo
                break;
            }
        }

        if (libroEncontrado == null)
            return null;

        // 2. Revisar historial de préstamos (último estado)
        string estadoPrestamo = "Disponible";

        if (File.Exists(prestamos))
        {
            string[] lineasPrestamos = File.ReadAllLines(prestamos);

            for (int i = lineasPrestamos.Length - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(lineasPrestamos[i])) continue;

                string[] datosPrestamo = lineasPrestamos[i].Split(';');

                if (datosPrestamo.Length >= 4 &&
                    datosPrestamo[1].Trim().Equals(libroBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    estadoPrestamo = datosPrestamo[3].Trim(); // Disponible / Prestado
                    break;
                }
            }
        }

        // 3. Resultado final
        string[] resultado = new string[libroEncontrado.Length + 1];
        libroEncontrado.CopyTo(resultado, 0);
        resultado[^1] = estadoPrestamo;

        return resultado;
    }

    static string OBTENER_USUARIO(bool es_administrador)
    {
        if (es_administrador)
        {
            return BUSCAR_USUARIO();
        }

        return INICIAR_SESION.Sesion.IdUsuario;
    }

    public static string BUSCAR_USUARIO()
    {
        string usuarios = ".//archivos//usuarios.csv";
        string respuesta;

        do
        {
            string USUARIO_BUSCADO = VALIDAR.USERNAME_ID_VALIDO("\nIngrese el ID del usuario: ");

            string[] lineas = File.ReadAllLines(usuarios);

            string nombre_usuario = "";
            string ID_usuario = "";

            foreach (string linea in lineas)
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;

                string[] datos = linea.Split(';');

                if (datos.Length > 6)
                {
                    if (datos[0].Equals(USUARIO_BUSCADO, StringComparison.OrdinalIgnoreCase))
                    {
                        nombre_usuario = datos[1];
                        ID_usuario = datos[0];
                        break;
                    }
                }
            }

            if (ID_usuario == "")
            {
                ALERTAS.RESULTADO_NO_ENCONTRADO();
                continue;
            }

            respuesta = VALIDAR.SI_NO($"\n¿Es '{nombre_usuario}' el usuario que busca? (S/N): ");

            if (respuesta == "S")
            {
                return ID_usuario;
            }

        } while (true);
    }

    static string GENERAR_ID_PRESTAMO()
    {
        string prestamos = ".//archivos//prestamos.csv";

        if (!File.Exists(prestamos))
        {
            return "001P";
        }

        string[] lineas = File.ReadAllLines(prestamos);
        int contador = 0;

        foreach (string linea in lineas.Skip(1))
        {
            if (!string.IsNullOrWhiteSpace(linea))
            {
                contador++;
            }
        }

        return $"{contador + 1:D3}P";
    }

    static void GUARDAR_PRESTAMO(string idLibro, string idUsuario)
    {
        string prestamos = ".//archivos//prestamos.csv";

        string idPrestamo = GENERAR_ID_PRESTAMO();

        using (StreamWriter sw = new StreamWriter(prestamos, true))
        {
            sw.WriteLine($"{idPrestamo};{idLibro};{idUsuario};Prestado;{DateTime.Now};Pendiente");
        }
    }

    public static void MOSTRAR_PRESTAMOS_ADMIN()
    {
        string prestamos = ".//archivos//prestamos.csv";
        string[] lineas = File.ReadAllLines(prestamos);

        Console.WriteLine("\n+-------------+----------+------------+----------------+----------------+------------------+");
        Console.Write("| ");
        Decoraciones.COLORES_TITULARES("ID Préstamo", 11);
        Decoraciones.COLORES_TITULARES("ID Libro", 8);
        Decoraciones.COLORES_TITULARES("ID Usuario", 10);
        Decoraciones.COLORES_TITULARES("Disponibilidad", 14);
        Decoraciones.COLORES_TITULARES("Fecha Préstamo", 14);
        Decoraciones.COLORES_TITULARES("Fecha Devolución", 16);
        Console.WriteLine("\n+-------------+----------+------------+----------------+----------------+------------------+");

        foreach (string linea in lineas.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;

            string[] columnas = linea.Split(';');
            if (columnas.Length < 6) continue;

            DateTime fecha;
            bool fechaValida = DateTime.TryParse(columnas[4], out fecha);

            Console.Write($"| {columnas[0],-11} | {columnas[1],-8} | {columnas[2],-10} | {columnas[3],-14} | {(fechaValida ? fecha.ToString("dd/MM/yyyy") : columnas[4]),-14} | ");

            if (columnas[5].Trim().Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
            {
                Decoraciones.PRESTAMO_PENDIENTE($"{columnas[5].Trim(),-16}");
                Console.Write(" |");
            }
            else
            {
                Console.Write($"{columnas[5].Trim(),-16} |");
            }

            Console.WriteLine();
            Console.WriteLine("+-------------+----------+------------+----------------+----------------+------------------+");
        }
    }

    public static void MOSTRAR_PRESTAMOS_USER()
    {
        string prestamos = ".//archivos//prestamos.csv";
        string[] lineas = File.ReadAllLines(prestamos);

        Console.WriteLine("\n+-------------+----------+----------------+----------------+------------------+");
        Console.Write("| ");
        Decoraciones.COLORES_TITULARES("ID Préstamo", 11);
        Decoraciones.COLORES_TITULARES("ID Libro", 8);
        Decoraciones.COLORES_TITULARES("Disponibilidad", 14);
        Decoraciones.COLORES_TITULARES("Fecha Préstamo", 14);
        Decoraciones.COLORES_TITULARES("Fecha Devolución", 16);
        Console.WriteLine("\n+-------------+----------+----------------+----------------+------------------+");

        foreach (string linea in lineas.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;

            string[] columnas = linea.Split(';');
            if (columnas.Length < 6) continue;

            if (!columnas[2].Trim().Equals(INICIAR_SESION.Sesion.IdUsuario, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            DateTime fecha;
            bool fechaValida = DateTime.TryParse(columnas[4], out fecha);

            Console.Write($"| {columnas[0],-11} | {columnas[1],-8} | {columnas[3],-14} | {(fechaValida ? fecha.ToString("dd/MM/yyyy") : columnas[4]),-14} | ");

            if (columnas[5].Trim().Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
            {
                Decoraciones.PRESTAMO_PENDIENTE($"{columnas[5].Trim(),-16}");
            }
            else
            {
                Console.Write($"{columnas[5].Trim(),-16}");
            }

            Console.WriteLine(" |");
            Console.WriteLine("+-------------+----------+----------------+----------------+------------------+");
        }
    }

    public static void DEVOLVER_LIBRO()
    {
        string prestamos = ".//archivos//prestamos.csv";

        if (!File.Exists(prestamos))
        {
            Decoraciones.TEXTO_VERDE("No hay préstamos registrados.");
            return;
        }

        string[] lineas = File.ReadAllLines(prestamos);
        string idPrestamo = VALIDAR.PRESTAMO_ID_VALIDO("\nIngrese el ID del préstamo: ");

        bool encontrado = false;

        for (int i = 1; i < lineas.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lineas[i])) continue;

            string[] columnas = lineas[i].Split(';');

            if (columnas[0].Trim().Equals(idPrestamo.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                columnas[3] = "Disponible";
                columnas[5] = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                lineas[i] = string.Join(";", columnas);
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Decoraciones.TEXTO_VERDE("No se encontró el préstamo especificado.");
            return;
        }

        File.WriteAllLines(prestamos, lineas);
        Decoraciones.TEXTO_VERDE("Libro devuelto correctamente.");
        Decoraciones.SALIR_AL_PANEL();
    }
}