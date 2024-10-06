using System;
public class Fraction
{
    private int numerator;
    private int denominator;

    // Constructors
    public Fraction() : this(1, 1) { }

    public Fraction(int numerator) : this(numerator, 1) { }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException("Denominator cannot be zero.");
        }
        this.numerator = numerator;
        this.denominator = denominator;
    }

    // Getters and Setters
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    public int Denominator
    {
        get { return denominator; }
        set
        {
            if (value == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }
            denominator = value;
        }
    }

    // Methods
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}
