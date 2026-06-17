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
        Console.WriteLine(" ───────────────────────────────────────────────────────────────────────── ");
        Decoraciones.ENCABEZADO();
        Console.WriteLine("                      PANEL DE CREACIÓN DE CATEGORÍAS                      ");
        Console.ResetColor();
        Console.WriteLine();

        CATEGORIA cat = new CATEGORIA();
        if (File.Exists(categorias))
        {
            cat.idCategoria = File.ReadAllLines(categorias).Length + 1;
        }
        else
        {
            cat.idCategoria = 1;
        }

        Decoraciones.NOTA_CATEGORIAS();

        do
        {
            Console.Write("Ingrese el nombre de la categoría: ");
            cat.nombreCategoria = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(cat.nombreCategoria))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!cat.nombreCategoria.All(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! No se aceptan caracteres especiales.");
                Console.ResetColor();
            }
        } while (String.IsNullOrWhiteSpace(cat.nombreCategoria) || !cat.nombreCategoria.All(char.IsLetter));
    }
}

// Hacer que si ingresan la categoría en minúsculas o con alguna variación extraña como aVENtura se ponga todo en minúscula con la primera letra en mayúscula.
// Probarloooo.


/* Encontrar la manera de cambiar idCategoria a string para podr añadirle letras al ID. 
Ahorita está como int por que para que se vaya sumando 1 a 1 el ID "categorias" tiene que estar como int. */