using System;

// I have added the following
// File-based scripture library

// Random scripture selection

// Difficulty levels (easy, normal, hard)

// Progress display with a visual bar

// Hint system to reveal hidden words



class Program
{
    static void Main(string[] args)
    {
        // Test 1 — Default constructor (1/1)
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        // Test 2 — One-parameter constructor (5/1)
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        // Test 3 — Two-parameter constructor (3/4)
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        // Test 4 — Another example (1/3)
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Test 5 — Using setters
        f4.SetTop(2);
        f4.SetBottom(5);
        Console.WriteLine(f4.GetFractionString());  // Should show "2/5"
        Console.WriteLine(f4.GetDecimalValue());    // Should show 0.4
    }
}
