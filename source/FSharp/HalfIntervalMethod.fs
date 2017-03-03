namespace Exploring.Net.FSharp

open Interval

module HalfIntervalMethod = 

    let findRoot aFunction interval =

        let rec findRootByHalfInterval interval =
            if size interval < 1E-10
                then midpoint interval
                else
                    match aFunction (midpoint interval) with
                        | 0.0 -> midpoint interval
                        | value -> findRootByHalfInterval ((if value < 0.0 then rightHalf else leftHalf) interval)

        let values = map aFunction interval
        if crossesZero values 
            then findRootByHalfInterval (if ascending values then interval else swap interval)
            else raise (new System.ArgumentException("Values are not opposite signs."))

    let findSineRoot interval = findRoot sin interval
