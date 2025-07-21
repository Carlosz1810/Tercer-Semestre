using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AtraccionParque
{
    // Clase Persona
    public class Persona
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }

        public Persona(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}";
        }
    }

    // Clase Atraccion
    public class Atraccion
    {
        private const int CapacidadMaxima = 30;
        private Queue<Persona> filaDeEspera;
        private List<Persona> asientosAsignados;
        private int contadorPersonas;

        public Atraccion()
        {
            filaDeEspera = new Queue<Persona>();
            asientosAsignados = new List<Persona>();
            contadorPersonas = 0;
        }

        public void AnadirPersonaAFila(string nombrePersona)
        {
            contadorPersonas++;
            Persona nuevaPersona = new Persona(contadorPersonas, nombrePersona);
            filaDeEspera.Enqueue(nuevaPersona);
            Console.WriteLine($"[INFO] {nuevaPersona.Nombre} (ID: {nuevaPersona.Id}) se ha unido a la fila.");
        }

        public void AsignarAsientos()
        {
            if (asientosAsignados.Count >= CapacidadMaxima)
            {
                Console.WriteLine("\n[AVISO] La atracción ya está llena. No se pueden asignar más asientos en esta ronda.");
                return;
            }

            int asientosPorAsignarEnEstaRonda = Math.Min(filaDeEspera.Count, CapacidadMaxima - asientosAsignados.Count);

            if (asientosPorAsignarEnEstaRonda == 0)
            {
                Console.WriteLine("\n[INFO] No hay personas en la fila de espera para asignar asientos.");
                return;
            }

            Console.WriteLine($"\nIniciando asignación de {asientosPorAsignarEnEstaRonda} asientos...");
            for (int i = 0; i < asientosPorAsignarEnEstaRonda; i++)
            {
                Persona personaActual = filaDeEspera.Dequeue();
                asientosAsignados.Add(personaActual);
                Console.WriteLine($"[ASIGNADO] Asiento para {personaActual.Nombre} (ID: {personaActual.Id}). Asientos ocupados: {asientosAsignados.Count}/{CapacidadMaxima}");
                Thread.Sleep(50); // Pequeña pausa para simular el proceso
            }

            if (asientosAsignados.Count == CapacidadMaxima)
            {
                Console.WriteLine("\n[COMPLETO] ¡Todos los asientos han sido asignados!");
            }
            else
            {
                Console.WriteLine($"\n[INFO] Se asignaron todos los asientos disponibles en la fila. Asientos ocupados: {asientosAsignados.Count}/{CapacidadMaxima}");
            }
        }

        // --- Reportería ---

        public void MostrarFilaDeEspera()
        {
            Console.WriteLine("\n--- Fila de Espera Actual ---");
            if (filaDeEspera.Any())
            {
                int posicion = 1;
                foreach (var persona in filaDeEspera)
                {
                    Console.WriteLine($"  {posicion}. {persona}");
                    posicion++;
                }
            }
            else
            {
                Console.WriteLine("  La fila de espera está vacía.");
            }
            Console.WriteLine("-----------------------------");
        }

        public void MostrarAsientosAsignados()
        {
            Console.WriteLine("\n--- Asientos Asignados ---");
            if (asientosAsignados.Any())
            {
                int asiento = 1;
                foreach (var persona in asientosAsignados)
                {
                    Console.WriteLine($"  Asiento {asiento}: {persona}");
                    asiento++;
                }
            }
            else
            {
                Console.WriteLine("  No hay asientos asignados aún.");
            }
            Console.WriteLine($"  Total asientos ocupados: {asientosAsignados.Count}/{CapacidadMaxima}");
            Console.WriteLine("--------------------------");
        }

        public int ObtenerAsientosDisponibles()
        {
            return CapacidadMaxima - asientosAsignados.Count;
        }

        // Método para "vaciar" la atracción y simular una nueva ronda
        public void ReiniciarAtraccion()
        {
            filaDeEspera.Clear();
            asientosAsignados.Clear();
            contadorPersonas = 0;
            Console.WriteLine("\n[INFO] La atracción ha sido reiniciada. Todos los asientos están vacíos y la fila de espera se ha limpiado.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Atraccion miAtraccion = new Atraccion();
            bool salir = false;

            Console.WriteLine("--- Simulación Interactiva de Asignación de Asientos en Atracción ---");

            while (!salir)
            {
                Console.WriteLine("\n=== Menú Principal ===");
                Console.WriteLine("1. Añadir persona a la fila");
                Console.WriteLine("2. Asignar asientos");
                Console.WriteLine("3. Mostrar fila de espera");
                Console.WriteLine("4. Mostrar asientos asignados");
                Console.WriteLine("5. Ver asientos disponibles");
                Console.WriteLine("6. Reiniciar atracción (vaciar asientos y fila)");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre de la persona: ");
                        string nombre = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nombre))
                        {
                            miAtraccion.AnadirPersonaAFila(nombre);
                        }
                        else
                        {
                            Console.WriteLine("[ERROR] El nombre no puede estar vacío.");
                        }
                        break;
                    case "2":
                        miAtraccion.AsignarAsientos();
                        break;
                    case "3":
                        miAtraccion.MostrarFilaDeEspera();
                        break;
                    case "4":
                        miAtraccion.MostrarAsientosAsignados();
                        break;
                    case "5":
                        Console.WriteLine($"\nAsientos disponibles: {miAtraccion.ObtenerAsientosDisponibles()}/{30}");
                        break;
                    case "6":
                        miAtraccion.ReiniciarAtraccion();
                        break;
                    case "7":
                        salir = true;
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("[ERROR] Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear(); // Limpiar la consola para una mejor experiencia
            }
        }
    }
}