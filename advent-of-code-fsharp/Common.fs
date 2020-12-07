module Common
open System.IO

let parseNumbers filePath =
    System.IO.File.ReadLines(filePath) |> Seq.map(int);

let parseStrings filePath =
    System.IO.File.ReadLines(filePath)