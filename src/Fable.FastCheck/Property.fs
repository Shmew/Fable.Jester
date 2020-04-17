namespace Fable.FastCheck

open Fable.Core

type PreconditionFailure =
    inherit System.Exception

    [<Emit("$0.interruptExecution")>]
    member _.interruptExecution : bool = jsNative

/// A property is the combination of:
/// - Arbitraries: how to generate the inputs for the algorithm.
/// - Predicate: how to confirm the algorithm succeeded?
type IProperty<'T,'Return> =
    /// Generate values of type 'T
    ///
    /// Option parameter runId: Id of the generation, starting at 0
    /// - if set the generation might be biased
    abstract generate: mrng: Random * ?runId: float -> Shrinkable<'T>

    /// true in case of asynchronous property, false otherwise.
    abstract isAsync: unit -> bool

    /// Check the predicate for a value.
    abstract run: v: 'T -> 'Return

type Property<'T> =
    inherit IProperty<'T, U2<PreconditionFailure, string> option>
    
    /// Generate values of type 'T
    ///
    /// Option parameter runId: Id of the generation, starting at 0
    /// - if set the generation might be biased
    abstract generate: mrng: Random * ?runId: float -> Shrinkable<'T>

    /// true in case of asynchronous property, false otherwise.
    abstract isAsync: unit -> bool

    /// Check the predicate for a value.
    abstract run: v: 'T -> U2<PreconditionFailure, string> option

    /// The arbitrary of the property.
    abstract arb : Arbitrary<'T>

    /// The predicate the arbitrary will be tested against.
    abstract predicate : ('T -> U2<bool, unit>)    

/// Asynchronous property, see IAsyncProperty
/// 
/// Prefer using asyncProperty instead
type AsyncProperty<'T> =
    inherit IProperty<'T, JS.Promise<U2<PreconditionFailure, string> option>>

    /// Generate values of type 'T
    ///
    /// Option parameter runId: Id of the generation, starting at 0
    /// - if set the generation might be biased
    abstract generate: mrng: Random * ?runId: float -> Shrinkable<'T>

    /// true in case of asynchronous property, false otherwise.
    abstract isAsync: unit -> bool

    /// Check the predicate for a value.
    abstract run: v: 'T -> JS.Promise<U2<PreconditionFailure, string> option> 

    /// The arbitrary of the property.
    abstract arb : Arbitrary<'T>

    /// The predicate the arbitrary will be tested against.
    abstract predicate : ('T -> JS.Promise<U2<bool, unit>>)
    