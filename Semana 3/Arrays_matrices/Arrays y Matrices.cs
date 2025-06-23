using System;
using System.Collections.Generic; // Para usar List<T>
using System.Linq; // Para métodos LINQ como Where y Select

namespace AcademicRecords
{
    /// <summary>
    /// Representa la información detallada de un alumno en el sistema.
    /// </summary>
    public class Student
    {
        // Propiedades del alumno
        public int StudentId { get; private set; } // Identificador único del alumno
        public string GivenNames { get; private set; } // Nombres del alumno
        public string Surnames { get; private set; } // Apellidos del alumno
        public string ResidentialAddress { get; private set; } // Dirección de residencia
        public List<string> ContactPhones { get; private set; } // Lista de números de teléfono

        /// <summary>
        /// Constructor para inicializar una nueva instancia de la clase Student.
        /// </summary>
        /// <param name="id">ID único del estudiante.</param>
        /// <param name="names">Nombres del estudiante.</param>
        /// <param name="lastNames">Apellidos del estudiante.</param>
        /// <param name="address">Dirección de residencia del estudiante.</param>
        /// <param name="phones">Una colección de números de teléfono (opcional).</param>
        public Student(int id, string names, string lastNames, string address, IEnumerable<string>? phones = null)
        {
            // Asignación de propiedades obligatorias
            StudentId = id;
            GivenNames = names;
            Surnames = lastNames;
            ResidentialAddress = address;

            // Inicialización de la lista de teléfonos. Si se proporcionan teléfonos, se añaden a la lista.
            ContactPhones = new List<string>();
            if (phones != null)
            {
                foreach (var phone in phones)
                {
                    if (!string.IsNullOrWhiteSpace(phone))
                    {
                        ContactPhones.Add(phone.Trim()); // Añade solo teléfonos no vacíos y sin espacios en blanco
                    }
                }
            }
        }

        /// <summary>
        /// Muestra todos los detalles del alumno en la consola.
        /// </summary>
        public void DisplayDetails()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"  ID del Estudiante: {StudentId}");
            Console.WriteLine($"  Nombres Completos: {GivenNames} {Surnames}");
            Console.WriteLine($"  Dirección Postal: {ResidentialAddress}");
            Console.Write("  Números de Contacto: ");
            if (ContactPhones.Any()) // Verifica si hay algún teléfono registrado
            {
                Console.WriteLine(string.Join(", ", ContactPhones)); // Une los teléfonos con coma y espacio
            }
            else
            {
                Console.WriteLine("Ninguno registrado.");
            }
            Console.WriteLine("------------------------------------------");
        }
    }

    /// <summary>
    /// Clase principal que gestiona el proceso de inscripción y visualización de alumnos.
    /// </summary>
    public class EnrollmentProcessor
    {
        private List<Student> registeredStudents = new List<Student>(); // Colección de alumnos registrados

        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.Title = "Sistema de Gestión de Expedientes Académicos"; // Establece el título de la consola
            var processor = new EnrollmentProcessor();
            processor.RunEnrollmentCycle();
        }

        /// <summary>
        /// Ejecuta el ciclo principal para registrar múltiples alumnos.
        /// </summary>
        public void RunEnrollmentCycle()
        {
            Console.WriteLine("\n===== INICIANDO GESTIÓN DE EXPEDIENTES ACADÉMICOS =====");

            bool keepEnrolling = true;
            while (keepEnrolling)
            {
                Console.WriteLine("\n--- Captura de Datos de Nuevo Alumno ---");
                Student? newStudent = CaptureStudentData(); // Intenta capturar los datos de un alumno

                if (newStudent != null)
                {
                    registeredStudents.Add(newStudent); // Si se capturó con éxito, lo añade a la lista
                    Console.WriteLine("\n¡Alumno registrado con éxito!");
                    newStudent.DisplayDetails(); // Muestra los detalles del alumno recién registrado
                }
                else
                {
                    Console.WriteLine("No se pudo completar el registro del alumno.");
                }

                // Pregunta al usuario si desea continuar o finalizar
                Console.Write("\n¿Registrar otro alumno? (Sí/No): ");
                string? response = Console.ReadLine()?.ToLower().Trim();
                keepEnrolling = (response == "s" || response == "si"); // Continúa si la respuesta es 's' o 'si'
            }

            DisplayAllRegisteredStudents(); // Muestra todos los alumnos al finalizar el ciclo
            Console.WriteLine("\n===== GESTIÓN DE EXPEDIENTES FINALIZADA. HASTA PRONTO. =====");
            // Console.ReadKey(); // Descomentar para pausar la consola antes de cerrar
        }

        /// <summary>
        /// Solicita y valida la entrada de datos para un nuevo alumno.
        /// </summary>
        /// <returns>Una nueva instancia de Student si los datos son válidos, de lo contrario null.</returns>
        private Student? CaptureStudentData()
        {
            int studentId = GetValidatedIntegerInput("Ingrese el ID del alumno: ", "ID inválido. Por favor, ingrese un número entero.");
            string names = GetValidatedStringInput("Ingrese los nombres del alumno: ", "Los nombres no pueden estar vacíos.");
            string lastNames = GetValidatedStringInput("Ingrese los apellidos del alumno: ", "Los apellidos no pueden estar vacíos.");
            string address = GetValidatedStringInput("Ingrese la dirección del alumno: ", "La dirección no puede estar vacía.");

            // Captura de números de teléfono (hasta 3, permitiendo vacíos para finalizar)
            Console.WriteLine("Ingrese hasta 3 números de teléfono (presione Enter vacío para finalizar):");
            List<string> phones = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Teléfono de Contacto {i + 1}: ");
                string? phoneInput = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(phoneInput))
                {
                    break; // Sale si el usuario no ingresa nada
                }
                phones.Add(phoneInput);
            }

            // Crea y retorna la instancia del alumno
            return new Student(studentId, names, lastNames, address, phones);
        }

        /// <summary>
        /// Obtiene una entrada de texto validada del usuario, asegurando que no esté vacía.
        /// </summary>
        /// <param name="prompt">El mensaje para el usuario.</param>
        /// <param name="errorMessage">El mensaje de error si la entrada es inválida.</param>
        /// <returns>La cadena de texto validada.</returns>
        private string GetValidatedStringInput(string prompt, string errorMessage)
        {
            string? input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(errorMessage);
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        /// <summary>
        /// Obtiene una entrada de número entero validada del usuario.
        /// </summary>
        /// <param name="prompt">El mensaje para el usuario.</param>
        /// <param name="errorMessage">El mensaje de error si la entrada no es un entero válido.</param>
        /// <returns>El número entero validado.</returns>
        private int GetValidatedIntegerInput(string prompt, string errorMessage)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }

        /// <summary>
        /// Muestra los detalles de todos los alumnos que han sido registrados.
        /// </summary>
        private void DisplayAllRegisteredStudents()
        {
            Console.WriteLine("\n\n===== RESUMEN DE ALUMNOS REGISTRADOS =====");
            if (!registeredStudents.Any())
            {
                Console.WriteLine("No hay alumnos registrados para mostrar.");
                return;
            }

            foreach (var student in registeredStudents)
            {
                student.DisplayDetails();
            }
        }
    }
}