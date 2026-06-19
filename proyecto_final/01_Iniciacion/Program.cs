class Program
{
    public static void Main(String[] args)
    {
        Decoraciones.ENCABEZADO_INICIAL();
        
        String ROL = INICIAR_SESION.INICIO_DE_SESION();
        if (ROL == "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR. ACCESO DENEGADO.");
            Console.ResetColor();
            return;
        }

        if (ROL == "Administrador")
        {
            Console.Clear();
            MENUS.MENU_ADMIN();
        }
        else
        {
            Console.Clear();
            MENUS.MENU_USUARIO();
        }
    }
}
