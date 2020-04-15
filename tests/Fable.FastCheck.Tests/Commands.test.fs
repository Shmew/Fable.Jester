module CommandsTests

open Fable.Jester
open Fable.FastCheck
open Fable.FastCheck.Jest

type Model () = 
    let mutable count = 0

    member _.Count = 
        let count = count
        count

    member _.Decrement () = count <- count - 1

    member _.Increment () = count <- count + 1

type Msg =
    | Decrement
    | Increment

let update msg (model: Model) =
    match msg with
    | Decrement -> model.Decrement()
    | Increment -> model.Increment()
    
type DecrementCommand () =
    interface ICommand<Model, Model> with
        member _.check (m: Model) = true
        member _.run (m: Model, r: Model) =
            update Decrement r
            Jest.expect(r.Count).toBeLessThanOrEqual(m.Count)
            m.Decrement()
        
        member _.toString () = "Decrement"

type IncrementCommand () =
    interface ICommand<Model, Model> with
        member _.check (m: Model) = true
        member _.run (m: Model, r: Model) =
            update Increment r
            Jest.expect(r.Count).toBeGreaterThanOrEqual(m.Count)
            m.Increment()
        
        member _.toString () = "Increment" 

let commandArb = 
    Arbitrary.commands [ Arbitrary.constant (DecrementCommand() :> ICommand<Model,Model>); Arbitrary.constant (IncrementCommand() :> ICommand<Model,Model>) ]

type AsyncDecrementCommand () =
    interface IAsyncCommand<Model, Model> with
        member _.check (m: Model) = promise { return true }
        member _.run (m: Model, r: Model) =
            promise {
                update Decrement r
                Jest.expect(r.Count).toBeLessThanOrEqual(m.Count)
                m.Decrement()
            }
        
        member _.toString () = "Decrement" 

type AsyncIncrementCommand () =
    interface IAsyncCommand<Model, Model> with
        member _.check (m: Model) = promise { return true }
        member _.run (m: Model, r: Model) =
            promise {
                update Increment r
                Jest.expect(r.Count).toBeGreaterThanOrEqual(m.Count)
                m.Increment()
            }
        
        member _.toString () = "Increment" 

let asyncCommandArb =
    Arbitrary.asyncCommands [ Arbitrary.constant (AsyncDecrementCommand() :> IAsyncCommand<Model,Model>); Arbitrary.constant (AsyncIncrementCommand() :> IAsyncCommand<Model,Model>) ]

Jest.describe("Commands tests", fun () ->
    Jest.test.prop("Commands are runnable", commandArb, fun cmds ->
        cmds
        |> Seq.iter (fun cmd ->
            cmd.run(Model(), Model())
        )
    )
    Jest.test.prop("ModelRun executes model", commandArb, fun cmds ->
        FastCheck.modelRun(Model(), Model(), cmds)
    )
)

Jest.describe("Async Commands tests", fun () ->
    Jest.test.prop("Async commands are runnable", asyncCommandArb, fun cmds ->
        promise {
            for cmd in cmds do
                do! cmd.run(Model(), Model())
        }
    )
    Jest.test.prop("AsyncModelRun executes model", asyncCommandArb, fun cmds ->
        FastCheck.asyncModelRun(Model(), Model(), cmds)
    )
)
