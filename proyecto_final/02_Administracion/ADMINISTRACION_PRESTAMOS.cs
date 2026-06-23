using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

// En administración de préstamos se pueden prestar libros, devolver libros, consultar préstamos activos, consultar historial de préstamos, etc.

class ADMINISTRACION_PRESTAMOS
{
    public static void MENU_PRESTAMOS()
    {
        Decoraciones.ENCABEZADO();
        Decoraciones.TEXTO_CYAN("                ADMINISTRACIÓN DE PRÉSTAMOS Y DEVOLUCIONES");
        Console.WriteLine("");
        Console.WriteLine(
            "1. Ver historial de préstamos.\n" +
            "2. Prestar libro\n" +
            "3. Devolver libro.\n" +
            "4. Regresar al menú.");

        Console.WriteLine("");

        int respuesta = VALIDAR.OPCION("Digite el número de la acción que desea realizar: ", 1, 3);

        switch (respuesta)
        {
            case 1:
            PRESTAMOS.MOSTRAR_PRESTAMOS();
                break;
            case 2:
            if (INICIAR_SESION.Sesion.Rol == "Administrador")
                {
                    PRESTAMOS.PRESTAR_LIBRO_ADMIN();
                }
                else
                {
                    PRESTAMOS.PRESTAR_LIBRO_USER();
                }
            
                break;
            case 3:
            PRESTAMOS.DEVOLVER_LIBRO();
                break;
            case 4:
            MENUS.MENU_ADMIN();
                break;
        }

        Console.WriteLine();
    }
}


/* 
Para mañana: 
- Búsqueda del usuario luego de la confirmación del libro.
- Confirmar si es el usuario correcto.
- Agregar validaciones. 
- Completar ID de Préstamos con lo del IDLibro y IDUsuario.
- Ver porqué no se cambia de "Disponible" a "Prestado"

To-do:
- ¿Por qué me sale cuando ingreso el usuario que no está en el formato correcto? - Corregido, ahora corregir más bien por qué cuando digo "¿Es 'usuario' el usuario que busca? Me imprime otra vez también el ID del usuario que el di :/ Estoy segura que eso de return texto
*/