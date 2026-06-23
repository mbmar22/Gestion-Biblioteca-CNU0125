using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

class PRESTAMOS
{
    public string IdPrestamo { get; set; }
    public string LibroId { get; set; }
    public string UsuarioId { get; set; }

    public string Disponibilidad { get; set; } 
    public DateTime Fecha_Prestamo { get; set; }
    public DateTime? Fecha_Devolucion { get; set; }

    public PRESTAMOS(
        string idPrestamo,
        string libroId,
        string usuarioId,
        string disponibilidad,
        DateTime fechaPrestamo,
        DateTime? fechaDevolucion = null
    )
    {
        IdPrestamo = idPrestamo;
        LibroId = libroId;
        UsuarioId = usuarioId;
        Disponibilidad = disponibilidad;
        Fecha_Prestamo = fechaPrestamo;
        Fecha_Devolucion = fechaDevolucion;
    }

    public static void MOSTRAR_PRESTAMOS()
    {
        
    }

    public static void PRESTAR_LIBRO_USER()
    {
        String libros = ".//archivos//libros.csv";
        String prestamos = ".//archivos//prestamos.csv";

        string repetir;

        using (StreamWriter sw = new StreamWriter(prestamos, true))
        {
            if (!File.Exists(prestamos) || new FileInfo(prestamos).Length == 0)
            {
                sw.WriteLine("IdPrestamo;IdLibro;UsuarioId;Disponibilidad;FechaPrestamo;FechaDevolucion");
            }
        }

        do
        {
            Decoraciones.PRESTAR_LIBRO();

            int contadorIdP;

            if (File.Exists(prestamos))
            {
                contadorIdP = File.ReadAllLines(prestamos).Length;
            }
            else
            {
                contadorIdP = 1;
            }

            string idPrestamo = $"{contadorIdP:D3}P";

            string resp = "N";

            String[] lineas = File.ReadAllLines(libros);
            String[] lines = File.ReadAllLines(prestamos);

            do
            {
                String libro_buscado = VALIDAR.NO_VACIO("Ingrese el ID del libro: ");
                Console.WriteLine("\n");

                for (int i = 0; i < lineas.Length; i++)
                {
                    String[] datos = lineas[i].Split(';');

                    if (datos.Length > 6)
                    { 
                        if (datos[0].Equals(libro_buscado, StringComparison.OrdinalIgnoreCase))
                        {
                            if(datos[5] != "Activo")
                            {
                                Decoraciones.LIBRO_NO_DISPONIBLE();
                            }
                            else
                            {
                                bool libroPrestado = false; // este bool comienza falso porque asumimos que inicialmente el libro no está prestado
                                bool tieneHistorial = false; // este otro es para ver si el libro ya fue prestado

                                for (int j = lines.Length - 1; j >= 0; j--)
                                {
                                    String[] data = lines[j].Split(';');

                                    if (data.Length > 3 && data[1].Equals(libro_buscado, StringComparison.OrdinalIgnoreCase))
                                    {
                                        tieneHistorial = true;

                                        if(data[3] == "Prestado")
                                        {
                                            libroPrestado = true;
                                        }

                                        break;
                                    }
                                }

                                if(libroPrestado)
                                {
                                    Decoraciones.LIBRO_NO_DISPONIBLE();
                                }
                                else
                                {
                                    Decoraciones.MOSTRAR_LIBRO(datos);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                                    if (tieneHistorial) // o sea, si ya había sido prestado pero está disponible para prestar
                                    {
                                        resp = VALIDAR.SI_NO($"\nEs '{datos[1]}' el libro que desea prestar? (S/N): ");
                                        Console.ResetColor(); 

                                        if (resp == "S")
                                        {
                                            string nombreUsuario = INICIAR_SESION.Sesion.IdUsuario;
                                            string disponibilidad = "Prestado";

                                            PRESTAMOS prest = new PRESTAMOS(idPrestamo, datos[0], nombreUsuario, disponibilidad, DateTime.Now);

                                            using (StreamWriter sw = new StreamWriter(prestamos, true))
                                            {
                                                sw.WriteLine($"{prest.IdPrestamo};{prest.LibroId};{prest.UsuarioId};{prest.Disponibilidad};{prest.Fecha_Prestamo}");
                                            }
                                        }
                                    }
                                    else // el libro nunca ha sido prestado
                                    {
                                        resp = VALIDAR.SI_NO($"\nEs '{datos[1]}' el libro que desea prestar? (S/N): ");
                                        Console.ResetColor();
                                        if (resp == "S")
                                        {
                                            string nombreUsuario = INICIAR_SESION.Sesion.IdUsuario;
                                            string disponibilidad = "Prestado";

                                            PRESTAMOS prest = new PRESTAMOS(idPrestamo, datos[0], nombreUsuario, disponibilidad, DateTime.Now);

                                            using (StreamWriter sw = new StreamWriter(prestamos, true))
                                            {
                                                sw.WriteLine($"{prest.IdPrestamo};{prest.LibroId};{prest.UsuarioId};{prest.Disponibilidad};{prest.Fecha_Prestamo}");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } while (resp == "N");
    
            repetir = VALIDAR.SI_NO("¿Desea prestar otro libro? (S/N): ");
        } while (repetir == "S");
    }

    public static void PRESTAR_LIBRO_ADMIN()
    {
        String libros = ".//archivos//libros.csv";
        String prestamos = ".//archivos//prestamos.csv";

        string repetir;

        using (StreamWriter sw = new StreamWriter(prestamos, true))
        {
            if (!File.Exists(prestamos) || new FileInfo(prestamos).Length == 0)
            {
                sw.WriteLine("IdPrestamo;IdLibro;UsuarioId;Disponibilidad;FechaPrestamo;FechaDevolucion");
            }
        }

        do
        {
            Decoraciones.PRESTAR_LIBRO();

            int contadorIdP;

            if (File.Exists(prestamos))
            {
                contadorIdP = File.ReadAllLines(prestamos).Length;
            }
            else
            {
                contadorIdP = 1;
            }

            string idPrestamo = $"{contadorIdP:D3}P";

            string resp = "N";

            String[] lineas = File.ReadAllLines(libros);
            String[] lines = File.ReadAllLines(prestamos);

            do
            {
                String libro_buscado = VALIDAR.NO_VACIO("Ingrese el ID del libro: ");
                Console.WriteLine("\n");

                for (int i = 0; i < lineas.Length; i++)
                {
                    String[] datos = lineas[i].Split(';');

                    if (datos.Length > 6)
                    { 
                        if (datos[0].Equals(libro_buscado, StringComparison.OrdinalIgnoreCase))
                        {
                            if(datos[5] != "Activo")
                            {
                                Decoraciones.LIBRO_NO_DISPONIBLE();
                            }
                            else
                            {
                                bool libroPrestado = false; // este bool comienza falso porque asumimos que inicialmente el libro no está prestado
                                bool tieneHistorial = false; // este otro es para ver si el libro ya fue prestado

                                for (int j = lines.Length - 1; j >= 0; j--)
                                {
                                    String[] data = lines[j].Split(';');

                                    if (data.Length > 3 && data[1].Equals(libro_buscado, StringComparison.OrdinalIgnoreCase))
                                    {
                                        tieneHistorial = true;

                                        if(data[3] == "Prestado")
                                        {
                                            libroPrestado = true;
                                        }

                                        break;
                                    }
                                }

                                if(libroPrestado)
                                {
                                    Decoraciones.LIBRO_NO_DISPONIBLE();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Decoraciones.MOSTRAR_LIBRO(datos);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                                    if (tieneHistorial) // o sea, si ya había sido prestado pero está disponible para prestar
                                    {
                                        resp = VALIDAR.SI_NO($"\nEs '{datos[1]}' el libro que desea prestar? (S/N): ");
                                        Console.ResetColor(); 
                                        if (resp == "S")
                                        {
                                            string nombreUsuario = BUSCAR_USUARIO();
                                            string disponibilidad = "Prestado";

                                            PRESTAMOS prest = new PRESTAMOS(idPrestamo, datos[0], nombreUsuario, disponibilidad, DateTime.Now);

                                            using (StreamWriter sw = new StreamWriter(prestamos, true))
                                            {
                                                sw.WriteLine($"{prest.IdPrestamo};{prest.LibroId};{prest.UsuarioId};{prest.Disponibilidad};{prest.Fecha_Prestamo}");
                                            }
                                        }
                                    }
                                    else // el libro nunca ha sido prestado
                                    {
                                        resp = VALIDAR.SI_NO($"\nEs '{datos[1]}' el libro que desea prestar? (S/N): ");
                                        Console.ResetColor();
                                        if (resp == "S")
                                        {
                                            string nombreUsuario = BUSCAR_USUARIO();
                                            string disponibilidad = "Prestado";

                                            PRESTAMOS prest = new PRESTAMOS(idPrestamo, datos[0], nombreUsuario, disponibilidad, DateTime.Now);

                                            using (StreamWriter sw = new StreamWriter(prestamos, true))
                                            {
                                                sw.WriteLine($"{prest.IdPrestamo};{prest.LibroId};{prest.UsuarioId};{prest.Disponibilidad};{prest.Fecha_Prestamo}");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } while (resp == "N");
    
            repetir = VALIDAR.SI_NO("¿Desea prestar otro libro? (S/N): ");
        } while (repetir == "S");
    }

    public static string BUSCAR_USUARIO()
    {
        string usuarios = ".//archivos//usuarios.csv";
        string answer = "S";

        do
        {
            string usuario_buscado = VALIDAR.USERNAME_ID_VALIDO("\nIngrese el ID del usuario: ");

            string[] lineas = File.ReadAllLines(usuarios);

            bool encontrado = false;
            string nombreUsuario = "";
            string idUsuario = "";

            foreach (string linea in lineas)
            {
                string[] dato = linea.Split(';');

                if (dato.Length > 1 &&
                    dato[0].Equals(usuario_buscado, StringComparison.OrdinalIgnoreCase))
                {
                    encontrado = true;
                    nombreUsuario = dato[1];
                    idUsuario = dato [0];
                    break;
                }
            }

            if (!encontrado)
            {
                return "BBB";
            }

            answer = VALIDAR.SI_NO($"\n¿Es '{nombreUsuario}' el usuario que busca? (S/N): ");

            if (answer == "S")
            {
                return idUsuario;
            }

        } while (answer == "N");

        return "";
    }


    public static void DEVOLVER_LIBRO()
    {

    }


}

// por qué 