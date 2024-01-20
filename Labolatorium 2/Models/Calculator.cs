public enum Operators
{
    Add,
    Sub,
    Mul,
    Div
}

public class Calculator
{
    public Operators? Operator { get; set; }
    public double? X { get; set; }
    public double? Y { get; set; }

    public string Op
    {
        get
        {
            return Operator switch
            {
                Operators.Add => "+",
                Operators.Sub => "-",
                Operators.Mul => "*",
                Operators.Div => "/",
                _ => ""
            };
        }
    }

    public bool IsValid()
    {
        return Operator != null && X != null && Y != null;
    }

    public double Calculate()
    {
        if (!IsValid())
        {
            throw new InvalidOperationException("Nieprawidłowe dane wejściowe dla kalkulatora.");
        }

        return Operator switch
        {
            Operators.Add => (double)(X + Y),
            Operators.Sub => (double)(X - Y),
            Operators.Mul => (double)(X * Y),
            Operators.Div => Y != 0 ? (double)(X / Y) : throw new DivideByZeroException("Dzielenie przez zero."),
            _ => double.NaN
        };
    }
}
