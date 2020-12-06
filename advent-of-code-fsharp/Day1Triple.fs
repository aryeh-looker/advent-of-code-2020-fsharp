module Day1Triple
open System.IO
open Common

let findTriple desiredSum numbers =
    let numberSet = Set.ofSeq(numbers);
    numbers |> Seq.tryPick (fun a ->
       numbers |> Seq.skip 1 |> Seq.tryPick (fun b ->
            let searchFor = desiredSum - (a + b)
            if numberSet.Contains(searchFor)
            then Some (a, b, desiredSum - (a + b))
            else None
        )
    )

let run desiredSum numbers =
    match (findTriple desiredSum numbers) with
        | None -> None
        | Some (a, b, c) -> Some (a * b * c);