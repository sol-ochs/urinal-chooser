module UrinalLogic

    let chooseUrinal (row: list<int>) =
        if row.IsEmpty then
            raise (System.ArgumentException("There are no urinals."))

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
                |> List.filter (fun (d, _) -> d = maxDistance)
            
            let edgeUrinalsWithMaxDistance =
                urinalsWithMaxDistance
                |> List.filter (fun (_, i) -> i = 0 || i = row.Length-1)

            if not edgeUrinalsWithMaxDistance.IsEmpty then
                let (_, bestUrinal) = edgeUrinalsWithMaxDistance.Head
                bestUrinal
            else
                let (_, bestUrinal) = urinalsWithMaxDistance.Head
                bestUrinal