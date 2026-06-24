using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

class ADMINISTRACION_CATEGORIAS
{
    static String categorias = ".//archivos//categorias.csv";

    class CATEGORIA
    {
        public string idCategoria { get; set; } = "ID Categoría";
        public string nombreCategoria {get ; set; } = "Categoría";
    }
    
    public static void CREAR_CATEGORIA()
    {
        string repetir;
        do
        {
            CATEGORIA category = new CATEGORIA();
            Decoraciones.ENCABEZADO();
            Decoraciones.TEXTO_CYAN("                      PANEL DE CREACIÓN DE CATEGORÍAS                      \n");

            // asignación de ID de categoría
            int contadorIdC;

            if (File.Exists(categorias))
            {
                contadorIdC = File.ReadAllLines(categorias).Length;
            }
            else
            {
                contadorIdC = 1;
            }

            category.idCategoria = $"{contadorIdC:D3}C";

            INSTRUCCIONES.NOTA_CATEGORIAS();

            bool categoria_existente;
            // ENTRADAS
            do
            {
                categoria_existente = false;

                category.nombreCategoria = VALIDAR.LETRAS_ESPACIOS("Ingrese el nombre de la categoría: ");

                // verificar repetidos
                if (File.Exists(categorias))
                {
                    string[] lineas = File.ReadAllLines(categorias);

                    foreach (string linea in lineas)
                    {
                        string[] datos = linea.Split(';');

                        if (datos.Length > 1 &&
                            datos[1].Equals(category.nombreCategoria,
                            StringComparison.OrdinalIgnoreCase))
                        {
                            categoria_existente = true;

                            Decoraciones.TEXTO_ROJO("¡ ERROR ! Esa categoría ya existe.");

                            break;
                        }
                    }
                }

            } while (categoria_existente);

            bool existe = File.Exists(categorias);

            using (StreamWriter sw = new StreamWriter(categorias, true))
            {
                if (!File.Exists(categorias) || new FileInfo(categorias).Length == 0)
                {
                    sw.WriteLine("IdCategoría;Categoría");
                }
            }

            // guardar nueva categoria
            String CATEGORIAS = category.idCategoria + ";" + category.nombreCategoria;
            File.AppendAllText(categorias, CATEGORIAS + Environment.NewLine);

            Decoraciones.TEXTO_VERDE("\n¡Categoría registrada con éxito!");
            repetir = VALIDAR.SI_NO("\n¿Desea registrar otra categoría? (S/N): ");

        } while (repetir == "S");

        Console.WriteLine("Regresará al Panel de Administración.");
        Decoraciones.cargando();
    }
}