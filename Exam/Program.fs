open System
open System.IO
open Exam
open Utils

module Exam =

    let pathToLE = Path.Combine(Environment.CurrentDirectory, "polynomTest2LE.dat")
    
    printfn "Little endianness"
    getBytes pathToLE
    |> bytesToArrayOfDouble
    |> splitCoefficientsAndArgsLE
    |> calculateAndPrint
    
    printfn "Big endianness"
    let pathToBE = Path.Combine(Environment.CurrentDirectory, "polynomTest1BE.dat")

    getBytes pathToBE
    |> Array.rev
    |> bytesToArrayOfDouble
    |> splitCoefficientsAndArgsBE
    |> calculateAndPrint
