using System;

class Fraction
{
    private int numerator;
    private int denominator;

    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor with one parameter (numerator, denominator defaults to 1)
    public Fraction(int top)
    {
        numerator = top;
        denominator = 1;
    }

    // Constructor with two parameters (numerator and denominator)
    public Fraction(int top, int bottom)
    {
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        numerator = top;
        denominator = bottom;
    }

    // Getter for numerator
    public int GetNumerator()
    {
        return numerator;
    }

    public void SetNumerator(int top)
    {
        numerator = top;
    }

    public int GetDenominator()
    {
        return denominator;
    }

    public void SetDenominator(int bottom)
    {
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        denominator = bottom;
    }
    
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Returns decimal value of fraction
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}
