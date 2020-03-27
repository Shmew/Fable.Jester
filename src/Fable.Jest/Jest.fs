namespace Fable.Jest

open Fable.Core

[<Global>]
type jest =
    member _.disableAutomock () : jest = jsNative
        
    member _.enableAutomock () : jest = jsNative

    member _.genMockFromModule (moduleName: string) : obj = jsNative // how does .default work here?

    member _.mock (moduleName: string, ?factory, ?options) : jest = jsNative // figure out how to handle factory object creation, private member with toPlainJSOB?

    member _.unmock (moduleName: string) : jest = jsNative

    member _.doMock (moduleName: string, ?factory, ?options) : jest = jsNative

    member _.dontMock (moduleName: string) : jest = jsNative

    member _.requireActual (moduleName: string) : obj = jsNative

    member _.requireMock (moduleName: string) : obj = jsNative

    member _.resetModules () : jest = jsNative

    member _.isolateModules f : obj = jsNative

    member _.fn (?args) : obj = jsNative

    member _.isMockFunction f : bool = jsNative

    member _.spyOn (object: 'T, methodName: string) : obj = jsNative

    [<Emit("$0.spyOn($1..., 'get')")>]
    member _.spyOnGet (object: 'T, methodName: string) : obj = jsNative
        
    [<Emit("$0.spyOn($1..., 'set')")>]
    member _.spyOnSet (object: 'T, methodName: string) : obj = jsNative

    member _.clearAllMocks () : jest = jsNative

    member _.resetAllMocks () : jest = jsNative

    member _.restoreAllMocks () : unit = jsNative

    member _.useFakeTimers () : jest = jsNative

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

module JestHelpers =
    let asyncToPromise (value: Async<'T>) = Async.StartAsPromise(value)

type Jest =
    [<Global>]
    static member afterAll (fn: unit -> unit, ?timeout: int) : unit = jsNative

    [<Global>]
    static member afterEach (fn: unit -> unit, ?timeout: int) : unit = jsNative
    
    [<Global>]
    static member beforeAll (fn: unit -> unit, ?timeout: int) : unit = jsNative
    
    [<Global>]
    static member describe (name: string, fn: unit -> unit) : unit = jsNative
    
    [<Emit("describe.each($0)($1...)")>]
    static member describeEach (table: U2<ResizeArray<'T>,ResizeArray<ResizeArray<'T>>>, name:string, fn: unit -> unit, ?timeout: int) : unit = jsNative
    
    [<Emit("describe.only($0...)")>]
    static member describeOnly (name: string, fn: unit -> unit) : unit = jsNative
        
    [<Emit("describe.only.each($0)($1...)")>]
    static member describeOnlyEach (table: U2<ResizeArray<'T>,ResizeArray<ResizeArray<'T>>>, name:string, fn: unit -> unit) : unit = jsNative

    [<Emit("describe.skip($0...)")>]
    static member describeSkip (name: string, fn: unit -> unit) : unit = jsNative

    [<Emit("describe.skip.each($0)($1...)")>]
    static member describeSkipEach (table: U2<ResizeArray<'T>,ResizeArray<ResizeArray<'T>>>, name:string, fn: unit -> unit) : unit = jsNative

    [<Global>]
    static member expect (value: JS.Promise<'T>) : expectedPromise = jsNative

    static member inline expect (value: Async<'T>) : expectedPromise =
        Jest.expect(JestHelpers.asyncToPromise value)

    [<Global>]
    static member test (name: string, fn: unit -> unit, ?timeout: int) : unit = jsNative

    [<Global>]
    static member test (name: string, fn: unit -> JS.Promise<unit>, ?timeout: int) : unit = jsNative

    [<Emit("test.each($0)($1...)")>]
    static member testEach (table: U2<ResizeArray<'T>,ResizeArray<ResizeArray<'T>>>, name:string, fn: unit -> unit, ?timeout: int) : unit = jsNative

    [<Emit("test.each($0)($1...)")>]
    static member testEach (table: U2<ResizeArray<'T>,ResizeArray<ResizeArray<'T>>>, name:string, fn: unit -> JS.Promise<unit>, ?timeout: int) : unit = jsNative

    [<Emit("test.only($0...)")>]
    static member testOnly (name: string, fn: unit -> unit, ?timeout: int) : unit = jsNative

    [<Emit("test.only($0...)")>]
    static member testOnly (name: string, fn: unit -> JS.Promise<unit>, ?timeout: int) : unit = jsNative

    [<Emit("test.only.each($0)($1...)")>]
    static member testOnlyEach (table: U2<ResizeArray<'T>,ResizeArray<ResizeArray<'T>>>, name:string, fn: unit -> unit) : unit = jsNative
        
    [<Emit("test.only.each($0)($1...)")>]
    static member testOnlyEach (table: U2<ResizeArray<'T>,ResizeArray<ResizeArray<'T>>>, name:string, fn: unit -> JS.Promise<unit>) : unit = jsNative

    [<Emit("test.skip($0...)")>]
    static member testSkip (name: string, fn: unit -> unit) : unit = jsNative
        
    [<Emit("test.skip($0...)")>]
    static member testSkip (name: string, fn: unit -> JS.Promise<unit>) : unit = jsNative

    [<Emit("test.skip.each($0)($1...)")>]
    static member testSkipEach (table: U2<ResizeArray<'T>,ResizeArray<ResizeArray<'T>>>, name:string, fn: unit -> unit) : unit = jsNative

    [<Emit("test.skip.each($0)($1...)")>]
    static member testSkipEach (table: U2<ResizeArray<'T>,ResizeArray<ResizeArray<'T>>>, name:string, fn: unit -> JS.Promise<unit>) : unit = jsNative

    [<Emit("test.todo($0)")>]
    static member testTodo (name: string) : unit = jsNative

[<AutoOpen>]
module JestMagic =
    type Jest with
        [<Global>]
        static member expect (value: 'T) : expected<unit> = jsNative
