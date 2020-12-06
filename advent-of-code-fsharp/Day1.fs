module Day1
open System.IO
open Common

let findPair desiredSum numbers =
    (
        let numberSet = Set.ofSeq(numbers);
        let n = numbers |> Seq.tryFind (fun n -> numberSet.Contains(desiredSum - n));
        match n with
            | None -> None
            | Some nValue -> Some (nValue, desiredSum - nValue)
    )

let run desiredSum numbers =
    match (findPair desiredSum numbers) with
        | None -> None
        | Some (a, b) -> Some (a * b);