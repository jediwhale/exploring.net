namespace Exploring.Net.FSharp

module NewtonsMethod =

    let findFixedPoint (aFunction: float -> float) firstGuess =

        let rec tryAGuess guess =
            let newGuess = aFunction guess
            let goodEnough = abs(newGuess - guess) < 1E-10
            if goodEnough then newGuess else tryAGuess newGuess 

        tryAGuess firstGuess
