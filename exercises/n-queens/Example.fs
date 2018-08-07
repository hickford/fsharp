module NQueens

// solve n queens problem. place n queens on an n x n board such that none threaten each other. returns row of each queen by column.
let queens n =
// solve a problem by backtracking
    let solveByBacktracking moves solved initialState = 
        let rec inner state = 
            match state with
                | Some progress when (progress |> solved |> not) ->
                    progress |> moves |> Seq.map (Some >> inner) |> Seq.tryFind Option.isSome |> Option.flatten
                | _ -> state
        initialState |> Some |> inner
    let legal rows =
        // check that no queens are threatening each other
        let n = rows |> Seq.length
        let areDistinct = Seq.distinct >> Seq.length >> (=) n
        let forwardDiagonals = rows |> Seq.mapi (+)
        let backDiagonals = rows |> Seq.mapi (-)
        rows |> areDistinct && forwardDiagonals |> areDistinct && backDiagonals |> areDistinct
    let solved progress = (List.length progress) = n
    let moves progress = 
        let prepend x = x::progress
        [0..n-1] |> Seq.map prepend |> Seq.filter legal
    [] |> solveByBacktracking moves solved
