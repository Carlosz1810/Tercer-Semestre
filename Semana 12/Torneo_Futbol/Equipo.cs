using System;
using System.Collections.Generic;

public class Equipo
{
    // Propiedades del equipo
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Jugador> Jugadores { get; set; }

    // Constructor de la clase
    public Equipo(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
        // Inicializa la lista de jugadores
        Jugadores = new List<Jugador>();
    }

    // Método para agregar un jugador al equipo
    public void AgregarJugador(Jugador jugador)
    {
        Jugadores.Add(jugador);
        Console.WriteLine($"Jugador {jugador.Nombre} agregado al equipo {Nombre}.");
    }

    // Método para mostrar la información del equipo y sus jugadores
    public void MostrarInformacion()
    {
        Console.WriteLine($"\n--- Equipo: {Nombre} (ID: {Id}) ---");
        Console.WriteLine($"Número de jugadores: {Jugadores.Count}");
        Console.WriteLine("Lista de Jugadores:");
        if (Jugadores.Count == 0)
        {
            Console.WriteLine("\tNo hay jugadores registrados en este equipo.");
        }
        else
        {
            foreach (var jugador in Jugadores)
            {
                jugador.MostrarInformacion();
            }
        }
    }
}