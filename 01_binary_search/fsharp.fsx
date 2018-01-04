
open System

let rec binarySearch (arr: int array) (item: int) =
  if arr.Length = 0 then -1 else
  let half = arr.Length / 2
  let center = arr.[half]
  if center = item then half
  else if center > item then
    if half = 0 then -1 else
    binarySearch (arr.[0..half - 1]) item
  else 
    if half = arr.Length - 1 then -1 else
    binarySearch (arr.[half + 1..arr.Length - 1]) item

let binarySearch2 (arr: int array) (item: int) =
  let mutable start = 0
  let mutable end' = arr.Length - 1
  let mutable index = -1
  while start <= end' && index = -1 do
    let mid = (end' + start) / 2
    let guess = arr.[mid]
    if guess = item then
      index <- mid
    else if guess > item then
      end' <- mid - 1
    else
      start <- mid + 1
  index

let myList = [|1; 3; 5; 7; 9|]

printfn "%d" <| binarySearch myList 3
printfn "%d" <| binarySearch2 myList 3

printfn "%d" <| binarySearch myList -3
printfn "%d" <| binarySearch2 myList -3