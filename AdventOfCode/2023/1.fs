module One

open System
open System.IO
open Core

let path = "/Users/drhim/dev/AdventOfCode/AdventOfCode/2023/input.txt"

let FunnyFold (col : string list) =
    let left = 
        col
        |> List.find(fun i -> 
            let r = tryParseInt i
            match r with 
            | Some x -> true
            | None -> false
        )
    
    let right =
        col 
        |> List.rev
        |> List.find(fun i ->
            let r = tryParseInt i
            match r with
            | Some x -> true
            | None -> false)
    
    left + right

let solve =
    File.ReadLines(path)
    |> Seq.map(fun line -> 
        line
        |> List.ofSeq
        |> List.map(fun c -> sprintf "%c" c)
    )
    |> Seq.map(FunnyFold)
    |> Seq.map(int)
    |> Seq.sum
    
let digits = ["one", 1; "two", 2 ; "three", 3 ; "four", 4; "five", 5 ; "six", 6 ; "seven", 7 ; "eight", 8 ; "nine", 9 ; "1", 1; "2", 2; "3", 3 ; "4", 4 ; "5", 5; "6", 6; "7", 7; "8", 8 ; "9", 9]

let converter (nums : seq<int>) = 
    Seq.toList nums |> fun l -> l.[0] * 10 + l.[l.Length - 1]
let rec FunnyFunction (line : string) =
    match (line, digits |> List.filter(fun (x, _) -> line.StartsWith(x))) with
    | ("", _ ) -> Seq.empty
    | (_, [] ) -> FunnyFunction (line.Substring(1))
    | (_, (word, num) :: _) -> seq {
        yield num
        yield! FunnyFunction (line.Substring 1)
    }
    

let solve2 =
    File.ReadLines(path)
    |> Seq.map(FunnyFunction >> converter)
    |> Seq.sum