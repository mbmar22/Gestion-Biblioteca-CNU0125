class Prestamos : ADMINISTRACION_USUARIOS
{
    public string IdPrestamo { get; set; }
    public DateTime Fecha_Prestamo { get; set; }
    public DateTime? Fecha_Devolucion { get; set; }
    //public 

    public Prestamos(
        string idPrestamo,
        DateTime fechaPrestamo,
        DateTime? fechaDevolucion = null
    )
    {
        IdPrestamo = idPrestamo;
        Fecha_Prestamo = fechaPrestamo;
        Fecha_Devolucion = fechaDevolucion;
    }
}