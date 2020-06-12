namespace Fable.FastCheck

type ExecutionTree<'T> internal (tree: Bindings.IExecutionTree<'T>) =
    /// Status of the property
    member _.status = tree.status

    /// Generated value.
    member _.value = tree.value

    /// Values derived from this value.
    member _.children = tree.children |> List.ofSeq

module RunDetails =
    type Parameters<'T> internal (parameters: Bindings.Parameters<'T>) =
        /// Stop run on failure
        /// 
        /// It makes the run stop at the first encountered failure without shrinking.
        /// 
        /// When used in complement to `seed` and `path`,
        /// it replays only the minimal counterexample.
        member _.endOnFailure = parameters.endOnFailure
    
        /// Custom values added at the beginning of generated ones
        /// 
        /// It enables users to come with examples they want to test at every run
        member _.examples = parameters.examples |> List.ofSeq
        
        /// Interrupt test execution after a given time limit: disabled by default
        /// 
        /// NOTE: Relies on `Date.now()`.
        /// 
        /// NOTE:
        /// Useful to avoid having too long running processes in your CI.
        ///
        /// Replay capability (see seed, path) can still be used if needed.
        /// 
        /// WARNING:
        /// If the test got interrupted before any failure occured
        /// and before it reached the requested number of runs specified by numRuns
        /// it will be marked as success. Except if markInterruptAsFailure as been set to `true`
        member _.interruptAfterTimeLimit = parameters.interruptAfterTimeLimit
    
        /// Logger (see statistics): `console.log` by default
        member _.logger = parameters.logger
    
        /// Mark interrupted runs as failed runs: disabled by default
        member _.markInterruptAsFailure = parameters.markInterruptAsFailure
    
        /// Maximal number of skipped values per run
        /// 
        /// Skipped is considered globally, so this value is used to compute maxSkips = maxSkipsPerRun * numRuns.
        ///
        /// Runner will consider a run to have failed if it skipped maxSkips+1 times before having generated numRuns valid entries.
        /// 
        /// See pre for more details on pre-conditions
        member _.maxSkipsPerRun = parameters.maxSkipsPerRun
    
        /// Number of runs before success: 100 by default
        member _.numRuns = parameters.numRuns
    
        /// Way to replay a failing property directly with the counterexample.
        ///
        /// It can be fed with the counterexamplePath returned by the failing test (requires `seed` too).
        member _.path = parameters.path
    
        /// Initial seed of the generator: `Date.now()` by default
        /// 
        /// It can be forced to replay a failed run.
        /// 
        /// In theory, seeds are supposed to be 32 bits integers.
        ///
        /// In case of double value, the seed will be rescaled into a 
        /// valid 32 bits integer (eg.: values between 0 and 1 will be evenly spread into the range of possible seeds).
        member _.seed = parameters.seed
    
        /// Skip all runs after a given time limit: disabled by default
        /// 
        /// NOTE: Relies on `Date.now()`.
        /// 
        /// NOTE:
        /// Useful to stop too long shrinking processes.
        /// Replay capability (see seed, path) can resume the shrinking.
        /// 
        /// WARNING:
        /// It skips runs. Thus test might be marked as failed.
        /// Indeed, it might not reached the requested number of successful runs.
        member _.skipAllAfterTimeLimit = parameters.skipAllAfterTimeLimit
    
        /// Maximum time in milliseconds for the predicate to answer: disabled by default
        /// 
        /// WARNING: Only works for async code (see asyncProperty), will not interrupt a synchronous code.
        member _.timeout = parameters.timeout
    
        /// Force the use of unbiased arbitraries: biased by default.
        member _.unbiased = parameters.unbiased
 
        /// Verbosity level.
        member _.verbose = parameters.verbose

        /// Algorithm used for randomization.
        member _.randomType = parameters.randomType

/// Post-run details produced by check.
/// 
/// A failing property can easily detected by checking the `failed` flag of this structure.
type RunDetails<'T> internal (runDetails: Bindings.IRunDetails<'T>) =
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

    /// Configuration used for this test.
    member _.runConfiguration = runDetails.runConfiguration

    member internal _.runDetails = runDetails

module FastCheckOptionsExtensions =
    open Fable.Core

    type FastCheckOptions with
        /// Custom reporter replacing the default reporter. 
        ///
        /// It is responsible to throw in case of failure.
        ///
        /// Cannot be used in conjunction with the async/promise reporter options.
        ///
        /// it will be used by assert for both synchronous and asynchronous properties.
        static member reporter (handler: RunDetails<'T> -> unit) = Interop.mkParametersOptionAttr "reporter" handler
        
        /// Custom reporter replacing the default reporter. 
        ///
        /// It is responsible to throw in case of failure.
        ///
        /// it will be used by assert for asynchronous properties only.
        static member promiseReporter (handler: RunDetails<'T> -> JS.Promise<'T>) = Interop.mkParametersOptionAttr "promiseReporter" handler
        
        /// Custom reporter replacing the default reporter. 
        ///
        /// It is responsible to throw in case of failure.
        ///
        /// it will be used by assert for asynchronous properties only.
        static member asyncReporter (handler: RunDetails<'T> -> Async<'T>) = Interop.mkParametersOptionAttr "promiseReporter" (handler >> Async.StartAsPromise)
