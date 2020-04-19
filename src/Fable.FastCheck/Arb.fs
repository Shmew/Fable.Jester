namespace Fable.FastCheck

open ElmishModel
open Fable.Core
open Fable.Core.JsInterop
open Microsoft.FSharp.Reflection
open System
open System.ComponentModel
open System.Text.RegularExpressions

[<AutoOpen>]
module ArbitraryBuilder =
    let inline private dispose (x: #IDisposable) = x.Dispose()
    let inline private using (a, k) = 
        try k a
        finally dispose a

    type ArbitraryBuilder internal () =
        member _.Bind (a: #Arbitrary<_>, f) = a.bind(f)

        member _.Combine (a: #Arbitrary<_>, f) = a.bind(f)

        member _.Delay f = f

        member this.For (s: #seq<_>, m) =
            using(s.GetEnumerator(), fun (enum: Collections.Generic.IEnumerator<_>) ->
                this.While(enum.MoveNext,
                    this.Delay(fun () -> m enum.Current)))

        member _.Return a = Bindings.fc.constant a

        member _.ReturnFrom (a: #Arbitrary<_>) = a

        member _.Run f = f()

        member this.TryFinally ((m: #Arbitrary<_>), handler) =
            try this.ReturnFrom(m)
            finally handler()

        member this.TryWith ((m: #Arbitrary<_>), handler) =
            try this.ReturnFrom(m)
            with e -> handler e

        member this.Using (a, k) = 
            this.TryFinally(k a, (fun () -> dispose a))

        member this.While (p, m) =
            if not (p()) then this.Zero()
            else this.Bind(m(), fun () ->
                this.While(p, m))

        member this.Zero () = this.Return ()

    let arbitrary = ArbitraryBuilder()

[<RequireQualifiedAccess>]
module Arbitrary =
    type ConstrainedDefaults =
        /// Any type of values following the constraints defined by `settings`.
        static member inline anything (constraints: IObjConstraintProperty list) = Bindings.fc.anything(constraints)
        
        static member inline asciiString (maxLength: int) = Bindings.fc.asciiString(maxLength)
        static member inline asciiString (minLength: int, maxLength: int) = Bindings.fc.asciiString(minLength, maxLength)
        
        /// Creates a scheduler with a wrapped act function.
        static member inline asyncScheduler (act: ((unit -> Async<unit>) -> Async<unit>)) =
            let act (f: unit -> JS.Promise<unit>) =
                    (fun () -> f() |> Async.AwaitPromise)
                    |> act
                    |> Async.StartAsPromise

            Bindings.fc.scheduler(Bindings.SchedulerAct.create act).map(fun s -> AsyncScheduler(PromiseScheduler(s)))

        /// A base64 string will always have a length multiple of 4 (padded with =).
        static member inline base64String (maxLength: int) = Bindings.fc.base64String(maxLength)
        /// A base64 string will always have a length multiple of 4 (padded with =).
        static member inline base64String (minLength: int, maxLength: int) = Bindings.fc.base64String(minLength, maxLength)
        
        /// All possible bigint between min (included) and max (included).
        static member inline bigInt (min: bigint, max: bigint) = Bindings.fc.bigInt(min, max)
        
        /// All possible bigint between -2^(n-1) (included) and 2^(n-1)-1 (included).
        static member inline bigintN (n: int) = Bindings.fc.bigIntN(n)
        
        /// All possible bigint between 0 (included) and max (included).
        static member inline bigUint (max: bigint) = Bindings.fc.bigUint(max)

        /// All possible bigint between 0 (included) and 2^n -1 (included).
        static member inline bigUintN (n: int) = Bindings.fc.bigUintN(n)

        static member inline dateTime (constraints: IDateConstraintProperty list) = Bindings.fc.date(constraints)
        
        /// Floating point numbers between 0.0 (included) and max (excluded) - accuracy of `max / 2**53`.
        static member inline double (max: float) = Bindings.fc.double(max)
        /// Floating point numbers between min (included) and max (excluded) - accuracy of `(max - min) / 2**53`.
        static member inline double (min: float, max: float) = Bindings.fc.double(min, max)
        
        /// Floating point numbers between 0.0 (included) and max (excluded) - accuracy of `max / 2**24`.
        static member inline float (max: float) = Bindings.fc.float(max)
        /// Floating point numbers between min (included) and max (excluded) - accuracy of `(max - min) / 2**24`.
        static member inline float (min: float, max: float) = Bindings.fc.float(min, max)
        
        static member inline fullUnicodeString (maxLength: int) = Bindings.fc.fullUnicodeString(maxLength)
        static member inline fullUnicodeString (minLength: int, maxLength: int) = Bindings.fc.fullUnicodeString(minLength, maxLength)
        
        static member inline hexaString (maxLength: int) = Bindings.fc.hexaString(maxLength)
        static member inline hexaString (minLength: int, maxLength: int) = Bindings.fc.hexaString(minLength, maxLength)
        
        static member inline integer (max: int) = Bindings.fc.integer(max)
        static member inline integer (min: int, max: int) = Bindings.fc.integer(min, max)
        
        /// JSON strings with a maximal depth.
        static member inline json (maxDepth: int) = Bindings.fc.json(maxDepth)
        
        /// JSON compliant values with a maximal depth.
        static member inline jsonObject (maxDepth: int) = Bindings.fc.jsonObject(maxDepth)
        
        /// Lorem ipsum string of words with maximal number of words.
        static member inline lorem (maxWordsCount: int) = Bindings.fc.lorem(maxWordsCount)
        /// Lorem ipsum string of words or sentences with maximal number of words or sentences.
        static member inline lorem (maxWordsCount: int, sentencesMode: bool) = 
            Bindings.fc.lorem(maxWordsCount, sentencesMode)
        
        /// Objects following the constraints defined by `settings`.
        static member inline object (constraints: IObjConstraintProperty list) = 
            Bindings.fc.object(constraints)
        
        /// Creates a scheduler with a wrapped act function.
        static member inline promiseScheduler (act: ((unit -> JS.Promise<unit>) -> JS.Promise<unit>)) = 
            Bindings.fc.scheduler(Bindings.SchedulerAct.create act).map(fun s -> new PromiseScheduler(s))

        static member inline string (maxLength: int) = Bindings.fc.string(maxLength)
        static member inline string (minLength: int, maxLength: int) = Bindings.fc.string(minLength, maxLength)
        
        static member inline string16bits (maxLength: int) = Bindings.fc.string16bits(maxLength)
        static member inline string16bits (minLength: int, maxLength: int) = Bindings.fc.string16bits(minLength, maxLength)
        
        /// JSON strings with unicode support and a maximal depth.
        static member inline unicodeJson (maxDepth: int) = Bindings.fc.unicodeJson(maxDepth)
        
        /// JSON compliant values with unicode support and a maximal depth.
        static member inline unicodeJsonObject (maxDepth: int) = Bindings.fc.unicodeJsonObject(maxDepth)
        
        static member inline unicodeString (maxLength: int) = Bindings.fc.unicodeString(maxLength)
        static member inline unicodeString (minLength: int, maxLength: int) = Bindings.fc.unicodeString(minLength, maxLength)
        
        /// UUID of a given version (in v1 to v5).
        /// 
        /// According to RFC 4122 - https://tools.ietf.org/html/rfc4122
        /// 
        /// No mixed case, only lower case digits (0-9a-f).
        static member inline uuidV (versionNumber: IUuidVersionConstraintProperty) = Bindings.fc.uuidV(versionNumber)
        
        /// According to RFC 3986 - https://www.ietf.org/rfc/rfc3986.txt - `authority = [ userinfo "@" ] host [ ":" port ]`
        static member inline webAuthority (constraints: IWebAuthorityConstraintProperty list) = Bindings.fc.webAuthority(constraints)
        
        /// According to RFC 3986 and WHATWG URL Standard
        /// - https://www.ietf.org/rfc/rfc3986.txt
        /// - https://url.spec.whatwg.org/
        static member inline webUrl (constraints: IWebUrlConstraintProperty list) = Bindings.fc.webUrl(constraints)    

    type Defaults =
        /// Any type of values.
        static member inline anything = Bindings.fc.anything()

        /// Single ascii characters - char code between 0x00 (included) and 0x7f (included).
        static member inline ascii = Bindings.fc.ascii()

        static member inline asciiString = Bindings.fc.asciiString()
        
        /// Scheduler of asyncs.
        static member inline asyncScheduler = Bindings.fc.scheduler().map(fun s -> AsyncScheduler(PromiseScheduler(s)))

        /// Single base64 characters - A-Z, a-z, 0-9, + or /
        static member inline base64 = Bindings.fc.base64()
        
        /// A base64 string will always have a length multiple of 4 (padded with =)
        static member inline base64String = Bindings.fc.base64String()
        
        /// Uniformly distributed bigint values
        static member inline bigInt = Bindings.fc.bigInt()

        /// Uniformly distributed bigint positive values
        static member inline bigUint = Bindings.fc.bigUint()

        static member inline boolean = Bindings.fc.boolean()

        static member inline byte = Bindings.fc.integer(int Byte.MinValue, int Byte.MaxValue).map(byte)
        
        /// Single printable ascii characters - char code between 0x20 (included) and 0x7e (included)
        static member inline char = Bindings.fc.char()
        
        /// Single characters - all values in 0x0000-0xffff can be generated
        /// 
        /// WARNING:
        /// 
        /// Some generated characters might appear invalid regarding UCS-2 and UTF-16 encoding.
        ///
        /// Indeed values within 0xd800 and 0xdfff constitute surrogate pair characters and are illegal without their paired character.
        static member inline char16bits = Bindings.fc.char16bits()
        
        /// A comparison boolean function returns:
        ///
        /// - true whenever a < b
        ///
        /// - false otherwise (ie. a = b or a > b)
        static member inline compareBooleanFunc = Bindings.fc.compareBooleanFunc()
        
        /// A comparison function returns:
        ///
        /// - Negative value whenever a < b.
        ///
        /// - Positive value whenever a > b
        ///
        /// - Zero whenever a and b are equivalent
        /// 
        /// Comparison functions are transitive: `a < b and b < c => a < c`
        /// 
        /// They also satisfy: `a < b <=> b > a` and `a = b <=> b = a`
        static member inline compareFunc = Bindings.fc.compareFunc()
        
        static member inline dateTime = Bindings.fc.date()
        
        static member inline dateTimeOffset = Bindings.fc.date().map(DateTimeOffset)

        /// Having an extension with at least two lowercase characters.
        /// 
        /// According to RFC 1034, RFC 1123 and WHATWG URL Standard
        /// - https://www.ietf.org/rfc/rfc1034.txt
        /// - https://www.ietf.org/rfc/rfc1123.txt
        /// - https://url.spec.whatwg.org/
        static member inline domain = Bindings.fc.domain()
        
        /// Floating point numbers between 0.0 (included) and 1.0 (excluded) - accuracy of `1 / 2**53`.
        static member inline double = Bindings.fc.double()
        
        /// According to RFC 5322 - https://www.ietf.org/rfc/rfc5322.txt
        static member inline emailAddress = Bindings.fc.emailAddress()
        
        static member inline exn : Arbitrary<exn> = Bindings.fc.string().map(fun s -> Exception(s))

        /// Floating point numbers between 0.0 (included) and 1.0 (excluded) - accuracy of `1 / 2**24`.
        static member inline float = Bindings.fc.float()

        static member inline float32 = Bindings.fc.integer(int Single.MinValue, int Single.MaxValue).map(float32)
        
        /// Single unicode characters - any of the code points defined in the unicode standard.
        /// 
        /// WARNING: Generated values can have a length greater than 1.
        static member inline fullUnicode = Bindings.fc.fullUnicode()
        
        static member inline fullUnicodeString = Bindings.fc.fullUnicodeString()
        
        static member inline guid = arbitrary { return Guid() }

        /// Single hexadecimal characters - 0-9 or a-f
        static member inline hexa = Bindings.fc.hexa()
        
        static member inline hexaString = Bindings.fc.hexaString()
        
        static member int16 = Bindings.fc.integer(int Int16.MinValue, int Int16.MaxValue).map(int16)

        static member integer = Bindings.fc.integer()

        /// Integers between Number.MIN_SAFE_INTEGER (included) and Number.MAX_SAFE_INTEGER (included).
        static member int64 = Bindings.fc.maxSafeInteger()
        
        /// Valid IP v4.
        /// 
        /// Following RFC 3986
        /// https://tools.ietf.org/html/rfc3986#section-3.2.2
        static member inline ipV4 = Bindings.fc.ipV4()
        
        /// Valid IP v4 according to WhatWG.
        /// 
        /// Following WhatWG, the specification for web-browsers:
        /// https://url.spec.whatwg.org/
        /// 
        /// There is no equivalent for IP v6 according to the IP v6 parser:
        /// https://url.spec.whatwg.org/#concept-ipv6-parser
        static member inline ipV4Extended = Bindings.fc.ipV4Extended()
        
        /// Valid IP v6.
        /// 
        /// Following RFC 3986:
        /// https://tools.ietf.org/html/rfc3986#section-3.2.2
        static member inline ipV6 = Bindings.fc.ipV6()
        
        /// JSON compliant string.
        static member inline json = Bindings.fc.json()

        /// JSON compliant values.
        static member inline jsonObject = Bindings.fc.jsonObject()
        
        /// lorem ipsum strings of words.
        static member inline lorem = Bindings.fc.lorem()
        
        /// Integers between Number.MIN_SAFE_INTEGER (included) and Number.MAX_SAFE_INTEGER (included).
        static member inline maxSafeInteger = Bindings.fc.maxSafeInteger()
        
        /// positive integers between 0 (included) and Number.MAX_SAFE_INTEGER (included).
        static member inline maxSafeNat = Bindings.fc.maxSafeNat()
        
        static member inline object = Bindings.fc.object()
        
        static member inline sbyte = Bindings.fc.integer(int SByte.MinValue, int SByte.MaxValue).map(sbyte)

        /// Scheduler of promises.
        static member inline promiseScheduler = Bindings.fc.scheduler().map(fun s -> PromiseScheduler(s))

        /// Any valid Regex.
        static member inline regex =
            Bindings.fc
                .string()
                .filter(fun s -> 
                    try 
                        Regex(s, RegexOptions.ECMAScript) 
                        |> fun _ -> true 
                    with _ -> false)
                .map(Regex)

        static member inline string = Bindings.fc.string()
        
        static member inline string16bits = Bindings.fc.string16bits()
        
        static member inline timeSpan = Bindings.fc.date().map(fun d -> d.TimeOfDay)

        /// Single unicode characters defined in the BMP plan - char code between 
        /// 0x0000 (included) and 0xffff (included) and without the range 0xd800 
        /// to 0xdfff (surrogate pair characters).
        static member inline unicode = Bindings.fc.unicode()
        
        /// JSON strings with unicode support.
        static member inline unicodeJson = Bindings.fc.unicodeJson()
        
        /// JSON compliant values with unicode support.
        static member inline unicodeJsonObject = Bindings.fc.unicodeJsonObject()
        
        static member inline unicodeString = Bindings.fc.unicodeString()
        
        static member inline uint16 = Bindings.fc.integer(int UInt16.MinValue, int UInt16.MaxValue)

        static member inline uint32 = Bindings.fc.maxSafeNat().filter(fun i -> i < 0L || i > int64 UInt32.MaxValue)
        
        /// Due to number limitations this is just an alias and cast from maxSafeNat.
        static member inline uint64 = Bindings.fc.maxSafeNat().map(uint64)

        /// UUID from v1 to v5.
        /// 
        /// According to RFC 4122:
        /// https://tools.ietf.org/html/rfc4122
        /// 
        /// No mixed case, only lower case digits (0-9a-f).
        static member inline uuid = Bindings.fc.uuid()
        
        /// According to RFC 3986:
        /// https://www.ietf.org/rfc/rfc3986.txt 
        /// 
        /// `authority = [ userinfo "@" ] host [ ":" port ]`
        static member inline webAuthority = Bindings.fc.webAuthority()
        
        /// Fragments of an URI (web included).
        /// 
        /// According to RFC 3986:
        /// https://www.ietf.org/rfc/rfc3986.txt
        /// 
        /// eg.: In the url `https://domain/plop?page=1#hello=1&world=2`, `?hello=1&world=2` are query parameters.
        static member inline webFragments = Bindings.fc.webFragments()
        
        /// Query parameters of an URI (web included).
        /// 
        /// According to RFC 3986:
        /// https://www.ietf.org/rfc/rfc3986.txt
        /// 
        /// eg.: In the url `https://domain/plop/?hello=1&world=2`, `?hello=1&world=2` are query parameters.
        static member inline webQueryParameters = Bindings.fc.webQueryParameters()
        
        /// Internal segment of an URI (web included).
        /// 
        /// According to RFC 3986:
        /// https://www.ietf.org/rfc/rfc3986.txt
        /// 
        /// eg.: In the url `https://github.com/dubzzz/fast-check/`, `dubzzz` and `fast-check` are segments.
        static member inline webSegment = Bindings.fc.webSegment()
        
        /// According to RFC 3986 and WHATWG URL Standard:
        ///
        /// - https://www.ietf.org/rfc/rfc3986.txt
        ///
        /// - https://url.spec.whatwg.org/
        static member inline webUrl = Bindings.fc.webUrl()

    let inline apply (arbF: Arbitrary<'T -> 'U>) (arb: Arbitrary<'T>) =
        arbF.bind(fun f -> arb.map f)

    let inline bind (f: 'A -> Arbitrary<'B>) (arb: Arbitrary<'A>) = arb.bind(f)

    let inline map (f: 'A -> 'B) (a: Arbitrary<'A>) = a.map(f)

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    module Operators =
        /// Infix apply.
        let inline (<*>) f m = apply f m
        
        /// Infix map.
        let inline (<!>) f m = map f m
        
        /// Infix bind.
        let inline (>>=) f m = bind f m
        
        /// Infix bind (right to left).
        let inline (=<<) m f = bind f m
    
        /// Left-to-right Kleisli composition
        let inline (>=>) f g = fun x -> f x >>= g
    
        /// Right-to-left Kleisli composition
        let inline (<=<) x = (fun f a b -> f b a) (>=>) x

    open Operators
    
    let inline bind2 (f: 'A -> 'B -> Arbitrary<'C>) (a: Arbitrary<'A>) (b: Arbitrary<'B>) = 
        f >=> b >>= a

    /// Applies the given function to the arbitrary. 
    /// Returns an arbitrary comprised of the results 
    /// x for each generated value where the function 
    /// returns Some(x).
    let choose (chooser: 'T -> 'U option) (arb: Arbitrary<'T>) =
        arb.filter(chooser >> Option.isSome).map(chooser >> Option.get)
    
    /// Clones a constant, useful when generating an arbitrary from a mutable value.
    let inline clonedConstant (value: 'T) = Bindings.fc.clonedConstant(value)
        
    /// Creates an arbitrary that returns a constant value.
    let inline constant (value: 'T) = 
        try Bindings.fc.constant(value)
        with _ -> Bindings.fc.clonedConstant(value)

    /// Sequence of Command to be executed by modelRun.
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than a normal sequence of Commands.
    let inline commands (commandArbs: Arbitrary<ICommand<'Model,'Real>> list) = 
        Bindings.fc.commands(ResizeArray commandArbs, ?maxCommands = None)
    
    /// Sequence of Command to be executed by modelRun.
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than a normal sequence of Commands.
    let inline commandsOfMax (maxCommands: int) (commandArbs: Arbitrary<ICommand<'Model,'Real>> list) = 
        Bindings.fc.commands(ResizeArray commandArbs, maxCommands = maxCommands)

    /// Sequence of Command to be executed by modelRun.
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than a normal sequence of Commands.
    let inline commandsOfSettings (settings: ICommandConstraintProperty list) (commandArbs: Arbitrary<ICommand<'Model,'Real>> list) = 
        Bindings.fc.commands(ResizeArray commandArbs, settings = createObj !!(settings))

    /// Build an arbitrary that randomly generates one of the values in the given non-empty seq.
    let inline elements (xs: 'T seq) =
        match xs with
        | :? array<'T> as arr ->
            Bindings.fc.integer(0, arr.Length - 1).map(Array.get arr)
        | :? list<'T> as lst ->
            Bindings.fc.integer(0, lst.Length - 1).map(fun i -> List.item i lst)
        | _ -> Bindings.fc.integer(0, (Seq.length xs) - 1).map(fun i -> Seq.item i xs)

    /// Create another arbitrary by filtering values against a predicate.
    /// 
    /// Return true to keep the element, false otherwise.
    let inline filter f (a: Arbitrary<'T>) = a.filter f

    /// Creates an arbitrary function that returns the given arbitrary value.
    let inline func (arb: Arbitrary<'TOut>) = Bindings.fc.func(arb)

    /// Produce an infinite stream of values.
    /// 
    /// WARNING: Requires Object.assign.
    let inline infiniteStream (arb: Arbitrary<'T>) = 
        Bindings.fc.infiniteStream(arb)

    let inline map2 (f: 'A -> 'B -> 'C) (a: Arbitrary<'A>) (b: Arbitrary<'B>) =
        map f a <*> b
    
    let inline map3 (f: 'A -> 'B -> 'C -> 'D) (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>) =
        map f a <*> b <*> c
    
    let inline map4 (f: 'A -> 'B -> 'C -> 'D -> 'E) (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>) (d: Arbitrary<'D>) =
        map f a <*> b <*> c <*> d
    
    let inline map5 (f: 'A -> 'B -> 'C -> 'D -> 'E -> 'G) (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>) (d: Arbitrary<'D>) (e: Arbitrary<'E>) =
        map f a <*> b <*> c <*> d <*> e
    
    let inline map6 (f: 'A -> 'B -> 'C -> 'D -> 'E -> 'G -> 'H) (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>) (d: Arbitrary<'D>) (e: Arbitrary<'E>) (g: Arbitrary<'G>) =
        map f a <*> b <*> c <*> d <*> e <*> g

    /// Randomly switch the case of characters generated by Arbitrary<string> (upper/lower).
    let inline mixedCase (stringArb: Arbitrary<string>) = 
        Bindings.fc.mixedCase(stringArb)

    /// Randomly switch the case of characters generated by Arbitrary<string> (upper/lower).
    let inline mixedCaseWithToggle (toggleCase: bool) (stringArb: Arbitrary<string>) = 
        Bindings.fc.mixedCase(stringArb, toggleCase)

    /// Generates an option of a given arbitrary.
    let inline option (arb: Arbitrary<'T>) = Bindings.fc.option(arb)

    /// Generates an option of a given arbitrary.
    ///
    /// The probability of None is `1. / freq`.
    let inline optionOfFreq (freq: float) (arb: Arbitrary<'T>) = 
        Bindings.fc.option(arb, freq)

    /// Sequence of IAsyncCommand to be executed by asyncModelRun.
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than a normal sequence of IAsyncCommand.
    let inline asyncCommands (commandArbs: Arbitrary<IAsyncCommand<'Model,'Real>> list) =
        let commandArbs =
            commandArbs
            |> List.map (map (fun cmd -> AsyncCommand(cmd) :> IPromiseCommand<'Model,'Real>))

        Bindings.fc.commands(ResizeArray commandArbs, ?maxCommands = None)
        |> map (Seq.map (fun cmd -> PromiseCommandConverter(cmd) :> IAsyncCommand<'Model,'Real>))

    /// Sequence of IAsyncCommand to be executed by asyncModelRun.
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than a normal sequence of IAsyncCommand.
    let inline asyncCommandsOfMax (maxCommands: int) (commandArbs: Arbitrary<IAsyncCommand<'Model,'Real>> list) =
        let cmds =
            commandArbs
            |> List.map (map (fun cmd -> AsyncCommand(cmd) :> IPromiseCommand<'Model,'Real>))

        Bindings.fc.commands(ResizeArray cmds, maxCommands = maxCommands)
        |> map (Seq.map (fun cmd -> PromiseCommandConverter(cmd) :> IAsyncCommand<'Model,'Real>))

    /// Sequence of IAsyncCommand to be executed by asyncModelRun.
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than a normal sequence of IAsyncCommand.
    let inline asyncCommandsOfSettings (settings: ICommandConstraintProperty list) (commandArbs: Arbitrary<IAsyncCommand<'Model,'Real>> list) = 
        let cmds =
            commandArbs
            |> List.map (map (fun cmd -> AsyncCommand(cmd) :> IPromiseCommand<'Model,'Real>))

        Bindings.fc.commands(ResizeArray cmds, settings = createObj !!(settings))
        |> map (Seq.map (fun cmd -> PromiseCommandConverter(cmd) :> IAsyncCommand<'Model,'Real>))

    /// Sequence of IPromiseCommand to be executed by promiseModelRun.
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than a normal sequence of IPromiseCommand.
    let inline promiseCommands (commandArbs: Arbitrary<IPromiseCommand<'Model,'Real>> list) = 
        Bindings.fc.commands(ResizeArray commandArbs, ?maxCommands = None)

    /// Sequence of IPromiseCommand to be executed by promiseModelRun.
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than a normal sequence of IPromiseCommand.
    let inline promiseCommandsOfMax (maxCommands: int) (commandArbs: Arbitrary<IPromiseCommand<'Model,'Real>> list) = 
        Bindings.fc.commands(ResizeArray commandArbs, maxCommands = maxCommands)

    /// Sequence of IPromiseCommand to be executed by promiseModelRun.
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than a normal sequence of IPromiseCommand.
    let inline promiseCommandsOfSettings (settings: ICommandConstraintProperty list) (commandArbs: Arbitrary<IPromiseCommand<'Model,'Real>> list) = 
        Bindings.fc.commands(ResizeArray commandArbs, settings = createObj !!(settings))

    /// Records following the `recordModel` schema.
    let inline record (recordModel: Map<string,obj>) = 
        Bindings.fc.record(createObj !!(recordModel |> Map.toList))

    /// Records following the `recordModel` schema.
    let inline recordWithDeletedKeys (recordModel: Map<string,obj>) = 
        Bindings.fc.record(createObj !!(recordModel |> Map.toList), true)

    /// Generates a result of the given arbitraries.
    let inline result (ok: Arbitrary<'Success>) (err: Arbitrary<'Failure>) =
        Defaults.boolean |> bind (fun b -> if b then ok.map Ok else err.map Error)

    /// Generates a result of the given arbitraries.
    ///
    /// The probability of Error is `1. / freq`.
    let inline resultOfFreq (freq: float) (ok: Arbitrary<'Success>) (err: Arbitrary<'Failure>) =
        optionOfFreq freq ok
        |> bind (fun res ->
            arbitrary {
                let! ok = ok
                let! err = err
                
                return
                    match res with
                    | Some _ -> Ok ok
                    | None -> Error err
            }
        )
    /// Creates a string arbitrary using the characters produced by a char arbitrary.
    let inline stringOf (charArb: Arbitrary<char>) = 
        Bindings.fc.stringOf(charArb)

    /// Creates a string arbitrary using the characters produced by a char arbitrary.
    let inline stringOfMaxSize (maxLength: int) (charArb: Arbitrary<char>) = 
        Bindings.fc.stringOf(charArb, maxLength)

    /// Creates a string arbitrary using the characters produced by a char arbitrary.
    let inline stringOfSize (minLength: int) (maxLength: int) (charArb: Arbitrary<char>) = 
        Bindings.fc.stringOf(charArb, minLength, maxLength)

    let inline unzip (a: Arbitrary<'A * 'B>) =
        a.map(fst), a.map(snd)
    
    let inline unzip3 (a: Arbitrary<'A * 'B * 'C>) =
        a.map(fun (res,_,_) -> res), a.map(fun (_,res,_) -> res), a.map(fun (_,_,res) -> res)
    
    let inline unzip4 (a: Arbitrary<'A * 'B * 'C * 'D>) =
        a.map(fun (res,_,_,_) -> res),
        a.map(fun (_,res,_,_) -> res), 
        a.map(fun (_,_,res,_) -> res), 
        a.map(fun (_,_,_,res) -> res)
    
    let inline unzip5 (a: Arbitrary<'A * 'B * 'C * 'D * 'E>) =
        a.map(fun (res,_,_,_,_) -> res), 
        a.map(fun (_,res,_,_,_) -> res), 
        a.map(fun (_,_,res,_,_) -> res), 
        a.map(fun (_,_,_,res,_) -> res), 
        a.map(fun (_,_,_,_,res) -> res)
    
    let inline unzip6 (a: Arbitrary<'A * 'B * 'C * 'D * 'E * 'F>) =
        a.map(fun (res,_,_,_,_,_) -> res), 
        a.map(fun (_,res,_,_,_,_) -> res), 
        a.map(fun (_,_,res,_,_,_) -> res), 
        a.map(fun (_,_,_,res,_,_) -> res), 
        a.map(fun (_,_,_,_,res,_) -> res), 
        a.map(fun (_,_,_,_,_,res) -> res)
    
    let inline zip (a: Arbitrary<'A>) (b: Arbitrary<'B>) =
        map2(fun x y -> x, y) a b
    
    let inline zip3 (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>) =
        map3(fun x y z -> x, y, z) a b c
    
    let inline zip4 (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>) (d: Arbitrary<'D>) =
        map4(fun w x y z -> w, x, y, z) a b c d
    
    let inline zip5 (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>) (d: Arbitrary<'D>) (e: Arbitrary<'E>) =
        map5(fun v w x y z -> v, w, x, y, z) a b c d e
    
    let inline zip6 (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>)  (d: Arbitrary<'D>) (e: Arbitrary<'E>) (f: Arbitrary<'F>) =
        map6(fun u v w x y z -> u, v, w, x, y, z) a b c d e f

    module Array =
        let inline traverse (f: 'T -> Arbitrary<'U>) (arbs: Arbitrary<'T> []) =
            constant [||]
            |> Array.foldBack (fun x xs ->
                let x' = x |> bind f
                map2 (fun h t -> Array.append [|h|] t) x' xs
            ) arbs

        let inline sequence (arbs: Arbitrary<'T> []) =
            traverse (constant) arbs

        let inline ofLength (size: int) (arb: Arbitrary<'T>) =
            Array.init size (fun _ -> arb)
            |> sequence

        let inline ofRange (min: int) (max: int) (arb: Arbitrary<'T>) =
            ConstrainedDefaults.integer(min, max)
            |> map(fun i -> 
                Array.init i (fun _ -> arb))
            |> bind sequence

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        let inline yatesShuffle (arr: 'T []) =
            let inline swap (arr: 'T []) i j =
                let v = arr.[j]
                arr.[j] <- arr.[i]
                arr.[i] <- v
        
            let maxI = arr.Length - 1
            
            fun i -> ConstrainedDefaults.integer(i, maxI) :> Arbitrary<int>
            |> Array.init (maxI - 1)
            |> sequence
            |> map(fun res ->
                res |> Array.iteri (swap arr)
                arr)

        /// Creates an arbitrary of a collection that is shuffled.
        let inline shuffle (xs: 'T []) =
            let xs = xs |> Seq.toArray
            Array.copy xs
            |> yatesShuffle

        /// Creates an arbitrary of a collection of a given length 
        /// such that all elements have the given sum.
        let inline piles (length: int) (sum: int) =
            if length <= 0 then constant [||]
            else 
                arbitrary {
                    let result = Array.zeroCreate<int> length
                    let! n' = clonedConstant sum
                    let mutable n = n'

                    let! m' = clonedConstant sum
                    let mutable m = m'
                    
                    for i in length .. -1 .. 1 do
                        if i = 1 then
                            result.[i - 1] <- n
                        else
                            let! r = ConstrainedDefaults.integer(int (Math.Ceiling(float n / float i)), Math.Min(m, n))
                                    
                            result.[i - 1] <- r
                            n <- n - r
                            m <- Math.Min(m, r)
                    return result
                }
                |> bind yatesShuffle

        /// Creates an array of arrays arbitrary from a given arbitrary.
        let inline twoDimOfDim (rows: int) (cols: int) (arb: Arbitrary<'T>) =
            Array.chunkBySize rows <!> ofLength (rows * cols) arb

        /// Creates a array of arrays arbitrary from a given arbitrary.
        let inline twoDimOf (arb: Arbitrary<'T>) =
            arbitrary {
                let! rows = ConstrainedDefaults.integer(0, 200)
                let! cols = ConstrainedDefaults.integer(0, 200)
                return! twoDimOfDim rows cols arb 
            }

        /// Creates an arbitrary that is shuffled and a sub-section of the given collection.
        let inline shuffledSub (originalArray: 'T []) = 
            Bindings.fc.shuffledSubarray(originalArray)
            |> map Array.ofSeq

        /// Creates an arbitrary that is shuffled and a sub-section of the given collection.
        let inline shuffledSubOfSize (minLength: int) (maxLength: int) (xs: 'T []) = 
            Bindings.fc.shuffledSubarray(xs, minLength, maxLength)
            |> map Array.ofSeq

        /// Creates an arbitrary that is a sub-section of the given collection.
        let inline sub (xs: 'T []) = 
            Bindings.fc.subarray(ResizeArray xs)
            |> map Array.ofSeq

        /// Creates an arbitrary that is a sub-section of the given collection.
        let inline subOfSize (minLength: int) (maxLength: int) (xs: 'T []) = 
            Bindings.fc.subarray(ResizeArray xs, minLength, maxLength)
            |> map Array.ofSeq

    module List =
        let inline traverse f (arbs: Arbitrary<'T> list) =
            constant []
            |> List.foldBack (fun x xs ->
                let x' = x |> bind f
                map2 (fun h t -> h::t) x' xs
            ) arbs

        let inline sequence (arbs: Arbitrary<'T> list) =
            traverse (constant) arbs

        let inline ofLength (size: int) (arb: Arbitrary<'T>) =
            List.init size (fun _ -> arb)
            |> sequence

        let inline ofRange (min: int) (max: int) (arb: Arbitrary<'T>) =
            ConstrainedDefaults.integer(min, max)
            |> map(fun i -> 
                List.init i (fun _ -> arb))
            |> bind sequence

        /// Creates an arbitrary of a collection that is shuffled.
        let inline shuffle (xs: 'T list) =
            let xs = xs |> Seq.toArray
            Array.copy xs
            |> Array.yatesShuffle
            |> map List.ofArray

        /// Creates an arbitrary of a collection of a given length 
        /// such that all elements have the given sum.
        let inline piles length sum = 
            Array.piles length sum
            |> map List.ofArray

        /// Creates an arbitrary that is shuffled and a sub-section of the given collection.
        let inline shuffledSub (originalArray: 'T list) = 
            Bindings.fc.shuffledSubarray(originalArray)
            |> map List.ofSeq

        /// Creates an arbitrary that is shuffled and a sub-section of the given collection.
        let inline shuffledSubOfSize (minLength: int) (maxLength: int) (xs: 'T list) = 
            Bindings.fc.shuffledSubarray(xs, minLength, maxLength)
            |> map List.ofSeq

        /// Creates an arbitrary that is a sub-section of the given collection.
        let inline sub (xs: 'T list) = 
            Bindings.fc.subarray(ResizeArray xs)
            |> map List.ofSeq

        /// Creates an arbitrary that is a sub-section of the given collection.
        let inline subOfSize (minLength: int) (maxLength: int) (xs: 'T list) = 
            Bindings.fc.subarray(ResizeArray xs, minLength, maxLength)
            |> map List.ofSeq

        /// Creates a list of lists arbitrary from a given arbitrary.
        let inline twoDimOfDim (rows: int) (cols: int) (arb: Arbitrary<'T>) =
            List.chunkBySize rows <!> ofLength (rows * cols) arb

        /// Creates a array of arrays arbitrary from a given arbitrary.
        let inline twoDimOf (arb: Arbitrary<'T>) =
            arbitrary {
                let! rows = ConstrainedDefaults.integer(0, 200)
                let! cols = ConstrainedDefaults.integer(0, 200)
                return! twoDimOfDim rows cols arb 
            }

    module Map =
        let ofRange (min: int) (max: int) (key: Arbitrary<'Key>) (value: Arbitrary<'Value>) =
            arbitrary {
                let! size = ConstrainedDefaults.integer(min, max)
                let! keys, values = zip (List.ofLength size key) (List.ofLength size value)
                
                return List.zip keys values |> Map.ofList
            }

        let ofLength (length: int) (key: Arbitrary<'Key>) (value: Arbitrary<'Value>) =
            ofRange length length key value

    module ResizeArray =
        let inline traverse f (arbs: ResizeArray<Arbitrary<'T>>) =
            constant []
            |> List.foldBack (fun x xs ->
                let x' = x |> bind f
                map2 (fun h t -> h::t) x' xs
            ) (List.ofSeq arbs)
            |> map ResizeArray
    
        let inline sequence (arbs: ResizeArray<Arbitrary<'T>>) =
            traverse (constant) arbs
    
        let inline ofLength (size: int) (arb: Arbitrary<'T>) =
            Array.init size (fun _ -> arb)
            |> ResizeArray
            |> sequence

        let inline ofRange (min: int) (max: int) (arb: Arbitrary<'T>) =
            ConstrainedDefaults.integer(min, max)
            |> map(fun i -> 
                Array.init i (fun _ -> arb)
                |> ResizeArray)
            |> bind sequence

        /// Creates an arbitrary of a collection that is shuffled.
        let inline shuffle (xs: ResizeArray<'T>) =
            let xs = xs |> Seq.toArray
            Array.copy xs
            |> Array.yatesShuffle
            |> map ResizeArray

        /// Creates an arbitrary of a collection of a given length 
        /// such that all elements have the given sum.
        let inline piles k sum = 
            Array.piles k sum
            |> map ResizeArray

        /// Creates an arbitrary that is shuffled and a sub-section of the given collection.
        let inline shuffledSub (originalArray: ResizeArray<'T>) = 
            Bindings.fc.shuffledSubarray(originalArray)

        /// Creates an arbitrary that is shuffled and a sub-section of the given collection.
        let inline shuffledSubOfSize (minLength: int, maxLength: int) (xs: ResizeArray<'T>) = 
            Bindings.fc.shuffledSubarray(xs, minLength, maxLength)

        /// Creates an arbitrary that is a sub-section of the given collection.
        let inline sub (xs: ResizeArray<'T>) = Bindings.fc.subarray(xs)

        /// Creates an arbitrary that is a sub-section of the given collection.
        let inline subOfSize (minLength: int) (maxLength: int) (xs: ResizeArray<'T>) = 
            Bindings.fc.subarray(xs, minLength, maxLength)

        /// Creates a ResizeArray of ResizeArrays arbitrary from a given arbitrary.
        let inline twoDimOfDim (rows: int) (cols: int) (arb: Arbitrary<'T>) =
            List.ofLength (rows * cols) arb
            |> map (fun arr -> 
                List.chunkBySize rows arr 
                |> List.map ResizeArray 
                |> ResizeArray) 
            
        /// Creates a ResizeArray of ResizeArrays arbitrary from a given arbitrary.
        let inline twoDimOf (arb: Arbitrary<'T>) =
            arbitrary {
                let! rows = ConstrainedDefaults.integer(0, 200)
                let! cols = ConstrainedDefaults.integer(0, 200)
                return! twoDimOfDim rows cols arb 
            }
    
    module Seq =
        let inline traverse f (arbs: Arbitrary<'T> seq) =
            constant Seq.empty
            |> Seq.foldBack (fun x xs ->
                let x' = x |> bind f
                map2 (fun h t -> Seq.append (Seq.singleton(h)) t) x' xs
            ) arbs
    
        let inline sequence (arbs: Arbitrary<'T> seq) =
            traverse (constant) arbs
    
        let inline ofLength (size: int) (arb: Arbitrary<'T>) =
            Seq.init size (fun _ -> arb)
            |> sequence
    
        let inline ofRange (min: int) (max: int) (arb: Arbitrary<'T>) =
            ConstrainedDefaults.integer(min, max)
            |> map(fun i -> 
                Seq.init i (fun _ -> arb))
            |> bind sequence
    
        /// Creates an arbitrary of a collection that is shuffled.
        let inline shuffle (xs: 'T seq) =
            let xs = xs |> Seq.toArray
            Array.copy xs
            |> Array.yatesShuffle
            |> map Seq.ofArray

        /// Creates an arbitrary of a collection of a given length 
        /// such that all elements have the given sum.
        let inline piles k sum = 
            Array.piles k sum
            |> map Seq.ofArray

        /// Creates an arbitrary that is shuffled and a sub-section of the given collection.
        let inline shuffledSub (originalArray: 'T seq) = 
            Bindings.fc.shuffledSubarray(originalArray)
            |> map (fun r -> r :> seq<'T>)
        
        /// Creates an arbitrary that is shuffled and a sub-section of the given collection.
        let inline shuffledSubOfSize (minLength: int) (maxLength: int) (xs: 'T seq) = 
            Bindings.fc.shuffledSubarray(xs, minLength, maxLength)
            |> map (fun r -> r :> seq<'T>)

        /// Creates an arbitrary that is a sub-section of the given collection.
        let inline sub (xs: 'T seq) = 
            Bindings.fc.subarray(ResizeArray xs)
            |> map (fun r -> r :> seq<'T>)
            
        /// Creates an arbitrary that is a sub-section of the given collection.
        let inline subOfSize (minLength: int) (maxLength: int) (xs: 'T seq) = 
            Bindings.fc.subarray(ResizeArray xs, minLength, maxLength)
            |> map (fun r -> r :> seq<'T>)

        /// Creates a seq of seqs arbitrary from a given arbitrary.
        let inline twoDimOfDim (rows: int) (cols: int) (arb: Arbitrary<'T>) =
            Seq.chunkBySize rows <!> ofLength (rows * cols) arb

        /// Creates a seq of seqs arbitrary from a given arbitrary.
        let inline twoDimOf (arb: Arbitrary<'T>) =
            arbitrary {
                let! rows = ConstrainedDefaults.integer(0, 200)
                let! cols = ConstrainedDefaults.integer(0, 200)
                return! twoDimOfDim rows cols arb 
            }

    module Set =
        let ofRange (min: int) (max: int) (arb: Arbitrary<'T>) =
            List.ofRange min max arb |> map Set.ofList

        let ofLength (length: int) (arb: Arbitrary<'T>) =
            List.ofLength length arb |> map Set.ofList

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    module rec Auto =
        let primitive<'T> (type': System.Type) =
            let t = type'.FullName

            if t = typeof<bigint>.FullName then Defaults.bigInt |> box |> Some
            elif t = typeof<bool>.FullName then Defaults.boolean |> box |> Some
            elif t = typeof<byte>.FullName then Defaults.byte |> box |> Some
            elif t = typeof<char>.FullName then Defaults.char |> box |> Some
            elif t = typeof<DateTime>.FullName then Defaults.dateTime |> box |> Some
            elif t = typeof<DateTimeOffset>.FullName then Defaults.dateTimeOffset |> box |> Some
            elif t = typeof<decimal>.FullName then unbox<decimal> Defaults.integer |> box |> Some
            elif t = typeof<exn>.FullName then Defaults.exn |> box |> Some
            elif t = typeof<float>.FullName then unbox<float> Defaults.integer |> box |> Some
            elif t = typeof<float32>.FullName then Defaults.float32 |> box |> Some
            elif t = typeof<Guid>.FullName then Defaults.guid |> box |> Some
            elif t = typeof<int16>.FullName then Defaults.int16 |> box |> Some
            elif t = typeof<int32>.FullName then Defaults.integer |> box |> Some
            elif t = typeof<obj>.FullName then Defaults.object |> box |> Some
            elif t = typeof<Regex>.FullName then Defaults.regex |> box |> Some
            elif t = typeof<sbyte>.FullName then Defaults.sbyte |> box |> Some
            elif t = typeof<string>.FullName then Defaults.string |> box |> Some
            elif t = typeof<TimeSpan>.FullName then Defaults.timeSpan |> box |> Some
            elif t = typeof<uint16>.FullName then Defaults.uint16 |> box |> Some
            elif t = typeof<uint32>.FullName then Defaults.uint32 |> box |> Some
            elif t = typeof<unit>.FullName then constant () |> box |> Some
            else None
            |> Option.map unbox<Arbitrary<'T>>

        let gen<'T> (t: System.Type) : Arbitrary<'T> =
            match primitive<'T>(t) with
            | Some res -> res
            | None ->
                if FSharpType.IsTuple t then mkTuple t |> box
                elif FSharpType.IsRecord(t, allowAccessToPrivateRepresentation = true) then 
                    mkRecord t |> box
                elif FSharpType.IsUnion(t, allowAccessToPrivateRepresentation = true) then 
                    mkDU t |> box
                elif FSharpType.IsFunction t then
                    try t.GetGenericArguments().[1] |> Some
                    with _ -> None
                    |> Option.map gen
                    |> function
                    | Some res -> res |> func |> box
                    | None -> 
                        FSharpType.GetFunctionElements(t) 
                        |> snd 
                        |> gen
                        |> func 
                        |> box
                elif t.IsArray then 
                    t.GetElementType() 
                    |> gen 
                    |> Array.ofRange 0 10 
                    |> box
                elif t.IsEnum then
                    t.GetEnumValues()
                    |> unbox<array<_>>
                    |> Array.map (fun o -> constant o)
                    |> Seq.sequence
                    |> bind elements
                    |> map (fun o -> System.Enum.Parse(t, o.ToString()))
                    |> box
                elif t.IsGenericType then
                    match t.GetGenericTypeDefinition() with
                    | tDef when tDef = typedefof<Option<_>> -> 
                        t.GenericTypeArguments.[0] 
                        |> gen 
                        |> option 
                        |> box
                    | tDef when tDef = typedefof<List<_>> ->
                        t.GenericTypeArguments.[0] 
                        |> gen 
                        |> List.ofRange 0 10
                        |> box
                    | tDef when tDef = typedefof<seq<_>> ->
                        t.GenericTypeArguments.[0] 
                        |> gen 
                        |> Seq.ofRange 0 10
                        |> box
                    | tDef when tDef = typedefof<ResizeArray<_>> ->
                        t.GenericTypeArguments.[0] 
                        |> gen 
                        |> ResizeArray.ofRange 0 10
                        |> box
                    | tDef when tDef = typedefof<Result<_,_>> ->
                        let ok = t.GenericTypeArguments.[0] |> gen 
                        let err = t.GenericTypeArguments.[1] |> gen
                        
                        result ok err |> box
                    | tDef when tDef = typedefof<System.Collections.Generic.Dictionary<_,_>> ->
                        let keys = 
                            t.GenericTypeArguments.[0] 
                            |> gen
                            |> map (fun k -> unbox<IComparable> k)
                        let values = t.GenericTypeArguments.[1] |> gen

                        Map.ofRange 1 10 keys values
                        |> map (Map.toSeq >> dict)
                        |> box
                    | tDef when tDef = typedefof<Map<_,_>> -> mkMap t |> box
                    | tDef when tDef = typedefof<Set<_>> -> mkSet t |> box
                    | tDef when tDef = typedefof<Async<_>> ->
                        t.GenericTypeArguments.[0]
                        |> gen 
                        |> map (fun res -> async { return res })
                        |> box
                    | tDef when tDef = typedefof<JS.Promise<_>> ->
                        t.GenericTypeArguments.[0]
                        |> gen 
                        |> map (fun res -> promise { return res })
                        |> box
                    | tDef when tDef = typedefof<JS.Set<_>> ->
                        mkSet t
                        |> map (Set.toSeq >> (fun s -> JS.Constructors.Set.Create(s)))
                        |> box
                    | tDef when tDef = typedefof<JS.Map<_,_>> ->
                        mkMap t 
                        |> map (Map.toSeq >> (fun s -> JS.Constructors.Map.Create(s))) 
                        |> box
                    | _ -> failwithf "Unsupported type for auto generation: %s" t.FullName
                else failwithf "Unsupported type for auto generation: %s" t.FullName
                |> unbox<Arbitrary<'T>>

        let mkMap (t: System.Type) =
            let keys = 
                t.GenericTypeArguments.[0] 
                |> gen
                |> map (fun k -> unbox<IComparable> k)
            let values = t.GenericTypeArguments.[1] |> gen

            Map.ofRange 1 10 keys values

        let mkSet (t: System.Type) =
            t.GenericTypeArguments.[0] 
            |> gen 
            |> map (fun v -> unbox<IComparable> v)
            |> Set.ofRange 0 10 

        let mkTuple (type': System.Type) =
            FSharpType.GetTupleElements(type') 
            |> Array.map gen
            |> Array.sequence
            |> bind (fun arr ->
                FSharpValue.MakeTuple(arr, type')
                |> constant)

        let mkRecord (type': System.Type) =
            let names, arbs =
                FSharpType.GetRecordFields(type', allowAccessToPrivateRepresentation = true)
                |> Array.map (fun field -> (field.Name, gen field.PropertyType))
                |> Array.unzip

            Array.sequence arbs
            |> map (fun fields ->
                Array.zip names fields
                |> List.ofArray
                |> fun res -> createObj !!res)

        let mkDUAllCases<'T> (type': System.Type) =
            FSharpType.GetUnionCases(type', allowAccessToPrivateRepresentation = true)
            |> Array.map (fun uc -> 
                uc.GetFields()
                |> Array.map (fun field -> gen field.PropertyType)
                |> Array.sequence
                |> map(fun o -> FSharpValue.MakeUnion(uc, o) :?> 'T))
            |> List.ofArray
            |> List.sequence

        let mkDU (type': System.Type) =
            FSharpType.GetUnionCases(type', allowAccessToPrivateRepresentation = true)
            |> Array.map (fun uc -> 
                uc.GetFields()
                |> Array.map (fun field -> gen field.PropertyType)
                |> Array.sequence
                |> map (fun o -> FSharpValue.MakeUnion(uc, o) :?> 'T))
            |> List.ofArray
            |> List.sequence
            |> bind elements

    /// Attempts to auto generate arbitraries for a given type.
    ///
    /// This is mostly intended for very complex types that
    /// would be very cumbersome to write an Arbitrary for.
    ///
    /// All types generated from this will use the default 
    /// Arbitrary for each primitive.
    ///
    /// Classes are not supported, see https://github.com/fable-compiler/Fable/issues/2027
    let inline auto<'T> () : Arbitrary<'T> =
        Auto.gen<'T> typeof<'T>

type Arbitrary =
    /// Creates an arbitrary of elmish commands to use with runModel.
    static member inline elmish (init: 'Model * Elmish.Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: ('Msg -> 'Model -> 'Model -> unit)) =
        let model = Model<'Model,'Msg>(init, update)
        let real = Model<'Model,'Msg>(init, update)
        let cmds = 
            arbitrary {
                let! msgs = Arbitrary.Auto.mkDUAllCases<'Msg> typeof<'Msg>

                return!
                    msgs
                    |> List.map (fun msg -> 
                        Msg<'Model,'Msg>(msg, asserter) :> ICommand<Model<'Model,'Msg>,Model<'Model,'Msg>>
                        |> Arbitrary.constant)
                    |> Arbitrary.commands
            }
            
        Arbitrary.zip3 (Arbitrary.clonedConstant model) (Arbitrary.clonedConstant real) cmds
    /// Creates an arbitrary of elmish commands to use with runModel.
    static member inline elmish (init: 'Model * Elmish.Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: ('Msg -> 'Model -> 'Model -> unit), msgs: Arbitrary<'Msg list>) =
        let model = Model<'Model,'Msg>(init, update)
        let real = Model<'Model,'Msg>(init, update)
        let cmds = 
            arbitrary {
                let! msgs = msgs

                return!
                    msgs
                    |> List.map (fun msg -> 
                        Msg<'Model,'Msg>(msg, asserter) :> ICommand<Model<'Model,'Msg>,Model<'Model,'Msg>>
                        |> Arbitrary.constant)
                    |> Arbitrary.commands
            }
            
        Arbitrary.zip3 (Arbitrary.clonedConstant model) (Arbitrary.clonedConstant real) cmds
    /// Creates an arbitrary of elmish commands to use with runModel.
    static member inline elmish (init: 'Model, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: ('Msg -> 'Model -> 'Model -> unit)) =
        let model = Model<'Model,'Msg>((init, Elmish.Cmd.none), update)
        let real = Model<'Model,'Msg>((init, Elmish.Cmd.none), update)
        let cmds = 
            arbitrary {
                let! msgs = Arbitrary.Auto.mkDUAllCases<'Msg> typeof<'Msg>

                return!
                    msgs
                    |> List.map (fun msg -> 
                        Msg<'Model,'Msg>(msg, asserter) :> ICommand<Model<'Model,'Msg>,Model<'Model,'Msg>>
                        |> Arbitrary.constant)
                    |> Arbitrary.commands
            }
        
        Arbitrary.zip3 (Arbitrary.clonedConstant model) (Arbitrary.clonedConstant real) cmds
    /// Creates an arbitrary of elmish commands to use with runModel.
    static member inline elmish (init: 'Model, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: ('Msg -> 'Model -> 'Model -> unit), msgs: Arbitrary<'Msg list>) =
        let model = Model<'Model,'Msg>((init, Elmish.Cmd.none), update)
        let real = Model<'Model,'Msg>((init, Elmish.Cmd.none), update)
        let cmds = 
            arbitrary {
                let! msgs = msgs

                return!
                    msgs
                    |> List.map (fun msg -> 
                        Msg<'Model,'Msg>(msg, asserter) :> ICommand<Model<'Model,'Msg>,Model<'Model,'Msg>>
                        |> Arbitrary.constant)
                    |> Arbitrary.commands
            }
        
        Arbitrary.zip3 (Arbitrary.clonedConstant model) (Arbitrary.clonedConstant real) cmds
    /// Creates an arbitrary of elmish commands to use with runModel.
    static member inline elmish (init: 'Model, update: 'Msg -> 'Model -> 'Model, asserter: ('Msg -> 'Model -> 'Model -> unit)) =
        let model = Model<'Model,'Msg>((init, Elmish.Cmd.none), (fun msg model -> update msg model, Elmish.Cmd.none))
        let real = Model<'Model,'Msg>((init, Elmish.Cmd.none), (fun msg model -> update msg model, Elmish.Cmd.none))
        let cmds = 
            arbitrary {
                let! msgs = Arbitrary.Auto.mkDUAllCases<'Msg> typeof<'Msg>

                return!
                    msgs
                    |> List.map (fun msg -> 
                        Msg<'Model,'Msg>(msg, asserter) :> ICommand<Model<'Model,'Msg>,Model<'Model,'Msg>>
                        |> Arbitrary.constant)
                    |> Arbitrary.commands
            }
        
        Arbitrary.zip3 (Arbitrary.clonedConstant model) (Arbitrary.clonedConstant real) cmds
    /// Creates an arbitrary of elmish commands to use with runModel.
    static member inline elmish (init: 'Model, update: 'Msg -> 'Model -> 'Model, asserter: ('Msg -> 'Model -> 'Model -> unit), msgs: Arbitrary<'Msg list>) =
        let model = Model<'Model,'Msg>((init, Elmish.Cmd.none), (fun msg model -> update msg model, Elmish.Cmd.none))
        let real = Model<'Model,'Msg>((init, Elmish.Cmd.none), (fun msg model -> update msg model, Elmish.Cmd.none))
        let cmds = 
            arbitrary {
                let! msgs = msgs

                return!
                    msgs
                    |> List.map (fun msg -> 
                        Msg<'Model,'Msg>(msg, asserter) :> ICommand<Model<'Model,'Msg>,Model<'Model,'Msg>>
                        |> Arbitrary.constant)
                    |> Arbitrary.commands
            }
        
        Arbitrary.zip3 (Arbitrary.clonedConstant model) (Arbitrary.clonedConstant real) cmds

module Operators =
    /// Infix apply.
    let inline (<*>) f m = Arbitrary.apply f m
    
    /// Infix map.
    let inline (<!>) f m = Arbitrary.map f m
    
    /// Infix bind.
    let inline (>>=) f m = Arbitrary.bind f m
    
    /// Infix bind (right to left).
    let inline (=<<) m f = Arbitrary.bind f m

    /// Left-to-right Kleisli composition
    let inline (>=>) f g = fun x -> f x >>= g

    /// Right-to-left Kleisli composition
    let inline (<=<) x = (fun f a b -> f b a) (>=>) x
