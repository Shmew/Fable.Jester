namespace Fable.FastCheck

open Fable.Core

type ICommand<'Model,'Real> =
    /// Check if the model is in the right state to apply the command
    /// 
    /// WARNING: does not change the model
    /// Model, simplified or schematic representation of real system
    abstract check: m: 'Model -> bool

    /// Receive the non-updated model and the real or system under test.
    /// Perform the checks post-execution - Throw in case of invalid state.
    /// Update the model accordingly
    /// Model, simplified or schematic representation of real system
    /// Sytem under test
    abstract run: m: 'Model * r: 'Real -> unit

    /// Name of the command
    abstract toString: unit -> string

type IAsyncCommand<'Model,'Real> =
    /// Check if the model is in the right state to apply the command
    /// 
    /// WARNING: does not change the model
    /// Model, simplified or schematic representation of real system
    abstract check: m: 'Model -> JS.Promise<bool>

    /// Receive the non-updated model and the real or system under test.
    /// Perform the checks post-execution - Throw in case of invalid state.
    /// Update the model accordingly
    /// Model, simplified or schematic representation of real system
    /// Sytem under test
    abstract run: m: 'Model * r: 'Real -> JS.Promise<unit>

    /// Name of the command
    abstract toString: unit -> string

type ICommandWrapper<'Model,'Real> =
    inherit ICommand<'Model,'Real>

    abstract cmd: ICommand<'Model,'Real>

    abstract hasRan: bool with get, set

    abstract clone: unit -> ICommandWrapper<'Model,'Real>

type IAsyncCommandWrapper<'Model,'Real> =
    inherit IAsyncCommand<'Model,'Real>

    abstract cmd: IAsyncCommand<'Model,'Real>

    abstract hasRan: bool with get, set

    abstract clone: unit -> IAsyncCommandWrapper<'Model,'Real>

type ICommandSeq<'Model,'Real> =
    inherit seq<ICommandWrapper<'Model,'Real>>

    abstract commands: ResizeArray<ICommandWrapper<'Model,'Real>>

    abstract metadataForReplay: (unit -> string)

    [<Emit("$0.[cloneMethod]$1")>]
    abstract clone: unit -> ICommandSeq<'Model,'Real>

    abstract toString: unit -> string

type IAsyncCommandSeq<'Model,'Real> =
    inherit seq<IAsyncCommandWrapper<'Model,'Real>>

    abstract commands: ResizeArray<IAsyncCommandWrapper<'Model,'Real>>

    abstract metadataForReplay: (unit -> string)

    [<Emit("$0.[cloneMethod]$1")>]
    abstract clone: unit -> IAsyncCommandSeq<'Model,'Real>

    abstract toString: unit -> string
