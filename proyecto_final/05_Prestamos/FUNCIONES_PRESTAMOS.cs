using System.ComponentModel;
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

    public static void PRESTAR_LIBRO()
    {
        String libros = ".//archivos//libros.csv";
        String prestamos = ".//archivos//prestamos.csv";
        String usuarios = ".//archivos//usuarios.csv";

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
            Decoraciones.ENCABEZADO();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("PRESTAR LIBRO");
            Console.ResetColor();
            Console.WriteLine();

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

                                    if (tieneHistorial)
                                    {
                                        Console.WriteLine("Este libro ya había sido prestado pero está disponible");
                                        resp = VALIDAR.SI_NO($"\nEs '{datos[1]}' el libro que desea prestar? (S/N): ");
                                        Console.ResetColor(); 
                                    }
                                    else
                                    {
                                        Console.WriteLine("El libro nunca ha sido prestado");
                                        resp = VALIDAR.SI_NO($"\nEs '{datos[1]}' el libro que desea prestar? (S/N): ");
                                        Console.ResetColor();
                                        
                                    }

                                    string respue = "N"; 
                                    string nombreUsuario = "";

                                    do
                                    {
                                        string usuario_buscado = VALIDAR.USERNAME_ID_VALIDO("\nIngrese el ID del usuario: ");

                                        string[] lineass = File.ReadAllLines(usuarios);

                                        bool encontrado = false;
                                        
                                        for (int k = 0; k < lineass.Length; k++)
                                        {
                                            string[] dato = lineass[k].Split(';');

                                            if(dato.Length > 1 && dato[0].Equals(usuario_buscado, StringComparison.OrdinalIgnoreCase))
                                            {
                                                encontrado = true;
                                                nombreUsuario = dato[1];
                                                break;
                                            }
                                        }

                                        if (encontrado)
                                        {
                                            respue = VALIDAR.SI_NO($"¿Es '{nombreUsuario}' el usuario que busca? (S/N): ");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Usuario no encontrado. Intente otra vez.");
                                        }
                                        
                                    } while (respue == "N");

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
            } while (resp == "N");
    
            repetir = VALIDAR.SI_NO("¿Desea prestar otro libro? (S/N): ");
        } while (repetir == "S");
    }


    public static void DEVOLVER_LIBRO()
    {

    }


}


// añadir en el código del préstamo la cantidad de veces que ha sido prestado el libro? o ya mucho?, no lo sé la verdad, xd

/* problema: El código debe de revisar el último registro del libro en caso de estar en la lista de préstamos y en base a su disponibilidad escoger si se hace o no.
ideas para solucionarlo: 
- En el id de préstamos 000P, añadir el código del libro, tipo 001P001L001C, para que el programa lea el 001 cantidad que significa cantidad de veces que ha sido prestado ese libro, entonces, en base a eso debe de buscar la cantidad máxima y decidir en base a eso.
El problema es que habría que convertir aislar ese 001 y convertirlo a string como en lo de usuario. No sé que hacer la verdad.

*/