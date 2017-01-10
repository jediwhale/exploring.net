namespace Exploring.Net.FSharp

module Newton =

    let GoodEnough oldGuess newGuess = abs((oldGuess - newGuess) / oldGuess) < 0.001

    let rec SqrtFromGuess guess input =
        let newGuess = (guess + input / guess) / 2.0
        if GoodEnough guess newGuess then newGuess else SqrtFromGuess newGuess input

    let Sqrt input = SqrtFromGuess 1.0 input
