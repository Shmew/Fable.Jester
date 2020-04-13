namespace Fable.FastCheck

open Fable.Core
open System

type Stream<'T> =
    inherit IterableIterator<'T>
    
    abstract next: ?value: 'T -> IteratorResult<'T>

    [<Emit("$0.return($1...)")>]
    abstract return': ?value: 'T -> IteratorResult<'T>

    [<Emit("$0.[Symbol.iterator]()")>]
    abstract symbol: unit -> IterableIterator<'T>

    abstract throw: ?value: 'T -> IteratorResult<'T>

    /// Map all elements of the Stream using `f`
    /// 
    /// WARNING: It closes the current stream
    /// Mapper function
    abstract map: f: ('T -> 'U) -> Stream<'U>

    /// Flat map all elements of the Stream using `f`
    /// 
    /// WARNING: It closes the current stream
    /// Mapper function
    abstract flatMap: f: ('T -> IterableIterator<'U>) -> Stream<'U>

    /// Drop elements from the Stream while `f(element) === true`
    /// 
    /// WARNING: It closes the current stream
    /// Drop condition
    abstract dropWhile: f: ('T -> bool) -> Stream<'T>

    /// Drop `n` first elements of the Stream
    /// 
    /// WARNING: It closes the current stream
    /// Number of elements to drop
    abstract drop: n: int -> Stream<'T>

    /// Take elements from the Stream while `f(element) === true`
    /// 
    /// WARNING: It closes the current stream
    /// Take condition
    abstract takeWhile: f: ('T -> bool) -> Stream<'T>

    /// Take `n` first elements of the Stream
    /// 
    /// WARNING: It closes the current stream
    /// Number of elements to take
    abstract take: n: int -> Stream<'T>

    /// Filter elements of the Stream
    /// 
    /// WARNING: It closes the current stream
    /// Elements to keep
    abstract filter: f: ('T -> bool) -> Stream<'T>

    /// Check whether all elements of the Stream are successful for `f`
    /// 
    /// WARNING: It closes the current stream
    /// Condition to check
    abstract every: f: ('T -> bool) -> bool

    /// Check whether one of the elements of the Stream is successful for `f`
    /// 
    /// WARNING: It closes the current stream
    /// Condition to check
    abstract has: f: ('T -> bool) -> bool * 'T option

    /// Join `others` Stream to the current Stream
    /// 
    /// WARNING: It closes the current stream and the other ones (as soon as it iterates over them)
    /// Streams to join to the current Stream
    abstract join: [<ParamArray>] others: ResizeArray<IterableIterator<'T>> -> Stream<'T>

    /// Take the `nth` element of the Stream of the last (if it does not exist)
    /// 
    /// WARNING: It closes the current stream
    /// Position of the element to extract
    abstract getNthOrLast: nth: int -> 'T option
