namespace AgendaClinica.Models
{
    // Clase Paciente: Representa la información de un paciente.
    public class Paciente
    {
        // Propiedades de la clase Paciente
        public int Id { get; set; } // Identificador único del paciente
        public string Nombre { get; set; } = string.Empty; // Nombre completo del paciente
        public string Cedula { get; set; } = string.Empty; // Número de cédula o identificación
        public string Telefono { get; set; } = string.Empty; // Número de teléfono de contacto
        public string Direccion { get; set; } = string.Empty; // Dirección del paciente

        // Constructor para inicializar un nuevo objeto Paciente.
        public Paciente(int id, string nombre, string cedula, string telefono, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Cedula = cedula;
            Telefono = telefono;
            Direccion = direccion;
        }

        // Método para mostrar la información del paciente.
        public void MostrarInfo()
        {
            Console.WriteLine($"  ID Paciente: {Id}");
            Console.WriteLine($"  Nombre: {Nombre}");
            Console.WriteLine($"  Cédula: {Cedula}");
            Console.WriteLine($"  Teléfono: {Telefono}");
            Console.WriteLine($"  Dirección: {Direccion}");
        }
    }
}