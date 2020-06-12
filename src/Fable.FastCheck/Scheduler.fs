namespace Fable.FastCheck

open Fable.Core
open System.ComponentModel

type SchedulerReturnTask internal (promTask: Bindings.SchedulerReturnTask) =
    member _.isDone = promTask.isDone
    member _.isFaulty = promTask.isFaulty

type PromiseSchedulerReturn internal (promReturn: Bindings.PromiseSchedulerReturn) =
    member _.isDone = promReturn.isDone
    member _.isFaulty = promReturn.isFaulty
    member _.task = promReturn.task |> Promise.map SchedulerReturnTask

    member internal _.promReturn = promReturn

type PromiseScheduler<'Metadata> internal (scheduler: Bindings.Scheduler<obj,obj,_>) =
    /// Adds a promise to the scheduler, returns the same 
    /// promise that now runs in the context of the scheduler.
    member _.schedule (prom: JS.Promise<'T>, ?label: string, ?metadata: 'Metadata) =
        prom
        |> Promise.map (box)
        |> fun prom -> scheduler.schedule(prom, ?label = label, ?metadata = metadata)
        |> Promise.map unbox<'T>

    /// Adds a functions that generates promises to the scheduler, returns the same 
    /// promise that now runs in the context of the scheduler.
    member _.scheduleFunction (f: 'Args -> JS.Promise<'T>) =
        unbox<'Args> >> f >> Promise.map box
        |> scheduler.scheduleFunction
        >> Promise.map unbox<'T>
        |> fun res -> 
            fun (args: 'Args) -> (box args) |> res

    /// Adds a sequence of promises to the scheduler with labels, returns the same 
    /// promises that now runs in the context of the scheduler.
    member _.scheduleSequence (funcs: seq<(unit -> JS.Promise<obj>) * string>) =
        funcs 
        |> Seq.map (fun (prom, label) -> Bindings.ScheduleSequenceItem.create(prom, label, None))
        |> ResizeArray
        |> scheduler.scheduleSequence
    /// Adds a sequence of promises to the scheduler with labels, returns the same 
    /// promises that now runs in the context of the scheduler.
    member _.scheduleSequence (funcs: seq<(unit -> JS.Promise<obj>) * string * ('Metadata option)>) =
        funcs 
        |> Seq.map Bindings.ScheduleSequenceItem.create
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

    /// Produce an array containing all the scheduled tasks so far with their execution status. 
    ///
    /// If the task has been executed, it includes a string representation of the associated 
    /// output or error produced by the task if any.
    ///
    /// Tasks will be returned in the order they get executed by the scheduler.
    member _.report () = scheduler.report()

    member internal _.scheduler = scheduler

type AsyncSchedulerReturn internal (promReturn: Bindings.PromiseSchedulerReturn) =
    member _.isDone = promReturn.isDone
    member _.isFaulty = promReturn.isFaulty
    member _.task = promReturn.task |> Promise.map SchedulerReturnTask |> Async.AwaitPromise

    member internal _.promReturn = promReturn

type AsyncScheduler<'Metadata> [<EditorBrowsable(EditorBrowsableState.Never)>] (promScheduler: PromiseScheduler<'Metadata>) =
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
    member _.scheduleSequence (funcs: seq<(unit -> Async<obj>) * string>) =
        funcs 
        |> Seq.map (fun (f,label) -> Bindings.ScheduleSequenceItem.create(f >> Async.StartAsPromise, label, None))
        |> ResizeArray
        |> promScheduler.scheduler.scheduleSequence
        |> AsyncSchedulerReturn
    /// Adds a sequence of promises to the scheduler with labels, returns the same 
    /// promises that now runs in the context of the scheduler.
    member _.scheduleSequence (funcs: seq<(unit -> Async<obj>) * string * ('Metadata option)>) =
        funcs 
        |> Seq.map (fun (f,label,m) -> Bindings.ScheduleSequenceItem.create(f >> Async.StartAsPromise, label, m))
        |> ResizeArray
        |> promScheduler.scheduler.scheduleSequence

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

    /// Produce an array containing all the scheduled tasks so far with their execution status. 
    ///
    /// If the task has been executed, it includes a string representation of the associated 
    /// output or error produced by the task if any.
    ///
    /// Tasks will be returned in the order they get executed by the scheduler.
    member _.report () = promScheduler.report()

    member internal _.scheduler = promScheduler.scheduler
