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

let asserter msg oldModel newModel =
    match msg with
    | Decrement -> Jest.expect(oldModel.Count).toBeGreaterThan(newModel.Count)
    | Increment -> Jest.expect(oldModel.Count).toBeLessThan(newModel.Count)

Jest.describe("Elmish Model tests", fun () ->
    Jest.test.elmish("Model assertions run via auto generation", init(), update, asserter)
    Jest.test.elmish("Model assertions run via explicity arbitrary", init(), update, asserter, Arbitrary.constant [ Decrement; Increment ])
)
