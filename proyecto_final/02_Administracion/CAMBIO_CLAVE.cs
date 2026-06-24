class CAMBIO_CLAVE
{
    static string usuarios = ".//archivos//usuarios.csv";

    public static int VERIFICAR_USUARIO()
    {
        if (!File.Exists(usuarios))
        {
            ALERTAS.ARCHIVO_NO_ENCONTRADO();
            Console.ReadKey();
            return -1;
        }

        do
        {
            Console.Clear();
            Decoraciones.ENCABEZADO();
            Decoraciones.TEXTO_CYAN("                    PANEL DE CAMBIO DE CONTRASEÑA");

            string usuario = VALIDAR.AL_MENOS_UNA_LETRA("\nIngrese su usuario: ");
            string clave = VALIDAR.NO_VACIO("Ingrese su contraseña actual: ");

            string[] lineas = File.ReadAllLines(usuarios);
            bool usuarioEncontrado = false;

            for (int i = 0; i < lineas.Length; i++)
            {
                string[] datos = lineas[i].Split(';');

                if (datos.Length < 6)
                {
                    continue;
                }

                if (datos[3].Equals(usuario, StringComparison.OrdinalIgnoreCase))
                {
                    usuarioEncontrado = true;

                    if (datos[4] == clave)
                    {
                        return i;
                    }

                    Decoraciones.TEXTO_ROJO("\n¡ ERROR ! Contraseña incorrecta.");
                    Console.ReadKey();
                    break;
                }
            }

            if (!usuarioEncontrado)
            {
                Decoraciones.TEXTO_ROJO("\n¡ ERROR ! Usuario no encontrado.");
                Console.ReadKey();
            }

        } while (true);
    }

    public static bool MODIFICAR_CLAVE()
    {
        int indice_usuario = VERIFICAR_USUARIO();

        if (indice_usuario == -1)
        {
            return false;
        }

        string nueva_clave = VALIDAR.NO_VACIO("\nIngrese la nueva contraseña: ");
        string confirmacion_clave = VALIDAR.NO_VACIO("Confirme la nueva contraseña: ");

        if (nueva_clave != confirmacion_clave)
        {
            Decoraciones.TEXTO_ROJO("\n¡ERROR! Las contraseñas no coinciden.");
            Console.ReadKey();
            return false;
        }

        string[] lineas = File.ReadAllLines(usuarios);
        string[] datos = lineas[indice_usuario].Split(';');

        if (nueva_clave == datos[4])
        {
            Decoraciones.TEXTO_ROJO("\n¡ ERROR ! La nueva contraseña no puede ser igual a la actual.");
            Console.ReadKey();
            return false;
        }
        datos[4] = nueva_clave;

        lineas[indice_usuario] = string.Join(";", datos);

        File.WriteAllLines(usuarios, lineas);

        Decoraciones.TEXTO_VERDE("\n¡Contraseña actualizada con éxito!");
        Console.Write("Presione cualquier tecla para salir del programa... ");
        Console.ReadKey();

        return true;
    }
}