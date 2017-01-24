namespace Exploring.Net.FSharp

module Newton =

    let GoodEnough oldGuess newGuess = abs((oldGuess - newGuess) / oldGuess) < 0.000001

    let rec SquareRootFromGuess guess input =
        let newGuess = (guess + input / guess) / 2.0
        if GoodEnough guess newGuess then newGuess else SquareRootFromGuess newGuess input

    let SquareRoot input =
        match input with
        | 0.0 -> 0.0
        | x when x < 0.0 -> raise (new System.ArgumentOutOfRangeException())
        | _ -> SquareRootFromGuess 1.0 input
