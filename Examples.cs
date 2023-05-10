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

    public static void Summing2()
    {
        var x = Enumerable.Range(1, 2097152).Select(x => 1d / x).ToList();
        var sum1 = Sum.KahanSum(x);
        var sum2 = Sum.NaiveSum(x);
        var sum3 = Sum.RumpSum(x);
        var sum4 = Sum.PairwiseSum(x);
       
        Console.WriteLine(Utils.UlpError(sum3, sum4));
        Console.WriteLine(Utils.UlpError(sum4, sum2));

    }

}