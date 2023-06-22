namespace Exam

open System
open System.IO

module Utils =

    let private getBound = (double 1 / Math.Sqrt(Ulp.getU) - double 1) / double 2

    let getBytes path = File.ReadAllBytes(path)

    let bytesToArrayOfDouble (buffer: byte[]) =
        seq { 0 .. buffer.Length / 8 - 1 }
        |> Seq.map (fun x -> double <| BitConverter.ToDouble(buffer, x * 8))
        |> Seq.toArray

    let splitCoefficientsAndArgsLE (arr: double[]) =
        let n = arr.Length
        let args = arr[n - 3 ..]
        let coefficients = arr[0 .. n - 4]
        args, coefficients
    
    let posterioriError(a: double[], x: double) =
        let n = a.Length - 1
        let mutable p = a[n-1]
        let mutable m = abs(a[n-1])/double 2
        for i = 0 to n do
            p <- p * x + a[i]
            m <- m * abs(x) + abs(p)
        m <- Ulp.getU * (double 2 * m - abs(p))
        m
    
    let getPosterioriError(a: double[], x: double) =
        match a.Length with
        | 0 -> double 0
        | 1 -> double 0
        | _ -> posterioriError(a, x)
    
    let prioriError (n: int) =
        let u = Ulp.getU

        match n with
        | x when double x >= getBound -> failwith "n is too big"
        | 1 -> double 0
        | _ -> double 2 * double n * u / (double 1 - double 2 * double n * u)

    let splitCoefficientsAndArgsBE (arr: double[]) =
        let n = arr.Length
        arr |> Array.Reverse
        let args = arr[n - 1 ..]
        let coefficients = arr[0 .. n - 2]
        args, coefficients

    let calculateAndPrint (args: double[], coefficients: double[]) =
        args
        |> Array.iter (fun x ->
            let prioriError =
                prioriError (coefficients.Length - 1) * HornerAlgo.prioriSum(coefficients, x)

            let result, e = HornerAlgo.calculate (coefficients, x)
            let pe = getPosterioriError(coefficients, x)
            printfn $" Priori error = {prioriError}\n Result = {result}\n Posteriori error = {e} \n PE (2 var) = {pe}"
        )
