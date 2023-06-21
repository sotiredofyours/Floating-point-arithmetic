namespace Exam

open System

module HornerAlgo =

    let prioriSum (a: double[], x: double) =
        let n = a.Length - 1
        let mutable e = abs (a[n])

        for i = n - 1 downto 0 do
            e <- e * abs x + abs (a[i])
        e

    let private calculatePolynomial (a: double[], x: double) =
        let n = a.Length - 1
        let mutable r: double = a[n]
        let mutable s: double = abs(a[n]) / double 2

        for i = n - 1 downto 1 do
            r <- ((r * x) + a[i])
            s <- ((s * abs(x)) + abs(r))

        r <- ((r * x) + a[0])

        let mutable b: double =
            (double 2 * double s * double (abs(x)) + double (abs(r)))

        b <- Ulp.getU * (b / (double 1 - double (2 * n - 1) * Ulp.getU))
        r, b

    let calculate (a: double[], x: double) =
        match a.Length with
        | 0 -> double 0, double 0
        | 1 -> a[0], 0
        | _ -> calculatePolynomial (a, x)
