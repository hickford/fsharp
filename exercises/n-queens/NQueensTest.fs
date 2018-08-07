// This file was auto-generated based on version 2.1.0 of the canonical data.

module NQueensTest

open FsUnit.Xunit
open Xunit

open NQueens

let legal rows =
    // check that no queens are threatening each other
    let n = rows |> Seq.length
    let areDistinct = Seq.distinct >> Seq.length >> (=) n
    let forwardDiagonals = rows |> Seq.mapi (+)
    let backDiagonals = rows |> Seq.mapi (-)
    rows |> areDistinct && forwardDiagonals |> areDistinct && backDiagonals |> areDistinct

[<Fact>]
let ``2 by 2 board`` () =
    queens 2 |> should equal None

let check n solution =
    solution |> Option.map List.length |> should equal (Some n)
    solution |> Option.map List.min |> should equal (Some 0)
    solution |> Option.map List.max |> should lessThan (Some n)
    solution |> Option.map legal |> should equal (Some true)

[<Fact>]
let ``4 by 4 board`` () =
    queens 4 |> check 4

[<Fact>]
let ``8 by 8 board`` () =
    queens 8 |> check 8

