namespace Fable.Jester

open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open FSharp.Core
open System.ComponentModel

[<EditorBrowsable(EditorBrowsableState.Never)>]
[<RequireQualifiedAccess>]
module JestInternal =
    [<Global("expect")>]
    let expectHtml (value: obj) : expectedHtml<unit> = jsNative

    [<Global("expect")>]
    let expectHtmlPromise (value: obj) : expectedHtmlPromise = jsNative

    [<Global("expect")>]
    let expectPromise (value: JS.Promise<'T>) : expectedPromise = jsNative

type Jest =
    /// Advances all timers by the needed milliseconds so that only 
    /// the next timeouts/intervals will run.
    ///
    /// Optionally, you can provide steps, so it will run steps 
    /// amount of next timeouts/intervals.
    [<Emit("jest.advanceTimersToNextTimer($0...)")>]
    static member advanceTimersToNextTimer (?steps: int) : unit = jsNative

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

    /// Removes any pending timers from the timer system.
    [<Emit("jest.clearAllTimers()")>]
    static member clearAllTimers () : unit = jsNative

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
    [<Emit("expect(Array.from($0))")>]
    static member expect (value: 'a seq) : expected<unit> = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Emit("expect($0.then(prom => Promise.resolve(Array.from(prom))))")>]
    static member inline expect (value: JS.Promise<'a []>) : expectedPromise = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Emit("expect($0.then(prom => Promise.resolve(Array.from(prom))))")>]
    static member expect (value: JS.Promise<'a list>) : expectedPromise = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Emit("expect($0.then(prom => Promise.resolve(Array.from(prom))))")>]
    static member expect (value: JS.Promise<'a seq>) : expectedPromise = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member expect (value: Async<'a []>) = 
        importSideEffects "@testing-library/jest-dom"
        Jest.expect(Async.StartAsPromise(value)).resolves
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member expect (value: Async<'a list>) = 
        importSideEffects "@testing-library/jest-dom"
        Jest.expect(Async.StartAsPromise(value)).resolves
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member expect (value: Async<'a seq>) = 
        importSideEffects "@testing-library/jest-dom"
        Jest.expect(Async.StartAsPromise(value)).resolves
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: HTMLElement) : expectedHtml<unit> = 
        importSideEffects "@testing-library/jest-dom"
        JestInternal.expectHtml(value)
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: HTMLElement option) : expectedHtml<unit> = 
        importSideEffects "@testing-library/jest-dom"
        JestInternal.expectHtml(value)
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: JS.Promise<HTMLElement>) : expectedHtmlPromise =
        importSideEffects "@testing-library/jest-dom"
        JestInternal.expectHtmlPromise(value)
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: Async<HTMLElement>) = 
        importSideEffects "@testing-library/jest-dom"
        Jest.expect(Async.StartAsPromise value).resolves
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: Node) : expectedHtml<unit> =
        importSideEffects "@testing-library/jest-dom"
        JestInternal.expectHtml(value)
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: Node option) : expectedHtml<unit> =
        importSideEffects "@testing-library/jest-dom"
        JestInternal.expectHtml(value)
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: JS.Promise<Node>) : expectedHtmlPromise =
        importSideEffects "@testing-library/jest-dom"
        JestInternal.expectHtmlPromise(value)
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: Async<Node>) = 
        importSideEffects "@testing-library/jest-dom"
        Jest.expect(Async.StartAsPromise value).resolves
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: decimal) : expectedNumber<unit> = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: decimal option) : expectedNumber<unit> = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: JS.Promise<decimal>) : expectedNumberPromise = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: Async<decimal>) = 
        Jest.expect(Async.StartAsPromise value).resolves
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: float) : expectedNumber<unit> = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: float option) : expectedNumber<unit> = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: JS.Promise<float>) : expectedNumberPromise = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: Async<float>) = 
        Jest.expect(Async.StartAsPromise value).resolves
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: int) : expectedNumber<unit> = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: int option) : expectedNumber<unit> = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: JS.Promise<int>) : expectedNumberPromise = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: Async<int>) = 
        Jest.expect(Async.StartAsPromise value).resolves
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: string) : expectedString<unit> = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: string option) : expectedString<unit> = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    [<Global>]
    static member expect (value: JS.Promise<string>) : expectedStringPromise = jsNative
    /// The expect function is used every time you want to test a value.
    ///
    /// The argument to expect should be the value that your code produces, 
    /// and any argument to the matcher should be the correct value. If you 
    /// mix them up, your tests will still work, but the error messages on 
    /// failing tests will look strange.
    static member inline expect (value: Async<string>) = 
        Jest.expect(Async.StartAsPromise value).resolves

    /// When mocking time, `Date.now()` will also be mocked. If you for some 
    /// reason need access to the real current time, you can invoke this function.
    [<Emit("jest.getRealSystemTime()")>]
    static member getRealSystemTime () : int64 = jsNative

    /// Returns the number of fake timers still left to run.
    [<Emit("jest.getTimerCount()")>]
    static member getTimerCount () : int = jsNative

    /// Runs failed tests n-times until they pass or until the max number 
    /// of retries is exhausted. 
    ///
    /// ** This only works with jest-circus. **
    [<Emit("jest.retryTimes($0)")>]
    static member retryTimes (count: int) : unit = jsNative

    /// Exhausts all tasks queued by setImmediate().
    [<Emit("jest.runAllImmediates()")>]
    static member runAllImmediates () : unit = jsNative
    
    /// Exhausts the micro-task queue (usually interfaced in node 
    /// via process.nextTick).
    [<Emit("jest.runAllTicks()")>]
    static member runAllTicks () :  unit = jsNative
    
    /// Exhausts both the macro-task queue (i.e., all tasks queued by 
    /// setTimeout(), setInterval(), and setImmediate()) and the 
    /// micro-task queue (usually interfaced in node via process.nextTick).
    [<Emit("jest.runAllTimers()")>]
    static member runAllTimers () : unit = jsNative
    
    /// Executes only the macro-tasks that are currently pending (i.e., 
    /// only the tasks that have been queued by setTimeout() or 
    /// setInterval() up to this point). 
    ///
    /// If any of the currently pending macro-tasks schedule new 
    /// macro-tasks, those new tasks will not be executed by this call.
    [<Emit("jest.runOnlyPendingTimers($0)")>]
    static member runOnlyPendingTimers () : unit = jsNative
    
    /// Executes only the macro task queue (i.e. all tasks queued by 
    /// setTimeout() or setInterval() and setImmediate()).
    [<Emit("jest.runTimersToTime($0)")>]
    static member runTimersToTime (msToRun: int) : unit = jsNative

    /// Set the current system time used by fake timers. Simulates a user 
    /// changing the system clock while your program is running. 
    ///
    /// It affects the current time but it does not in itself cause e.g. 
    /// timers to fire; they will fire exactly as they would have done 
    /// without the call to `setSystemTime`.
    ///
    /// Same as setSystemTime(0)
    [<Emit("jest.setSystemTime()")>]
    static member setSystemTime () : unit = jsNative
    /// Set the current system time used by fake timers. Simulates a user 
    /// changing the system clock while your program is running. 
    ///
    /// It affects the current time but it does not in itself cause e.g. 
    /// timers to fire; they will fire exactly as they would have done 
    /// without the call to `setSystemTime`.
    [<Emit("jest.setSystemTime($0)")>]
    static member setSystemTime (ticks: int) : unit = jsNative
    /// Set the current system time used by fake timers. Simulates a user 
    /// changing the system clock while your program is running. 
    ///
    /// It affects the current time but it does not in itself cause e.g. 
    /// timers to fire; they will fire exactly as they would have done 
    /// without the call to `setSystemTime`.
    [<Emit("jest.setSystemTime($0)")>]
    static member setSystemTime (ticks: int64) : unit = jsNative

    /// Set the default timeout interval for tests and before/after 
    /// hooks in milliseconds.
    ///
    /// The default timeout interval is 5 seconds if this method is not called.
    ///
    /// If you want to set the timeout for all test files, a good place to 
    /// do this is in setupFilesAfterEnv.
    [<Emit("jest.setTimeout($0)")>]
    static member setTimeout (timeout: int) : unit = jsNative
    
    /// Instructs Jest to use fake versions of the standard timer 
    /// functions (setTimeout, setInterval, clearTimeout, 
    /// clearInterval, nextTick, setImmediate and clearImmediate).
    [<Emit("jest.useFakeTimers('modern')")>]
    static member useFakeTimers () : unit = jsNative

[<RequireQualifiedAccess>]
module Jest = 
    /// Creates a block that groups together several related tests.
    type describe =
        /// Runs only one describe block.
        [<Emit("describe.only($0...)")>]
        static member only (name:string, fn: unit -> unit) : unit = jsNative
    
        /// Skips this describe block.
        [<Emit("describe.skip($0...)")>]
        static member skip (name:string, fn: unit -> unit) : unit = jsNative
            
    type test =
        /// Runs only this test within the scope it's defined in.
        ///
        /// The default timeout is 5 seconds.
        [<Emit("test.only($0...)")>]
        static member only (name:string, fn: unit -> unit, ?timeout: int) : unit = jsNative
        /// Runs only this test within the scope it's defined in.
        ///
        /// The default timeout is 5 seconds.
        [<Emit("test.only($0, async () => { await $1 }, $2)")>]
        static member only (name: string, prom: JS.Promise<unit>, ?timeout: int) : unit = jsNative
        /// Runs only this test within the scope it's defined in.
        ///
        /// The default timeout is 5 seconds.
        static member inline only (name: string, asnc: Async<unit>, ?timeout: int) : unit =
            test.only(name, Async.StartAsPromise asnc, ?timeout = timeout)

        /// Skips a test.
        ///
        /// The default timeout is 5 seconds.
        [<Emit("test.skip($0...)")>]
        static member skip (name:string, fn: unit -> unit, ?timeout: int) : unit = jsNative
        /// Skips a test.
        ///
        /// The default timeout is 5 seconds.
        [<Emit("test.skip($0, async () => { await $1 }, $2)")>]
        static member skip (name: string, prom: JS.Promise<unit>, ?timeout: int) : unit = jsNative
        /// Skips a test.
        ///
        /// The default timeout is 5 seconds.
        static member inline skip (name: string, asnc: Async<unit>, ?timeout: int) : unit =
            test.skip(name, Async.StartAsPromise asnc, ?timeout = timeout)

        /// Creates a todo category in your test results to keep 
        /// track of what needs to be implemented still.
        [<Emit("test.todo($0)")>]
        static member todo (name: string) : unit = jsNative

[<AutoOpen>]
module JestExtensions =
    type AsyncBuilder with
        member this.Bind (computation: JS.Promise<unit>, f: unit -> Async<unit>) = 
            this.Bind((Async.AwaitPromise computation), f)
        member this.ReturnFrom (computation: JS.Promise<unit>) = 
            this.ReturnFrom(computation |> Async.AwaitPromise)

    type Jest with
        /// The expect function is used every time you want to test a value.
        ///
        /// The argument to expect should be the value that your code produces, 
        /// and any argument to the matcher should be the correct value. If you 
        /// mix them up, your tests will still work, but the error messages on 
        /// failing tests will look strange.
        static member expect (value: JS.Promise<'T>) = JestInternal.expectPromise(value)
        /// The expect function is used every time you want to test a value.
        ///
        /// The argument to expect should be the value that your code produces, 
        /// and any argument to the matcher should be the correct value. If you 
        /// mix them up, your tests will still work, but the error messages on 
        /// failing tests will look strange.
        static member expect(value: Async<'T>) =
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
        static member test (name: string, fn: unit -> unit, ?timeout: int) : unit = jsNative
        /// Runs a test.
        ///
        /// The default timeout is 5 seconds.
        [<Emit("test($0, async () => { await $1 }, $2)")>]
        static member test (name: string, prom: JS.Promise<unit>, ?timeout: int) : unit = jsNative
        /// Runs a test.
        ///
        /// The default timeout is 5 seconds.
        static member inline test (name: string, asnc: Async<unit>, ?timeout: int) : unit =
            Jest.test(name, Async.StartAsPromise asnc, ?timeout = timeout)
