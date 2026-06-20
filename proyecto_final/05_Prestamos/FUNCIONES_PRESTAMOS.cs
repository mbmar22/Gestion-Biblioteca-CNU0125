class Prestamos
{
    public string IdPrestamo { get; set; }
    public REGISTRO_LIBROS.LIBROS LibroRegistrado;

    public ADMINISTRACION_USUARIOS.USUARIO UsuarioRegistrado;
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