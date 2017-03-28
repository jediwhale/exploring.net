namespace Exploring.Net.UnitTestF

open NUnit.Framework
open Exploring.Net.FSharp.NewtonsMethod
open Exploring.Net.CSharp

[<AbstractClass>]
type NewtonsMethodTest() =

    abstract member FindSquareRoot: float -> float

    [<Test>]
    member this.``initial guess is correct``() =
        Assert.AreEqual(1.0, this.FindSquareRoot(1.0)) 

    [<Test>]
    member this.``result gets close enough``() =
        Assert.AreEqual(2.0, this.FindSquareRoot(4.0), 1E-10);

[<TestFixture>]
type NewtonsMethodTestFSharp() =
    inherit NewtonsMethodTest()
    override this.FindSquareRoot input = squareRoot input

[<TestFixture>]
type NewtonsMethodTestCSharp() =
    inherit NewtonsMethodTest()
    override this.FindSquareRoot input = NewtonsMethod.SquareRoot input
    