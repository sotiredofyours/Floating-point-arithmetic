namespace Exam

open System

module HornerAlgo =
    
    let calculatePalindrome (a: double[], x: double) =
        let n = a.Length - 1
        let mutable r: double = a[n]
        let mutable s: double = Math.Abs(a[n]) / double 2
        for i = n - 1 downto 1 do
            r <- ((r * x) + a[i])
            s <- ((s * Math.Abs(x)) + Math.Abs(r))
        r <- ((r * x) + a[0])
        let mutable b: double = (double 2 * (double s + double (Math.Abs(x))) + double (Math.Abs(r)))
        b <- Ulp.getU * (b /(double 1 - double (2*n - 1) * Ulp.getU))
        r, b