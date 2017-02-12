namespace Exploring.Net.FSharp

module Newton =

    let private GoodEnough oldGuess newGuess = abs((oldGuess - newGuess) / oldGuess) < 0.000001

    let rec private SquareRootFromGuess guess input =
        let newGuess = (guess + input / guess) / 2.0
        if GoodEnough guess newGuess then newGuess else SquareRootFromGuess newGuess input

    let SquareRoot = function
        | 0.0 -> 0.0
        | input when input < 0.0 -> raise (new System.ArgumentOutOfRangeException())
        | input -> SquareRootFromGuess 1.0 input
