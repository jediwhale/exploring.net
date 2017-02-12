namespace Exploring.Net.FSharp

module Example =

    let rec Recurse input = if input = 0 then 42 else Recurse(input-1) 
