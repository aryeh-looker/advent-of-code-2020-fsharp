module Day1Pair
open System.IO
open Common

// find pair of numbers that sum to `desiredSum`
let findPair desiredSum numbers =
    (
        let numberSet = Set.ofSeq(numbers);
        let n = numbers |> Seq.tryFind (fun n -> numberSet.Contains(desiredSum - n));
        match n with
            | None -> None
            | Some nValue -> Some (nValue, desiredSum - nValue)
    )

// compute product of pair of numbers that sum to `desiredSum`
let run desiredSum numbers =
    match (findPair desiredSum numbers) with
        | None -> None
        | Some (a, b) -> Some (a * b);
