namespace Exploring.Net.FSharp

type Interval = 
    {Start: double; End: double}

    member this.Midpoint = (this.Start + this.End) / 2.0

    member this.SmallEnough threshold = abs(this.End - this.Start) < threshold
    member this.CrossesZero = sign(this.Start) = -sign(this.End) && sign(this.Start) <> 0
    member this.Ascending = this.Start < this.End

    member this.LeftHalf = {Start = this.Start; End = this.Midpoint}
    member this.RightHalf = {Start = this.Midpoint; End =  this.End}
    member this.Swap = {Start = this.End; End = this.Start}
    member this.Map aFunction = {Start = aFunction this.Start; End = aFunction this.End}

module HalfIntervalMethod = 

    let rec FindRootByHalfInterval aFunction (interval: Interval) =
        match interval.SmallEnough 1E-10 with
            | true -> interval.Midpoint
            | false ->
                match aFunction interval.Midpoint with
                    | 0.0 -> interval.Midpoint
                    | x when x > 0.0 -> FindRootByHalfInterval aFunction interval.RightHalf
                    | _ -> FindRootByHalfInterval aFunction interval.LeftHalf

    let FindRoot aFunction (interval: Interval) =
        let values = interval.Map aFunction
        match values.CrossesZero with
            | true -> FindRootByHalfInterval aFunction (if values.Ascending then interval.Swap else interval)
            | _ -> raise (new System.ArgumentException("Values are not opposite signs."))

    let FindSineRoot interval = FindRoot sin interval