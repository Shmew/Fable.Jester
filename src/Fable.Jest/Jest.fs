namespace Fable.Jest

open Fable.Core
open FSharp.Core
open System.ComponentModel

[<EditorBrowsable(EditorBrowsableState.Never)>]
[<RequireQualifiedAccess>]
module JestInternal =
    [<Global("expect")>]
    let expectPromise (value: JS.Promise<'T>) : expectedPromise = jsNative

[<Global>]
type jest =
    /// Instructs Jest to use fake versions of the standard timer 
    /// functions (setTimeout, setInterval, clearTimeout, 
    /// clearInterval, nextTick, setImmediate and clearImmediate).
    member _.useFakeTimers () : unit = jsNative
    
    /// Exhausts the micro-task queue (usually interfaced in node 
    /// via process.nextTick).
    member _.runAllTicks () :  unit = jsNative

    /// Exhausts both the macro-task queue (i.e., all tasks queued by 
    /// setTimeout(), setInterval(), and setImmediate()) and the 
    /// micro-task queue (usually interfaced in node via process.nextTick).
    member _.runAllTimers () : unit = jsNative

    /// Exhausts all tasks queued by setImmediate().
    member _.runAllImmediates () : unit = jsNative

    /// Executes only the macro task queue (i.e. all tasks queued by 
    /// setTimeout() or setInterval() and setImmediate()).
    member _.advanceTimersByTime (msToRun: int) : unit = jsNative
    /// Executes only the macro task queue (i.e. all tasks queued by 
    /// setTimeout() or setInterval() and setImmediate()).
    member _.runTimersToTime (msToRun: int) : unit = jsNative
        
    /// Executes only the macro-tasks that are currently pending (i.e., 
    /// only the tasks that have been queued by setTimeout() or 
    /// setInterval() up to this point). 
    ///
    /// If any of the currently pending macro-tasks schedule new 
    /// macro-tasks, those new tasks will not be executed by this call.
    member _.runOnlyPendingTimers () : unit = jsNative

    /// Advances all timers by the needed milliseconds so that only 
    /// the next timeouts/intervals will run.
    ///
    /// Optionally, you can provide steps, so it will run steps 
    /// amount of next timeouts/intervals.
    member _.advanceTimersToNextTimer (?steps: int) : unit = jsNative

    /// Removes any pending timers from the timer system.
    member _.clearAllTimers () : unit = jsNative

    /// Returns the number of fake timers still left to run.
    member _.getTimerCount () : unit = jsNative

    /// Set the default timeout interval for tests and before/after 
    /// hooks in milliseconds.
    ///
    /// The default timeout interval is 5 seconds if this method is not called.
    ///
    /// If you want to set the timeout for all test files, a good place to 
    /// do this is in setupFilesAfterEnv.
    member _.setTimeout (timeout: int) : unit = jsNative

    /// Runs failed tests n-times until they pass or until the max number 
    /// of retries is exhausted. 
    ///
    /// ** This only works with jest-circus. **
    member _.retryTimes (count: int) : unit = jsNative

type Jest =
    /// Runs a function after all the tests in this file have completed. 
    /// If the function returns a promise or is a generator, Jest waits 
    /// for that promise to resolve before continuing.
    ///
    /// Optionally, you can provide a timeout (in milliseconds) for 
    /// specifying how long to wait before aborting. 
    ///
    /// The default timeout is 5 seconds.
    [<Global>]
    static member afterAll (fn: unit -> unit, ?timeout: int) : unit = jsNative

    /// Runs a function after each one of the tests in this file completes. 
    /// If the function returns a promise or is a generator, Jest waits 
    /// for that promise to resolve before continuing.
    ///
    /// Optionally, you can provide a timeout (in milliseconds) for 
    /// specifying how long to wait before aborting. 
    ///
    /// The default timeout is 5 seconds.
    [<Global>]
    static member afterEach (fn: unit -> unit, ?timeout: int) : unit = jsNative
    
    /// Runs a function before any of the tests in this file run. 
    /// If the function returns a promise or is a generator, 
    /// Jest waits for that promise to resolve before running tests.
    ///
    /// Optionally, you can provide a timeout (in milliseconds) for 
    /// specifying how long to wait before aborting. 
    ///
    /// The default timeout is 5 seconds.
    [<Global>]
    static member beforeAll (fn: unit -> unit, ?timeout: int) : unit = jsNative

    /// Runs a function before each of the tests in this file runs. 
    /// If the function returns a promise or is a generator, 
    /// Jest waits for that promise to resolve before running the test.
    /// 
    /// Optionally, you can provide a timeout (in milliseconds) for 
    /// specifying how long to wait before aborting. 
    ///
    /// The default timeout is 5 seconds.
    [<Global>]
    static member beforeEach (fn: unit -> unit, ?timeout: int) : unit = jsNative

    /// Creates a block that groups together several related tests.
    [<Global>]
    static member describe (name: string, fn: unit -> unit) : unit = jsNative

    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Emit("expect(Array.from($0))")>]
    static member expect (value: 'a []) : expected<unit> = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Emit("expect(Array.from($0))")>]
    static member expect (value: 'a list) : expected<unit> = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Emit("expect($0.then(prom => Promise.resolve(Array.from(prom))))")>]
    static member inline expect (value: JS.Promise<'a []>) : expectedPromise = jsNative
        //promise { 
        //    let! v = value
        //    return ResizeArray v
        //}
        //|> fun prom -> JestInternal.expectPromise(prom)
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Emit("expect($0.then(prom => Promise.resolve(Array.from(prom))))")>]
    static member inline expect (value: JS.Promise<'a list>) : expectedPromise = jsNative
        //promise { 
        //    let! v = value
        //    return ResizeArray v
        //}
        //|> fun prom -> JestInternal.expectPromise(prom)
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: Async<'a []>) = 
        Jest.expect(Async.StartAsPromise(value)).resolves
        //|> fun prom -> JestInternal.expectPromise(prom).resolves
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: Async<'a list>) = 
        Jest.expect(Async.StartAsPromise(value)).resolves
    
[<RequireQualifiedAccess>]
module Jest = 
    /// Creates a block that groups together several related tests.
    type describe =
        /// Runs only one describe block.
        [<Emit("describe.only($0...)")>]
        static member inline only (name:string, fn: unit -> unit) : unit = jsNative
    
        /// Skips this describe block.
        [<Emit("describe.skip($0...)")>]
        static member inline skip (name:string, fn: unit -> unit) : unit = jsNative
            
    type test =
        /// Runs only this test within the scope it's defined in.
        ///
        /// The default timeout is 5 seconds.
        [<Emit("test.only($0...)")>]
        static member only (name:string, fn: unit -> unit, ?timeout: int) : unit = jsNative
        /// Runs only this test within the scope it's defined in.
        ///
        /// The default timeout is 5 seconds.
        [<Emit("test.only($0...)")>]
        static member only (name:string, fn: unit -> JS.Promise<unit>, ?timeout: int) : unit = jsNative

        /// Skips a test.
        ///
        /// The default timeout is 5 seconds.
        [<Emit("test.skip($0...)")>]
        static member skip (name:string, fn: unit -> unit) : unit = jsNative
        /// Skips a test.
        ///
        /// The default timeout is 5 seconds.
        [<Emit("test.skip($0...)")>]
        static member skip (name:string, fn: unit -> JS.Promise<unit>) : unit = jsNative

        /// Creates a todo category in your test results to keep 
        /// track of what needs to be implemented still.
        [<Emit("test.todo($0)")>]
        static member todo (name: string) : unit = jsNative

[<AutoOpen>]
module JestExtensions =
    type Jest with
        /// The expect function is used every time you want to test a value.
        ///
        /// The argument to expect should be the value that your code produces, 
        /// and any argument to the matcher should be the correct value. If you 
        /// mix them up, your tests will still work, but the error messages on 
        /// failing tests will look strange.
        static member inline expect (value: JS.Promise< 'T>) = JestInternal.expectPromise(value)
        /// The expect function is used every time you want to test a value.
        ///
        /// The argument to expect should be the value that your code produces, 
        /// and any argument to the matcher should be the correct value. If you 
        /// mix them up, your tests will still work, but the error messages on 
        /// failing tests will look strange.
        static member inline expect(value: Async< 'a>) =
            JestInternal.expectPromise(Async.StartAsPromise(value)).resolves
        /// The expect function is used every time you want to test a value.
        ///
        /// The argument to expect should be the value that your code produces, 
        /// and any argument to the matcher should be the correct value. If you 
        /// mix them up, your tests will still work, but the error messages on 
        /// failing tests will look strange.
        [<Global>]
        static member expect (value: obj) : expected<unit> = jsNative

        /// Runs a test.
        ///
        /// The default timeout is 5 seconds.
        [<Global>]
        static member inline test (name: string, fn: unit -> unit, ?timeout: int) : unit = jsNative
        /// Runs a test.
        ///
        /// The default timeout is 5 seconds.
        [<Global>]
        static member inline test (name: string, fn: unit -> JS.Promise<unit>, ?timeout: int) : unit = jsNative
