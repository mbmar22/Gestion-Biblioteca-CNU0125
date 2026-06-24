class VALIDAR
{
    static String categorias = ".//archivos//categorias.csv";
    static String usuarios = ".//archivos//usuarios.csv";
    
    static String prestamos = ".//archivos//prestamos.csv";

    public static bool SIN_PUNTO_Y_COMA(string texto)
    {
        return string.IsNullOrWhiteSpace(texto) || texto.Contains(';');
    }
    public static string NO_VACIO(string mensaje)
    {
        string texto;

        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();

            if (SIN_PUNTO_Y_COMA(texto))
            {
                ALERTAS.VACIO();
            }

        } while (SIN_PUNTO_Y_COMA(texto));        
        return texto;
    }

    public static int OPCION(string mensaje, int min, int max)
    {
        int opcion;

        do
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(entrada))
            {
                ALERTAS.VACIO();
                opcion = -1;
            }
            else if (!int.TryParse(entrada, out opcion))
            {
                Decoraciones.TEXTO_ROJO("¡ ERROR ! Debe ingresar un número.");

            }
            else if (opcion < min || opcion > max)
            {
                Decoraciones.TEXTO_ROJO($"¡ ERROR ! Debe ingresar una opción entre {min} y {max}.");
            }

        } while (opcion < min || opcion > max);

        return opcion;
    }

    public static string SOLO_LETRAS(string mensaje)
    {
        string texto;

        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();

            if (SIN_PUNTO_Y_COMA(texto))
            {
                ALERTAS.VACIO();
            }
            else if (!texto.All(char.IsLetter))
            {
                Decoraciones.TEXTO_ROJO("¡ ERROR ! Solo se permiten letras.");
            }

        } while (SIN_PUNTO_Y_COMA(texto) || !texto.All(char.IsLetter));

        return texto;
    }

    public static string LETRAS_ESPACIOS(string mensaje)
    {
        string texto;
        bool valido;

        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();

            valido = !SIN_PUNTO_Y_COMA(texto) && texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));

            if (String.IsNullOrWhiteSpace(texto))
            {
                ALERTAS.VACIO();
            }
            else if (!valido)
            {
                Decoraciones.TEXTO_ROJO("¡ ERROR ! Solo se permiten letras y espacios.");
            }

        } while (!valido);

        return texto;
    }

    public static string AUTORVALIDO(string mensaje)
    {
        string texto;
        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();

            if (SIN_PUNTO_Y_COMA(texto))
            {
                ALERTAS.VACIO();
            }
            // validar que solo sean letras, espacios yciertos caracteres 

            else if (!texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' || c == '\'' || c == '-'))
            {
                Decoraciones.TEXTO_ROJO("¡ ERROR ! No se permiten números y ciertos caracteres especiales.");
            }

        } while (SIN_PUNTO_Y_COMA(texto) || !texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' ||  c == '\'' || c == '-'));

        return texto;
    }


    public static string CATEGORIAVALIDA(string mensaje)
    {
        String respuesta;
        bool categoria_encontrada = false;
        String[] lineas = File.ReadAllLines(categorias);

        do // ciclo para recorrer el archivo hasta que encuentre una categoria q exista
        {
            do // validacion d la respuesta
            {
                Console.Write(mensaje);

                respuesta = Console.ReadLine();

                if (SIN_PUNTO_Y_COMA(respuesta))
                {
                    ALERTAS.VACIO();
                }

            } while (SIN_PUNTO_Y_COMA(respuesta));

            // mostrar categorías
            if (respuesta == "1")
            {
                Decoraciones.mostrar_categorias();
                continue;
            }

            for (int i = 0; i < lineas.Length; i++)
            {
                String[] datos = lineas[i].Split(';');

                if (datos.Length > 1)
                {
                    if (datos[1].Equals(respuesta, StringComparison.OrdinalIgnoreCase))
                    {
                        categoria_encontrada = true;
                        respuesta = datos[1];
                        break;
                    }
                }
            }

            Console.WriteLine(); 

            if (!categoria_encontrada)
            {
                ALERTAS.RESULTADO_NO_ENCONTRADO();
            }

        } while (!categoria_encontrada);
        return respuesta;
    }

    public static string USERNAME_VALIDO(string mensaje)
    {
        string texto;
        bool usuario_existente;
        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();
            usuario_existente = false;

            if (SIN_PUNTO_Y_COMA(texto))
            {
                ALERTAS.VACIO();
            }
            else if (!texto.Any(char.IsLetter))
            {
                ALERTAS.UNA_LETRA();
            }
            else
            {
                if (File.Exists(usuarios))
                {
                    string[] lineas = File.ReadAllLines(usuarios);

                    foreach (string linea in lineas)
                    {
                        string[] datos = linea.Split(';');

                        if (datos.Length >= 4 &&
                            datos[3].Equals(texto, StringComparison.OrdinalIgnoreCase))
                        {
                            usuario_existente = true;

                            Decoraciones.TEXTO_ROJO("¡ ERROR ! Ese nombre de usuario ya existe.");
                            break;
                        }
                    }
                }
            }

        } while (SIN_PUNTO_Y_COMA(texto) || !texto.Any(char.IsLetter) || usuario_existente);
        return texto;
    }


    public static string USERNAME_ID_VALIDO(string mensaje)
    {
        string texto;
        bool usuario_existente;

        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();
            usuario_existente = false;

            if (string.IsNullOrWhiteSpace(texto))
            {
                ALERTAS.VACIO();
                continue;
            }

            texto = texto.Trim();

            if (SALIR(texto))
            {
                return texto;
            }

            if (File.Exists(usuarios))
            {
                string [] lineas = File.ReadAllLines(usuarios);

                foreach (string linea in lineas.Skip(1)) // el skip es para que ignore el encabezado
                {
                    string[] datos = linea.Split(';');

                    if (datos.Length > 0 &&
                    datos[0].Trim().Equals(texto, StringComparison.OrdinalIgnoreCase))
                    {
                        usuario_existente = true;
                        break;
                    }
                }
            }

            if (!usuario_existente)
            {
                Decoraciones.TEXTO_ROJO("El ID ingresado no existe.");
            }
        } while (!usuario_existente);

        return texto;
    }
    public static string PRESTAMO_ID_VALIDO(string mensaje)
    {
        string texto;
        bool prestamo_existente;

        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();
            prestamo_existente = false;

            if (string.IsNullOrWhiteSpace(texto))
            {
                ALERTAS.VACIO();
                continue;
            }

            texto = texto.Trim();

            if (SALIR(texto))
            {
                return texto;
            }

            if (File.Exists(prestamos))
            {
                string[] lineas = File.ReadAllLines(prestamos);

                foreach (string linea in lineas.Skip(1))
                {
                    string[] datos = linea.Split(';');

                    if (datos.Length > 0 &&
                        datos[0].Trim().Equals(texto, StringComparison.OrdinalIgnoreCase))
                    {
                        prestamo_existente = true;
                        break;
                    }
                }
            }

            if (!prestamo_existente)
            {
                Decoraciones.TEXTO_ROJO("El ID ingresado no existe.");
            }
        } while (!prestamo_existente);

        return texto;
    }
    
    public static string SI_NO(string mensaje)
    {
        string respuesta;

        do
        {
            Console.Write(mensaje);
            respuesta = Console.ReadLine().ToUpper();

            if (respuesta != "S" && respuesta != "N")
            {
                ALERTAS.YESNO();
            }

        } while (respuesta != "S" && respuesta != "N");

        return respuesta;
    }
    public static bool CONFIRMAR(string mensaje)
    {
        string respuesta;

        do
        {
            Console.Write(mensaje);
            respuesta = Console.ReadLine().ToUpper();

            if (respuesta != "S" && respuesta != "N")
            {
                ALERTAS.YESNO();
            }

        } while (respuesta != "S" && respuesta != "N");

        return respuesta == "S";
    }

    public static string AL_MENOS_UNA_LETRA(string mensaje)
    {
        string texto;
        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();

            if (SIN_PUNTO_Y_COMA(texto))
            {
                ALERTAS.VACIO();
            }
            else if (!texto.Any(char.IsLetter))
            {
                ALERTAS.UNA_LETRA();
            }

        } while ( SIN_PUNTO_Y_COMA(texto) || !texto.Any(char.IsLetter));
        return texto;
    }

    public static bool SALIR(string mensaje)
    {
        return mensaje.Trim().ToUpper() == "X";
    }
}