module LibraryTests

open System
open Xunit
open Library

[<Fact>]
let chooseUrinal_singleUnuccupied_returnsZero () =
    let row = [ 0 ]
    let expected = 0
    
    let result = chooseUrinal row

    Assert.Equal(expected, result)

// [<Fact>]
// let chooseUrinal_singlOccupied_throws () =
//     let row = [ 1 ]

//     let ex = Assert.Throws<Exception> (fun () -> chooseUrinal row)

//     Assert.Equal("There are no unoccupied urinals. Go find a water bottle or something.", ex.Message)

[<Fact>]
let chooseUrinal_allUnoccupied_returnFirst () =
    let row = [ 0; 0; 0 ]
    let expected = 0
    
    let result = chooseUrinal row

    Assert.Equal(expected, result)