open System
open System.IO
open Exam
open Utils

module Exam =
    
    let pathToLE = Path.Combine(Environment.CurrentDirectory, "polynomTest2LE.dat")   
    getBytes pathToLE
        |> bytesToArrayOfDouble
        |> splitCoefficientsAndArgsLE
        |> calculateAndPrint
    
    let pathToBE = Path.Combine(Environment.CurrentDirectory, "polynomTest1BE.dat")
    getBytes pathToBE
        |> bytesToArrayOfDouble
        |> splitCoefficientsAndArgsBE
        |> calculateAndPrint
    