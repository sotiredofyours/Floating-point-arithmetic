
open System
open System.Collections.Generic
open System.IO
open Exam
open System.Linq

module Reader =
    
    let path = Path.Combine(Environment.CurrentDirectory, "polynomTest2LE.dat")   
    let buffer  = File.ReadAllBytes(path)
    let values = List<double>()
    for i = 0 to buffer.Length / 8 - 1 do
        values.Add( BitConverter.ToDouble(buffer, i * 8))
        printfn $"%g{values[i]}"
    
    let arr = [| double 1..3 |]
    let x, b = HornerAlgo.calculatePalindrome(arr, 2)
    
    let y = Ulp.getGamma 1000
    
    printf $"%g{y} %g{b}"