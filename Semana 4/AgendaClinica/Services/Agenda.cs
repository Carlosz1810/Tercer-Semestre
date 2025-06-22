using AgendaClinica.Models;

namespace AgendaClinica.Services
{
    // Clase Agenda: Gestiona la colección de turnos y las operaciones relacionadas.
    public class Agenda
    {
        // Lista genérica para almacenar los turnos. Permite un tamaño dinámico.
        private List<Turno> _listaDeTurnos;
        private int _nextTurnoId; // Para asignar ID's únicos a los turnos
        private int _nextPacienteId; // Para asignar ID's únicos a los pacientes

        // Constructor de la clase Agenda.
        public Agenda()
        {
            _listaDeTurnos = new List<Turno>();
            _nextTurnoId = 1;
            _nextPacienteId = 1;
        }

        // Método para generar un ID de paciente único.
        public int GenerarNuevoPacienteId()
        {
            return _nextPacienteId++;
        }

        // Método para generar un ID de turno único.
        public int GenerarNuevoTurnoId()
        {
            return _nextTurnoId++;
        }

        // Método para agregar un nuevo turno a la agenda.
        public void AgregarTurno(Turno nuevoTurno)
        {
            _listaDeTurnos.Add(nuevoTurno);
            Console.WriteLine($"\nTurno ID {nuevoTurno.IdTurno} agregado exitosamente para el paciente {nuevoTurno.PacienteAsignado.Nombre}.");
        }

        // Método para consultar y retornar un turno por su ID.
        public Turno? ConsultarTurnoPorId(int idTurno)
        {
            // Usamos LINQ para encontrar el turno, o null si no se encuentra.
            return _listaDeTurnos.FirstOrDefault(t => t.IdTurno == idTurno);
        }

        // Método para consultar y retornar una lista de turnos para una fecha específica.
        public List<Turno> ConsultarTurnosPorFecha(DateTime fecha)
        {
            // Usamos LINQ para filtrar turnos por fecha.
            return _listaDeTurnos.Where(t => t.Fecha.Date == fecha.Date).ToList();
        }

        // Método para consultar y retornar una lista de turnos asociados a un paciente específico.
        public List<Turno> ConsultarTurnosPorPaciente(int idPaciente)
        {
            // Usamos LINQ para filtrar turnos por el ID del paciente.
            return _listaDeTurnos.Where(t => t.PacienteAsignado.Id == idPaciente).ToList();
        }

        // Método para actualizar el estado de un turno existente.
        public bool ActualizarEstadoTurno(int idTurno, string nuevoEstado)
        {
            Turno? turno = ConsultarTurnoPorId(idTurno);
            if (turno != null)
            {
                turno.Estado = nuevoEstado;
                Console.WriteLine($"\nEstado del Turno ID {idTurno} actualizado a '{nuevoEstado}'.");
                return true;
            }
            Console.WriteLine($"\nError: Turno ID {idTurno} no encontrado.");
            return false;
        }

        // Método para eliminar un turno de la agenda.
        public bool EliminarTurno(int idTurno)
        {
            Turno? turnoParaEliminar = ConsultarTurnoPorId(idTurno);
            if (turnoParaEliminar != null)
            {
                _listaDeTurnos.Remove(turnoParaEliminar);
                Console.WriteLine($"\nTurno ID {idTurno} eliminado exitosamente.");
                return true;
            }
            Console.WriteLine($"\nError: Turno ID {idTurno} no encontrado para eliminar.");
            return false;
        }

        // Método para visualizar todos los turnos registrados en la agenda.
        public void VisualizarTodosLosTurnos()
        {
            if (_listaDeTurnos.Count == 0)
            {
                Console.WriteLine("\nNo hay turnos registrados en la agenda.");
                return;
            }

            Console.WriteLine("\n--- LISTA DE TODOS LOS TURNOS ---");
            foreach (var turno in _listaDeTurnos)
            {
                turno.MostrarInfo(); // Llama al método MostrarInfo de cada turno
            }
            Console.WriteLine("---------------------------------");
        }
    }
}