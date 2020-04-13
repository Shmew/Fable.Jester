namespace Fable.FastCheck

open Fable.Core

type Random =
    /// Clone the random number generator
    abstract clone: unit -> Random
    /// Generate an integer having `bits` random bits
    /// Number of bits to generate
    abstract next: bits: float -> float
    /// Generate a random boolean
    abstract nextBoolean: unit -> bool
    /// Generate a random integer (32 bits)
    abstract nextInt: unit -> float
    /// Generate a random integer between min (included) and max (included)
    /// Minimal integer value
    /// Maximal integer value
    abstract nextInt: min: float * max: float -> float
    /// Generate a random any between min (included) and max (included)
    /// Minimal any value
    /// Maximal any value
    abstract nextBigInt: min: obj option * max: obj option -> obj option
    /// Generate a random floating point number between 0.0 (included) and 1.0 (excluded)
    abstract nextDouble: unit -> float

type IteratorResult<'T> =
    [<Emit("$0.done")>]
    abstract done': bool
    abstract index: int
    abstract value: 'T

type Iterator<'T> =
    abstract next: ?value: 'T -> IteratorResult<'T>
    [<Emit("$0.return($1...)")>]
    abstract return': ?value: 'T -> IteratorResult<'T>
    abstract throw: ?value: 'T -> IteratorResult<'T>
    
type Iterable<'T> =
    [<Emit("$0.[Symbol.iterator]()")>]
    abstract symbol: unit -> Iterator<'T>

type IterableIterator<'T> =
    abstract next: ?value: 'T -> IteratorResult<'T>
    [<Emit("$0.return($1...)")>]
    abstract return': ?value: 'T -> IteratorResult<'T>
    [<Emit("$0.[Symbol.iterator]()")>]
    abstract symbol: unit -> IterableIterator<'T>
    abstract throw: ?value: 'T -> IteratorResult<'T>
    
type ICommandConstraintProperty = interface end
type IDateConstraintProperty = interface end
type IObjConstraintProperty = interface end
type IParametersOptionProperty = interface end
type IRecordConstraintProperty = interface end
type IUuidVersionConstraintProperty = interface end
type IWebAuthorityConstraintProperty = interface end
type IWebUrlConstraintProperty = interface end
