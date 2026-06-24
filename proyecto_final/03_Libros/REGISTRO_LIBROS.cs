using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
class REGISTRO_LIBROS
{

    static String libros = ".//archivos//libros.csv";
    static String categorias = ".//archivos//categorias.csv";

    // cambié el struct a class para trabajar con clases heredadas. No sé qué estoy haciendo la verdad, jaja
    public class LIBROS
    {
        public string ID = "ID Libro";
        public String titulo = "Título";
        public String autor = "Autor";
        public String descripcion = "Descripción";
        public String categoria = "Categoría";
        public String ingreso = "Fecha de Ingreso";
        public String estado = "Estado";

    }

    public static void REGISTRAR()
    {
        string repetir;
        do
        {
            LIBROS LIBRO = new LIBROS();
            Decoraciones.ENCABEZADO();  
            Decoraciones.TEXTO_CYAN("                        PANEL DE REGISTRO DE LIBROS\n");

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
            LIBRO.ingreso = DateTime.Now.ToString("dd/MM/yyyy");

            String nuevo_libro = LIBRO.ID + ";" + LIBRO.titulo + ";" + LIBRO.autor + ";" + LIBRO.categoria + ";" + LIBRO.descripcion + ";" + LIBRO.estado + ";" + LIBRO.ingreso;
        
            // proceso de guardar el libro
            File.AppendAllText(libros,nuevo_libro + Environment.NewLine);

            Decoraciones.TEXTO_VERDE("\n¡Libro registrado con éxito!");

            repetir = VALIDAR.SI_NO("\n¿Desea registrar otro libro? (S/N): ");

        } while (repetir == "S");

        Console.WriteLine("Regresará al Panel de Administración.");
        Decoraciones.cargando();
    }
}