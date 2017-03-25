namespace Exploring.Net.FSharp

open System

module NewtonsMethod =

    let findFixedPoint (aFunction: float -> float) firstGuess =

        let rec tryAGuess guess =
            let newGuess = aFunction guess
            match newGuess with
            | x when Double.IsNaN x -> raise (new ApplicationException("nan"))
            | x when Double.IsInfinity x -> raise (new ApplicationException("infinity"))
            | _ ->
                printfn "guess %f new guess %f" guess newGuess
                let goodEnough = abs((guess - newGuess) / guess) < 1E-6
                if goodEnough then newGuess else tryAGuess newGuess 

        tryAGuess firstGuess

    let derivative (aFunction: float -> float) =
        let dx = 1E-6
        fun x -> (aFunction (x + dx) - aFunction x) / dx

    let newtonsMethod (aFunction: float -> float) guess = 
        printfn "at x %f" (aFunction guess)
        printfn "at x + dx %f" (aFunction (guess + 1e-6))
        printfn "slope %f" ((derivative aFunction) guess)
        let newtonsTransform = fun x -> x - (aFunction x) / ((derivative aFunction) x)
        findFixedPoint newtonsTransform guess

    let squareRoot input = newtonsMethod (fun x -> x*x - input) 1.0
