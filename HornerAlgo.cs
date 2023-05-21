namespace FloatingPointArithmetic;

public class HornerAlgo
{
    public static (double, double) HornerAlgorithm(double[] a, double x)
    {
        var n = a.Length;
        var r = a[n - 1];
        var s = Math.Abs(a[n - 1]) / 2;
        var u = 1 / 2d * Utils.Ulp(1);
        for (int i = n-1; i > 1; i--)
        {
            r = r * x + a[i-1];
            s = s * Math.Abs(x) + Math.Abs(r);
        }

        r = r * x + a[0];
        var b = 2 * (s * Math.Abs(x) + Math.Abs(r));
        b = u * b / (1 - (2 * (n-1) - 1)*u) ;
        return (r, b);
    }
    
    public static (float, float) HornerAlgorithm(float[] a, float x)
    {
        var n = a.Length;
        var r = a[n - 1];
        var s = Math.Abs(a[n - 1]) / 2;
        var u = 1 / 2f * Utils.Ulp(1f);
        for (int i = n-1; i > 1; i--)
        {
            r = r * x + a[i-1];
            s = s * Math.Abs(x) + Math.Abs(r);
        }

        r = r * x + a[0];
        var b = 2 * (s * Math.Abs(x) + Math.Abs(r));
        b = u * b / (1 - (2 * (n-1) - 1)*u) ;
        return (r, b);
    }
}