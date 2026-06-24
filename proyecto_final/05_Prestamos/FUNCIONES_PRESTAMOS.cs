class PRESTAMOS
{
    public static void PRESTAR_LIBRO(bool es_administrador)
    {
        string repetir = "";

        CREAR_ARCHIVO_PRESTAMOS();
        do
        {
            Decoraciones.PRESTAR_LIBRO();

            string[] libro = BUSCAR_LIBRO();

            if (libro == null)
            {
                ALERTAS.RESULTADO_NO_ENCONTRADO();
                continue;
            }

            if (!LIBRO_DISPONIBLE(libro[0]))
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
            }

            repetir = VALIDAR.SI_NO("¿Desea prestar otro libro? (S/N): ");

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

    static string[] BUSCAR_LIBRO()
    {
        string libros = ".//archivos//libros.csv";
        string libroBuscado = VALIDAR.NO_VACIO("Ingrese el ID del libro: ");

        string[] lineas = File.ReadAllLines(libros);

        foreach (string linea in lineas)
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;

            string[] datos = linea.Split(';');

            if (datos.Length >= 6)
            {
                if (datos[0].Equals(libroBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    return datos;
                }
            }
        }
        return null;
    }

    static bool LIBRO_DISPONIBLE(string idLibro)
    {
        string prestamos = ".//archivos//prestamos.csv";

        if (!File.Exists(prestamos))
        {
            return true;
        }

        string[] lineas = File.ReadAllLines(prestamos);

        for (int i = lineas.Length - 1; i >= 0; i--)
        {
            if (string.IsNullOrWhiteSpace(lineas[i])) continue;

            string[] datos = lineas[i].Split(';');

            if (datos.Length > 3 && datos[1] == idLibro)
            {
                return datos[3] != "Prestado";
            }
        }

        return true;
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

                if (datos.Length > 1)
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

        foreach (string l in lineas)
        {
            if (!string.IsNullOrWhiteSpace(l)) // si solo hay una linea (el encabezado) o el archivo esta vacio
            {
                contador++;
            }
        }

        return $"{(contador + 1):D3}P";
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
        String prestamos = ".//archivos//prestamos.csv";

        String [] linea = File.ReadAllLines(prestamos);

        Console.WriteLine("\n+-------------+----------+------------+----------------+----------------+-------------------+");
        Console.Write("| ");
        Decoraciones.COLORES_TITULARES("ID Préstamo");
        Decoraciones.COLORES_TITULARES("ID Libro");
        Decoraciones.COLORES_TITULARES("ID Usuario");
        Decoraciones.COLORES_TITULARES("Disponibilidad");
        Decoraciones.COLORES_TITULARES("Fecha Préstamo");
        Decoraciones.COLORES_TITULARES(" Fecha Devolución");
        Console.WriteLine("\n+-------------+----------+------------+----------------+----------------+-------------------+");

        foreach (string lineas in linea.Skip(1)) // saltar la primera por que es el encabezado, y el encabezado ya lo estamos imprimiendo aparte.
        {
            string[] columnas = lineas.Split(";");
            string fechaTexto = columnas[4];
            DateTime fecha = DateTime.Parse(fechaTexto); // esto es para convertir la fecha que está guardada con el registro del tiempo

            Console.WriteLine($"| {columnas[0], -11} | {columnas[1], -8} | {columnas[2], -10} | {columnas[3], -14} | {fecha.ToString("dd/MM/yyyy"), -14} | {columnas[5], -17} |");
        }
    }

    public static void MOSTRAR_PRESTAMOS_USER()
    {
        
    }
}