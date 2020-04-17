namespace Fable.FastCheck

open Fable.Core
open System.ComponentModel

type ICommand<'Model,'Real> =
    /// Check if the model is in the right state to apply the command.
    abstract check: m: 'Model -> bool

    /// Receive the non-updated model and the real or system under test.
    ///
    /// Perform the checks post-execution - Throw in case of invalid state.
    ///
    /// Update the model accordingly.
    abstract run: m: 'Model * r: 'Real -> unit

    /// Name of the command.
    abstract toString: unit -> string

type IAsyncCommand<'Model,'Real> =
    /// Check if the model is in the right state to apply the command.
    abstract check: m: 'Model -> Async<bool>

    /// Receive the non-updated model and the real or system under test.
    ///
    /// Perform the checks post-execution - Throw in case of invalid state.
    ///
    /// Update the model accordingly.
    abstract run: m: 'Model * r: 'Real -> Async<unit>

    /// Name of the command.
    abstract toString: unit -> string

type IPromiseCommand<'Model,'Real> =
    /// Check if the model is in the right state to apply the command.
    abstract check: m: 'Model -> JS.Promise<bool>

    /// Receive the non-updated model and the real or system under test.
    ///
    /// Perform the checks post-execution - Throw in case of invalid state.
    ///
    /// Update the model accordingly.
    abstract run: m: 'Model * r: 'Real -> JS.Promise<unit>

    /// Name of the command.
    abstract toString: unit -> string

[<EditorBrowsable(EditorBrowsableState.Never)>]
type PromiseCommandConverter<'Model,'Real> (cmd: IPromiseCommand<'Model,'Real>) =
    interface IAsyncCommand<'Model,'Real> with
        member _.check (m: 'Model) = cmd.check m |> Async.AwaitPromise
        member _.run (m: 'Model, r: 'Real) =
            cmd.run(m,r) |> Async.AwaitPromise
        member _.toString () = cmd.toString() 

[<EditorBrowsable(EditorBrowsableState.Never)>]
type AsyncCommand<'Model,'Real> (cmd: IAsyncCommand<'Model,'Real>) =
    interface IPromiseCommand<'Model,'Real> with
        member _.check (m: 'Model) = cmd.check m |> Async.StartAsPromise
        member _.run (m: 'Model, r: 'Real) =
            cmd.run(m,r) |> Async.StartAsPromise
        member _.toString () = cmd.toString() 

    member _.asyncCmd = cmd

type ICommandWrapper<'Model,'Real> =
    inherit ICommand<'Model,'Real>

    /// The command to run.
    abstract cmd: ICommand<'Model,'Real>

    /// Indicates if the command has been executed.
    abstract hasRan: bool with get, set

    /// Create a clone of this command.
    abstract clone: unit -> ICommandWrapper<'Model,'Real>

type IAsyncCommandWrapper<'Model,'Real> =
    inherit IAsyncCommand<'Model,'Real>

    /// The command to run.
    abstract cmd: IAsyncCommand<'Model,'Real>

    /// Indicates if the command has been executed.
    abstract hasRan: bool with get, set

    /// Create a clone of this command.
    abstract clone: unit -> IAsyncCommandWrapper<'Model,'Real>

type IPromiseCommandWrapper<'Model,'Real> =
    inherit IPromiseCommand<'Model,'Real>

    /// The command to run.
    abstract cmd: IPromiseCommand<'Model,'Real>

    /// Indicates if the command has been executed.
    abstract hasRan: bool with get, set

    /// Create a clone of this command.
    abstract clone: unit -> IPromiseCommandWrapper<'Model,'Real>

[<EditorBrowsable(EditorBrowsableState.Never)>]
type AsyncCommandWrapper<'Model,'Real> (cmdWrapper: IAsyncCommandWrapper<'Model,'Real>) =
    let mutable hasRan = cmdWrapper.hasRan

    interface IPromiseCommandWrapper<'Model,'Real> with
        member _.cmd = AsyncCommand(cmdWrapper.cmd) :> IPromiseCommand<'Model,'Real>
        member _.hasRan
            with get() = hasRan
            and set(c) = hasRan <- c
        member _.clone () = AsyncCommandWrapper(cmdWrapper.clone()) :> IPromiseCommandWrapper<'Model,'Real>

        member _.check (m: 'Model) = cmdWrapper.check m |> Async.StartAsPromise
        member _.run (m: 'Model, r: 'Real) =
            cmdWrapper.run(m,r) |> Async.StartAsPromise
        member _.toString () = cmdWrapper.toString() 

    member _.asyncCmdWrapper = cmdWrapper

type ICommandSeq<'Model,'Real> =
    inherit seq<ICommandWrapper<'Model,'Real>>

    /// Collection of commandwrappers.
    abstract commands: ResizeArray<ICommandWrapper<'Model,'Real>>

    /// The meta-data given for a replay.
    abstract metadataForReplay: (unit -> string)

    /// Clone the command seq.
    //[<Emit("[cloneMethod]()")>]
    abstract clone: unit -> ICommandSeq<'Model,'Real>

    /// The string representation of the command seq.
    abstract toString: unit -> string

type IAsyncCommandSeq<'Model,'Real> =
    inherit seq<IAsyncCommandWrapper<'Model,'Real>>

    /// Collection of commandwrappers.
    abstract commands: ResizeArray<IAsyncCommandWrapper<'Model,'Real>>

    /// The meta-data given for a replay.
    abstract metadataForReplay: (unit -> string)

    /// Clone the command seq.
    //[<Emit("[cloneMethod]()")>]
    abstract clone: unit -> IAsyncCommandSeq<'Model,'Real>

    /// The string representation of the command seq.
    abstract toString: unit -> string

type IPromiseCommandSeq<'Model,'Real> =
    inherit seq<IPromiseCommandWrapper<'Model,'Real>>

    /// Collection of commandwrappers.
    abstract commands: ResizeArray<IPromiseCommandWrapper<'Model,'Real>>

    /// The meta-data given for a replay.
    abstract metadataForReplay: (unit -> string)

    /// Clone the command seq.
    //[<Emit("[cloneMethod]()")>]
    abstract clone: unit -> IPromiseCommandSeq<'Model,'Real>

    /// The string representation of the command seq.
    abstract toString: unit -> string

[<EditorBrowsable(EditorBrowsableState.Never)>]
type AsyncCommandSeq<'Model,'Real> (cmdSeq: IAsyncCommandSeq<'Model,'Real>) =
    interface System.Collections.IEnumerable with
        member _.GetEnumerator () =
            cmdSeq
            |> Seq.map (fun cmd -> 
                AsyncCommandWrapper<'Model,'Real>(cmd) 
                    :> IPromiseCommandWrapper<'Model,'Real>)
            |> fun res -> res.GetEnumerator() :> System.Collections.IEnumerator

    interface System.Collections.Generic.IEnumerable<IPromiseCommandWrapper<'Model,'Real>> with
        member _.GetEnumerator () =
            cmdSeq
            |> Seq.map (fun cmd -> 
                AsyncCommandWrapper<'Model,'Real>(cmd) 
                    :> IPromiseCommandWrapper<'Model,'Real>)
            |> fun res -> res.GetEnumerator()
        
    interface IPromiseCommandSeq<'Model,'Real> with
        member _.commands = 
            cmdSeq.commands 
            |> Seq.map (fun cmdWrapper -> 
                AsyncCommandWrapper<'Model,'Real>(cmdWrapper) 
                    :> IPromiseCommandWrapper<'Model,'Real>) 
            |> ResizeArray
        member _.metadataForReplay = cmdSeq.metadataForReplay
        member _.clone () = 
            AsyncCommandSeq(cmdSeq.clone()) 
                :> IPromiseCommandSeq<'Model,'Real>
        member _.toString () = cmdSeq.toString()

    member _.asyncCmdSeq = cmdSeq