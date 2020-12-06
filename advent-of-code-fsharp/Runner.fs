module Runner

let printUsage () =
    printfn """
    AdventOfCode <cmd> <param> <file>. Examples:

        AdventOfCode day1pair 2020 path/to/data -- product of two numbers that sum to 2020
        AdventOfCode day1triple 2020 path/to/data -- product of three numbers that sum to 2020
    """

[<EntryPoint>]
let main argv =
    if argv.Length.Equals 0
    then (printUsage |> ignore; 1)
    else
        let desiredSum = argv.[1] |> int
        let numbers = argv.[2] |> Common.parseNumbers
        match argv.[0] with
        | "day1pair" ->
            match Day1Pair.run desiredSum numbers with
            | None -> eprintfn "Could not find pair that sums to %A" desiredSum; 1;
            | Some v -> printfn "%A" v; 0
        | "day1triple" ->
            match Day1Triple.run desiredSum numbers with
            | None -> printfn "Could not find triple that sums to %A" desiredSum; 1
            | Some v -> eprintfn "%A" v; 0
        | _ -> (printUsage |> ignore; 1);