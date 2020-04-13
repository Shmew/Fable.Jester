namespace Fable.FastCheck

type Command<'Model,'Real,'RunResult,'CheckResult> =
    /// Check if the model is in the right state to apply the command
    /// 
    /// WARNING: does not change the model
    /// Model, simplified or schematic representation of real system
    abstract check: m: 'Model -> 'CheckResult

    /// Receive the non-updated model and the real or system under test.
    /// Perform the checks post-execution - Throw in case of invalid state.
    /// Update the model accordingly
    /// Model, simplified or schematic representation of real system
    /// Sytem under test
    abstract run: m: 'Model * r: 'Real -> 'RunResult

    /// Name of the command
    abstract toString: unit -> string

type CommandWrapper<'Model,'Real,'RunResult,'CheckResult> =
    inherit Command<'Model,'Real,'RunResult,'CheckResult>
    abstract cmd: Command<'Model,'Real,'RunResult,'CheckResult>
    abstract hasRan: bool with get, set
    abstract check: m: obj -> obj
    abstract run: m: 'Model * r: 'Real -> 'RunResult
    abstract clone: unit -> CommandWrapper<'Model,'Real,'RunResult,'CheckResult>
    abstract toString: unit -> string

type CommandsIterable<'Model,'Real,'RunResult,'CheckResult> =
    inherit Iterable<CommandWrapper<'Model,'Real,'RunResult,'CheckResult>>

    abstract commands: ResizeArray<CommandWrapper<'Model,'Real,'RunResult,'CheckResult>>
    abstract metadataForReplay: (unit -> string)
    abstract ``[Symbol.iterator]``: unit -> Iterator<CommandWrapper<'Model,'Real,'RunResult,'CheckResult>>
    abstract ``[cloneMethod]``: unit -> CommandsIterable<'Model,'Real,'RunResult,'CheckResult>
    abstract toString: unit -> string

type Setup<'Model,'Real> =
    abstract model: 'Model
    abstract real: 'Real
