namespace Fable.FastCheck

open Fable.Core
open System.ComponentModel

type PromiseScheduler [<EditorBrowsable(EditorBrowsableState.Never)>] (scheduler: Bindings.Scheduler<obj,obj>) =
    /// Adds a promise to the scheduler, returns the same 
    /// promise that now runs in the context of the scheduler.
    member _.schedule (prom: JS.Promise<'T>) =
        prom
        |> Promise.map (box)
        |> scheduler.schedule
        |> Promise.map unbox<'T>
    /// Adds an async to the scheduler, returns the same 
    /// async that now runs in the context of the scheduler.
    member this.schedule (a: Async<'T>) =
        Async.StartAsPromise a
        |> this.schedule
        |> Async.AwaitPromise

    /// Adds a functions that generates promises to the scheduler, returns the same 
    /// promise that now runs in the context of the scheduler.
    member _.scheduleFunction (f: 'Args -> JS.Promise<'T>) =
        unbox<'Args> >> f >> Promise.map box
        |> scheduler.scheduleFunction
        >> Promise.map unbox<'T>
        |> fun res -> 
            fun (args: 'Args) -> (box args) |> res
    /// Adds a functions that generates asyncs to the scheduler, returns the same 
    /// async that now runs in the context of the scheduler.
    member this.scheduleFunction (f: 'Args -> Async<'T>) =
        f 
        >> Async.StartAsPromise
        |> this.scheduleFunction
        >> Async.AwaitPromise

    /// Adds a sequence of promises to the scheduler, returns the same 
    /// promises that now runs in the context of the scheduler.
    member _.scheduleSequence (funcs: seq<unit -> JS.Promise<obj>>) =
        scheduler.scheduleSequence (ResizeArray funcs)
    /// Adds a sequence of asyncs to the scheduler, returns the same 
    /// asyncs that now runs in the context of the scheduler.
    member _.scheduleSequence (funcs: seq<unit -> Async<obj>>) =
        funcs 
        |> Seq.map (fun f -> f >> Async.StartAsPromise)
        |> ResizeArray
        |> scheduler.scheduleSequence
    /// Adds a sequence of promises to the scheduler with labels, returns the same 
    /// promises that now runs in the context of the scheduler.
    member _.scheduleSequence (funcs: seq<(unit -> JS.Promise<obj>) * string>) =
        funcs 
        |> Seq.map Bindings.ScheduleSequenceItem.create
        |> ResizeArray
        |> scheduler.scheduleSequence
    /// Adds a sequence of asyncs to the scheduler, returns the same 
    /// asyncs that now runs in the context of the scheduler.
    member _.scheduleSequence (funcs: seq<(unit -> Async<obj>) * string>) =
        funcs 
        |> Seq.map (fun (f,label) -> Bindings.ScheduleSequenceItem.create(f >> Async.StartAsPromise, label))
        |> ResizeArray
        |> scheduler.scheduleSequence

    /// Number of pending tasks waiting to be scheduled by the scheduler.
    member _.count () = scheduler.count()

    /// Wait for one promise to resolve in the scheduler.
    ///
    /// Throws if there is no more pending tasks.
    member _.waitOne () = scheduler.waitOne()

    /// Tries to wait for one promise to resolve in the scheduler.
    ///
    /// Returns None if there is no more pending tasks.
    member _.tryWaitOne () =
        try Some (scheduler.waitOne())
        with _ -> None

    /// Wait all scheduled tasks, including the ones that might be created by one of the resolved task.
    ///
    /// Do not use if waitAll call has to be wrapped into an helper function such as act that can 
    /// relaunch new tasks afterwards.
    member _.waitAll () = scheduler.waitAll()

    /// The inner scheduler object, intended for internal use.
    [<EditorBrowsable(EditorBrowsableState.Never)>]
    member _.scheduler = scheduler

type AsyncSchedulerReturn [<EditorBrowsable(EditorBrowsableState.Never)>] (promReturn: Bindings.PromiseSchedulerReturn) =
    member _.isDone = promReturn.isDone

    member _.isFaulty = promReturn.isFaulty

    member _.task = promReturn.task |> Async.AwaitPromise

type AsyncScheduler [<EditorBrowsable(EditorBrowsableState.Never)>] (promScheduler: PromiseScheduler) =
    /// Adds an async to the scheduler, returns the same 
    /// async that now runs in the context of the scheduler.
    member _.schedule (a: Async<'T>) =
        Async.StartAsPromise a
        |> promScheduler.schedule
        |> Async.AwaitPromise

    /// Adds a functions that generates asyncs to the scheduler, returns the same 
    /// async that now runs in the context of the scheduler.
    member _.scheduleFunction (f: 'Args -> Async<'T>) =
        f 
        >> Async.StartAsPromise
        |> promScheduler.scheduleFunction
        >> Async.AwaitPromise

    /// Adds a sequence of asyncs to the scheduler, returns the same 
    /// asyncs that now runs in the context of the scheduler.
    member _.scheduleSequence (funcs: seq<unit -> Async<obj>>) =
        funcs 
        |> Seq.map (fun f -> f >> Async.StartAsPromise)
        |> ResizeArray
        |> promScheduler.scheduler.scheduleSequence
        |> AsyncSchedulerReturn
    /// Adds a sequence of asyncs to the scheduler, returns the same 
    /// asyncs that now runs in the context of the scheduler.
    member _.scheduleSequence (funcs: seq<(unit -> Async<obj>) * string>) =
        funcs 
        |> Seq.map (fun (f,label) -> Bindings.ScheduleSequenceItem.create(f >> Async.StartAsPromise, label))
        |> ResizeArray
        |> promScheduler.scheduler.scheduleSequence
        |> AsyncSchedulerReturn

    /// Number of pending tasks waiting to be scheduled by the scheduler.
    member _.count () = promScheduler.scheduler.count()

    /// Wait for one promise to resolve in the scheduler.
    ///
    /// Throws if there is no more pending tasks.
    member _.waitOne () = promScheduler.scheduler.waitOne()  |> Async.AwaitPromise

    /// Tries to wait for one promise to resolve in the scheduler.
    ///
    /// Returns None if there is no more pending tasks.
    member _.tryWaitOne () =
        try Some (promScheduler.scheduler.waitOne()  |> Async.AwaitPromise)
        with _ -> None

    /// Wait all scheduled tasks, including the ones that might be created by one of the resolved task.
    ///
    /// Do not use if waitAll call has to be wrapped into an helper function such as act that can 
    /// relaunch new tasks afterwards.
    member _.waitAll () = promScheduler.scheduler.waitAll() |> Async.AwaitPromise

    /// The inner scheduler object, intended for internal use.
    [<EditorBrowsable(EditorBrowsableState.Never)>]
    member _.scheduler = promScheduler.scheduler
