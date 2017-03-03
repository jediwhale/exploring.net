namespace Exploring.Net.FSharp

module Interval = 

    type IntervalType = {Start: float; Finish: float}

    let create start finish = {Start = start; Finish = finish}

    let midpoint interval = (interval.Start + interval.Finish) / 2.0
    let size interval = abs(interval.Finish - interval.Start)

    let crossesZero interval = sign(interval.Start) = -sign(interval.Finish) && sign(interval.Start) <> 0
    let ascending interval = interval.Start < interval.Finish

    let leftHalf interval = create interval.Start (midpoint interval)
    let rightHalf interval = create (midpoint interval) interval.Finish
    let swap interval = create interval.Finish interval.Start
    let map aFunction interval  = create (aFunction interval.Start) (aFunction interval.Finish)
