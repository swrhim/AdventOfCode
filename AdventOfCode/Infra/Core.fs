module Core

open System

let (|Int|_|) (s : string) =
    match Int32.TryParse s with
    | true, int -> Some int
    | _ -> None

let tryParseInt s =
    match s with
    | Int i -> Some i
    | _ -> None