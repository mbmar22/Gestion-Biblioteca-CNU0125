class ALERTAS
{
    public static void VACIO()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
        Console.ResetColor();
    }

    public static void ARCHIVO_NO_ENCONTRADO()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("¡ ERROR ! No se ha encontrado el archivo al que se desea acceder.");
        Console.ResetColor();
    }

    public static void YESNO()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("¡ ERROR ! Solo puede ingresar S o N.");
        Console.ResetColor();
    }

    public static void UNA_LETRA()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("¡ ERROR ! Debe contener al menos una letra.");
        Console.ResetColor();
    }

    public static void RESULTADO_NO_ENCONTRADO()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("¡ ERROR ! No se han encontrado resultados que coincidan con su búsqueda");
        Console.ResetColor();
    }

    public static void ACCESO_DENEGADO()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("ERROR. ACCESO DENEGADO.");
        Console.ResetColor();
    }
}