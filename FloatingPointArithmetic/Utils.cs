using System.Text;

namespace FloatingPointArithmetic;

public static class Utils
{
    public static string ToBinaryString(float value)
    {
        var sb = new StringBuilder();
        var bytes = BitConverter.GetBytes(value);
        foreach (Byte b in bytes)
            for (int i = 0; i < 8; i++)
            {
                sb.Insert(0, ((b >> i) & 1) == 1 ? "1" : "0");
            }

        return sb.ToString();
    }

    public static float FromBinaryString(string binaryString)
    {
        var intValue = Convert.ToInt32(binaryString, 2);
        return BitConverter.ToSingle(BitConverter.GetBytes(intValue), 0);
    }

    public static (int, int, int) GetConstants(string binaryString)
    {
        var s = binaryString[0] == 0 ? 0 : 1;
        var offsetExponent = binaryString[1..9];
        var e = Convert.ToInt32(offsetExponent, 2);
        var mantissa = binaryString[10..];
        var m = Convert.ToInt32(mantissa, 2);
        return (s, e, m);
    }

    public static (int, int, int) GetConstants(float value)
    {
        var bs = ToBinaryString(value);
        return GetConstants(bs);
    }

    public static float GetNumberFromConstants((int, int, int) constants)
    {
        var s = constants.Item1;
        var e = constants.Item2;
        var m = constants.Item3;
        var sign = s == 0 ? -1 : 1;
        return sign * (float) Math.Pow(2, e - 127) * (float) (1 + m / Math.Pow(2, 23));
    }

    public static float GetNumberFromConstants(float value)
    {
        var constants = GetConstants(value);
        var s = constants.Item1;
        var e = constants.Item2;
        var m = constants.Item3;
        var sign = s == 0 ? -1 : 1;
        return sign * (float) Math.Pow(2, e - 127) * (float) (1 + m / Math.Pow(2, 23));
    }

    public static float Ulp(float value)
    {
        var bits = BitConverter.SingleToInt32Bits(value);
        var nextValue = BitConverter.Int32BitsToSingle(bits + 1);
        return nextValue - value;
    }

    public static double Ulp(double value)
    {
        var bits = BitConverter.DoubleToInt64Bits(value);
        var nextValue = BitConverter.Int64BitsToDouble(bits + 1);
        return nextValue - value;
    }

    public static double AbsoluteError(double given, double exact)
    {
        return Math.Abs(given - exact);
    }

    public static float AbsoluteError(float given, float exact)
    {
        return Math.Abs(given - exact);
    }

    public static double RelativeError(double given, double exact)
    {
        return Math.Abs(given - exact) / Math.Abs(exact) * 100;
    }

    public static float RelativeError(float given, float exact)
    {
        return Math.Abs(given - exact) / Math.Abs(exact) * 100;
    }

    public static float UlpError(float given, float exact)
    {
        return Math.Abs(given - exact) / Ulp(exact);
    }

    public static double UlpError(double given, double exact)
    {
        return Math.Abs(given - exact) / Ulp(exact);
    }
}