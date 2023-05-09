using FloatingPointArithmetic;

var bs = Utils.ToBinaryString(0xFF);
Console.WriteLine(bs);
var constants = Utils.GetConstants(bs);
Console.WriteLine($"{constants.Item1} {constants.Item2} {constants.Item3}");
var trueValue = Utils.GetNumberFromConstants(constants);
Console.WriteLine(trueValue);
Console.WriteLine(Utils.Ulp(1));