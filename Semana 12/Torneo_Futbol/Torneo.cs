using System;
using System.Collections.Generic;
using System.Linq;

public class Torneo
{
    // Usa un diccionario para una búsqueda eficiente de equipos por su ID.
    private Dictionary<int, Equipo> equipos;
    private int proximoEquipoId = 1;

    // Constructor de la clase
    public Torneo()
    {
        equipos = new Dictionary<int, Equipo>();
    }

    // ------------------- Métodos de Reportería -------------------

    // Método para registrar un nuevo equipo
    public void RegistrarEquipo(string nombre)
    {
        var nuevoEquipo = new Equipo(proximoEquipoId, nombre);
        equipos.Add(proximoEquipoId, nuevoEquipo);
        Console.WriteLine($"\nEquipo '{nombre}' registrado con éxito. ID: {proximoEquipoId}");
        proximoEquipoId++;
    }

    // Método para registrar un jugador en un equipo específico
    public void RegistrarJugador(int equipoId, string nombre, int edad, string posicion, int numeroCamiseta)
    {
        if (equipos.ContainsKey(equipoId))
        {
            var jugador = new Jugador(equipos[equipoId].Jugadores.Count + 1, nombre, edad, posicion, numeroCamiseta);
            equipos[equipoId].AgregarJugador(jugador);
        }
        else
        {
            Console.WriteLine($"\nError: No se encontró un equipo con el ID {equipoId}.");
        }
    }

    // Método para listar todos los equipos
    public void ListarEquipos()
    {
        Console.WriteLine("\n--- Equipos Registrados en el Torneo ---");
        if (equipos.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados.");
            return;
        }
        foreach (var equipo in equipos.Values)
        {
            Console.WriteLine($"- {equipo.Nombre} (ID: {equipo.Id}) - {equipo.Jugadores.Count} jugadores");
        }
    }

    // Método para listar todos los jugadores de un equipo
    public void ListarJugadoresPorEquipo(int equipoId)
    {
        if (equipos.ContainsKey(equipoId))
        {
            equipos[equipoId].MostrarInformacion();
        }
        else
        {
            Console.WriteLine($"\nError: No se encontró un equipo con el ID {equipoId}.");
        }
    }

    // Método para buscar un jugador por su nombre en todo el torneo
    public void BuscarJugador(string nombre)
    {
        Console.WriteLine($"\n--- Buscando jugador con nombre '{nombre}' ---");
        var jugadorEncontrado = false;
        foreach (var equipo in equipos.Values)
        {
            var jugador = equipo.Jugadores.FirstOrDefault(j => j.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (jugador != null)
            {
                Console.WriteLine($"Jugador encontrado: {jugador.Nombre}");
                Console.WriteLine($"Pertenece al equipo: {equipo.Nombre}");
                jugador.MostrarInformacion();
                jugadorEncontrado = true;
                // Puedes detener la búsqueda después de encontrar el primer jugador
                break; 
            }
        }

        if (!jugadorEncontrado)
        {
            Console.WriteLine("No se encontró un jugador con ese nombre en el torneo.");
        }
    }
}