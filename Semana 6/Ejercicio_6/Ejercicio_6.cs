using System;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList<T>
{
    public Node<T>? Head { get; private set; }
    public int Count { get; private set; }

    public LinkedList()
    {
        Head = null;
        Count = 0;
    }

    public void AddLast(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        Count++;
    }

    public void AddFirst(T data)
    {
        Node<T> newNode = new Node<T>(data);
        newNode.Next = Head;
        Head = newNode;
        Count++;
    }

    public void PrintList()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }
        Node<T>? current = Head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    public Node<T>? Find(Predicate<T> predicate)
    {
        Node<T>? current = Head;
        while (current != null)
        {
            if (predicate(current.Data))
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public bool Remove(T data)
    {
        if (Head == null)
        {
            return false;
        }

        // Si el elemento a eliminar es la cabeza
        // Se usa el operador null-conditional para Head.Data para mayor seguridad.
        if (Head.Data?.Equals(data) == true)
        {
            Head = Head.Next;
            Count--;
            return true;
        }

        Node<T>? current = Head;
        // La condición del bucle ahora asegura que current y current.Next no son null
        while (current != null && current.Next != null)
        {
            // Ahora, dentro del bucle, sabemos que current.Next no es null.
            // Se añade una comprobación para current.Next.Data en caso de que 'T' pudiera ser null.
            // Para 'Estudiante', sus propiedades string no son nullables, pero es buena práctica.
            if (current.Next.Data != null && current.Next.Data.Equals(data))
            {
                current.Next = current.Next.Next;
                Count--;
                return true;
            }
            current = current.Next;
        }

        return false; // No se encontró el elemento
    }
}

public class Estudiante
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public int NotaDefinitiva { get; set; }

    public Estudiante(string cedula, string nombre, string apellido, string correo, int notaDefinitiva)
    {
        Cedula = cedula;
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        NotaDefinitiva = notaDefinitiva;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Cédula: {Cedula}, Nombre: {Nombre} {Apellido}, Correo: {Correo}, Nota: {NotaDefinitiva}");
    }
}

public class GestionEstudiantes
{
    private LinkedList<Estudiante> estudiantesList;

    public GestionEstudiantes()
    {
        estudiantesList = new LinkedList<Estudiante>();
    }

    public void AgregarEstudiante(Estudiante estudiante)
    {
        if (estudiante.NotaDefinitiva >= 6) // Asumiendo 6 como nota mínima para aprobar
        {
            estudiantesList.AddFirst(estudiante);
        }
        else
        {
            estudiantesList.AddLast(estudiante);
        }
    }

    public void BuscarEstudiantePorCedula(string cedula)
    {
        Node<Estudiante>? foundNode = estudiantesList.Find(e => e.Cedula == cedula);
        if (foundNode != null)
        {
            Console.WriteLine("Estudiante encontrado:");
            foundNode.Data.PrintInfo();
        }
        else
        {
            Console.WriteLine($"No se encontró ningún estudiante con la cédula {cedula}.");
        }
    }

    public void EliminarEstudiante(string cedula)
    {
        Node<Estudiante>? studentToDeleteNode = estudiantesList.Find(e => e.Cedula == cedula);
        if (studentToDeleteNode != null)
        {
            if (estudiantesList.Remove(studentToDeleteNode.Data))
            {
                Console.WriteLine($"Estudiante con cédula {cedula} eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine($"Error al intentar eliminar al estudiante con cédula {cedula}.");
            }
        }
        else
        {
            Console.WriteLine($"No se encontró ningún estudiante con la cédula {cedula} para eliminar.");
        }
    }

    public int TotalEstudiantesAprobados()
    {
        int count = 0;
        Node<Estudiante>? current = estudiantesList.Head;
        while (current != null)
        {
            if (current.Data.NotaDefinitiva >= 6)
            {
                count++;
            }
            current = current.Next;
        }
        return count;
    }

    public int TotalEstudiantesReprobados()
    {
        int count = 0;
        Node<Estudiante>? current = estudiantesList.Head;
        while (current != null)
        {
            if (current.Data.NotaDefinitiva < 6)
            {
                count++;
            }
            current = current.Next;
        }
        return count;
    }

    public void MostrarTodosEstudiantes()
    {
        Console.WriteLine("\n--- Lista de todos los estudiantes ---");
        if (estudiantesList.Head == null)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }
        Node<Estudiante>? current = estudiantesList.Head;
        while (current != null)
        {
            current.Data.PrintInfo();
            current = current.Next;
        }
        Console.WriteLine("--------------------------------------");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        GestionEstudiantes gestion = new GestionEstudiantes();
        bool running = true;

        // Cargar algunos datos iniciales para probar
        gestion.AgregarEstudiante(new Estudiante("12345", "Juan", "Perez", "juan.p@mail.com", 8));
        gestion.AgregarEstudiante(new Estudiante("67890", "Maria", "Gonzalez", "maria.g@mail.com", 5));
        gestion.AgregarEstudiante(new Estudiante("11223", "Pedro", "Ramirez", "pedro.r@mail.com", 7));
        gestion.AgregarEstudiante(new Estudiante("44556", "Ana", "Lopez", "ana.l@mail.com", 4));

        while (running)
        {
            Console.WriteLine("\n=== MENÚ DE GESTIÓN DE ESTUDIANTES ===");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Buscar estudiante por cédula");
            Console.WriteLine("3. Eliminar estudiante por cédula");
            Console.WriteLine("4. Ver total de estudiantes aprobados");
            Console.WriteLine("5. Ver total de estudiantes reprobados");
            Console.WriteLine("6. Mostrar todos los estudiantes");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n--- AGREGAR NUEVO ESTUDIANTE ---");
                        Console.Write("Cédula: ");
                        string? cedula = Console.ReadLine();
                        Console.Write("Nombre: ");
                        string? nombre = Console.ReadLine();
                        Console.Write("Apellido: ");
                        string? apellido = Console.ReadLine();
                        Console.Write("Correo: ");
                        string? correo = Console.ReadLine();
                        Console.Write("Nota Definitiva (1-10): ");
                        if (int.TryParse(Console.ReadLine(), out int nota))
                        {
                            if (string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(nombre) ||
                                string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(correo))
                            {
                                Console.WriteLine("Todos los campos (cédula, nombre, apellido, correo) son obligatorios.");
                            }
                            else if (nota < 1 || nota > 10)
                            {
                                Console.WriteLine("La nota debe estar entre 1 y 10.");
                            }
                            else
                            {
                                gestion.AgregarEstudiante(new Estudiante(cedula, nombre, apellido, correo, nota));
                                Console.WriteLine("Estudiante agregado exitosamente.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada de nota no válida. Intente de nuevo.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("\n--- BUSCAR ESTUDIANTE ---");
                        Console.Write("Ingrese la cédula del estudiante a buscar: ");
                        string? searchCedula = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(searchCedula))
                        {
                            Console.WriteLine("La cédula no puede estar vacía.");
                        }
                        else
                        {
                            gestion.BuscarEstudiantePorCedula(searchCedula);
                        }
                        break;
                    case 3:
                        Console.WriteLine("\n--- ELIMINAR ESTUDIANTE ---");
                        Console.Write("Ingrese la cédula del estudiante a eliminar: ");
                        string? deleteCedula = Console.ReadLine();
                         if (string.IsNullOrWhiteSpace(deleteCedula))
                        {
                            Console.WriteLine("La cédula no puede estar vacía.");
                        }
                        else
                        {
                            gestion.EliminarEstudiante(deleteCedula);
                        }
                        break;
                    case 4:
                        Console.WriteLine("\n--- TOTAL ESTUDIANTES APROBADOS ---");
                        Console.WriteLine($"Total de estudiantes aprobados: {gestion.TotalEstudiantesAprobados()}");
                        break;
                    case 5:
                        Console.WriteLine("\n--- TOTAL ESTUDIANTES REPROBADOS ---");
                        Console.WriteLine($"Total de estudiantes reprobados: {gestion.TotalEstudiantesReprobados()}");
                        break;
                    case 6:
                        gestion.MostrarTodosEstudiantes();
                        break;
                    case 7:
                        running = false;
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}