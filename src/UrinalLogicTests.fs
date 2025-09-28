module UrinalLogicTests

open NUnit.Framework
open UrinalLogic

[<TestFixture>]
type UrinalLogicTests() =

    [<Test>]
    member _.``chooseUrinal should throw exception when input list is empty``() =
        let row = []
        Assert.Throws<System.ArgumentException>(fun () -> chooseUrinal row |> ignore) |> ignore

    [<Test>]
    member _.``chooseUrinal should choose single unoccupied urinal in row of one``() =
        let row = [0]
        let result = chooseUrinal row
        Assert.AreEqual(0, result)

    [<Test>]
    member _.``chooseUrinal should throw exception when all urinals are occupied``() =
        let row = [1; 1; 1; 1; 1]
        Assert.Throws<System.Exception>(fun () -> chooseUrinal row |> ignore) |> ignore

    [<Test>]
    member _.``chooseUrinal should choose closest edge urinal when all are empty``() =
        let row = [0; 0; 0; 0; 0]
        let result = chooseUrinal row
        Assert.AreEqual(0, result)

    [<Test>]
    member _.``chooseUrinal should choose middle urinal when edges are occupied``() =
        let row = [1; 0; 0; 0; 1]
        let result = chooseUrinal row
        Assert.AreEqual(2, result)

    [<Test>]
    member _.``chooseUrinal should choose closest middle urinal when edges are occupied``() =
        let row = [1; 0; 0; 0; 0; 0; 0; 1]
        let result = chooseUrinal row
        Assert.AreEqual(3, result)

    [<Test>]
    member _.``chooseUrinal should prefer closest edge urinal when distances are equal``() =
        let row = [0; 1; 0; 1; 0]
        let result = chooseUrinal row
        Assert.That(result, Is.EqualTo(0).Or.EqualTo(4))

    [<Test>]
    member _.``chooseUrinal should choose far edge urinal when only closest edge is occupied``() =
        let row = [1; 0; 0; 0; 0]
        let result = chooseUrinal row
        Assert.AreEqual(4, result)

    [<Test>]
    member _.``chooseUrinal should choose close edge urinal when far edge is occupied``() =
        let row = [0; 0; 0; 0; 1]
        let result = chooseUrinal row
        Assert.AreEqual(0, result)

    [<Test>]
    member _.``chooseUrinal should choose closer edge urinal when middle is occupied``() =
        let row = [0; 0; 1; 0; 0]
        let result = chooseUrinal row
        Assert.That(result, Is.EqualTo(0))

    [<Test>]
    member _.``chooseUrinal should handle complex scenario with multiple occupied``() =
        let row = [1; 0; 0; 1; 0; 0; 0; 1]
        let result = chooseUrinal row
        Assert.AreEqual(5, result)

    [<Test>]
    member _.``chooseUrinal should handle single unoccupied urinal``() =
        let row = [1; 0; 1]
        let result = chooseUrinal row
        Assert.AreEqual(1, result)

    [<Test>]
    member _.``chooseUrinal should handle asymmetric pattern``() =
        let row = [1; 0; 0; 0; 0; 1; 1]
        let result = chooseUrinal row
        Assert.AreEqual(2, result)

    [<Test>]
    member _.``chooseUrinal should handle long row with single occupied``() =
        let row = [0; 0; 0; 1; 0; 0; 0; 0; 0; 0]
        let result = chooseUrinal row
        Assert.AreEqual(9, result)