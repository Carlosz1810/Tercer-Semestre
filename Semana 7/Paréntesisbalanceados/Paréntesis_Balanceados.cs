using System;
using System.Collections.Generic;

public class ParenthesisChecker
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Bienvenido al Verificador de Paréntesis, Llaves y Corchetes ===");
        Console.WriteLine(" == Ingrese una expresión matemática para verificar su balanceo == ");
        Console.WriteLine("  = Escriba 'salir' para terminar el programa =  ");

        while (true)
        {
            Console.Write("Ingrese su expresión: ");
            string? inputExpression = Console.ReadLine(); // Se usa string? para el valor que puede ser nulo de ReadLine

            if (string.IsNullOrEmpty(inputExpression) || inputExpression.ToLower() == "salir")
            {
                break;
            }

            // Comprueba si la entrada está balanceada y muestra el resultado
            if (IsBalanced(inputExpression))
            {
                Console.WriteLine($"Expresión: \"{inputExpression}\" -> Fórmula balanceada.");
            }
            else
            {
                Console.WriteLine($"Expresión: \"{inputExpression}\" -> Fórmula NO balanceada.");
            }
        }
    }

    /// <summary>
    /// Verifica si los paréntesis, llaves y corchetes en una expresión matemática están correctamente balanceados.
    /// </summary>
    /// <param name="expression">La expresión matemática a verificar.</param>
    /// <returns>True si la expresión está balanceada, False en caso contrario.</returns>
    public static bool IsBalanced(string expression)
    {
        // Se utiliza una pila para almacenar los caracteres de apertura.
        Stack<char> stack = new Stack<char>();

        // Itera sobre cada caracter de la expresión
        foreach (char c in expression)
        {
            // Si el caracter es un paréntesis de apertura, se añade a la pila.
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            // Si el caracter es un paréntesis de cierre
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si la pila está vacía, significa que hay un paréntesis de cierre sin uno de apertura correspondiente.
                if (stack.Count == 0)
                {
                    return false;
                }

                // Obtiene el último paréntesis de apertura de la pila.
                char lastOpen = stack.Pop();

                // Verifica si el paréntesis de cierre coincide con el último de apertura.
                if (!Matches(lastOpen, c))
                {
                    return false;
                }
            }
        }

        // Si la pila está vacía al final, todos los paréntesis de apertura tienen su correspondiente cierre.
        return stack.Count == 0;
    }

    /// <summary>
    /// Verifica si un paréntesis de apertura y uno de cierre coinciden.
    /// </summary>
    /// <param name="open">El paréntesis de apertura.</param>
    /// <param name="close">El paréntesis de cierre.</param>
    /// <returns>True si coinciden, False en caso contrario.</returns>
    private static bool Matches(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '{' && close == '}') ||
               (open == '[' && close == ']');
    }
}