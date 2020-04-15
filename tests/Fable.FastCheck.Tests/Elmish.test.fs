module ElmishTests

open Elmish
open Fable.Jester
open Fable.FastCheck
open Fable.FastCheck.Jest

type Model = { Count: int }

let init () =
    { Count = 0 }, Cmd.none

type Msg =
    | Decrement
    | Increment

let update msg (model: Model) =
    match msg with
    | Decrement -> { model with Count = model.Count - 1 }, Cmd.none
    | Increment -> { model with Count = model.Count + 1 }, Cmd.none

let assertions = [
    Decrement, (fun old new' -> Jest.expect(old.Count).toBeGreaterThan(new'.Count))
    Increment, (fun old new' -> Jest.expect(old.Count).toBeLessThan(new'.Count))
]

Jest.describe("Elmish Model tests", fun () ->
    Jest.test.elmish("Model assertions run", init(), update, assertions)
)
