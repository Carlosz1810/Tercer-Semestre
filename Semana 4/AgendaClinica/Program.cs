using AgendaClinica.Models;
using AgendaClinica.Services;

namespace AgendaClinica
{
    public class Program
    {
        // Instancia de la clase Agenda para gestionar los turnos.
        private static Agenda _agenda = new Agenda();

        static void Main(string[] args)
        {
            Console.WriteLine("+++++ BIENVENIDO A LA AGENDA DE TURNOS DE LA CLÍNICA +++++");

            bool continuar = true;
            while (continuar)
            {
                MostrarMenu();
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarNuevoTurno();
                        break;
                    case "2":
                        VisualizarTodosLosTurnos();
                        break;
                    case "3":
                        ConsultarTurnoPorId();
                        break;
                    case "4":
                        ConsultarTurnosPorFecha();
                        break;
                    case "5":
                        ConsultarTurnosPorPaciente();
                        break;
                    case "6":
                        ActualizarEstadoTurno();
                        break;
                    case "7":
                        EliminarTurno();
                        break;
                    case "8":
                        continuar = false;
                        Console.WriteLine("\n¡Gracias por usar la Agenda de Turnos! Saliendo...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Por favor, intente de nuevo.");
                        break;
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear(); // Limpia la consola para mantener la interfaz limpia
            }
        }

        // Muestra las opciones del menú principal.
        static void MostrarMenu()
        {
            Console.WriteLine("\n===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1. Registrar Nuevo Turno");
            Console.WriteLine("2. Visualizar Todos los Turnos");
            Console.WriteLine("3. Consultar Turno por ID");
            Console.WriteLine("4. Consultar Turnos por Fecha");
            Console.WriteLine("5. Consultar Turnos por ID de Paciente");
            Console.WriteLine("6. Actualizar Estado de Turno");
            Console.WriteLine("7. Eliminar Turno");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una opción: ");
        }

        // Lógica para registrar un nuevo turno.
        static void RegistrarNuevoTurno()
        {
            Console.WriteLine("\n=== REGISTRAR NUEVO TURNO ===");

            // Solicitar datos del paciente
            int pacienteId = _agenda.GenerarNuevoPacienteId(); // Genera un ID de paciente único
            Console.Write("Ingrese el nombre del paciente: ");
            string nombrePaciente = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese la cédula del paciente: ");
            string cedulaPaciente = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese el teléfono del paciente: ");
            string telefonoPaciente = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese la dirección del paciente: ");
            string direccionPaciente = Console.ReadLine() ?? string.Empty;

            // Crear objeto Paciente
            Paciente nuevoPaciente = new Paciente(pacienteId, nombrePaciente, cedulaPaciente, telefonoPaciente, direccionPaciente);

            // Solicitar datos del turno
            int turnoId = _agenda.GenerarNuevoTurnoId(); // Genera un ID de turno único

            DateTime fechaTurno;
            Console.Write("Ingrese la fecha del turno (DD/MM/AAAA): ");
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaTurno))
            {
                Console.Write("Formato de fecha inválido. Intente de nuevo (DD/MM/AAAA): ");
            }

            TimeSpan horaTurno;
            Console.Write("Ingrese la hora del turno (HH:MM): ");
            while (!TimeSpan.TryParseExact(Console.ReadLine(), "hh\\:mm", null, out horaTurno))
            {
                Console.Write("Formato de hora inválido. Intente de nuevo (HH:MM): ");
            }

            Console.Write("Ingrese la especialidad del turno: ");
            string especialidadTurno = Console.ReadLine() ?? string.Empty;

            // Crear objeto Turno y agregarlo a la agenda
            Turno nuevoTurno = new Turno(turnoId, fechaTurno, horaTurno, nuevoPaciente, especialidadTurno);
            _agenda.AgregarTurno(nuevoTurno);
        }

        // Llama al método para visualizar todos los turnos.
        static void VisualizarTodosLosTurnos()
        {
            _agenda.VisualizarTodosLosTurnos();
        }

        // Lógica para consultar un turno por su ID.
        static void ConsultarTurnoPorId()
        {
            Console.WriteLine("\n=== CONSULTAR TURNO POR ID ===");
            Console.Write("Ingrese el ID del turno a buscar: ");
            if (int.TryParse(Console.ReadLine(), out int idBuscado))
            {
                Turno? turnoEncontrado = _agenda.ConsultarTurnoPorId(idBuscado);
                if (turnoEncontrado != null)
                {
                    Console.WriteLine("\nTurno encontrado:");
                    turnoEncontrado.MostrarInfo();
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún turno con ID {idBuscado}.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número.");
            }
        }

        // Lógica para consultar turnos por fecha.
        static void ConsultarTurnosPorFecha()
        {
            Console.WriteLine("\n=== CONSULTAR TURNOS POR FECHA ===");
            DateTime fechaBuscada;
            Console.Write("Ingrese la fecha para buscar turnos (DD/MM/AAAA): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaBuscada))
            {
                List<Turno> turnosEncontrados = _agenda.ConsultarTurnosPorFecha(fechaBuscada);
                if (turnosEncontrados.Count > 0)
                {
                    Console.WriteLine($"\nTurnos encontrados para la fecha {fechaBuscada.ToShortDateString()}:");
                    foreach (var turno in turnosEncontrados)
                    {
                        turno.MostrarInfo();
                    }
                }
                else
                {
                    Console.WriteLine($"No se encontraron turnos para la fecha {fechaBuscada.ToShortDateString()}.");
                }
            }
            else
            {
                Console.WriteLine("Formato de fecha inválido. Intente de nuevo (DD/MM/AAAA).");
            }
        }

        // Lógica para consultar turnos por ID de paciente.
        static void ConsultarTurnosPorPaciente()
        {
            Console.WriteLine("\n=== CONSULTAR TURNOS POR ID DE PACIENTE ===");
            Console.Write("Ingrese el ID del paciente para buscar sus turnos: ");
            if (int.TryParse(Console.ReadLine(), out int idPacienteBuscado))
            {
                List<Turno> turnosEncontrados = _agenda.ConsultarTurnosPorPaciente(idPacienteBuscado);
                if (turnosEncontrados.Count > 0)
                {
                    Console.WriteLine($"\nTurnos encontrados para el paciente ID {idPacienteBuscado}:");
                    foreach (var turno in turnosEncontrados)
                    {
                        turno.MostrarInfo();
                    }
                }
                else
                {
                    Console.WriteLine($"No se encontraron turnos para el paciente con ID {idPacienteBuscado}.");
                }
            }
            else
            {
                Console.WriteLine("ID de paciente inválido. Por favor, ingrese un número.");
            }
        }

        // Lógica para actualizar el estado de un turno.
        static void ActualizarEstadoTurno()
        {
            Console.WriteLine("\n=== ACTUALIZAR ESTADO DE TURNO ===");
            Console.Write("Ingrese el ID del turno a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int idActualizar))
            {
                Console.Write("Ingrese el nuevo estado (ej. Confirmado, Cancelado, Atendido): ");
                string nuevoEstado = Console.ReadLine() ?? string.Empty;
                _agenda.ActualizarEstadoTurno(idActualizar, nuevoEstado);
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número.");
            }
        }

        // Lógica para eliminar un turno.
        static void EliminarTurno()
        {
            Console.WriteLine("\n=== ELIMINAR TURNO ===");
            Console.Write("Ingrese el ID del turno a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idEliminar))
            {
                _agenda.EliminarTurno(idEliminar);
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número.");
            }
        }
    }
}