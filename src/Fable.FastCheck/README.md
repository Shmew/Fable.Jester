# Fable.FastCheck [![Nuget](https://img.shields.io/nuget/v/Fable.FastCheck.svg?maxAge=0&colorB=brightgreen&label=Fable.FastCheck)](https://www.nuget.org/packages/Fable.FastCheck) [![Nuget](https://img.shields.io/nuget/v/Fable.FastCheck.Jest.svg?maxAge=0&colorB=brightgreen&label=Fable.FastCheck.Jest)](https://www.nuget.org/packages/Fable.FastCheck.Jest)

Fable bindings for [fast-check](https://github.com/dubzzz/fast-check).

A quick look:

```fsharp
open Fable.Jester
open Fable.FastCheck
open Fable.FastCheck.Jest

Jest.describe("Arbitrary tests", fun () ->
    Jest.test.prop("Can generate default arbitraries", Arbitrary.Defaults.integer, fun i ->
        Jest.expect(i).not.toBeNaN()
        Jest.expect(i).toBeDefined()
        Jest.expect(i).not.toBeNull()
    )
    Jest.test.prop("Can generate arbitraries with constraints", Arbitrary.ConstrainedDefaults.integer(1, 5), fun i ->
        Jest.expect(i).toBeGreaterThanOrEqual(1)
        Jest.expect(i).toBeLessThanOrEqual(5)
    )
)
```

It can also be used to model-test your elmish applications:

```fsharp
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
```

Full documentation can be found [here](https://shmew.github.io/Fable.Jester).
