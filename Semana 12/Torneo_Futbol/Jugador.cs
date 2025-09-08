using System;

public class Jugador
{
    // Propiedades del jugador
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Posicion { get; set; }
    public int NumeroCamiseta { get; set; }

    // Constructor de la clase
    public Jugador(int id, string nombre, int edad, string posicion, int numeroCamiseta)
    {
        Id = id;
        Nombre = nombre;
        Edad = edad;
        Posicion = posicion;
        NumeroCamiseta = numeroCamiseta;
    }

    // Método para mostrar la información del jugador
    public void MostrarInformacion()
    {
        Console.WriteLine($"\t- Jugador: {Nombre} (ID: {Id})");
        Console.WriteLine($"\t  Edad: {Edad} años");
        Console.WriteLine($"\t  Posición: {Posicion}");
        Console.WriteLine($"\t  Número de Camiseta: {NumeroCamiseta}");
    }
}