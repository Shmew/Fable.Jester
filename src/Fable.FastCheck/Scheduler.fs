namespace Fable.FastCheck

open Fable.Core

type SchedulerSequenceItem =
    U2<(unit -> JS.Promise<obj option>), string>

type SchedulerConstraints =
    /// Ensure that all scheduled tasks will be executed in the right context (for instance it can be the `act` of React)
    abstract act: ((unit -> JS.Promise<unit>) -> JS.Promise<obj>)

type SchedulerScheduleSequenceReturnTaskPromise =
    abstract ``done``: bool

    abstract faulty: bool

type SchedulerScheduleSequenceReturn =
    [<Emit("$0.done")>]
    abstract done': bool

    abstract faulty: bool

    abstract task:JS.Promise<SchedulerScheduleSequenceReturnTaskPromise>

/// Instance able to reschedule the ordering of promises
/// for a given app
type Scheduler<'T,'TArgs> =
    /// Wrap a new task using the Scheduler
    abstract schedule: (JS.Promise<'T> -> string -> JS.Promise<'T>)

    /// Automatically wrap function output using the Scheduler
    abstract scheduleFunction: (('TArgs -> JS.Promise<'T>) -> ('TArgs -> JS.Promise<'T>))

    /// Schedule a sequence of promises to be executed sequencially.
    /// Items within the sequence might be interleaved by other scheduled operations.
    /// 
    /// Please note that whenever an item from the sequence has started,
    /// the scheduler will wait until its end before moving to another scheduled task.
    /// 
    /// A handle is returned by the function in order to monitor the state of the sequence.
    /// Sequence will be marked:
    /// - done if all the promises have been executed properly
    /// - faulty if one of theJS.Promises within the sequence throws
    abstract scheduleSequence: sequenceBuilders: ResizeArray<SchedulerSequenceItem> -> SchedulerScheduleSequenceReturn
    
    /// Count of pending scheduled tasks
    abstract count: unit -> float

    /// Wait one scheduled task to be executed
    abstract waitOne: (unit -> JS.Promise<unit>)

    /// Wait all scheduled tasks,
    /// including the ones that might be created by one of the resolved task
    abstract waitAll: (unit -> JS.Promise<unit>)