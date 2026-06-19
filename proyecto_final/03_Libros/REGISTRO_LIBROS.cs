using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
class REGISTRO_LIBROS
{

    static String libros = ".//archivos//libros.csv";
    static String categorias = ".//archivos//categorias.csv";
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
        string repetir;
        
        do
        {
            LIBROS LIBRO = new LIBROS();
            Console.WriteLine("        ──────────────────────────────────────────────────────────────");
            Decoraciones.ENCABEZADO();  
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                        PANEL DE REGISTRO DE LIBROS");
            Console.ResetColor();
            Console.WriteLine("");

            // asignacion del ID
            int contadorId;
            if (File.Exists(libros))
            {
                contadorId = File.ReadAllLines(libros).Length + 1;
            }
            else
            {
                contadorId = 1;
            }

            LIBRO.ID = $"{contadorId:D3}L";

            // titulo y autor del libro
            INSTRUCCIONES.NOTA_LIBRO();

            LIBRO.titulo = VALIDAR.NO_VACIO("Digite el nombre del título: ");

            LIBRO.autor = VALIDAR.AUTORVALIDO("Digite el nombre del autor: ");
            
            // descripcion del libro
            INSTRUCCIONES.NOTA_DESCRIPCION();

            LIBRO.descripcion = VALIDAR.NO_VACIO("Introduzca una descripción breve del libro: ");

            // categoria del libro
            INSTRUCCIONES.NOTA_CATEGORIAS();
            LIBRO.categoria = VALIDAR.CATEGORIAVALIDA("Digite el nombre de la categoría o digite '1' para" +
            "\nconsultar la lista de categorías existentes: ");
            
            // datos por defecto del libro
            LIBRO.estado = "Activo";        
            LIBRO.disponibilidad = "Disponible";
            LIBRO.ingreso = DateTime.Now.ToString("dd/MM/yyyy");

            String nuevo_libro = LIBRO.ID + ";" + LIBRO.titulo + ";" + LIBRO.autor + ";" + LIBRO.categoria + ";" + LIBRO.descripcion + ";" + LIBRO.disponibilidad + ";" + LIBRO.estado + ";" + LIBRO.ingreso;
        
            // proceso de guardar el libro
            File.AppendAllText(libros,nuevo_libro + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n¡Libro registrado con éxito!");
            Console.ResetColor();

            repetir = VALIDAR.SI_NO("\n¿Desea registrar otro libro? (S/N): ");

        } while (repetir == "S");

        Console.WriteLine("Regresará al Panel de Administración.");
        Decoraciones.cargando();
    }
}