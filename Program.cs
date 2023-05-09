using FloatingPointArithmetic;

var numbers = new double[]
{
     18014398509481984.0, // 2**54
     18014398509481982.0, // 2**54-2
     -9007199254740991.0, // -(2**53-1)
     -9007199254740991.0,
     -9007199254740991.0,
     -9007199254740991.0
};


var s1 = Sum.NaiveSum(numbers);
var s2 = Sum.KahanSum(numbers);
var s3 = Sum.RumpSum(numbers);
Console.WriteLine(Utils.RelativeError(s1, 2));