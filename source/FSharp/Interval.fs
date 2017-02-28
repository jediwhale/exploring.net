namespace Exploring.Net.FSharp

module Interval = 

    type IntervalType = {Start: float; Finish: float}

    let create start finish = {Start = start; Finish = finish}

    let Midpoint interval = (interval.Start + interval.Finish) / 2.0

    let Size interval = abs(interval.Finish - interval.Start)
    let CrossesZero interval = sign(interval.Start) = -sign(interval.Finish) && sign(interval.Start) <> 0
    let Ascending interval = interval.Start < interval.Finish

    let LeftHalf interval = create interval.Start (Midpoint interval)
    let RightHalf interval = create (Midpoint interval) interval.Finish
    let Swap interval = create interval.Finish interval.Start
    let Map aFunction interval  = create (aFunction interval.Start) (aFunction interval.Finish)

