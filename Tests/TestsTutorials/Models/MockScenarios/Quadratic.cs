namespace TestsTutorials.Models.MockScenarios;

public sealed class Quadratic
{
    private ILogProvider _log;

    public Quadratic(ILogProvider log)
    {
        _log = log;
    }

    private bool CanCalculate(double a, double b, double c, out double d)
    {
        d = b * b - 4 * a * c;
        
        return !(d < 0);
    }

    public Tuple<double, double> Calculate(double a, double b, double c)
    {
        if (!CanCalculate(a, b, c, out double d))
        {
            _log.Log("discriminant is negative");
            
            throw new InvalidOperationException("Can't calculate quadratic");
        }
        
        var x1 = (-b + Math.Sqrt(d)) / (2 * a);
        
        var x2 = (-b - Math.Sqrt(d)) / (2 * a);
        
        return new Tuple<double, double>(x1, x2);
    }
}