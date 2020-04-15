namespace Fable.FastCheck

open Fable.Core

type PreconditionFailure =
    inherit System.Exception

    [<Emit("$0.interruptExecution")>]
    member _.interruptExecution : bool = jsNative

/// Property
/// 
/// A property is the combination of:
/// - Arbitraries: how to generate the inputs for the algorithm
/// - Predicate: how to confirm the algorithm succeeded?
type IProperty<'T,'Return> =
    /// Generate values of type Ts
    /// Random number generator
    /// Id of the generation, starting at 0 - if set the generation might be biased
    abstract generate: mrng: Random * ?runId: float -> Shrinkable<'T>

    /// Is the property asynchronous?
    /// 
    /// true in case of asynchronous property, false otherwise
    abstract isAsync: unit -> bool

    /// Check the predicate for v
    /// Value of which we want to check the predicate
    abstract run: v: 'T -> 'Return

/// Property, see IProperty
/// 
/// Prefer using property instead
type Property<'T> =
    inherit IProperty<'T, U2<PreconditionFailure, string> option>
    
    abstract generate: mrng: Random * ?runId: float -> Shrinkable<'T>

    abstract isAsync: unit -> bool

    abstract run: v: 'T -> U2<PreconditionFailure, string> option

    abstract arb : Arbitrary<'T>

    abstract predicate : ('T -> U2<bool, unit>)    

/// Asynchronous property, see IAsyncProperty
/// 
/// Prefer using asyncProperty instead
type AsyncProperty<'T> =
    inherit IProperty<'T, JS.Promise<U2<PreconditionFailure, string> option>>

    abstract generate: mrng: Random * ?runId: float -> Shrinkable<'T>

    abstract isAsync: unit -> bool

    abstract run: v: 'T -> JS.Promise<U2<PreconditionFailure, string> option> 

    abstract arb : Arbitrary<'T>

    abstract predicate : ('T -> JS.Promise<U2<bool, unit>>)
    