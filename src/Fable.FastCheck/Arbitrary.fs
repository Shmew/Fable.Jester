namespace Fable.FastCheck

open Fable.Core

/// A Shrinkable<'T> holds an internal value of type `'T`
/// and can shrink it to smaller values.
type Shrinkable<'T> =
    abstract value_ : 'T

    abstract shrink: unit -> seq<Shrinkable<'T>>

    /// State storing the result of hasCloneMethod.
    ///
    /// If true the value will be cloned each time it gets accessed.
    abstract hasToBeCloned : bool

    /// Safe value of the shrinkable.
    ///
    /// Depending on hasToBeCloned it will either be value_ or a clone of it.
    abstract value : 'T

    /// Create another shrinkable by mapping all values using the provided `mapper`
    ///
    /// Both the original value and the shrunk ones are impacted.
    abstract map: mapper: ('T -> 'U) -> Shrinkable<'U>

    /// Create another shrinkable by filtering its shrunk values against a predicate.
    /// 
    /// Return true to keep the element, false otherwise.
    abstract filter: predicate: ('T -> bool) -> Shrinkable<'T>

type Shrinkable =
    [<Emit("new Shrinkable($1...)")>]
    static member Create (value_: 'T, ?shrink: (unit -> seq<Shrinkable<'T>>)) : Shrinkable<'T> = jsNative

type Arbitrary<'T> =
    /// Generate a value of type `'T` along with its shrink method
    /// based on the provided random number generator.
    abstract generate: mrng: Random -> Shrinkable<'T>

    /// Create another arbitrary by filtering values against a predicate.
    /// 
    /// Return true to keep the element, false otherwise.
    abstract filter: predicate: ('T -> bool) -> Arbitrary<'T>

    /// Create another arbitrary by mapping all produced values using the provided mapper function.
    abstract map: mapper: ('T -> 'U) -> Arbitrary<'U>

    /// Create another arbitrary by mapping a value from a base Arbirary using the fmapper function.
    [<Emit("$0.chain($1)")>]
    abstract bind: fmapper: ('T -> Arbitrary<'U>) -> Arbitrary<'U>

    /// Create another Arbitrary with no shrink values.
    abstract noShrink: unit -> Arbitrary<'T>

    /// Create another Arbitrary having bias - by default returns itself.
    abstract withBias: freq: float -> Arbitrary<'T>

    /// Create another Arbitrary that cannot be biased.
    abstract noBias: unit -> Arbitrary<'T>

type ArbitraryWithShrink<'T> =
    inherit Arbitrary<'T>

    /// Produce a stream of shrinks of value.
    abstract shrink: value: 'T * ?shrunkOnce: bool -> seq<'T>

    /// Build the Shrinkable associated to value.
    abstract shrinkableFor: value: 'T * ?shrunkOnce: bool -> Shrinkable<'T>
