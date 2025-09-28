module UrinalLogicTests

open NUnit.Framework
open UrinalLogic

[<TestFixture>]
type UrinalLogicTests() =

    [<Test>]
    member _.``chooseUrinal should throw exception when input list is empty``() =
        let row = []
        Assert.Throws<System.ArgumentException>(fun () -> chooseUrinal row |> ignore) |> ignore