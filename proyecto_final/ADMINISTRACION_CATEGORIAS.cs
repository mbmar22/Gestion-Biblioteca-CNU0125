using System.Data.Common;

class ADMINISTRACION_CATEGORIAS
{
    static String categorias = ".//archivos//categorias.csv";

    class CATEGORIA
    {
        public int idCategoria { get; set; }
        public string nombreCategoria {get ; set; } = "Categoría";
    }

    public static void CREAR_CATEGORIA()
    {
        Decoraciones.ENCABEZADO();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                      PANEL DE CREACIÓN DE CATEGORÍAS                      ");
        Console.ResetColor();
        Console.WriteLine();

        CATEGORIA category = new CATEGORIA();
        if (File.Exists(categorias))
        {
            category.idCategoria = File.ReadAllLines(categorias).Length + 1;
        }
        else
        {
            category.idCategoria = 1;
        }

        Decoraciones.NOTA_CATEGORIAS();

        bool categoria_existente;

        do
        {
            Console.Write("Ingrese el nombre de la categoría: ");
            category.nombreCategoria = Console.ReadLine();
            categoria_existente = false;

            if (String.IsNullOrWhiteSpace(category.nombreCategoria))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!category.nombreCategoria.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! No se aceptan caracteres especiales.");
                Console.ResetColor();
            }
            else
            {
                if (File.Exists(categorias))
                {
                    string[] lineas = File.ReadAllLines(categorias);
                    foreach (string linea in lineas)
                    {
                        string[] datos = linea.Split(';');
                        
                        if (datos.Length >= 1 &&
                        datos[1].Equals(category.nombreCategoria, StringComparison.OrdinalIgnoreCase))
                        {
                            categoria_existente = true;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("¡ ERROR ! Ese nombre de categoría ya existe.");
                            Console.ResetColor();

                            break;
                        }
                    }
                }
            }
        } while (String.IsNullOrWhiteSpace(category.nombreCategoria) || !category.nombreCategoria.All(c => char.IsLetter(c) || char.IsWhiteSpace(c))|| categoria_existente);

        String CATEGORIAS = category.idCategoria + ";" + category.nombreCategoria;
        File.AppendAllText(categorias, CATEGORIAS + Environment.NewLine);

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n¡Categoría registrada con éxito!");
        Console.ResetColor();
        Console.WriteLine("Regresará al panel de administración");
        Decoraciones.cargando();

    }
}

// Hacer que si ingresan la categoría en minúsculas o con alguna variación extraña como aVENtura se ponga todo en minúscula con la primera letra en mayúscula.


/* Encontrar la manera de cambiar idCategoria a string para podr añadirle letras al ID. 
Ahorita está como int por que para que se vaya sumando 1 a 1 el ID "categorias" tiene que estar como int. */


// Hacer tipo ejercicio de la tienda.
// (g) al registrar usuarios, libros o categorias?

// No era que no se permitían carácteres especiales (???)
// (g) en q parte hay

// Permite agregar categorias repetidas.
// (g) si deja si no le ponen tilde, no se si poner un mensaje de q cuidado con la ortografia o buscar como validar q reconozca lo mismo.

/* Luego de que se agrega una categoría o un usuario, hay un cambio muy brusco cuando se regresa a la pantalla del menú. 
Investigar sobre como hacer que por ejemplo la consola muestre algo como "Regresando al menú..." por 3 segundos o algo así, o alguna transición de regreso o no sé, algo.*/

// (g) ya puse en decoraciones unos ... de carga por 3 segundos, se miran bien cute

// Ver lo del sonido.

// (g) excelenteee lo ponemos solo en errores ej las alertas y en ops exitosas como registrado correctamente
// o en todo como un sonido de click o asi?

// Por defecto el estado del usuario debe de ser activo.
// (g) okis