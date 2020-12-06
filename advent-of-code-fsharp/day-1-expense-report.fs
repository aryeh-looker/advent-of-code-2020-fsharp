module ExpenseReport
open System.IO

let parseNumbers filePath =
    System.IO.File.ReadLines(filePath) |> Seq.map(int);

let findPair desiredSum numbers =
    (
        let numberSet = Set.ofSeq(numbers);
        let n = numbers |> Seq.tryFind (fun n -> numberSet.Contains(desiredSum - n));
        match n with
            | None -> None
            | Some nValue -> Some (nValue, desiredSum - nValue)
    )

let multiplyPair (a, b) = a * b

[<EntryPoint>]
let main argv =
    if argv.Length.Equals 0
    then (printfn "Provide a path to file with newline-seperated numbers!"; 1)
    else (
        match parseNumbers argv.[0] |> findPair 2020 with
            | None -> printfn "Could not find pair that sums to 2020"
            | Some pair -> multiplyPair pair |> printfn "%A"
        0
    )