namespace Exploring.Net.FSharp

open System

module NewtonsMethod =
    [<Literal>]
    let smallAmount = 1E-6

    let findRoot aFunction firstGuess =

        let derivative = fun x -> (aFunction (x + smallAmount) - aFunction x) / smallAmount
        let newtonsTransform = fun x -> x - (aFunction x) / (derivative x)

        let rec tryAGuess guess =
            let newGuess = newtonsTransform guess
            if Double.IsNaN newGuess || Double.IsInfinity newGuess
                then newGuess
                else
                    let goodEnough = abs((guess - newGuess) / guess) < smallAmount
                    if goodEnough then newGuess else tryAGuess newGuess 

        tryAGuess firstGuess

    let squareRoot input = findRoot (fun x -> x*x - input) 1.0
