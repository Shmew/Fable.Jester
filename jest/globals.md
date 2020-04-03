# Globals in Jest

Jest exposes global functions to use when writing your 
tests. Instead of needing to keeps the docs open, all
of the functions are exposed from the `Jest` type.

Jest also has a `jest` object with additional helpers,
this has been merged into `Jest` so everything is readily
accessible.

## advanceTimersByTime

Executes only the macro task queue (i.e. all tasks 
queued by setTimeout() or setInterval() and setImmediate()).

Signature:
```fsharp
(msToRun:int) -> unit
```

Usage:
```fsharp
Jest.advanceTimersByTime(10)
```

## advanceTimersToNextTimer

Advances all timers by the needed milliseconds so that only 
the next timeouts/intervals will run.

Optionally, you can provide steps, so it will run steps 
amount of next timeouts/intervals.

Signature:
```fsharp
(?steps: int) -> unit
```

Usage:
```fsharp
Jest.advanceTimersToNextTimer()
Jest.advanceTimersToNextTimer(2)
```

## afterAll

Runs a function after all the tests in this file have completed. 
If the function returns a promise or is a generator, Jest waits 
for that promise to resolve before continuing.

Optionally, you can provide a timeout (in milliseconds) for 
specifying how long to wait before aborting. 

The default timeout is 5 seconds.

Signature:
```fsharp
(fn: unit -> unit, ?timeout: int) -> unit
```

Usage:
```fsharp
Jest.afterAll((fun () -> printfn "Hello world!"))
```

## afterEach

Runs a function after each one of the tests in this file completes. 
If the function returns a promise or is a generator, Jest waits 
for that promise to resolve before continuing.

Optionally, you can provide a timeout (in milliseconds) for 
specifying how long to wait before aborting. 

The default timeout is 5 seconds.

Signature:
```fsharp
(fn: unit -> unit, ?timeout: int) -> unit
```

Usage:
```fsharp
Jest.afterEach((fun () -> printfn "Hello world!"))
```

## beforeAll

Runs a function before any of the tests in this file run. 
If the function returns a promise or is a generator, 
Jest waits for that promise to resolve before running tests.

Optionally, you can provide a timeout (in milliseconds) for 
specifying how long to wait before aborting. 

The default timeout is 5 seconds.

Signature:
```fsharp
(fn: unit -> unit, ?timeout: int) -> unit
```

Usage:
```fsharp
Jest.beforeAll((fun () -> printfn "Hello world!"))
```

## beforeEach

Runs a function before each of the tests in this file runs. 
If the function returns a promise or is a generator, 
Jest waits for that promise to resolve before running the test.

Optionally, you can provide a timeout (in milliseconds) for 
specifying how long to wait before aborting. 

The default timeout is 5 seconds.

Signature:
```fsharp
(fn: unit -> unit, ?timeout: int) -> unit
```

Usage:
```fsharp
Jest.beforeEach((fun () -> printfn "Hello world!"))
```

## clearAllTimers

Removes any pending timers from the timer system.

Signature:
```fsharp
unit -> unit
```

Usage:
```fsharp
Jest.clearAllTimers()
```

## getTimerCount

Returns the number of fake timers still left to run.

Signature:
```fsharp
unit -> int
```

Usage:
```fsharp
Jest.getTimerCount()
```

## retryTimes

Runs failed tests n-times until they pass or until the max number 
of retries is exhausted. 

<Note type="warning">Requires [jest-circus].</Note>

Signature:
```fsharp
int -> unit
```

Usage:
```fsharp
Jest.retryTimes(10)
```

## runAllImmediates

Exhausts all tasks queued by setImmediate().

Signature:
```fsharp
unit -> unit
```

Usage:
```fsharp
Jest.runAllImmediates()
```

## runAllTicks

Exhausts the micro-task queue (usually interfaced in node 
via process.nextTick).

Signature:
```fsharp
unit -> unit
```

Usage:
```fsharp
Jest.runAllTicks()
```

## runAllTimers

Exhausts both the macro-task queue (i.e., all tasks queued by 
setTimeout(), setInterval(), and setImmediate()) and the 
micro-task queue (usually interfaced in node via process.nextTick).

Signature:
```fsharp
unit -> unit
```

Usage:
```fsharp
Jest.runAllTimers()
```

## runOnlyPendingTimers

Executes only the macro-tasks that are currently pending (i.e., 
only the tasks that have been queued by setTimeout() or 
setInterval() up to this point). 

If any of the currently pending macro-tasks schedule new 
macro-tasks, those new tasks will not be executed by this call.

Signature:
```fsharp
unit -> unit
```

Usage:
```fsharp
Jest.runOnlyPendingTimers()
```

## runTimersToTime

Executes only the macro task queue (i.e. all tasks queued by 
setTimeout() or setInterval() and setImmediate()).

Signature:
```fsharp
int -> unit
```

Usage:
```fsharp
Jest.runTimersToTime(10)
```

## setTimeout

Set the default timeout interval for tests and before/after 
hooks in milliseconds.

The default timeout interval is 5 seconds if this method is not called.

If you want to set the timeout for all test files, a good place to 
do this is in setupFilesAfterEnv.

Signature:
```fsharp
(msToRun:int) -> unit
```

Usage:
```fsharp
Jest.setTimeout(10)
```

## useFakeTimers

Instructs Jest to use fake versions of the standard timer 
functions (setTimeout, setInterval, clearTimeout, 
clearInterval, nextTick, setImmediate and clearImmediate).

Signature:
```fsharp
unit -> unit
```

Usage:
```fsharp
Jest.useFakeTimers()
```

## Where are the other globals?

Some functions were chosen not to be included in this
library. 

The reason for this being two-fold: 

* The missing functions are things like module and function mocking.
Well desgined F# code *shouldn't need mocks*. It's my opinion
that if you need a mock for a test, your test is *already failing*.
If you find that you *really* need this functionality, create an [issue]
and we can review/discuss it.
* It's additional work to maintain. ;)

[jest-circus]: https://www.npmjs.com/package/jest-circus
[issue]: https://github.com/Shmew/Fable.Jester/issues/new/choose
