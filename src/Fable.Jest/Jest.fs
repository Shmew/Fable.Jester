namespace Fable.Jest

open Fable.Core

[<Global>]
type jest =
    member _.useFakeTimers () : unit = jsNative
    
    member _.runAllTicks () :  unit = jsNative

    member _.runAllTimers () : unit = jsNative

    member _.runAllImmediates () : unit = jsNative

    member _.advanceTimersByTime (msToRun: int) : unit = jsNative
    member _.runTimersToTime (msToRun: int) : unit = jsNative
        
    member _.runOnlyPendingTimers () : unit = jsNative

    member _.advanceTimersToNextTimer (steps: int) : unit = jsNative

    member _.clearAllTimers () : unit = jsNative

    member _.getTimerCount () : unit = jsNative

    member _.setTimeout (timeout: int) : unit = jsNative

    member _.retryTimes (count: int) : unit = jsNative

type Jest =
    [<Global>]
    static member afterAll (fn: unit -> unit, ?timeout: int) : unit = jsNative

    [<Global>]
    static member afterEach (fn: unit -> unit, ?timeout: int) : unit = jsNative
    
    [<Global>]
    static member beforeAll (fn: unit -> unit, ?timeout: int) : unit = jsNative
    
    [<Global>]
    static member describe (name: string, fn: unit -> unit) : unit = jsNative
        
    [<Emit("describe.only($0...)")>]
    static member internal describeOnly (name: string, fn: unit -> unit) : unit = jsNative

    [<Emit("describe.skip($0...)")>]
    static member internal describeSkip (name: string, fn: unit -> unit) : unit = jsNative

    [<Global>]
    static member expect (value: JS.Promise<'T>) : expectedPromise = jsNative
    static member inline expect (value: Async<'T>) = Jest.expect(Async.StartAsPromise value).resolves

    [<Emit("test.only($0...)")>]
    static member internal testOnly (name: string, fn: unit -> unit, ?timeout: int) : unit = jsNative
    [<Emit("test.only($0...)")>]
    static member internal testOnly (name: string, fn: unit -> JS.Promise<unit>, ?timeout: int) : unit = jsNative

    [<Emit("test.skip($0...)")>]
    static member internal testSkip (name: string, fn: unit -> unit) : unit = jsNative
    [<Emit("test.skip($0...)")>]
    static member internal testSkip (name: string, fn: unit -> JS.Promise<unit>) : unit = jsNative

    [<Emit("test.todo($0)")>]
    static member internal testTodo (name: string) : unit = jsNative

[<RequireQualifiedAccess>]
module Jest = 
    type describe =
        static member inline only (name:string, fn: unit -> unit) : unit =
            Jest.describeOnly(name, fn)
    
        static member inline skip (name:string, fn: unit -> unit) : unit =
            Jest.describeSkip(name, fn)
            
    type test =
        static member inline todo (name: string) = Jest.testTodo name

        static member inline only (name:string, fn: unit -> unit, ?timeout: int) : unit =
            Jest.testOnly(name, fn, ?timeout = timeout)
        static member inline only (name:string, fn: unit -> JS.Promise<unit>, ?timeout: int) : unit =
            Jest.testOnly(name, fn, ?timeout = timeout)

        static member inline skip (name:string, fn: unit -> unit) : unit =
            Jest.testSkip(name, fn)
        static member inline skip (name:string, fn: unit -> JS.Promise<unit>) : unit =
            Jest.testSkip(name, fn)

[<AutoOpen>]
module JestMagic =
    type Jest with
        [<Global>]
        static member expect (value: 'T) : expected<unit> = jsNative

        [<Global>]
        static member test (name: string, fn: unit -> unit, ?timeout: int) : unit = jsNative
        [<Global>]
        static member test (name: string, fn: unit -> JS.Promise<unit>, ?timeout: int) : unit = jsNative
