using AgendaClinica.Models;

namespace AgendaClinica.Models
{
    // Clase Turno: Representa un turno programado en la clínica.
    public class Turno
    {
        // Propiedades de la clase Turno
        public int IdTurno { get; set; } // Identificador único del turno
        public DateTime Fecha { get; set; } // Fecha del turno
        public TimeSpan Hora { get; set; } // Hora del turno
        public Paciente PacienteAsignado { get; set; } // Objeto Paciente asociado a este turno (Composición)
        public string Especialidad { get; set; } = string.Empty; // Especialidad médica del turno
        public string Estado { get; set; } = "Pendiente"; // Estado actual del turno (ej. Pendiente, Confirmado, Cancelado, Atendido)

        // Constructor para inicializar un nuevo objeto Turno.
        public Turno(int idTurno, DateTime fecha, TimeSpan hora, Paciente pacienteAsignado, string especialidad)
        {
            IdTurno = idTurno;
            Fecha = fecha;
            Hora = hora;
            PacienteAsignado = pacienteAsignado;
            Especialidad = especialidad;
        }

        // Método para mostrar la información detallada del turno.
        public void MostrarInfo()
        {
            Console.WriteLine($"--- Turno ID: {IdTurno} ---");
            Console.WriteLine($"  Fecha: {Fecha.ToShortDateString()}");
            Console.WriteLine($"  Hora: {Hora}");
            Console.WriteLine($"  Especialidad: {Especialidad}");
            Console.WriteLine($"  Estado: {Estado}");
            Console.WriteLine("  Información del Paciente:");
            PacienteAsignado.MostrarInfo(); // Llama al método MostrarInfo del objeto Paciente
            Console.WriteLine("--------------------------");
        }
    }
}