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
    
let digits = Map ["one", 1; "two", 2 ; "three", 3 ; "four", 4; "five", 5 ; "six", 6 ; "seven", 7 ; "eight", 8 ; "nine", 9]

let FunnyFunction (col : string list) =
    match col with
    | head::tail -> ()
    | [] -> ()
let solve2 =
    File.ReadLines(path)
    |> Seq.map(fun line ->
        line
        |> List.ofSeq
        |> List.map(fun c -> sprintf "%c" c)
    )
    |> Seq.map(FunnyFunction)