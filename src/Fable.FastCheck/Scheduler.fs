namespace Fable.FastCheck

open Fable.Core
open System.ComponentModel

type Scheduler [<EditorBrowsable(EditorBrowsableState.Never)>] (scheduler: Bindings.Scheduler<obj,obj>) =
    member _.schedule (prom: JS.Promise<'T>) =
        prom
        |> Promise.map (box)
        |> scheduler.schedule
        |> Promise.map unbox<'T>

    member _.scheduleFunction (f: 'Args -> JS.Promise<'T>) =
        unbox<'Args> >> f >> Promise.map box
        |> scheduler.scheduleFunction
        >> Promise.map unbox<'T>
        |> fun res -> 
            fun (args: 'Args) -> (box args) |> res

    member _.scheduleSequence (funcs: seq<unit -> JS.Promise<obj>>) =
        scheduler.scheduleSequence (ResizeArray funcs)

    member _.scheduleSequence (funcs: seq<(unit -> JS.Promise<obj>) * string>) =
        funcs 
        |> Seq.map Bindings.ScheduleSequenceItem.create
        |> ResizeArray
        |> scheduler.scheduleSequence

    member _.count () = scheduler.count()

    member _.waitOne () = scheduler.waitOne()

    member _.waitAll () = scheduler.waitAll()

    member _.scheduler = scheduler
