module Runner
open Day1

let printUsage () =
    printfn """


    AdventOfCode <cmd> <param> <file>. Examples:

        AdventOfCode day1 2020 path/to/data -- product of two numbers that sum to 2020
        AdventOfCode day2 2020 path/to/data -- product of three numbers that sum to 2020
    """

[<EntryPoint>]
let main argv =
    if argv.Length.Equals 0
    then (printUsage |> ignore; 1)
    else
        let desiredSum = argv.[1] |> int
        let numbers = argv.[2] |> Common.parseNumbers
        match argv.[0] with
        | "day1" ->
            match Day1.run desiredSum numbers with
            | None -> eprintfn "Could not find pair that sums to %A" desiredSum; 1;
            | Some v -> printfn "%A" v; 0
        | "day2" ->
            match Day2.run desiredSum numbers with
            | None -> printfn "Could not find triple that sums to %A" desiredSum; 1
            | Some v -> eprintfn "%A" v; 0
        | _ -> (printUsage |> ignore; 1);