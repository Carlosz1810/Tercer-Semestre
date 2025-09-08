using System;

public class Program
{
    static void Main(string[] args)
    {
        Torneo torneo = new Torneo();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n=============================================");
            Console.WriteLine("  Menú de la Aplicación del Torneo de Fútbol");
            Console.WriteLine(" ===========================================");
            Console.WriteLine("1. Registrar un nuevo equipo");
            Console.WriteLine("2. Registrar un jugador en un equipo");
            Console.WriteLine("3. Listar todos los equipos");
            Console.WriteLine("4. Listar jugadores de un equipo específico");
            Console.WriteLine("5. Buscar un jugador por nombre");
            Console.WriteLine("6. Salir");
            Console.Write("Por favor, seleccione una opción: ");

            string? opcion = Console.ReadLine(); // Se usa string? para indicar que puede ser nulo

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre del equipo: ");
                    string? nombreEquipo = Console.ReadLine();
                    // Validación de la entrada para evitar nulos
                    if (!string.IsNullOrWhiteSpace(nombreEquipo))
                    {
                        torneo.RegistrarEquipo(nombreEquipo);
                    }
                    else
                    {
                        Console.WriteLine("El nombre del equipo no puede estar vacío.");
                    }
                    break;

                case "2":
                    Console.Write("Ingrese el ID del equipo: ");
                    string? inputEquipoId = Console.ReadLine();
                    // Se usa int.TryParse para validar la entrada y evitar excepciones
                    if (int.TryParse(inputEquipoId, out int equipoId))
                    {
                        Console.Write("Ingrese el nombre del jugador: ");
                        string? nombreJugador = Console.ReadLine();
                        Console.Write("Ingrese la edad del jugador: ");
                        string? inputEdadJugador = Console.ReadLine();
                        Console.Write("Ingrese la posición del jugador: ");
                        string? posicionJugador = Console.ReadLine();
                        Console.Write("Ingrese el número de camiseta: ");
                        string? inputNumeroCamiseta = Console.ReadLine();

                        // Se validan todas las entradas antes de registrar el jugador
                        if (!string.IsNullOrWhiteSpace(nombreJugador) &&
                            int.TryParse(inputEdadJugador, out int edadJugador) &&
                            !string.IsNullOrWhiteSpace(posicionJugador) &&
                            int.TryParse(inputNumeroCamiseta, out int numeroCamiseta))
                        {
                            torneo.RegistrarJugador(equipoId, nombreJugador, edadJugador, posicionJugador, numeroCamiseta);
                        }
                        else
                        {
                            Console.WriteLine("Error en la entrada de datos del jugador. Verifique la información.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de equipo no válido. Por favor, intente de nuevo.");
                    }
                    break;

                case "3":
                    torneo.ListarEquipos();
                    break;

                case "4":
                    Console.Write("Ingrese el ID del equipo para listar sus jugadores: ");
                    string? inputIdEquipoListar = Console.ReadLine();
                    if (int.TryParse(inputIdEquipoListar, out int idEquipoListar))
                    {
                        torneo.ListarJugadoresPorEquipo(idEquipoListar);
                    }
                    else
                    {
                        Console.WriteLine("ID de equipo no válido. Por favor, intente de nuevo.");
                    }
                    break;

                case "5":
                    Console.Write("Ingrese el nombre del jugador a buscar: ");
                    string? nombreBuscar = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nombreBuscar))
                    {
                        torneo.BuscarJugador(nombreBuscar);
                    }
                    else
                    {
                        Console.WriteLine("El nombre del jugador no puede estar vacío.");
                    }
                    break;

                case "6":
                    salir = true;
                    Console.WriteLine("Saliendo de la aplicación...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, elija una opción del 1 al 6.");
                    break;
            }
        }
    }
}