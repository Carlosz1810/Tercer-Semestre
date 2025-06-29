using System;
using System.Collections.Generic;
using System.Linq;

public class AnalizadorPrecios
{
    public List<double> Precios { get; set; }

    public AnalizadorPrecios(List<double> precios)
    {
        Precios = precios;
    }

    public double ObtenerMenorPrecio()
    {
        if (Precios == null || Precios.Count == 0)
        {
            throw new InvalidOperationException("La lista de precios está vacía.");
        }
        return Precios.Min();
    }

    public double ObtenerMayorPrecio()
    {
        if (Precios == null || Precios.Count == 0)
        {
            throw new InvalidOperationException("La lista de precios está vacía.");
        }
        return Precios.Max();
    }
}

public class Ejercicio10
{
    public static void Main(string[] args)
    {
        List<double> preciosEjemplo = new List<double> { 50, 75, 46, 22, 80, 65, 8 };
        AnalizadorPrecios analizador = new AnalizadorPrecios(preciosEjemplo);

        Console.WriteLine("--- Ejercicio 10 ---");
        Console.WriteLine($"Precios: {string.Join(", ", preciosEjemplo)}");
        Console.WriteLine($"El menor precio es: {analizador.ObtenerMenorPrecio()}");
        Console.WriteLine($"El mayor precio es: {analizador.ObtenerMayorPrecio()}");
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}