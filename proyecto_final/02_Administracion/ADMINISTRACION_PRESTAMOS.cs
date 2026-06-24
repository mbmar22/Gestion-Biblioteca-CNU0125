using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

// En administración de préstamos se pueden prestar libros, devolver libros, consultar préstamos activos, consultar historial de préstamos, etc.

class ADMINISTRACION_PRESTAMOS
{
    public static void MENU_PRESTAMOS()
    {
        Decoraciones.ENCABEZADO();
        Decoraciones.TEXTO_CYAN("                ADMINISTRACIÓN DE PRÉSTAMOS Y DEVOLUCIONES\n");
        Console.WriteLine(
            "1. Ver historial de préstamos.\n" +
            "2. Prestar libro\n" +
            "3. Devolver libro.\n" +
            "4. Regresar al menú.");

        Console.WriteLine("");

        int respuesta = VALIDAR.OPCION("Digite el número de la acción que desea realizar: ", 1, 4);

        switch (respuesta)
        {
            case 1:
                if (INICIAR_SESION.Sesion.Rol == "Administrador")
                {
                    PRESTAMOS.MOSTRAR_PRESTAMOS_ADMIN();
                }
                else
                {
                    PRESTAMOS.MOSTRAR_PRESTAMOS_USER();
                }
                break;
            case 2:
                if (INICIAR_SESION.Sesion.Rol == "Administrador")
                {
                    PRESTAMOS.PRESTAR_LIBRO(true);
                }
                else
                {
                    PRESTAMOS.PRESTAR_LIBRO(false);
                }
                break;
            case 3:
                break;
            case 4:
                MENUS.MENU_ADMIN();
                break;
        }
        Console.WriteLine();
    }
}