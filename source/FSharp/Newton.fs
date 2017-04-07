namespace Exploring.Net.FSharp

open System

module Newton =
    let smallAmount = 1E-6

    let rec findFixedPoint improveGuess guess =
        let newGuess = improveGuess guess
        if Double.IsNaN newGuess || Double.IsInfinity newGuess
            then newGuess
            else
                let goodEnough = abs((guess - newGuess) / guess) < smallAmount
                if goodEnough then newGuess else findFixedPoint improveGuess newGuess 

    let squareRoot input =
        let squareRootFromGuess = findFixedPoint (fun guess -> (guess + input / guess) / 2.0)
        match input with
            | 0.0 -> 0.0
            | input when input < 0.0 -> raise (new System.ArgumentOutOfRangeException())
            | input -> squareRootFromGuess 1.0 

    let findRoot aFunction firstGuess =
        let derivative = fun x -> (aFunction (x + smallAmount) - aFunction x) / smallAmount
        let newtonsTransform = fun x -> x - (aFunction x) / (derivative x)
        findFixedPoint newtonsTransform firstGuess

    let squareRoot2 input = findRoot (fun x -> x*x - input) 1.0
