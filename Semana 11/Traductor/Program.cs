using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Translator
{
    // El diccionario para almacenar las palabras. La clave es la palabra en inglés
    // y el valor es la traducción en español.
    private readonly Dictionary<string, string> dictionary;

    public Translator()
    {
        // Inicializa el diccionario con las palabras base.
        dictionary = new Dictionary<string, string>()
        {
            {"time", "tiempo"},
            {"person", "persona"},
            {"year", "año"},
            {"way", "camino / forma"},
            {"day", "día"},
            {"thing", "cosa"},
            {"man", "hombre"},
            {"world", "mundo"},
            {"life", "vida"},
            {"hand", "mano"},
            {"part", "parte"},
            {"child", "niño/a"},
            {"eye", "ojo"},
            {"woman", "mujer"},
            {"place", "lugar"},
            {"work", "trabajo"},
            {"week", "semana"},
            {"case", "caso"},
            {"point", "punto / tema"},
            {"government", "gobierno"},
            {"company", "empresa / compañía"}
        };
    }

    // Método principal para ejecutar el programa.
    public void Run()
    {
        bool isRunning = true;
        while (isRunning)
        {
            ShowMenu();
            // Asegura que la entrada no sea nula.
            string option = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();

            switch (option)
            {
                case "1":
                    TranslatePhrase();
                    break;
                case "2":
                    AddWordToDictionary();
                    break;
                case "3":
                    isRunning = false;
                    Console.WriteLine("¡Gracias por usar el traductor! Hasta luego.");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    // Muestra las opciones del menú.
    private void ShowMenu()
    {
        Console.WriteLine("==================== MENÚ ====================");
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Agregar palabras al diccionario");
        Console.WriteLine("3. Salir");
        Console.WriteLine("==============================================");
        Console.Write("\nSeleccione una opción: ");
    }

    // Procesa una frase, traduciendo las palabras que se encuentran en el diccionario.
    private void TranslatePhrase()
    {
        Console.Write("Ingrese la frase a traducir: ");
        // Asegura que la entrada no sea nula.
        string phrase = Console.ReadLine() ?? string.Empty;
        
        // Divide la frase en palabras.
        string[] words = phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        StringBuilder translatedPhrase = new StringBuilder();

        foreach (string word in words)
        {
            // Limpia la palabra de signos de puntuación y la convierte a minúsculas para la búsqueda.
            string cleanWord = new string(word.Where(c => char.IsLetter(c)).ToArray()).ToLower();

            if (dictionary.ContainsKey(cleanWord))
            {
                // Si la palabra está en el diccionario, usa su traducción.
                translatedPhrase.Append(dictionary[cleanWord]);
            }
            else
            {
                // Si no, usa la palabra original.
                translatedPhrase.Append(word);
            }

            translatedPhrase.Append(" ");
        }
        
        Console.WriteLine("\nTraducción: " + translatedPhrase.ToString().Trim());
    }

    // Permite al usuario agregar una nueva palabra al diccionario.
    private void AddWordToDictionary()
    {
        Console.WriteLine("Agregar una nueva palabra al diccionario:");
        Console.Write("Ingrese la palabra en inglés: ");
        // Asegura que la entrada no sea nula y la convierte a minúsculas.
        string englishWord = (Console.ReadLine() ?? string.Empty).ToLower();

        Console.Write("Ingrese la traducción en español: ");
        // Asegura que la entrada no sea nula y la convierte a minúsculas.
        string spanishTranslation = (Console.ReadLine() ?? string.Empty).ToLower();

        if (dictionary.ContainsKey(englishWord))
        {
            Console.WriteLine($"La palabra '{englishWord}' ya existe. Su traducción será actualizada.");
            dictionary[englishWord] = spanishTranslation;
        }
        else
        {
            dictionary.Add(englishWord, spanishTranslation);
            Console.WriteLine($"La palabra '{englishWord}' ha sido agregada con éxito.");
        }
    }
}

// El punto de entrada del programa.
public class Program
{
    public static void Main(string[] args)
    {
        Translator translator = new Translator();
        translator.Run();
    }
}