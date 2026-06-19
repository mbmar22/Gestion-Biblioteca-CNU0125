
class VALIDAR
{
    static String categorias = ".//archivos//categorias.csv";
    static String usuarios = ".//archivos//usuarios.csv";

    public static string NO_VACIO(string mensaje)
    {
        string texto;

        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(texto))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(texto));

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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
                opcion = -1;
            }
            else if (!int.TryParse(entrada, out opcion))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Debe ingresar un número.");
                Console.ResetColor();
            }
            else if (opcion < min || opcion > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"¡ ERROR ! Debe ingresar una opción entre {min} y {max}.");
                Console.ResetColor();
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

            if (String.IsNullOrWhiteSpace(texto))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!texto.All(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Solo se permiten letras.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(texto) || !texto.All(char.IsLetter));

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

            valido = !String.IsNullOrWhiteSpace(texto) &&
                    texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));

            if (String.IsNullOrWhiteSpace(texto))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!valido)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Solo se permiten letras y espacios.");
                Console.ResetColor();
            }

        } while (!valido);

        return texto;
    }
    public static string AL_MENOS_UNA_LETRA(string mensaje)
    {
        string texto;

        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(texto))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!texto.Any(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Debe contener al menos una letra.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(texto) || !texto.Any(char.IsLetter));

        return texto;
    }

    public static string AUTORVALIDO(string mensaje)
    {
        string texto;
        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(texto))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }

            // validar que solo sean letras y espacios, ese .All con el =>

            else if (!texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' || c == '\'' || c == '-'))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! No se permiten números y ciertos caracteres especiales.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(texto) || !texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' ||  c == '\'' || c == '-'));

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

                if (String.IsNullOrWhiteSpace(respuesta))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                    Console.ResetColor();
                }

            } while (String.IsNullOrWhiteSpace(respuesta));

            // mostrar categorías
            if (respuesta == "C")
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Categoría no encontrada.");
                Console.ResetColor();
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

            if (String.IsNullOrWhiteSpace(texto))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!texto.Any(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Debe contener al menos una letra.");
                Console.ResetColor();
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

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("¡ ERROR ! Ese nombre de usuario ya existe.");
                            Console.ResetColor();

                            break;
                        }
                    }
                }
            }

        } while (String.IsNullOrWhiteSpace(texto) || !texto.Any(char.IsLetter) || usuario_existente);
        return texto;
    }
}