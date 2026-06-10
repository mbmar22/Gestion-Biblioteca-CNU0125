class ManejarUsuario
{
    static String usuarios = ".//archivos//usuarios.csv";
    public static void MANEJAR_USUARIO()
    {
        Console.WriteLine("        ──────────────────────────────────────────────────────────────");
        Decoraciones.ENCABEZADO();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                     PANEL DE MODIFICACIÓN DE USUARIOS ");
        Console.WriteLine("");
        Console.ResetColor();

        if (! (File.Exists(usuarios)))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Archivo no encontrado.");
            Console.ResetColor();
            return;
        }
        String BUSCADO;
        do
        {
            Console.Write("Ingrese el nombre del usuario al que desea acceder: ");
            BUSCADO = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(BUSCADO))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Este campo no puede estar vacío.");
                Console.ResetColor();
            }
            else if (!BUSCADO.Any(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ ERROR ! Debe contener al menos una letra.");
                Console.ResetColor();
            }

        } while (String.IsNullOrWhiteSpace(BUSCADO) || !BUSCADO.Any(char.IsLetter));

        String [] lineas = File.ReadAllLines(usuarios);
        bool ENCONTRADO = false;
        int CAMBIO;
        String ROL = "";
        String ESTADO = "";

        for (int i = 0; i < lineas.Length; i++)
        {
            /* PARA EL MANEJO DE LAS LINEAS EN LOS ARREGLOS
            datos[0] = nombre     datos[1] = apellido
            datos[2] = usuario    datos[3] = contraseña
            datos[4] = rol        datos[5] = estado */

            String[] datos = lineas[i].Split(';');
            if (datos[2].ToLower() == BUSCADO.ToLower())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("¡Usuario encontrado éxitosamente!");
                Console.ResetColor();
                Console.WriteLine(
                "Nombre: " + datos[0] + " " + datos[1] +
                "\nUsuario: " + datos[2] +
                "\nRol: " + datos[4] +
                "\nEstado: " + datos[5]
                );
                Console.WriteLine("");
                Console.WriteLine("Puedes realizar las siguientes acciones: ");
                Console.WriteLine("1. Cambiar rol  - 2. Cambiar estado");
                Console.Write("Digite el número de la acción que desea realizar: ");
                while ((!int.TryParse(Console.ReadLine(), out CAMBIO)) || (CAMBIO != 1 && CAMBIO != 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡ ERROR ! Debe ingresar una opción válida (1 o 2).");
                    Console.ResetColor();
                    Console.Write("Digite el número de la acción que desea realizar: ");
                }
                if (CAMBIO == 1)
                {
                    if (datos[4] == "Administrador")
                    {
                        ROL = "Usuario";
                    }
                    else if (datos[4] == "Usuario")
                    {
                        ROL = "Administrador";
                    }
                    lineas[i] = $"{datos[0]};{datos[1]};{datos[2]};{datos[3]};{ROL};{datos[5]}";
                }
                else
                {
                    if (datos[5] == "Activo")
                    {
                        ESTADO = "Inactivo";
                    }
                    else if (datos[5] == "Inactivo")
                    {
                        ESTADO = "Activo";
                    }
                    lineas[i] = $"{datos[0]};{datos[1]};{datos[2]};{datos[3]};{datos[4]};{ESTADO}";
                }

                ENCONTRADO = true;
                if (ENCONTRADO)
                {
                File.WriteAllLines(usuarios, lineas);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n¡Cambios guardados con éxito!");
                Console.ResetColor();
                Console.WriteLine("Regresará al Panel de Administración.");
                Console.WriteLine("");
                }
            }
        }

        if (ENCONTRADO == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("¡ ERROR ! No se ha encontrado el usuario.");
            Console.ResetColor();
            Console.WriteLine("Regresará al Panel de Administración.");
            Console.WriteLine("");
        }
    }
}
