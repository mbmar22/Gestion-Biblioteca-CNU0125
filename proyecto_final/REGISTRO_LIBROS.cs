using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
class REGISTRO_LIBROS
{

    static String libros = ".//archivos//libros.csv";
    struct LIBROS
    {
        public string ID;
        public String titulo;
        public String autor;
        public String descripcion;
        public String categoria;
        public String ingreso;
        public String estado;
        public String disponibilidad;

    }

    public static void REGISTRAR()
    {
        LIBROS LIBRO = new LIBROS();
        Console.WriteLine("        ──────────────────────────────────────────────────────────────");
        Decoraciones.ENCABEZADO();  
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                        PANEL DE REGISTRO DE LIBROS");
        Console.ResetColor();
        Console.WriteLine("");


        int contadorId;

        if (File.Exists(libros))
        {
            contadorId = File.ReadAllLines(libros).Length + 1;
            if (contadorId < 10)
            {
                LIBRO.ID = ($"00{contadorId}L");
            }
            else if (contadorId >= 10 || contadorId <= 99)
            {
                LIBRO.ID = ($"0{contadorId}L");
            }
            else
            {
                LIBRO.ID = ($"{contadorId}L");
            }

        }
        else
        {
            contadorId = 1;
        }

        // titulo del libro
        Decoraciones.NOTA_LIBRO();

        do
        {
            Console.Write("Digite el título del nuevo libro: ");
            LIBRO.titulo = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(LIBRO.titulo))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(LIBRO.titulo));

        // nombre del autor, permite espacios y letras
        // voy a ver si luego uso el try catch para ver excepciones tipo J.K Rowling y asi

        do
        {
            Console.Write("Digite el nombre del autor del nuevo libro: ");
            LIBRO.autor = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(LIBRO.autor))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            // validar que solo sean letras y espacios, ese .All con el => es
            // para evaluar cada uno sin tener k usar un foreach pq q pereza

            else if (!LIBRO.autor.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' || c == '\'' || c == '-'))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! No se permiten números y ciertos caracteres especiales.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(LIBRO.autor) || !LIBRO.autor.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' ||  c == '\'' || c == '-'));
         
        // descripcion del libro
        Decoraciones.NOTA_DESCRIPCION();

        do
        {
            Console.Write("Digite una descripción corta del nuevo libro: ");
            LIBRO.descripcion = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(LIBRO.descripcion))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(LIBRO.descripcion));

        // categoria del libro (PENDIENTE)
        
        // estado del libro - no se permite registrar un libro inactivo pq se puede modificar despues
        
        LIBRO.estado = "Activo";

        // disponibilidad del libro - al momento d registrarse siempre debe ser disponible pq el libro 
        // solo esta no disponible cuando se realiza un prestamo
        
        LIBRO.disponibilidad = "Disponible";
        
        // ingreso del libro
        LIBRO.ingreso = DateTime.Now.ToString("dd/MM/yyyy");

        String nuevo_libro = LIBRO.ID + ";" + LIBRO.titulo + ";" + LIBRO.autor + ";" + LIBRO.descripcion + ";" + LIBRO.disponibilidad + ";" + LIBRO.estado + ";" + LIBRO.ingreso;
    
        // proceso de guardar el libro
        File.AppendAllText(libros,nuevo_libro + Environment.NewLine);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n¡Libro registrado con éxito!");
        Console.ResetColor();
        Console.WriteLine("Regresará al Panel de Administración.");   
        Decoraciones.cargando(); 
    }
}