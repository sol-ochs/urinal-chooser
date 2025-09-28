open System
open UrinalLogic

Console.WriteLine("Enter a row of urinals as 1s and 0s with 1s indicating 'Occupied' and 0s indicating 'Unoccupied': ")
let row =
    Console.ReadLine()
    |> Seq.map (fun c -> if c = '0' then 0 else 1)
    |> List.ofSeq

// print row
for urinal in row do
    match urinal with
    | 0 -> printf "[ ]"
    | _ -> printf "[x]"
printfn ""

try
    match chooseUrinal row with
    | Some bestUrinal ->
        for urinal in [ 0 .. row.Length-1 ] do
            match urinal with
            | _ when urinal = bestUrinal -> printf " ^ "
            | _ -> printf "   "
        printfn ""
    | None -> 
        printfn "There are no urinals available. Go find a water bottle or something."
with
    | :? System.ArgumentException as e -> printfn "Error: %s" e.Message