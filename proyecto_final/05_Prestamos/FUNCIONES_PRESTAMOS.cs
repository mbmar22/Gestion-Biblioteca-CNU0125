using System.Runtime.InteropServices;

class PRESTAMOS
{
    public string IdPrestamo { get; set; }
    public string LibroId { get; set; }
    public int UsuarioId { get; set; }

    public string Disponibilidad { get; set; } 
    public DateTime Fecha_Prestamo { get; set; }
    public DateTime? Fecha_Devolucion { get; set; }

    public PRESTAMOS(
        string idPrestamo,
        string libroId,
        int usuarioId,
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

        string repetir;

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

            do
            {
                String libro_buscado = VALIDAR.NO_VACIO("Ingrese el ID del libro: ");
                
                String[] lineas = File.ReadAllLines(libros);

                int resultados = 0;

                for (int i = 0; i < lineas.Length; i++)
                {
                    String[] datos = lineas[i].Split(';');

                    if (datos.Length > 7)
                    { 
                        if (datos[0].Equals(libro_buscado, StringComparison.OrdinalIgnoreCase))
                        {
                            resultados++;

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Decoraciones.MOSTRAR_LIBRO(datos);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;

                            if(datos[5] != "Disponible")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Libro no disponible.");
                                Console.ResetColor();
                            }
                            else
                            {
                                resp = VALIDAR.SI_NO($"\n¿Es '{datos[1]}' el libro que desea prestar? (S/ N): ");
                                Console.ResetColor();
                            }

                        }
                    }
                }
            } while (resp == "N");


            string respu = "N"; 

            do
            {
                String usuario_buscado = VALIDAR.USERNAME_ID_VALIDO("\nIngrese el ID del usuario: ");

                respu = VALIDAR.SI_NO(usuario_buscado);
                // Nada más ver por qué cuando se hace la confirmación del usuario imprime otra vez el id que se le dio, ver si es tal vez por el return, no sé.

            } while (respu == "N");

            repetir = VALIDAR.SI_NO("¿Desea prestar otro libro? (S/N): ");
        } while (repetir == "S");
    }

    public static void DEVOLVER_LIBRO()
    {

    }


}

