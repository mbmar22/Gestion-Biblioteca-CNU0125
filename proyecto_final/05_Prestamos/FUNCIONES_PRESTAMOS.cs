class PRESTAMOS
{
    public string IdPrestamo { get; set; }
    public REGISTRO_LIBROS.LIBROS Libro_Registrado { get; set; }
    public ADMINISTRACION_USUARIOS.USUARIO Usuario_Registrado { get; set; }
    public DateTime Fecha_Prestamo { get; set; }
    public DateTime? Fecha_Devolucion { get; set; }

    public PRESTAMOS(
        string idPrestamo,
        REGISTRO_LIBROS.LIBROS libroRegistrado,
        ADMINISTRACION_USUARIOS.USUARIO usuarioRegistrado,
        DateTime fechaPrestamo,
        DateTime? fechaDevolucion = null
    )
    {
        IdPrestamo = idPrestamo;
        Libro_Registrado = libroRegistrado;
        Usuario_Registrado = usuarioRegistrado;
        Fecha_Prestamo = fechaPrestamo;
        Fecha_Devolucion = fechaDevolucion;
    }
}