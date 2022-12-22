module Library

// // discriminated union
// type OccupiedOrUnoccupied<'T> =
//     | Occupied of 'T
//     | Unoccupied of 'T

// // pattern matching
// let isOccupied2 urinal = 
//     match urinal with
//     | 1 -> Occupied
//     | _ -> Unoccupied

let chooseUrinal (row: list<int>) = // use somethinArray?
    let isOccupied (_, u) = u = 1

    let occupied, unoccupied =
        row 
        |> List.indexed
        |> List.partition isOccupied
    
    if unoccupied.IsEmpty then
        failwith "There are no unoccupied urinals. Go find a water bottle or something."
    else if occupied.IsEmpty then
        0
    else
        let distanceToNearestOccupiedUrinal curr =
            let (nearestOccupied, _) =
                occupied 
                |> List.minBy (fun (occupiedUrinal, _) -> abs (curr - occupiedUrinal))
            abs (curr - nearestOccupied)
        
        let distances =
            unoccupied
            |> List.map (fun (i, _) -> i)
            |> List.map distanceToNearestOccupiedUrinal

        let urinalsWithDistances =
            unoccupied
            |> List.map (fun (i, _) -> i)
            |> List.zip distances
        
        let maxDistance = distances |> List.max
        
        let urinalsWithMaxDistance =
            urinalsWithDistances
            |> List.filter (fun (_, d) -> d = maxDistance)
        
        let edgeUrinalsWithMaxDistance =
            urinalsWithMaxDistance
            |> List.filter (fun (i, _) -> i = 0 || i = row.Length-1)

        if not edgeUrinalsWithMaxDistance.IsEmpty then
            let (_, bestUrinal) = edgeUrinalsWithMaxDistance.Head
            bestUrinal
        else
            let (_, bestUrinal) = urinalsWithMaxDistance.Head
            bestUrinal