class ManejarUsuario
{
    static String usuarios = ".//archivos//usuarios.txt";
    public static void MANEJAR_USUARIO()
    {
        Console.WriteLine("        ──────────────────────────────────────────────────────────────");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                     PANEL DE ADMINISTRACIÓN DE USUARIOS ");
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
        String TIPO = "";
        String ESTADO = "";

        for (int i = 0; i < lineas.Length; i++)
        {
            String[] datos = lineas[i].Split(',');
            if (datos[0].ToLower() == BUSCADO.ToLower())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("¡Usuario encontrado éxitosamente!");
                Console.ResetColor();
                Console.WriteLine(
                "Usuario: " + datos[0] +
                "\nRol: " + datos[2] +
                "\nEstado: " + datos[3]
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
                    if (datos[2] == "Administrador")
                    {
                        TIPO = "Usuario";
                    }
                    else if (datos[2] == "Usuario")
                    {
                        TIPO = "Administrador";
                    }
                    lineas[i] = datos[0] + "," + datos[1] + "," + TIPO + "," + datos[3];
                }
                else
                {
                    if (datos[3] == "Activo")
                    {
                        ESTADO = "Inactivo";
                    }
                    else if (datos[3] == "Inactivo")
                    {
                        ESTADO = "Activo";
                    }
                    lineas[i] = datos[0] + "," + datos[1] + "," + datos[2] + "," + ESTADO;
                }

                ENCONTRADO = true;
                if (ENCONTRADO)
                {
                File.WriteAllLines(usuarios, lineas);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n¡Cambios guardados con éxito!");
                Console.ResetColor();
                Console.WriteLine("Regresará al Panel de Administración.");
                }
            }
        }

        if (ENCONTRADO == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("¡ ERROR ! No se ha encontrado el usuario.");
            Console.ResetColor();
            Console.WriteLine("Regresará al Panel de Administración.");
        }
    }
}
