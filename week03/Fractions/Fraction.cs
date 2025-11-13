using System;

public class Fraction
{
    // --- Private attributes (fields) ---
    private int _top;
    private int _bottom;

    // --- Constructors ---

    // 1. No parameters → default 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 2. One parameter (numerator), denominator = 1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // 3. Two parameters (numerator and denominator)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // --- Getters and Setters ---
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // --- Methods to return representations ---

    // Returns string like "3/4"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns decimal value (double)
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}
