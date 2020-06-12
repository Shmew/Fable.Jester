namespace Fable.FastCheck

open Fable.Core
open System.ComponentModel

type Random =
    /// Clone the random number generator/
    abstract clone: unit -> Random

    /// Generate an integer having `bits` random bits.
    abstract next: bits: int -> int

    /// Generate a random boolean.
    abstract nextBoolean: unit -> bool

    /// Generate a random integer (32 bits).
    abstract nextInt: unit -> int

    /// Generate a random integer between min (included) and max (included).
    abstract nextInt: min: int * max: int -> int

    /// Generate a random any between min (included) and max (included).
    abstract nextBigInt: min: bigint * max: bigint -> bigint

    /// Generate a random floating point number between 0.0 (included) and 1.0 (excluded).
    abstract nextDouble: unit -> float
    
[<AutoOpen;EditorBrowsable(EditorBrowsableState.Never);Erase>]
module Types =
    type ICommandConstraintProperty = interface end
    type IDateConstraintProperty = interface end
    type IObjConstraintProperty = interface end
    type IFastCheckOptionsProperty = interface end
    type IRecordConstraintProperty = interface end
    type IUuidVersionConstraintProperty = interface end
    type IWebAuthorityConstraintProperty = interface end
    type IWebUrlConstraintProperty = interface end

[<StringEnum;RequireQualifiedAccess>]
type SchedulerReportStatus =
    /// Task still pending in the scheduler, not released yet.
    | Pending
    /// Task released by the scheduler but with errors.
    | Rejected
    /// Task released by the scheduler and successful.
    | Resolved

[<StringEnum;RequireQualifiedAccess>]
type SchedulingType =
    /// schedule
    | Promise
    /// scheduleFunction
    | Function
    /// scheduleSequence
    | Sequence

/// Describes a task for the report produced by the scheduler.
type SchedulerReportItem<'Metadata> =
    /// Execution status for this task.
    abstract status: SchedulerReportStatus
    /// How the task was scheduled.
    abstract schedulingType: SchedulingType
    /// Incremental id for the task, first received task has taskId = 1.
    abstract taskId: int
    /// Label of the task.
    abstract label: string
    /// Metadata provided when scheduling the task.
    abstract metadata: 'Metadata option
    /// Stringified output or error.
    abstract outputValue: string option

[<RequireQualifiedAccess>]
type ExecutionStatus =
    | Success = 0
    | Skipped = -1
    | Failure = 1

[<RequireQualifiedAccess>]
type VerbosityLevel =
    | None = 0
    | Verbose = 1
    | VeryVerbose = 2

[<StringEnum;RequireQualifiedAccess>]
type RandomType =
    | Congruential
    | Congruential32
    | Mersenne
    | Xorshift128plus
    | Xorshiro128plus
    