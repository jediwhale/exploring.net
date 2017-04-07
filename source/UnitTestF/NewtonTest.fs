namespace Exploring.Net.UnitTestF

open NUnit.Framework
open Exploring.Net.FSharp.Newton
open Exploring.Net.CSharp

[<AbstractClass>]
type NewtonTest() =

    abstract member FindSquareRoot: float -> float

    [<Test>]
    member this.``initial guess is correct``() =
        Assert.AreEqual(1.0, this.FindSquareRoot(1.0)) 

    [<Test>]
    member this.``result gets close enough``() =
        Assert.AreEqual(2.0, this.FindSquareRoot(4.0), 1E-10);

[<TestFixture>]
type NewtonTestFSharp() =
    inherit NewtonTest()
    override this.FindSquareRoot input = squareRoot2 input

[<TestFixture>]
type NewtonTestCSharp() =
    inherit NewtonTest()
    override this.FindSquareRoot input = Newton.SquareRoot2 input
    