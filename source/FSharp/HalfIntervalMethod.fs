namespace Exploring.Net.FSharp

open Interval

module HalfIntervalMethod = 

    let rec private FindRootByHalfInterval aFunction interval =
        match Size interval < 1E-10 with
            | true -> Midpoint interval
            | false ->
                match aFunction (Midpoint interval) with
                    | 0.0 -> Midpoint interval
                    | value -> FindRootByHalfInterval aFunction (if value > 0.0 then RightHalf interval else LeftHalf interval)

    let FindRoot aFunction interval =
        let values = Map aFunction interval
        match CrossesZero values with
            | true -> FindRootByHalfInterval aFunction (if Ascending values then Swap interval else interval)
            | _ -> raise (new System.ArgumentException("Values are not opposite signs."))

    let FindSineRoot interval = FindRoot sin interval