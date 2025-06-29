using System;
using System.Collections.Generic;
using System.Linq;

public class Vector
{
    public List<int> Componentes { get; set; }

    public Vector(List<int> componentes)
    {
        Componentes = componentes;
    }

    public int CalcularProductoEscalar(Vector otroVector)
    {
        if (Componentes.Count != otroVector.Componentes.Count)
        {
            throw new ArgumentException("Los vectores deben tener la misma dimensión para calcular el producto escalar.");
        }

        int productoEscalar = 0;
        for (int i = 0; i < Componentes.Count; i++)
        {
            productoEscalar += Componentes[i] * otroVector.Componentes[i];
        }
        return productoEscalar;
    }
}

public class Ejercicio11
{
    public static void Main(string[] args)
    {
        Vector vector1 = new Vector(new List<int> { 1, 2, 3 });
        Vector vector2 = new Vector(new List<int> { -1, 0, 2 });

        Console.WriteLine("===Ejercicio 11===");
        Console.WriteLine($"Vector 1: ({string.Join(", ", vector1.Componentes)})");
        Console.WriteLine($"Vector 2: ({string.Join(", ", vector2.Componentes)})");

        try
        {
            int resultado = vector1.CalcularProductoEscalar(vector2);
            Console.WriteLine($"El producto escalar es: {resultado}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}