namespace Fable.FastCheck

type Random =
    /// Clone the random number generator/
    abstract clone: unit -> Random

    /// Generate an integer having `bits` random bits.
    abstract next: bits: int -> int

    /// Generate a random boolean.
    abstract nextBoolean: unit -> bool

    /// Generate a random integer (32 bits).
    abstract nextInt: unit -> int

    /// Generate a random integer between min (included) and max (included).
    abstract nextInt: min: int * max: int -> int

    /// Generate a random any between min (included) and max (included).
    abstract nextBigInt: min: bigint * max: bigint -> bigint

    /// Generate a random floating point number between 0.0 (included) and 1.0 (excluded).
    abstract nextDouble: unit -> float
    
type ICommandConstraintProperty = interface end
type IDateConstraintProperty = interface end
type IObjConstraintProperty = interface end
type IFastCheckOptionsProperty = interface end
type IRecordConstraintProperty = interface end
type IUuidVersionConstraintProperty = interface end
type IWebAuthorityConstraintProperty = interface end
type IWebUrlConstraintProperty = interface end
