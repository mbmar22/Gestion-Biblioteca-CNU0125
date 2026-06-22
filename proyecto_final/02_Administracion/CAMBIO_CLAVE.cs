class CAMBIO_CLAVE
{

    static String usuarios = ".//archivos//usuarios.csv";

    public static int VERIFICAR_USUARIO()
    {
        Decoraciones.ENCABEZADO();
        string usuario = VALIDAR.AL_MENOS_UNA_LETRA("Ingrese su usuario: ");
        string clave = VALIDAR.NO_VACIO("Ingrese su contraseña actual: ");

        if (!File.Exists(usuarios))
        {
            ALERTAS.ARCHIVO_NO_ENCONTRADO();
            return -1;
        }

        String[] lineas = File.ReadAllLines(usuarios);

        for (int i = 0; i < lineas.Length; i++)
        {
            string[] datos = lineas[i].Split(';');

            if (datos.Length < 7)
            {
                continue;
            }

            if (datos[3].Equals(usuario, StringComparison.OrdinalIgnoreCase) && datos[4] == clave)
            {
                return i;
            }

            else if (datos[3].Equals(usuario, StringComparison.OrdinalIgnoreCase) && datos[4] != clave)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n¡ERROR! Contraseña incorrecta.");
                Console.ResetColor();
                return -1;
            }
        }

        Console.WriteLine("Usuario no encontrado");
        return -1;
    }

    public static bool MODIFICAR_CLAVE()
    {
        int indice_usuario = VERIFICAR_USUARIO();

        if (indice_usuario == -1)
        {
            return false;
        }

        string nueva_clave = VALIDAR.NO_VACIO("Ingrese la nueva contraseña: ");
        string confirmacion_clave = VALIDAR.NO_VACIO("Confirme la nueva contraseña: ");

        if (nueva_clave != confirmacion_clave)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n¡ERROR! Las contraseñas no coinciden.");
            Console.ResetColor();
            return false;
        }

        string[] lineas = File.ReadAllLines(usuarios);

        string[] datos = lineas[indice_usuario].Split(';');

        datos[4] = nueva_clave;

        lineas[indice_usuario] = String.Join(";", datos);

        File.WriteAllLines(usuarios, lineas);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nContraseña actualizada correctamente.");
        Console.ResetColor();
        return true;
    }
}