using System;
using System.Collections.Generic;
using System.Linq;

public class Estadisticas
{
    public List<double> MuestraNumeros { get; set; }

    public Estadisticas(List<double> muestra)
    {
        MuestraNumeros = muestra;
    }

    public double CalcularMedia()
    {
        if (MuestraNumeros == null || MuestraNumeros.Count == 0)
        {
            throw new InvalidOperationException("La muestra de números está vacía.");
        }
        return MuestraNumeros.Average();
    }

    public double CalcularDesviacionTipica()
    {
        if (MuestraNumeros == null || MuestraNumeros.Count < 2)
        {
            throw new InvalidOperationException("Se necesitan al menos dos números para calcular la desviación típica.");
        }

        double media = CalcularMedia();
        double sumaCuadradosDiferencias = MuestraNumeros.Sum(x => Math.Pow(x - media, 2));
        return Math.Sqrt(sumaCuadradosDiferencias / (MuestraNumeros.Count - 1)); // Desviación típica muestral
    }
}

public class Ejercicio13
{
    public static void Main(string[] args)
    {
        Console.WriteLine("===Ejercicio 13===");
        Console.Write("Introduce una muestra de números separados por comas (ej. 10,20,30,40): ");
        // Modificación 1: Usar el operador de coalescencia nula (??) para asegurar que 'entrada' nunca sea null
        // Si Console.ReadLine() devuelve null, se asignará una cadena vacía a 'entrada'.
        string entrada = Console.ReadLine() ?? string.Empty;

        List<double> numeros = new List<double>();
        try
        {
            // Modificación 2: Comprobar si la entrada está vacía después de la asignación segura
            if (string.IsNullOrWhiteSpace(entrada))
            {
                throw new ArgumentException("La entrada no puede estar vacía.");
            }

            numeros = entrada.Split(',')
                             .Select(s => double.Parse(s.Trim()))
                             .ToList();

            Estadisticas stats = new Estadisticas(numeros);

            Console.WriteLine($"\nMuestra de números: {string.Join(", ", stats.MuestraNumeros)}");
            Console.WriteLine($"Media: {stats.CalcularMedia():F2}"); // Formatear a 2 decimales
            Console.WriteLine($"Desviación Típica: {stats.CalcularDesviacionTipica():F2}"); // Formatear a 2 decimales
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Entrada inválida. Asegúrate de introducir números separados por comas.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        // Nuevo catch para la ArgumentException si la entrada está vacía
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.WriteLine("\nPresiona cualquier tecla para finalizar...");
        Console.ReadKey();
    }
}