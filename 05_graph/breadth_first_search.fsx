

open System.Collections.Generic
open System.Diagnostics

let graph =
  Map [
    "you", ["alice"; "bob"; "claire"]
    "bob", ["anuj"; "peggy"]
    "alice", ["peggy"]
    "claire", ["thom"; "jonny"]
    "anuj", []
    "peggy", []
    "thom", []
    "jonny", []
  ]
let friends = graph.["you"]

let queue = Queue<string>()

let enqueueAll frs =
  frs |> List.iter(fun i -> queue.Enqueue(i))

enqueueAll friends

let isSeller (name: string) =
  name.[name.Length - 1] = 'm'

let mutable finded = false

let watch = Stopwatch()

watch.Start()
let mutable searched = Set.empty<string>

while queue.Count <> 0 && not finded do
  let name = queue.Dequeue()
  if searched.Contains name then () else
  searched <- searched.Add name
  if isSeller name then
    printfn "%s is mongo seller" name
    finded <- true
  else
    let frs = graph.TryFind name
    match frs with
    | Some frs -> enqueueAll frs
    | _ -> ()

watch.Stop()
printfn "time: %dms" watch.ElapsedMilliseconds
