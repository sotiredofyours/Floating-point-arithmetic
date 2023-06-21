namespace FloatingPointArithmetic;

public static class Sum
{
    /// <summary>
    /// Kahan method of sum
    /// </summary>
    public static (float, float) Fast2Sum(float a, float b)
    {
        if (b > a) (a, b) = (b, a);
        var s = a + b;
        var t = b - (s - a);
        return (s, t);
    }

    public static (double, double) Fast2Sum(double a, double b)
    {
        if (b > a) (a, b) = (b, a);
        var s = a + b;
        var t = b - (s - a);
        return (s, t);
    }

    /// <summary>
    /// Knuth-Muller algorithm of sum to numbers. 
    /// </summary>
    public static (float, float) TwoSum(float a, float b)
    {
        var s = a + b;
        var bs = s - a;
        var at = s - bs;
        var t = (b - bs) + (a - at);
        return (s, t);
    }

    public static (double, double) TwoSum(double a, double b)
    {
        var s = a + b;
        var bs = s - a;
        var at = s - bs;
        var t = (b - bs) + (a - at);
        return (s, t);
    }

    /// <summary>
    /// Naive approach to sum N numbers.
    /// </summary>
    public static float NaiveSum(IEnumerable<float> numbers)
    {
        return numbers.Sum();
    }

    public static double NaiveSum(IEnumerable<double> numbers)
    {
        return numbers.Sum();
    }

    /// <summary>
    /// Kahan algorithm to sum N numbers.
    /// </summary>
    public static double KahanSum(IEnumerable<double> numbers)
    {
        var s = 0d;
        var c = 0d;
        foreach (var num in numbers)
        {
            var y = num + c;
            (s, c) = Fast2Sum(y, s);
        }

        return s;
    }

    public static float KahanSum(IEnumerable<float> numbers)
    {
        var s = 0f;
        var c = 0f;
        foreach (var num in numbers)
        {
            var y = num + c;
            (s, c) = Fast2Sum(y, s);
        }

        return s;
    }

    public static float RumpSum(IEnumerable<float> numbers)
    {
        var s = 0f;
        var c = 0f;
        foreach (var num in numbers)
        {
            (s, var e) = TwoSum(num, s);
            c += e;
        }

        return s + c;
    }

    public static double PairwiseSum(List<double> numbers)
    {
        if (numbers.Count <= 2)
        {
            return numbers.Sum();
        }

        var m = numbers.Count / 2;
        return PairwiseSum(numbers.Take(m).ToList()) + PairwiseSum(numbers.Skip(m).ToList());
    }

    public static double RumpSum(IEnumerable<double> numbers)
    {
        var s = 0d;
        var c = 0d;
        foreach (var num in numbers)
        {
            (s, var e) = TwoSum(num, s);
            c += e;
        }

        return s + c;
    }
}