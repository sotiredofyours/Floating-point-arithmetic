namespace Exam

open System

module Ulp =
    
    let getUlp (arg: double) =
        let bits = BitConverter.DoubleToInt64Bits(arg);
        let nextValue = BitConverter.Int64BitsToDouble(bits + 1L);
        double <| nextValue - arg
        
    let getU =
        getUlp(double 1) / double 2
        
    let getGamma n =
       double 2 * n * getU