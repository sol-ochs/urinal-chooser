open System
open UrinalLogic

let noUrinalsMessages = [
    "There are no urinals. Are you sure this is not a closet?"
    "There are no urinals. Are you in the women's bathroom?"
]

Console.WriteLine("Enter a row of urinals as 1s and 0s with 1s indicating 'Occupied' and 0s indicating 'Unoccupied': ")
let row =
    Console.ReadLine()
    |> Seq.map (fun c -> if c = '0' then 0 else 1)
    |> List.ofSeq

// TODO: Do more input validation
match row with
| [] ->
    let random = Random()
    let message = noUrinalsMessages.[random.Next(noUrinalsMessages.Length)]
    printfn "%s" message
    exit 0
| _ ->
    for urinal in row do
        match urinal with
        | 0 -> printf "[ ]"
        | _ -> printf "[x]"
    printfn ""

    match chooseUrinal row with
    | Some bestUrinal ->
        for urinal in [ 0 .. row.Length-1 ] do
            match urinal with
            | _ when urinal = bestUrinal -> printf " ^ "
            | _ -> printf "   "
        printfn ""
    | None -> 
        printfn "There are no urinals available. Go find a water bottle or something."