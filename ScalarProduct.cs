namespace FloatingPointArithmetic;

public static class ScalarProduct
{
    public static double NaiveScalarProduct(List<double> x, List<double> y)
    {
        var s = 0.0;
        for (var i = 0; i < x.Count; i++)
        {
            s += x[i] * y[i];
        }

        return s;
    }

    public static float NaiveScalarProduct(List<float> x, List<float> y)
    {
        var s = 0f;
        for (var i = 0; i < x.Count; i++)
        {
            s += x[i] * y[i];
        }

        return s;
    }

    public static double FmaScalarProduct(List<double> x, List<double> y)
    {
        var s = 0.0;
        for (var i = 0; i < x.Count; i++)
        {
            s = Math.FusedMultiplyAdd(x[i], y[i], s);
        }

        return s;
    }
    
    public static (double, double) FmaProductTwo(double a, double b)
    {
        var p = a * b;
        var t = Math.FusedMultiplyAdd(a, b, -p);
        return (p, t);
    }

    public static double ScalarProductOgita(List<double> x, List<double> y)
    {
        var s = 0.0;
        var c = 0.0;
        for (int i = 0; i < x.Count; i++)
        {
            var (p, pi) = FmaProductTwo(x[i], y[i]);
            (s, var t) = Sum.TwoSum(p, s);
            c += pi + t;
        }

        return s + c;
    }
    
    
}