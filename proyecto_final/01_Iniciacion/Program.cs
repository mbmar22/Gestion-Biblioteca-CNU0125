using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void Main(String[] args)
    {
        Decoraciones.ENCABEZADO_INICIAL();
        
        String ROL = INICIAR_SESION.INICIO_DE_SESION();
        if (ROL == "")
        {
            ALERTAS.ACCESO_DENEGADO();
            return;
        }

        if (ROL == "Administrador") // llamar menu de admin
        {
            MENUS.MENU_ADMIN();
        }
        else
        {
            MENUS.MENU_USUARIO(); // llamar menu de usuarios regulares
        }
    }
}