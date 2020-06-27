namespace Fable.FastCheck

open Fable.Core
open Fable.Core.JsInterop
open System

[<RequireQualifiedAccess>]
module Bindings =
    type Parameters<'T> =
        abstract endOnFailure: bool
        abstract examples: ResizeArray<'T> 
        abstract interruptAfterTimeLimit: int
        abstract logger: (string -> unit)
        abstract markInterruptAsFailure: bool
        abstract maxSkipsPerRun: int
        abstract numRuns: int
        abstract path: string
        abstract seed: float
        abstract skipAllAfterTimeLimit: int
        abstract timeout: int
        abstract unbiased: bool
        abstract verbose: VerbosityLevel
        abstract randomType: RandomType

    type SchedulerAct =
        abstract act: ((unit -> JS.Promise<unit>) -> JS.Promise<unit>)

    module SchedulerAct =
        let inline create (act: ((unit -> JS.Promise<unit>) -> JS.Promise<unit>)) = 
            createObj [ "act" ==> act ]
            |> fun res -> res :?> SchedulerAct

    type SchedulerReturnTask =
        [<Emit("$0.done")>]
        abstract isDone: bool
    
        [<Emit("$0.done")>]
        abstract isFaulty: bool
    
    type PromiseSchedulerReturn =
        [<Emit("$0.done")>]
        abstract isDone: bool
    
        [<Emit("$0.done")>]
        abstract isFaulty: bool
    
        abstract task: JS.Promise<SchedulerReturnTask>
    
    type ScheduleSequenceItem<'Metadata> =
        abstract builder: unit -> JS.Promise<obj>
        abstract label: string
        abstract metadata: 'Metadata option

    module ScheduleSequenceItem =
        let inline create (builder: unit -> JS.Promise<obj>, label: string, metadata: 'Metadata option) =
            createObj [ 
                "builder" ==> builder
                "label" ==> label
                if metadata.IsSome then "metadata" ==> metadata.Value
            ]
            |> fun res -> res :?> ScheduleSequenceItem<'Metadata>

    type Scheduler<'T,'TArgs,'Metadata> =
        abstract schedule: JS.Promise<'T> * ?label: string * ?metadata: 'Metadata -> JS.Promise<'T>
        abstract scheduleFunction: ('TArgs -> JS.Promise<'T>) -> ('TArgs -> JS.Promise<'T>)
        abstract scheduleSequence: sequenceBuilders: ResizeArray<ScheduleSequenceItem<'Metadata>> -> PromiseSchedulerReturn
        abstract count: unit -> int
        abstract waitOne: unit -> JS.Promise<unit>
        abstract waitAll: unit -> JS.Promise<unit>
        abstract report: unit -> ResizeArray<SchedulerReportItem<'Metadata>>

    type Setup<'Model,'Real> =
        abstract model: 'Model
        abstract real: 'Real
    
    module Setup =
        let inline create (model: 'Model) (real: 'Real) =
            createObj [ 
                "model" ==> model
                "real" ==> real
            ]
            |> fun res -> res :?> Setup<'Model,'Real>

    type IExecutionTree<'T> =
        abstract status: ExecutionStatus
        abstract value: 'T
        abstract children: ResizeArray<IExecutionTree<'T>>

    type IRunDetails<'T> =
        abstract failed: bool
        abstract interrupted: bool
        abstract numRuns: int
        abstract numSkips: int
        abstract numShrinks: int
        abstract seed: float
        abstract counterexample: 'T option
        abstract error: string option
        abstract counterexamplePath: string option
        abstract failures: ResizeArray<'T>
        abstract executionSummary: ResizeArray<IExecutionTree<'T>>
        abstract verbose: VerbosityLevel
        abstract runConfiguration: Parameters<'T>

    type FC =
        abstract __type: string
        abstract __version: string

        abstract anything: unit -> Arbitrary<'T>
        [<Emit("$0.anything(Object.fromEntries(Array.from($1)))")>]
        abstract anything: constraints: IObjConstraintProperty list -> Arbitrary<'T>
        
        abstract array: arb: Arbitrary<'T> -> Arbitrary<ResizeArray<'T>>
        abstract array: arb: Arbitrary<'T> * maxLength: int -> Arbitrary<ResizeArray<'T>>
        abstract array: arb: Arbitrary<'T> * minLength: int * maxLength: int -> Arbitrary<ResizeArray<'T>>
        
        abstract ascii: unit -> Arbitrary<char>
        
        abstract asciiString: unit -> Arbitrary<string>
        abstract asciiString: maxLength: int -> Arbitrary<string>
        abstract asciiString: minLength: int * maxLength: int -> Arbitrary<string>
        
        [<Emit("$0.assert($1...)")>]
        abstract assert': prop: AsyncProperty<'T> * ?parameters: obj -> JS.Promise<unit>
        [<Emit("$0.assert($1...)")>]
        abstract assert': prop: Property<'T> * ?parameters: obj -> unit
        
        abstract asyncModelRun: (unit -> Setup<'InitialModel, 'Real>) * seq<IPromiseCommand<'Model,'Real>> -> JS.Promise<unit>
        abstract asyncModelRun: (unit -> Setup<'InitialModel, 'Real>) * IPromiseCommandSeq<'Model,'Real> -> JS.Promise<unit>

        abstract asyncProperty: arb0: Arbitrary<'T0> * predicate: ('T0 ->JS.Promise<bool>) -> AsyncProperty<'T0>
        abstract asyncProperty: arb0: Arbitrary<'T0> * predicate: ('T0 ->JS.Promise<unit>) -> AsyncProperty<'T0>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * predicate: ('T0 -> 'T1 ->JS.Promise<bool>) -> AsyncProperty<'T0 * 'T1>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * predicate: ('T0 -> 'T1 ->JS.Promise<unit>) -> AsyncProperty<'T0 * 'T1>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * predicate: ('T0 -> 'T1 -> 'T2 ->JS.Promise<bool>) -> AsyncProperty<'T0 * 'T1 * 'T2>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * predicate: ('T0 -> 'T1 -> 'T2 ->JS.Promise<unit>) -> AsyncProperty<'T0 * 'T1 * 'T2>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 ->JS.Promise<bool>) -> AsyncProperty<'T0 * 'T1 * 'T2 * 'T3>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 ->JS.Promise<unit>) -> AsyncProperty<'T0 * 'T1 * 'T2 * 'T3>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 ->JS.Promise<bool>) -> AsyncProperty<'T0 * 'T1 * 'T2 * 'T3 * 'T4>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 ->JS.Promise<unit>) -> AsyncProperty<'T0 * 'T1 * 'T2 * 'T3 * 'T4>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * arb5: Arbitrary<'T5> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 ->JS.Promise<bool>) -> AsyncProperty<'T0 * 'T1 * 'T2 * 'T3 * 'T4 * 'T5>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * arb5: Arbitrary<'T5> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 ->JS.Promise<unit>) -> AsyncProperty<'T0 * 'T1 * 'T2 * 'T3 * 'T4 * 'T5>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * arb5: Arbitrary<'T5> * arb6: Arbitrary<'T6> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 ->JS.Promise<bool>) -> AsyncProperty<'T0 * 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6>
        abstract asyncProperty: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * arb5: Arbitrary<'T5> * arb6: Arbitrary<'T6> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 ->JS.Promise<unit>) -> AsyncProperty<'T0 * 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6>
                
        abstract base64: unit -> Arbitrary<char>

        abstract base64String: unit -> Arbitrary<string>
        abstract base64String: maxLength: int -> Arbitrary<string>
        abstract base64String: minLength: int * maxLength: int -> Arbitrary<string>

        abstract bigInt: unit -> Arbitrary<bigint>
        abstract bigInt: min: bigint * max: bigint -> Arbitrary<bigint>
        
        abstract bigIntN: int -> Arbitrary<bigint>

        abstract bigUint: unit -> Arbitrary<bigint>
        abstract bigUint: max: bigint -> Arbitrary<bigint>

        abstract bigUintN: int -> Arbitrary<bigint>

        abstract boolean: unit -> Arbitrary<bool>

        abstract char: unit -> Arbitrary<char>
        
        abstract char16bits: unit -> Arbitrary<char>

        abstract check: prop: AsyncProperty<'T> * ?parameters: obj -> JS.Promise<IRunDetails<'T>>
        abstract check: prop: Property<'T> * ?parameters: obj -> IRunDetails<'T>
        
        abstract clonedConstant: value: 'T -> Arbitrary<'T>
        
        abstract commands: commandArbs: ResizeArray<Arbitrary<IPromiseCommand<'Model,'Real>>> * ?maxCommands: int -> Arbitrary<seq<IPromiseCommand<'Model,'Real>>>
        abstract commands: commandArbs: ResizeArray<Arbitrary<ICommand<'Model,'Real>>> * ?maxCommands: int -> Arbitrary<seq<ICommand<'Model,'Real>>>
        abstract commands: commandArbs: ResizeArray<Arbitrary<IPromiseCommand<'Model,'Real>>> * ?settings: obj -> Arbitrary<seq<IPromiseCommand<'Model,'Real>>>
        abstract commands: commandArbs: ResizeArray<Arbitrary<ICommand<'Model,'Real>>> * ?settings: obj -> Arbitrary<seq<ICommand<'Model,'Real>>>

        abstract compareBooleanFunc: unit -> Arbitrary<('T -> 'T -> bool)>

        abstract compareFunc: unit -> Arbitrary<('T -> 'T -> int)>
        
        abstract constant: value: 'T -> Arbitrary<'T>

        abstract constantFrom: [<ParamArray>] values: ResizeArray<'T> -> Arbitrary<'T>
        
        abstract date: unit -> Arbitrary<DateTime>
        [<Emit("$0.date(Object.fromEntries(Array.from($1)))")>]
        abstract date: constraints: IDateConstraintProperty list -> Arbitrary<DateTime>

        abstract dedup: arb: Arbitrary<'T> * numValues: 'N -> Arbitrary<'T>

        abstract defaultReportMessage : out: IRunDetails<'T> -> string option

        abstract dictionary: keyArb: Arbitrary<string> * valueArb: Arbitrary<'T> -> Arbitrary<System.Collections.Generic.IDictionary<string,'T>>
        
        abstract domain: unit -> Arbitrary<string>
        abstract double: unit -> Arbitrary<float>
        abstract double: max: float -> Arbitrary<float>
        abstract double: min: float * max: float -> Arbitrary<float>

        abstract emailAddress: unit -> Arbitrary<string>
        
        abstract float: unit -> Arbitrary<float>
        abstract float: max: float -> Arbitrary<float>
        abstract float: min: float * max: float -> Arbitrary<float>

        abstract frequency: warbs: ResizeArray<obj> -> Arbitrary<'T>

        abstract fullUnicode: unit -> Arbitrary<string>
        
        abstract fullUnicodeString: unit -> Arbitrary<string>
        abstract fullUnicodeString: maxLength: int -> Arbitrary<string>
        abstract fullUnicodeString: minLength: int * maxLength: int -> Arbitrary<string>
        
        abstract func: arb: Arbitrary<'TOut> -> Arbitrary<('TArgs -> 'TOut)>
        
        abstract genericTuple: arbs: ResizeArray<Arbitrary<'T>> -> Arbitrary<ResizeArray<'T>>
        
        abstract hexa: unit -> Arbitrary<char>
        
        abstract hexaString: unit -> Arbitrary<string>
        abstract hexaString: maxLength: int -> Arbitrary<string>
        abstract hexaString: minLength: int * maxLength: int -> Arbitrary<string>

        abstract infiniteStream: arb: Arbitrary<'T> -> Arbitrary<seq<'T>>
        
        abstract integer: unit -> ArbitraryWithShrink<int>
        abstract integer: max: int -> ArbitraryWithShrink<int>
        abstract integer: min: int * max: int -> ArbitraryWithShrink<int>

        abstract ipV4: unit -> Arbitrary<string>
        
        abstract ipV4Extended: unit -> Arbitrary<string>

        abstract ipV6: unit -> Arbitrary<string>

        abstract json: unit -> Arbitrary<string>
        abstract json: maxDepth: int -> Arbitrary<string>

        abstract jsonObject: unit -> Arbitrary<'T>
        abstract jsonObject: maxDepth: int -> Arbitrary<'T>
        
        abstract letrec: builder: ((string -> Arbitrary<'T>) -> 'T) -> Arbitrary<'T>
        
        abstract lorem: unit -> Arbitrary<string>
        
        abstract lorem: maxWordsCount: int -> Arbitrary<string>
        abstract lorem: maxWordsCount: int * sentencesMode: bool -> Arbitrary<string>
        
        abstract maxSafeInteger: unit -> ArbitraryWithShrink<int64>
        
        abstract maxSafeNat: unit -> ArbitraryWithShrink<int64>
        
        abstract mixedCase: stringArb: Arbitrary<string> -> Arbitrary<string>
        [<Emit("$0.mixedCase($1 * { toggleCase: $2 })")>]
        abstract mixedCase: stringArb: Arbitrary<string> * toggleCase: bool -> Arbitrary<string>
        
        abstract modelRun: (unit -> Setup<'InitialModel,'Real>) * seq<ICommand<'Model,'Real>> -> unit
        abstract modelRun: (unit -> Setup<'InitialModel,'Real>) * ICommandSeq<'Model,'Real> -> unit

        abstract object: unit -> Arbitrary<'T>
        [<Emit("$0.object(Object.fromEntries(Array.from($1))")>]
        abstract object: constraints: IObjConstraintProperty list -> Arbitrary<'T>
        
        abstract oneof: [<ParamArray>] arbs: Arbitrary<'T> -> Arbitrary<'T>
        
        abstract option: arb: Arbitrary<'T> -> Arbitrary<'T option>
        abstract option: arb: Arbitrary<'T> * freq: float -> Arbitrary<'T option>
        
        abstract property: arb0: Arbitrary<'T0> * predicate: ('T0 -> bool) -> Property<'T0>
        abstract property: arb0: Arbitrary<'T0> * predicate: ('T0 -> unit) -> Property<'T0>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * predicate: ('T0 -> 'T1 -> bool) -> Property<'T0 * 'T1>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * predicate: ('T0 -> 'T1 -> unit) -> Property<'T0 * 'T1>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * predicate: ('T0 -> 'T1 -> 'T2 -> bool) -> Property<'T0 * 'T1 * 'T2>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * predicate: ('T0 -> 'T1 -> 'T2 -> unit) -> Property<'T0 * 'T1 * 'T2>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool) -> Property<'T0 * 'T1 * 'T2 * 'T3>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit) -> Property<'T0 * 'T1 * 'T2 * 'T3>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool) -> Property<'T0 * 'T1 * 'T2 * 'T3 * 'T4>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit) -> Property<'T0 * 'T1 * 'T2 * 'T3 * 'T4>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * arb5: Arbitrary<'T5> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool) -> Property<'T0 * 'T1 * 'T2 * 'T3 * 'T4 * 'T5>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * arb5: Arbitrary<'T5> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit) -> Property<'T0 * 'T1 * 'T2 * 'T3 * 'T4 * 'T5>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * arb5: Arbitrary<'T5> * arb6: Arbitrary<'T6> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool) -> Property<'T0 * 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6>
        abstract property: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * arb5: Arbitrary<'T5> * arb6: Arbitrary<'T6> * predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit) -> Property<'T0 * 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6>
        
        abstract record: recordModel: 'T -> Arbitrary<'T>
        [<Emit("$0.record($1, { withDeletedKeys: $2 })")>]
        abstract record: recordModel: 'T * withDeletedKeys: bool -> Arbitrary<'T>
        
        abstract sample: generator: Arbitrary<'T> -> ResizeArray<'T>
        abstract sample: generator: Arbitrary<'T> * parameters: obj -> ResizeArray<'T>
        abstract sample: generator: Arbitrary<'T> * parameters: int -> ResizeArray<'T>
        abstract sample: generator: #IProperty<'T,'Return> -> ResizeArray<'T>
        abstract sample: generator: #IProperty<'T,'Return> * parameters: obj -> ResizeArray<'T>
        abstract sample: generator: #IProperty<'T,'Return> * parameters: int -> ResizeArray<'T>
        
        abstract scheduledModelRun: Scheduler<'T,'TArgs,'Metadata> * Setup<'InitialModel,'Real> * seq<IPromiseCommand<'Model,'Real>> -> JS.Promise<unit>
        abstract scheduledModelRun: Scheduler<'T,'TArgs,'Metadata> * Setup<'InitialModel,'Real> * IPromiseCommandSeq<'Model,'Real> -> JS.Promise<unit>
        abstract scheduledModelRun: Scheduler<'T,'TArgs,'Metadata> * Setup<'InitialModel,'Real> * seq<IAsyncCommand<'Model,'Real>> -> JS.Promise<unit>
        abstract scheduledModelRun: Scheduler<'T,'TArgs,'Metadata> * Setup<'InitialModel,'Real> * IAsyncCommandSeq<'Model,'Real> -> JS.Promise<unit>

        abstract scheduler: ?constraints: SchedulerAct -> Arbitrary<Scheduler<'T,'TArgs,'Metadata>>
        // Not exposed: see https://github.com/fable-compiler/Fable/issues/1973
        abstract schedulerFor: ?constraints: SchedulerAct -> (ResizeArray<string> * ResizeArray<int> -> Scheduler<'T,'TArgs,'Metadata>)
        abstract schedulerFor: customOrdering: ResizeArray<int> * ?constraints: SchedulerAct -> Scheduler<'T,'TArgs,'Metadata>
        
        abstract set: arb: Arbitrary<'T> -> Arbitrary<ResizeArray<'T>>
        abstract set: arb: Arbitrary<'T> * maxLength: int -> Arbitrary<ResizeArray<'T>>
        abstract set: arb: Arbitrary<'T> * minLength: int * maxLength: int -> Arbitrary<ResizeArray<'T>>
        abstract set: arb: Arbitrary<'T> * compare: ('T -> 'T -> bool) -> Arbitrary<ResizeArray<'T>>
        abstract set: arb: Arbitrary<'T> * maxLength: int * compare: ('T -> 'T -> bool) -> Arbitrary<ResizeArray<'T>>
        abstract set: arb: Arbitrary<'T> * minLength: int * maxLength: int * compare: ('T -> 'T -> bool) -> Arbitrary<ResizeArray<'T>>
        
        abstract shuffledSubarray: originalArray: ResizeArray<'T> -> Arbitrary<ResizeArray<'T>>
        [<Emit("$0.shuffledSubarray(Array.from($1))")>]
        abstract shuffledSubarray: originalArray: 'T [] -> Arbitrary<ResizeArray<'T>>
        [<Emit("$0.shuffledSubarray(Array.from($1))")>]
        abstract shuffledSubarray: originalArray: 'T list -> Arbitrary<ResizeArray<'T>>
        [<Emit("$0.shuffledSubarray(Array.from($1))")>]
        abstract shuffledSubarray: originalArray: 'T seq -> Arbitrary<ResizeArray<'T>>
        abstract shuffledSubarray: originalArray: ResizeArray<'T> * minLength: int * maxLength: int -> Arbitrary<ResizeArray<'T>>
        abstract shuffledSubarray: originalArray: 'T [] * minLength: int * maxLength: int -> Arbitrary<ResizeArray<'T>>
        abstract shuffledSubarray: originalArray: 'T list * minLength: int * maxLength: int -> Arbitrary<ResizeArray<'T>>
        abstract shuffledSubarray: originalArray: 'T seq * minLength: int * maxLength: int -> Arbitrary<ResizeArray<'T>>
        
        abstract statistics: arb: Arbitrary<'T> * classify: ('T -> string) -> unit
        abstract statistics: arb: Arbitrary<'T> * classify: ('T -> string) * parameters: obj -> unit
        abstract statistics: arb: Arbitrary<'T> * classify: ('T -> string) * parameters: int -> unit
        abstract statistics: arb: Arbitrary<'T> * classify: ('T -> ResizeArray<string>) -> unit
        abstract statistics: arb: Arbitrary<'T> * classify: ('T -> ResizeArray<string>) * parameters: obj -> unit
        abstract statistics: arb: Arbitrary<'T> * classify: ('T -> ResizeArray<string>) * parameters: int -> unit
        abstract statistics: prop: #IProperty<'T,'Return> * classify: ('T -> string) -> unit
        abstract statistics: prop: #IProperty<'T,'Return> * classify: ('T -> string) * parameters: obj -> unit
        abstract statistics: prop: #IProperty<'T,'Return> * classify: ('T -> string) * parameters: int -> unit
        abstract statistics: prop: #IProperty<'T,'Return> * classify: ('T -> ResizeArray<string>) -> unit
        abstract statistics: prop: #IProperty<'T,'Return> * classify: ('T -> ResizeArray<string>) * parameters: obj -> unit
        abstract statistics: prop: #IProperty<'T,'Return> * classify: ('T -> ResizeArray<string>) * parameters: int -> unit
        
        abstract string: unit -> Arbitrary<string>
        abstract string: maxLength: int -> Arbitrary<string>
        abstract string: minLength: int * maxLength: int -> Arbitrary<string>
        
        abstract string16bits: unit -> Arbitrary<string>
        abstract string16bits: maxLength: int -> Arbitrary<string>
        abstract string16bits: minLength: int * maxLength: int -> Arbitrary<string>
        
        abstract stringify: value: 'T -> string
        
        abstract stringOf: charArb: Arbitrary<char> -> Arbitrary<string>
        abstract stringOf: charArb: Arbitrary<char> * maxLength: int -> Arbitrary<string>
        abstract stringOf: charArb: Arbitrary<char> * minLength: int * maxLength: int -> Arbitrary<string>

        abstract subarray: originalArray: ResizeArray<'T> -> Arbitrary<ResizeArray<'T>>
        abstract subarray: originalArray: ResizeArray<'T> * minLength: int * maxLength: int -> Arbitrary<ResizeArray<'T>>
        
        abstract tuple: arb0: Arbitrary<'T0> -> Arbitrary<'T0>
        abstract tuple: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> -> Arbitrary<'T0 * 'T1>
        abstract tuple: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> -> Arbitrary<'T0 * 'T1 * 'T2>
        abstract tuple: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> -> Arbitrary<'T0 * 'T1 * 'T2 * 'T3>
        abstract tuple: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> -> Arbitrary<'T0 * 'T1 * 'T2 * 'T3 * 'T4>
        abstract tuple: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * arb5: Arbitrary<'T5> -> Arbitrary<'T0 * 'T1 * 'T2 * 'T3 * 'T4 * 'T5>
        abstract tuple: arb0: Arbitrary<'T0> * arb1: Arbitrary<'T1> * arb2: Arbitrary<'T2> * arb3: Arbitrary<'T3> * arb4: Arbitrary<'T4> * arb5: Arbitrary<'T5> * arb6: Arbitrary<'T6> -> Arbitrary<'T0 * 'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6>
        
        abstract unicode: unit -> Arbitrary<char>

        abstract unicodeJson: unit -> Arbitrary<string>
        abstract unicodeJson: maxDepth: int -> Arbitrary<string>

        abstract unicodeJsonObject: unit -> Arbitrary<'T>
        abstract unicodeJsonObject: maxDepth: int -> Arbitrary<'T>
        
        abstract unicodeString: unit -> Arbitrary<string>
        abstract unicodeString: maxLength: int -> Arbitrary<string>
        abstract unicodeString: minLength: int * maxLength: int -> Arbitrary<string>

        abstract uuid: unit -> Arbitrary<string>

        [<Emit("$0.uuidV((Object.fromEntries([$1]))")>]
        abstract uuidV: versionNumber: IUuidVersionConstraintProperty -> Arbitrary<string>

        abstract webAuthority: unit -> Arbitrary<string>
        
        [<Emit("$0.webAuthority(Object.fromEntries(Array.from($1))")>]
        abstract webAuthority: constraints: IWebAuthorityConstraintProperty list -> Arbitrary<string>

        abstract webFragments: unit -> Arbitrary<string>

        abstract webQueryParameters: unit -> Arbitrary<string>

        abstract webSegment: unit -> Arbitrary<string>

        abstract webUrl: unit -> Arbitrary<string>
        [<Emit("$0.webUrl(Object.fromEntries(Array.from($1))")>]
        abstract webUrl: constraints: IWebUrlConstraintProperty list -> Arbitrary<string>

    let fc : FC = importAll "fast-check"
