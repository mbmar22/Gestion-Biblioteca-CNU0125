class PRESTAMOS
{
    public string IdPrestamo { get; set; }
    public string LibroId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime Fecha_Prestamo { get; set; }
    public DateTime? Fecha_Devolucion { get; set; }

    public PRESTAMOS(
        string idPrestamo,
        string libroId,
        int usuarioId,
        DateTime fechaPrestamo,
        DateTime? fechaDevolucion = null
    )
    {
        IdPrestamo = idPrestamo;
        LibroId = libroId;
        UsuarioId = usuarioId;
        Fecha_Prestamo = fechaPrestamo;
        Fecha_Devolucion = fechaDevolucion;
    }
}