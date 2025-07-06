using System;

// Clase para representar un nodo en la lista enlazada
public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; } // Propiedad 'Next' declarada como anulable

    public Node(T data)
    {
        Data = data;
        Next = null; // Asignación de null permitida porque 'Next' es anulable
    }
}

// Clase genérica para la lista enlazada
public class LinkedList<T>
{
    public Node<T>? Head { get; private set; } // Propiedad 'Head' declarada como anulable
    public int Count { get; private set; }

    public LinkedList()
    {
        Head = null; // Asignación de null permitida porque 'Head' es anulable
        Count = 0;
    }

    // Método para agregar un nodo al final de la lista
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

    // Método para imprimir los elementos de la lista
    public void PrintList()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }
        Node<T> current = Head;
        Console.Write("Lista: ");
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    // Función para contar el número de elementos
    public int GetNodeCount()
    {
        int count = 0;
        Node<T>? current = Head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }
}

public class ProgramEjercicio1
{
    public static void Main(string[] args)
    {
        ;
        LinkedList<int> myList = new LinkedList<int>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== MENÚ =====");
            Console.WriteLine("1. Agregar elemento");
            Console.WriteLine("2. Contar elementos");
            Console.WriteLine("3. Imprimir lista");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            string? input = Console.ReadLine(); // Lee la entrada del usuario

            switch (input)
            {
                case "1":
                    Console.Write("Ingrese el número a agregar: ");
                    string? dataInput = Console.ReadLine();
                    if (int.TryParse(dataInput, out int number))
                    {
                        myList.AddLast(number);
                        Console.WriteLine($"'{number}' agregado a la lista.");
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero.");
                    }
                    break;
                case "2":
                    int numberOfElements = myList.GetNodeCount();
                    Console.WriteLine($"Número de elementos en la lista: {numberOfElements}");
                    break;
                case "3":
                    myList.PrintList();
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }
}