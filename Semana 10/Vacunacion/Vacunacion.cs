using System;
using System.Collections.Generic;

namespace Vacunacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Crear 500 ciudadanos ficticios
            HashSet<string> todos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
            {
                todos.Add("Ciudadano " + i);
            }

            // 2. Crear conjunto ficticio de 90 ciudadanos vacunados con Pfizer
            HashSet<string> pfizer = new HashSet<string>();
            for (int i = 1; i <= 90; i++)
            {
                pfizer.Add("Ciudadano " + i);
            }

            // 3. Crear conjunto ficticio de 110 ciudadanos vacunados con AstraZeneca
            HashSet<string> astrazeneca = new HashSet<string>();
            for (int i = 60; i <= 169; i++) // Intersección con Pfizer
            {
                astrazeneca.Add("Ciudadano " + i);
            }

            // 4. Aplicar teoría de conjuntos
            HashSet<string> noVacunados = new HashSet<string>(todos);
            noVacunados.ExceptWith(pfizer);
            noVacunados.ExceptWith(astrazeneca);

            HashSet<string> ambasDosis = new HashSet<string>(pfizer);
            ambasDosis.IntersectWith(astrazeneca);

            HashSet<string> soloPfizer = new HashSet<string>(pfizer);
            soloPfizer.ExceptWith(astrazeneca);

            HashSet<string> soloAstrazeneca = new HashSet<string>(astrazeneca);
            soloAstrazeneca.ExceptWith(pfizer);

            // 5. Mostrar resultados con contadores y lista de ciudadanos
            Console.WriteLine("=== Ciudadanos que NO se han vacunado ===");
            Console.WriteLine($"Total: {noVacunados.Count}");
            foreach (var c in noVacunados) Console.WriteLine(c);

            Console.WriteLine("\n=== Ciudadanos con AMBAS dosis ===");
            Console.WriteLine($"Total: {ambasDosis.Count}");
            foreach (var c in ambasDosis) Console.WriteLine(c);

            Console.WriteLine("\n=== Ciudadanos con SOLO Pfizer ===");
            Console.WriteLine($"Total: {soloPfizer.Count}");
            foreach (var c in soloPfizer) Console.WriteLine(c);

            Console.WriteLine("\n=== Ciudadanos con SOLO AstraZeneca ===");
            Console.WriteLine($"Total: {soloAstrazeneca.Count}");
            foreach (var c in soloAstrazeneca) Console.WriteLine(c);

            // Pausa antes de cerrar
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}