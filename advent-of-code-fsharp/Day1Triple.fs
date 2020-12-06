module Day1Triple
open System.IO
open Common

// find triple of numbers that sum to `desiredSum`
let findTriple desiredSum numbers =
    let numberSet = Set.ofSeq(numbers) in
        numbers |> Seq.tryPick (fun a ->
           numbers |> Seq.skip 1 |> Seq.tryPick (fun b ->
                let searchFor = desiredSum - (a + b) in
                    if numberSet.Contains(searchFor)
                    then Some (a, b, searchFor)
                    else None
        )
    )

// product of triple of numbers that sum to `desiredSum`
let run desiredSum numbers =
    match (findTriple desiredSum numbers) with
        | None -> None
        | Some (a, b, c) -> Some (a * b * c);
