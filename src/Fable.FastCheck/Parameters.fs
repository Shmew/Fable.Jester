namespace Fable.FastCheck

type parameters =
    /// Initial seed of the generator: `Date.now()` by default
    /// 
    /// It can be forced to replay a failed run.
    /// 
    /// In theory, seeds are supposed to be 32 bits integers.
    /// In case of double value, the seed will be rescaled into a valid 32 bits integer (eg.: values between 0 and 1 will be evenly spread into the range of possible seeds).
    static member seed (value: float) = Interop.mkParametersOptionAttr "seed" value
    
    /// Number of runs before success: 100 by default
    static member numRuns (value: float) = Interop.mkParametersOptionAttr "numRuns" value
    
    /// Maximal number of skipped values per run
    /// 
    /// Skipped is considered globally, so this value is used to compute maxSkips = maxSkipsPerRun * numRuns.
    /// Runner will consider a run to have failed if it skipped maxSkips+1 times before having generated numRuns valid entries.
    /// 
    /// See pre for more details on pre-conditions
    static member maxSkipsPerRun (value: float) = Interop.mkParametersOptionAttr "maxSkipsPerRun" value
    
    /// Maximum time in milliseconds for the predicate to answer: disabled by default
    /// 
    /// WARNING: Only works for async code (see asyncProperty), will not interrupt a synchronous code.
    static member timeout (value: float) = Interop.mkParametersOptionAttr "timeout" value
    
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
    static member skipAllAfterTimeLimit (value: float) = Interop.mkParametersOptionAttr "skipAllAfterTimeLimit" value
    
    /// Interrupt test execution after a given time limit: disabled by default
    /// 
    /// NOTE: Relies on `Date.now()`.
    /// 
    /// NOTE:
    /// Useful to avoid having too long running processes in your CI.
    /// Replay capability (see seed, path) can still be used if needed.
    /// 
    /// WARNING:
    /// If the test got interrupted before any failure occured
    /// and before it reached the requested number of runs specified by numRuns
    /// it will be marked as success. Except if markInterruptAsFailure as been set to `true`
    static member interruptAfterTimeLimit (value: float) = Interop.mkParametersOptionAttr "interruptAfterTimeLimit" value
    
    /// Mark interrupted runs as failed runs: disabled by default
    static member markInterruptAsFailure (value: bool) = Interop.mkParametersOptionAttr "markInterruptAsFailure" value
    
    /// Way to replay a failing property directly with the counterexample.
    /// It can be fed with the counterexamplePath returned by the failing test (requires `seed` too).
    static member path (value: string) = Interop.mkParametersOptionAttr "path" value
    
    /// Logger (see statistics): `console.log` by default
    static member logger (value: string -> unit) = Interop.mkParametersOptionAttr "logger" value
    
    /// Force the use of unbiased arbitraries: biased by default
    static member unbiased (value: bool) = Interop.mkParametersOptionAttr "unbiased" value
        
    /// Custom values added at the beginning of generated ones
    /// 
    /// It enables users to come with examples they want to test at every run
    static member examples (value: ResizeArray<'T>) = Interop.mkParametersOptionAttr "examples" value
    
    /// Stop run on failure
    /// 
    /// It makes the run stop at the first encountered failure without shrinking.
    /// 
    /// When used in complement to `seed` and `path`,
    /// it replays only the minimal counterexample.
    static member endOnFailure (value: bool) = Interop.mkParametersOptionAttr "endOnFailure" value

module parameters =
    /// Random number generator: `xorshift128plus` by default
    /// 
    /// Random generator is the core element behind the generation of random values - changing it might directly impact the quality and performances of the generation of random values.
    /// It can be one of: 'mersenne', 'congruential', 'congruential32', 'xorshift128plus', 'xoroshiro128plus'
    type randomType =
        static member congruential = Interop.mkParametersOptionAttr "randomType" "congruential"
        static member congruential32 = Interop.mkParametersOptionAttr "randomType" "congruential32"
        static member mersenne = Interop.mkParametersOptionAttr "randomType" "mersenne"
        static member xorshift128plus = Interop.mkParametersOptionAttr "randomType" "xorshift128plus"
        static member xoroshiro128plus = Interop.mkParametersOptionAttr "randomType" "xoroshiro128plus"

    /// Set verbosity level
    type verbose =
        static member none = Interop.mkParametersOptionAttr "verbose" 0
        static member verbose = Interop.mkParametersOptionAttr "verbose" 1
        static member veryVerbose = Interop.mkParametersOptionAttr "verbose" 2
        