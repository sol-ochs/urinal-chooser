open System
open UrinalLogic

let welcomeMessage = """
Welcome to Urinal Chooser!
Enter rows of urinals as 0/1 (1 = occupied, 0 = empty).
Type 'q' to quit.
"""


let noUrinalsMessages = [
    "There are no urinals. Are you sure this is not a closet?"
    "There are no urinals. Are you in the women's bathroom?"
]

let printRow (row: list<int>) =
    for urinal in row do
        match urinal with
        | 0 -> printf "[ ]"
        | _ -> printf "[x]"
    printfn ""

let tryParseRow (input: string) : Result<list<int>, string> =
    if String.IsNullOrWhiteSpace input then
        Ok []
    else
        let trimmed = input.Trim()
        let invalid = trimmed |> Seq.exists (fun c -> c <> '0' && c <> '1')
        if invalid then
            Error "Input must be a sequence of only '0' and '1' characters."
        else
            Ok (trimmed |> Seq.map (fun c -> if c = '0' then 0 else 1) |> List.ofSeq)

let printBestIndicator (rowLength: int) (bestUrinal: int) =
    for urinal in [ 0 .. rowLength - 1 ] do
        match urinal with
        | _ when urinal = bestUrinal -> printf " ^ "
        | _ -> printf "   "
    printfn ""

printfn "%s" welcomeMessage

let mutable keepRunning = true
while keepRunning do
    printf "row> "
    let input = Console.ReadLine()
    match input with
    | null -> keepRunning <- false
    | _ when input.Trim().ToLower() = "q" || input.Trim().ToLower() = "quit" -> keepRunning <- false
    | _ ->
        match tryParseRow input with
        | Error msg ->
            printfn "%s" msg
        | Ok row ->
            match row with
            | [] ->
                let random = Random()
                let message = noUrinalsMessages.[random.Next(noUrinalsMessages.Length)]
                printfn "%s" message
            | _ ->
                printRow row
                match chooseUrinal row with
                | Some bestUrinal -> printBestIndicator row.Length bestUrinal
                | None -> printfn "There are no urinals available. Go find a water bottle or something."