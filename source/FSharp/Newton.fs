namespace Exploring.Net.FSharp

module Newton =

    let squareRoot input =

        let rec squareRootFromGuess guess =
            let newGuess = (guess + input / guess) / 2.0
            let goodEnough = abs((guess - newGuess) / guess) < 0.000001
            if goodEnough then newGuess else squareRootFromGuess newGuess 

        match input with
            | 0.0 -> 0.0
            | input when input < 0.0 -> raise (new System.ArgumentOutOfRangeException())
            | input -> squareRootFromGuess 1.0 
