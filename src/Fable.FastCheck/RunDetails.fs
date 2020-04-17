namespace Fable.FastCheck

[<RequireQualifiedAccess>]
type ExecutionStatus =
    | Success = 0
    | Skipped = -1
    | Failure = 1

/// Summary of the execution process.
type IExecutionTree<'T> =
    /// Status of the property.
    abstract status: ExecutionStatus

    /// Generated value.
    abstract value: 'T

    /// Values derived from this value.
    abstract children: ResizeArray<IExecutionTree<'T>>

type ExecutionTree<'T> (tree: IExecutionTree<'T>) =
    /// Status of the property
    member _.status = tree.status

    /// Generated value.
    member _.value = tree.value

    /// Values derived from this value.
    member _.children = tree.children |> List.ofSeq

[<RequireQualifiedAccess>]
type VerbosityLevel =
    | None = 0
    | Verbose = 1
    | VeryVerbose = 2

/// Post-run details produced by check.
/// 
/// A failing property can easily detected by checking the `failed` flag of this structure.
type IRunDetails<'T> =
    /// If the test failed.
    abstract failed: bool

    /// If the execution was interrupted.
    abstract interrupted: bool

    /// Number of runs.
    /// 
    /// - In case of failed property: Number of runs up to the first failure (including the failure run).
    ///
    /// - Otherwise: Number of successful executions.
    abstract numRuns: float

    /// Number of skipped entries due to failed pre-condition.
    /// 
    /// As `numRuns` it only takes into account the skipped values that occured before the first failure.
    abstract numSkips: float

    /// Number of shrinks required to get to the minimal failing case (aka counterexample).
    abstract numShrinks: float

    /// Seed that have been used by the run.
    /// 
    /// It can be forced in assert', check, sample and statistics using parameters.
    abstract seed: float

    /// In case of failure: the counterexample contains the minimal failing case (first failure after shrinking).
    abstract counterexample: 'T option

    /// In case of failure: it contains the reason of the failure.
    abstract error: string option

    /// In case of failure: path to the counterexample.
    /// 
    /// For replay purposes, it can be forced in assert', check, sample and statistics using parameters.
    abstract counterexamplePath: string option

    /// List all failures that have occurred during the run.
    /// 
    /// You must enable verbose with at least Verbosity.Verbose in Parameters
    /// in order to have values present.
    abstract failures: ResizeArray<'T>

    /// Execution summary of the run.
    /// 
    /// Traces the origin of each value encountered during the test and its execution status.
    ///
    /// Can help to diagnose shrinking issues.
    /// 
    /// You must enable verbose with at least Verbosity.Verbose in Parameters
    /// in order to have values in it:
    ///
    /// - Verbose: Only failures.
    ///
    /// - VeryVerbose: Failures, Successes and Skipped.
    abstract executionSummary: ResizeArray<IExecutionTree<'T>>

    /// Verbosity level required by the user.
    abstract verbose: VerbosityLevel

/// Post-run details produced by check.
/// 
/// A failing property can easily detected by checking the `failed` flag of this structure.
type RunDetails<'T> (runDetails: IRunDetails<'T>) =
    /// If the test failed.
    member _.failed = runDetails.failed

    /// If the execution was interrupted.
    member _.interrupted = runDetails.interrupted

    /// Number of runs.
    /// 
    /// - In case of failed property: Number of runs up to the first failure (including the failure run).
    ///
    /// - Otherwise: Number of successful executions.
    member _.numRuns = runDetails.numRuns

    /// Number of skipped entries due to failed pre-condition.
    /// 
    /// As `numRuns` it only takes into account the skipped values that occured before the first failure.
    member _.numSkips = runDetails.numSkips

    /// Number of shrinks required to get to the minimal failing case (aka counterexample).
    member _.numShrinks = runDetails.numShrinks

    /// Seed that have been used by the run.
    /// 
    /// It can be forced in assert', check, sample and statistics using parameters.
    member _.seed = runDetails.seed

    /// In case of failure: the counterexample contains the minimal failing case (first failure after shrinking).
    member _.counterexample = runDetails.counterexample

    /// In case of failure: it contains the reason of the failure.
    member _.error = runDetails.error

    /// In case of failure: path to the counterexample.
    /// 
    /// For replay purposes, it can be forced in assert', check, sample and statistics using parameters.
    member _.counterexamplePath = runDetails.counterexamplePath

    /// List all failures that have occurred during the run.
    /// 
    /// You must enable verbose with at least Verbosity.Verbose in Parameters
    /// in order to have values present.
    member _.failures = runDetails.failures |> List.ofSeq

    /// Execution summary of the run.
    /// 
    /// Traces the origin of each value encountered during the test and its execution status.
    ///
    /// Can help to diagnose shrinking issues.
    /// 
    /// You must enable verbose with at least Verbosity.Verbose in Parameters
    /// in order to have values in it:
    ///
    /// - Verbose: Only failures.
    ///
    /// - VeryVerbose: Failures, Successes and Skipped.
    member _.executionSummary = runDetails.executionSummary |> List.ofSeq

    /// Verbosity level required by the user.
    member _.verbose = runDetails.verbose
