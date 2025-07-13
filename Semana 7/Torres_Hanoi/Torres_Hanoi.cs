using System;
using System.Collections.Generic;
using System.Linq; // Necesario para la función Reverse en la impresión

public class TowersOfHanoi
{
    // Pilas que representan las tres torres: origen, auxiliar y destino
    private static Stack<int> source = new Stack<int>();
    private static Stack<int> auxiliary = new Stack<int>();
    private static Stack<int> destination = new Stack<int>();

    private static int numberOfDisks; // Número total de discos en el juego

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Resolución de las Torres de Hanoi ---");
        Console.Write("Ingrese el número de discos: ");
        
        // Valida la entrada del usuario para asegurar que sea un número entero positivo
        while (!int.TryParse(Console.ReadLine(), out numberOfDisks) || numberOfDisks <= 0)
        {
            Console.Write("Por favor, ingrese un número entero positivo para los discos: ");
        }

        // Inicializa la torre de origen con los discos en orden descendente (el más grande abajo)
        for (int i = numberOfDisks; i >= 1; i--)
        {
            source.Push(i);
        }

        Console.WriteLine("\nEstado inicial de las torres:");
        PrintTowers();

        // Llama a la función recursiva para resolver el problema
        SolveHanoi(numberOfDisks, source, destination, auxiliary);

        Console.WriteLine("\n--- ¡Problema resuelto! ---");
    }

    /// <summary>
    /// Resuelve el problema de las Torres de Hanoi de forma recursiva.
    /// </summary>
    /// <param name="n">Número de discos a mover.</param>
    /// <param name="sourcePeg">Pila de la torre de origen.</param>
    /// <param name="destinationPeg">Pila de la torre de destino.</param>
    /// <param name="auxiliaryPeg">Pila de la torre auxiliar.</param>
    public static void SolveHanoi(int n, Stack<int> sourcePeg, Stack<int> destinationPeg, Stack<int> auxiliaryPeg)
    {
        // Caso base: si solo hay un disco, muévelo directamente del origen al destino.
        if (n == 1)
        {
            MoveDisk(sourcePeg, destinationPeg);
            return;
        }

        // Paso 1: Mover n-1 discos del origen a la torre auxiliar, usando el destino como auxiliar.
        SolveHanoi(n - 1, sourcePeg, auxiliaryPeg, destinationPeg);

        // Paso 2: Mover el disco más grande (el n-ésimo disco) del origen al destino.
        MoveDisk(sourcePeg, destinationPeg);

        // Paso 3: Mover los n-1 discos de la torre auxiliar al destino, usando el origen como auxiliar.
        SolveHanoi(n - 1, auxiliaryPeg, destinationPeg, sourcePeg);
    }

    /// <summary>
    /// Mueve un disco de una torre de origen a una torre de destino y muestra el estado actual de las torres.
    /// </summary>
    /// <param name="sourcePeg">Pila de la torre de origen.</param>
    /// <param name="destinationPeg">Pila de la torre de destino.</param>
    private static void MoveDisk(Stack<int> sourcePeg, Stack<int> destinationPeg)
    {
        // Saca el disco superior de la torre de origen
        int disk = sourcePeg.Pop();
        // Coloca el disco en la torre de destino
        destinationPeg.Push(disk);

        Console.WriteLine($"\nMoviendo disco {disk} de {GetName(sourcePeg)} a {GetName(destinationPeg)}");
        PrintTowers();
    }

    /// <summary>
    /// Obtiene el nombre de una torre dado su objeto Stack.
    /// </summary>
    /// <param name="peg">La pila que representa la torre.</param>
    /// <returns>El nombre de la torre (Origen, Auxiliar, Destino).</returns>
    private static string GetName(Stack<int> peg)
    {
        if (peg == source) return "Origen";
        if (peg == auxiliary) return "Auxiliar";
        if (peg == destination) return "Destino";
        return "Desconocida";
    }

    /// <summary>
    /// Imprime el estado actual de todas las torres.
    /// </summary>
    private static void PrintTowers()
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Origen:    {string.Join(", ", source.Reverse())}"); // Reverse para mostrar de abajo hacia arriba
        Console.WriteLine($"Auxiliar:  {string.Join(", ", auxiliary.Reverse())}");
        Console.WriteLine($"Destino:   {string.Join(", ", destination.Reverse())}");
        Console.WriteLine("-----------------------------------");
    }
}