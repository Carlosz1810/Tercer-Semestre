using System;
using System.Collections.Generic;

public class Curso
{
    public List<string> Asignaturas { get; set; }

    public Curso(List<string> asignaturas)
    {
        Asignaturas = asignaturas;
    }

    public void MostrarAsignaturasConMensaje()
    {
        foreach (string asignatura in Asignaturas)
        {
            Console.WriteLine($"Yo estudio {asignatura}");
        }
    }
}

public class Ejercicio2
{
    public static void Main(string[] args)
    {
        List<string> misAsignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        Curso miCurso = new Curso(misAsignaturas);
        
        Console.WriteLine("--- Ejercicio 2 ---");
        miCurso.MostrarAsignaturasConMensaje();
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}