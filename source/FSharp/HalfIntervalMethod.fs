namespace Exploring.Net.FSharp

open Interval

module HalfIntervalMethod = 

    let rec private findRootByHalfInterval aFunction interval =
        match size interval with
            | size when size < 1E-10 -> midpoint interval
            | _ ->
                match aFunction (midpoint interval) with
                    | 0.0 -> midpoint interval
                    | value -> findRootByHalfInterval aFunction (interval |> (if value > 0.0 then rightHalf else leftHalf))

    let findRoot aFunction interval =
        let values = map aFunction interval
        match crossesZero values with
            | true -> findRootByHalfInterval aFunction (if ascending values then swap interval else interval)
            | _ -> raise (new System.ArgumentException("Values are not opposite signs."))

    let findSineRoot interval = findRoot sin interval