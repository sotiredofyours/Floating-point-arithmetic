namespace Exam

open System
open System.IO

module Utils =
    
    let getBytes path = File.ReadAllBytes(path)
        
    let bytesToArrayOfDouble (buffer: byte[]) = 
        seq { 0..buffer.Length / 8 - 1}
        |> Seq.map ( fun x ->
            double <| BitConverter.ToDouble(buffer, x * 8)
        )
        |> Seq.toArray
    
    let splitCoefficientsAndArgsLE (arr: double[]) =
        let n = arr.Length
        let args = arr[n - 3..]
        let coefficients = arr[0..n - 2]
        args, coefficients
    
    let splitCoefficientsAndArgsBE (arr: double[]) =
        let n = arr.Length
        let args = arr[n - 1..]
        let coefficients = arr[0..n - 2]
        args, coefficients
    
    let calculateAndPrint ( args:double[], coefficients:double[]) =
        args |> Array.iter (fun x ->
        let result = HornerAlgo.calculate(coefficients, x)
        printf $"{result}"
    )  