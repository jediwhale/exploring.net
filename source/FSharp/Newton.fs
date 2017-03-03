﻿namespace Exploring.Net.FSharp

module Newton =

    let squareRoot input =

        let rec squareRootFromGuess guess input =

            let goodEnough newGuess = abs((guess - newGuess) / guess) < 0.000001

            let newGuess = (guess + input / guess) / 2.0
            if goodEnough newGuess then newGuess else squareRootFromGuess newGuess input

        match input with
            | 0.0 -> 0.0
            | input when input < 0.0 -> raise (new System.ArgumentOutOfRangeException())
            | input -> squareRootFromGuess 1.0 input
