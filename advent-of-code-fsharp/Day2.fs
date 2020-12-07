module Day2
open System.Text.RegularExpressions

let countCharOccurences c = Seq.filter ((=) c) >> Seq.length

type PasswordPolicy = struct
    val Letter : char
    val MinOccurrences: int
    val MaxOccurrences: int
    new (letter, min, max) =
        {Letter = letter; MinOccurrences = min; MaxOccurrences = max;}
end

type PasswordLine = struct
    val PasswordPolicy : PasswordPolicy
    val Password : string
    new (policy, password) =
        {PasswordPolicy = policy; Password = password;}

    member this.IsValidPassword =
        let count = countCharOccurences this.PasswordPolicy.Letter this.Password
        count >= this.PasswordPolicy.MinOccurrences && count <= this.PasswordPolicy.MaxOccurrences
end

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
    else None

let parsePasswordLine line =
    match line with
    | Regex @"^(\d+)-(\d+) ([a-z]): (.+)$" [ min; max; letter; password ] ->
        Some (new PasswordLine(new PasswordPolicy(letter |> char, min |> int, max |> int), password))
    | _ -> None

// return count of valid passwords
let run passwords =
    passwords
    |> Seq.map parsePasswordLine
    |> Seq.filter (fun pl -> (pl.IsSome && pl.Value.IsValidPassword))
    |> Seq.length