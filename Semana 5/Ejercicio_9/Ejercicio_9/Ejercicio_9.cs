using System;
using System.Collections.Generic;
using System.Linq;

public class AnalizadorPalabra
{
    public string Palabra { get; set; }

    // El constructor ahora espera una cadena no anulable.
    // Si pasaras una cadena potencialmente nula, tendrías que manejarlo.
    public AnalizadorPalabra(string palabra)
    {
        // Asegúrate de que 'palabra' no sea nula antes de convertir a minúsculas.
        // El operador ! (null-forgiving) afirma que 'palabra' no será nula aquí.
        Palabra = palabra.ToLower();
    }

    // Este método debería estar en la clase AnalizadorPalabra
    public Dictionary<char, int> ContarVocales()
    {
        Dictionary<char, int> conteoVocales = new Dictionary<char, int>
        {
            {'a', 0}, {'e', 0}, {'i', 0}, {'o', 0}, {'u', 0}
        };

        foreach (char caracter in Palabra)
        {
            if (conteoVocales.ContainsKey(caracter))
            {
                conteoVocales[caracter]++;
            }
        }
        return conteoVocales;
    }
}

public class Ejercicio9
{
    public static void Main(string[] args)
    {
        Console.WriteLine("===Ejercicio 9===");
        Console.Write("Por favor, introduce una palabra: ");

        // Usa el operador de "no nulabilidad" (!) para decirle al compilador
        // que estás seguro de que Console.ReadLine() no devolverá null aquí.
        string palabraUsuario = Console.ReadLine()!;

        AnalizadorPalabra analizador = new AnalizadorPalabra(palabraUsuario);
        Dictionary<char, int> resultadoConteo = analizador.ContarVocales();

        Console.WriteLine($"\nConteo de vocales en '{palabraUsuario}':");
        foreach (var par in resultadoConteo)
        {
            Console.WriteLine($"- {par.Key}: {par.Value} veces");
        }
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}