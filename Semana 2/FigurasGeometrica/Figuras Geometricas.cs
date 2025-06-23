using System;

// Clase base para figuras geométricas (opcional, pero buena práctica para extender en el futuro)
public abstract class FiguraGeometrica
{
    // Propiedad abstracta para el área (debe ser implementada por las clases derivadas)
    public abstract double Area { get; }

    // Propiedad abstracta para el perímetro (debe ser implementada por las clases derivadas)
    public abstract double Perimetro { get; }
}

// Clase para representar un Círculo
public class Circulo : FiguraGeometrica
{
    // Variable privada para almacenar el radio del círculo.
    // Usamos 'double' para permitir valores decimales.
    private double radio;

    // Propiedad pública 'Radio' para acceder y modificar el valor del radio.
    // 'get' permite obtener el valor, 'set' permite asignarlo.
    public double Radio
    {
        get { return radio; }
        set
        {
            // Validamos que el radio no sea negativo.
            // Si es negativo, lanzamos una excepción para indicar un error.
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("El radio no puede ser negativo.");
            }
            radio = value;
        }
    }

    // Constructor de la clase Circulo.
    // Se llama cuando creamos una nueva instancia de Circulo.
    // Requiere un 'radio' como argumento inicial.
    public Circulo(double radio)
    {
        // Asignamos el valor del argumento 'radio' a la propiedad 'Radio'.
        // Esto también activa la validación en el 'set' de la propiedad.
        Radio = radio;
    }

    // CalcularArea es una propiedad que devuelve un valor double.
    // Se utiliza para calcular el área de un círculo.
    // La fórmula es Pi * radio * radio.
    public override double Area
    {
        get { return Math.PI * Radio * Radio; }
    }

    // CalcularPerimetro es una propiedad que devuelve un valor double.
    // Se utiliza para calcular el perímetro (circunferencia) de un círculo.
    // La fórmula es 2 * Pi * radio.
    public override double Perimetro
    {
        get { return 2 * Math.PI * Radio; }
    }
}

// Clase para representar un Cuadrado
public class Cuadrado : FiguraGeometrica
{
    // Variable privada para almacenar la longitud del lado del cuadrado.
    // Usamos 'double' para permitir valores decimales.
    private double lado;

    // Propiedad pública 'Lado' para acceder y modificar el valor del lado.
    public double Lado
    {
        get { return lado; }
        set
        {
            // Validamos que el lado no sea negativo.
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("El lado no puede ser negativo.");
            }
            lado = value;
        }
    }

    // Constructor de la clase Cuadrado.
    // Requiere un 'lado' como argumento inicial.
    public Cuadrado(double lado)
    {
        // Asignamos el valor del argumento 'lado' a la propiedad 'Lado'.
        Lado = lado;
    }

    // CalcularArea es una propiedad que devuelve un valor double.
    // Se utiliza para calcular el área de un cuadrado.
    // La fórmula es lado * lado.
    public override double Area
    {
        get { return Lado * Lado; }
    }

    // CalcularPerimetro es una propiedad que devuelve un valor double.
    // Se utiliza para calcular el perímetro de un cuadrado.
    // La fórmula es 4 * lado.
    public override double Perimetro
    {
        get { return 4 * Lado; }
    }
}

// Clase principal que contiene el método Main para ejecutar el programa.
public class Programa
{
    public static void Main(string[] args)
    {
        // --- Ejemplo de uso de la clase Circulo ---
        Console.WriteLine("--- Círculo ---");
        try
        {
            // Creamos una nueva instancia de Circulo con un radio de 3.5.
            Circulo miCirculo = new Circulo(3.5);
            Console.WriteLine($"Radio del círculo: {miCirculo.Radio}");
            // Accedemos a la propiedad 'Area' para obtener el área calculada.
            Console.WriteLine($"Área del círculo: {miCirculo.Area:F2}"); // :F2 formatea a 2 decimales
            // Accedemos a la propiedad 'Perimetro' para obtener el perímetro calculado.
            Console.WriteLine($"Perímetro del círculo: {miCirculo.Perimetro:F2}");

            // Intentamos cambiar el radio y ver los nuevos cálculos
            Console.WriteLine("\nCambiando el radio del círculo a 9.2...");
            miCirculo.Radio = 9.2;
            Console.WriteLine($"Nuevo radio: {miCirculo.Radio}");
            Console.WriteLine($"Nueva área del círculo: {miCirculo.Area:F2}");
            Console.WriteLine($"Nuevo perímetro del círculo: {miCirculo.Perimetro:F2}");

            // Ejemplo de un radio inválido (esto generará una excepción)
            // Circulo circuloInvalido = new Circulo(-1.0); // Descomentar para probar la excepción
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error al crear el círculo: {ex.Message}");
        }

        Console.WriteLine("\n" + new string('-', 30) + "\n"); // Separador

        // --- Ejemplo de uso de la clase Cuadrado ---
        Console.WriteLine("--- Cuadrado ---");
        try
        {
            // Creamos una nueva instancia de Cuadrado con un lado de 7.0.
            Cuadrado miCuadrado = new Cuadrado(7.0);
            Console.WriteLine($"Lado del cuadrado: {miCuadrado.Lado}");
            // Accedemos a la propiedad 'Area' para obtener el área calculada.
            Console.WriteLine($"Área del cuadrado: {miCuadrado.Area:F2}");
            // Accedemos a la propiedad 'Perimetro' para obtener el perímetro calculado.
            Console.WriteLine($"Perímetro del cuadrado: {miCuadrado.Perimetro:F2}");

            // Intentamos cambiar el lado y ver los nuevos cálculos
            Console.WriteLine("\nCambiando el lado del cuadrado a 2.5...");
            miCuadrado.Lado = 2.5;
            Console.WriteLine($"Nuevo lado: {miCuadrado.Lado}");
            Console.WriteLine($"Nueva área del cuadrado: {miCuadrado.Area:F2}");
            Console.WriteLine($"Nuevo perímetro del cuadrado: {miCuadrado.Perimetro:F2}");

            // Ejemplo de un lado inválido (esto generará una excepción)
            // Cuadrado cuadradoInvalido = new Cuadrado(-3.0); // Descomentar para probar la excepción
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error al crear el cuadrado: {ex.Message}");
        }

        Console.ReadKey(); // Espera a que el usuario presione una tecla para cerrar la consola
    }
}