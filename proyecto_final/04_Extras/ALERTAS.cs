class ALERTAS
{
    public static void VACIO()
    {
        Decoraciones.TEXTO_ROJO("¡ ERROR ! Este campo no puede estar vacío.");
    }

    public static void ARCHIVO_NO_ENCONTRADO()
    {
        Decoraciones.TEXTO_ROJO("¡ ERROR ! No se ha encontrado el archivo al que se desea acceder.");
    }

    public static void YESNO()
    {
        Decoraciones.TEXTO_ROJO("¡ ERROR ! Solo puede ingresar S o N.");
    }

    public static void UNA_LETRA()
    {
        Decoraciones.TEXTO_ROJO("¡ ERROR ! Debe contener al menos una letra.");
    }

    public static void RESULTADO_NO_ENCONTRADO()
    {
        Decoraciones.TEXTO_ROJO("¡ ERROR ! No se han encontrado resultados que coincidan con su búsqueda");
    }

    public static void ACCESO_DENEGADO()
    {
        Decoraciones.TEXTO_ROJO("ERROR. ACCESO DENEGADO.");
    }

    public static void LIBRO_NO_DISPONIBLE()
    {
        Decoraciones.TEXTO_ROJO("¡ ERROR ! Este libro no se encuentra disponible para préstamoss.\n");
    }
}