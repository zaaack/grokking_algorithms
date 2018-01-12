
// 4.1.1
let rec sum lst =
  match lst with
  | [] -> 0
  | head::tail -> head + (sum tail)

printfn "sum:%A" (sum [1;2;3])

// 4.1.2

let rec len lst =
  match lst with
  | [] -> 0
  | _::tail -> 1 + (len tail)

printfn "len:%A" (len [1;2;3])

// 4.1.3
let rec max lst =
  match lst with
  | [] -> None
  | head::tail ->
      match max tail with
      | Some m ->
          if head > m then Some head
          else if head < m then Some m
          else Some head
      | None -> Some head

printfn "max:%A" (max [1;2;3])
printfn "max:%A" (max [1])
printfn "max:%A" (max [])

let rec qsort (lst: int list) =
  match lst with
  | [] -> []
  | head::tail ->
      let greater = tail |> List.filter (fun i -> i >= head)
      let lessor = tail |> List.filter(fun i -> i < head)
      qsort lessor @ (head :: (qsort greater))

printfn "qsort: %A" (qsort [15;2;42;13;53;16;28;19])

