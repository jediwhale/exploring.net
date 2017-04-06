namespace Exploring.Net.FSharp

module Newton =

    let rec findFixedPoint aFunction guess =
        let newGuess = aFunction guess
        let goodEnough = abs((guess - newGuess) / guess) < 0.000001
        if goodEnough then newGuess else findFixedPoint aFunction newGuess 

    let squareRoot input =
        let squareRootFromGuess = findFixedPoint (fun guess -> (guess + input / guess) / 2.0)
        match input with
            | 0.0 -> 0.0
            | input when input < 0.0 -> raise (new System.ArgumentOutOfRangeException())
            | input -> squareRootFromGuess 1.0 
