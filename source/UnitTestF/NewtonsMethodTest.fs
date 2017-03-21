namespace Exploring.Net.UnitTestF

open NUnit.Framework
open Exploring.Net.FSharp.NewtonsMethod

[<AbstractClass>]
type NewtonsMethodTest() =

    abstract member FindFixedPoint: float -> float

    [<Test>]
    member this.``initial guess is right``() =
        Assert.AreEqual(1.0, this.FindFixedPoint(1.0))

    [<Test>]
    member this.``result gets close enough``() =
        Assert.AreEqual(-2.0, this.FindFixedPoint(0.0))

[<TestFixture>]
type NewtonsMethodTestFSharp() =
    inherit NewtonsMethodTest()
    override this.FindFixedPoint guess =
        findFixedPoint (fun x -> 2.0 - x*x) guess
    