namespace FloatingPointArithmetic;

public static class Examples
{
    public static void InfiniteCircle()
    {
        for (float i = 0f; i < 1e10f; i+= 1.0f)
        {
            if (i + 1f == i)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }

    public static void Pow()
    {
        Console.WriteLine(Math.Pow(float.NaN, 0)); 
        Console.WriteLine(Math.Pow(float.PositiveInfinity, 0));
    }

    public static void Summing()
    {
        var numbers = new double[]
        {
            18014398509481984.0, // 2**54
            18014398509481982.0, // 2**54-2
            -9007199254740991.0, // -(2**53-1)
            -9007199254740991.0,
            -9007199254740991.0,
            -9007199254740991.0
        };
        
        Console.WriteLine(Sum.RumpSum(numbers));
        Console.WriteLine(Sum.NaiveSum(numbers));
        Console.WriteLine(Sum.KahanSum(numbers));
    }
}