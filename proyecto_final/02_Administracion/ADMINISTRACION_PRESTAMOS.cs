using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

// En administración de préstamos se pueden prestar libros, devolver libros, consultar préstamos activos, consultar historial de préstamos, etc.

class ADMINISTRACION_PRESTAMOS
{
    static String libros = ".//archivos//libros.csv";
    static String usuarios = ".//archivos//usuarios.csv";
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

            String libro_buscado = VALIDAR.NO_VACIO("Ingrese el ID del libro: ");
            string usuario_buscado = VALIDAR.NO_VACIO("Ingrese el ID del usuario: ");

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
                            string Resp = VALIDAR.SI_NO($"\n¿Es '{datos[1]}' el libro que desea prestar? (S/ N): ");
                            if (Resp == "S")
                            {
                                int usuarioId = 0;
                                bool usuarioEncontrado = false;

                                String[] lineasUsuarios = File.ReadAllLines(usuarios);
                                for (int j = 0; j < lineasUsuarios.Length; j++)
                                {
                                    String[] datosUsuario = lineasUsuarios[j].Split(';');
                                    if (datosUsuario.Length > 0 && datosUsuario[0].Equals(usuario_buscado, StringComparison.OrdinalIgnoreCase))
                                    {
                                        usuarioEncontrado = true;
                                        usuarioId = int.Parse(datosUsuario[0]);
                                        break;
                                    }
                                }

                                if (!usuarioEncontrado)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Usuario no encontrado.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    PRESTAMOS prest = new PRESTAMOS(idPrestamo, datos[0], usuarioId, DateTime.Now);

                                    using (StreamWriter sw = new StreamWriter(prestamos, true))
                                    {
                                        if (!File.Exists(prestamos) || new FileInfo(prestamos).Length == 0)
                                        {
                                            sw.WriteLine("IdPrestamo;IdLibro;UsuarioId;FechaPrestamo;FechaDevolucion");
                                        }

                                        sw.WriteLine($"{prest.IdPrestamo};{prest.LibroId};{prest.UsuarioId};{prest.Fecha_Prestamo:dd/MM/yyyy};");
                                    }

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    datos [6] = "Prestado";
                                    Console.WriteLine("\nPréstamo registrado correctamente.");
                                    Console.ResetColor();
                                }
                            }
                        }
                        Console.WriteLine();
                        Console.ResetColor();
                        
                        // agregar validación
                        //bool confirmacion = false;

                    }
                }

                /* if (!encontrado)
                {
                    ALERTAS.RESULTADO_NO_ENCONTRADO();
                } */
            }

            repetir = VALIDAR.SI_NO("¿Desea prestar otro libro? (S/N): ");
        } while (repetir == "S");
    }

    static void DEVOLVER_LIBRO()
    {

    }
}


/* 
Para mañana: 
- Búsqueda del usuario luego de la confirmación del libro.
- Confirmar si es el usuario correcto.
- Agregar validaciones. 
- Agregar 
- Ver porqué no se cambia de "Disponible" a "Prestado"
*/