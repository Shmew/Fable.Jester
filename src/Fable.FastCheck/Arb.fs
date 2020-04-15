namespace Fable.FastCheck

open ElmishModel
open Fable.Core
open Fable.Core.JsInterop
open System
open System.ComponentModel

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
        /// For any type of values following the constraints defined by `settings`
        /// 
        /// You may use sample to preview the values that will be generated
        /// Constraints to apply when building instances
        static member inline anything (constraints: IObjConstraintProperty list) = Bindings.fc.anything(constraints)
        
        /// For strings of ascii
        /// Upper bound of the generated string length
        static member inline asciiString (maxLength: int) = Bindings.fc.asciiString(maxLength)
        /// For strings of ascii
        /// Lower bound of the generated string length
        /// Upper bound of the generated string length
        static member inline asciiString (minLength: int, maxLength: int) = Bindings.fc.asciiString(minLength, maxLength)
        
        /// For base64 strings
        /// 
        /// A base64 string will always have a length multiple of 4 (padded with =)
        /// Upper bound of the generated string length
        static member inline base64String (maxLength: int) = Bindings.fc.base64String(maxLength)
        /// For base64 strings
        /// 
        /// A base64 string will always have a length multiple of 4 (padded with =)
        /// Lower bound of the generated string length
        /// Upper bound of the generated string length
        static member inline base64String (minLength: int, maxLength: int) = Bindings.fc.base64String(minLength, maxLength)
        
        /// For date between constraints.min or new Date(-8640000000000000) (included) and constraints.max or new Date(8640000000000000) (included)
        static member inline date (constraints: IDateConstraintProperty list) = Bindings.fc.date(constraints)
        
        /// For floating point numbers between 0.0 (included) and max (excluded) - accuracy of `max / 2**53`
        /// Upper bound of the generated floating point
        static member inline double (max: float) = Bindings.fc.double(max)
        /// For floating point numbers between min (included) and max (excluded) - accuracy of `(max - min) / 2**53`
        /// Lower bound of the generated floating point
        /// Upper bound of the generated floating point
        static member inline double (min: float, max: float) = Bindings.fc.double(min, max)
        
        /// For floating point numbers between 0.0 (included) and max (excluded) - accuracy of `max / 2**24`
        /// Upper bound of the generated floating point
        static member inline float (max: float) = Bindings.fc.float(max)
        /// For floating point numbers between min (included) and max (excluded) - accuracy of `(max - min) / 2**24`
        /// Lower bound of the generated floating point
        /// Upper bound of the generated floating point
        static member inline float (min: float, max: float) = Bindings.fc.float(min, max)
        
        /// For strings of fullUnicode
        /// Upper bound of the generated string length
        static member inline fullUnicodeString (maxLength: int) = Bindings.fc.fullUnicodeString(maxLength)
        /// For strings of fullUnicode
        /// Lower bound of the generated string length
        /// Upper bound of the generated string length
        static member inline fullUnicodeString (minLength: int, maxLength: int) = Bindings.fc.fullUnicodeString(minLength, maxLength)
        
        /// For strings of hexa
        /// Upper bound of the generated string length
        static member inline hexaString (maxLength: int) = Bindings.fc.hexaString(maxLength)
        /// For strings of hexa
        /// Lower bound of the generated string length
        /// Upper bound of the generated string length
        static member inline hexaString (minLength: int, maxLength: int) = Bindings.fc.hexaString(minLength, maxLength)
        
        /// For integers between -2147483648 (included) and max (included)
        /// Upper bound for the generated integers (eg.: 2147483647, Number.MAX_SAFE_INTEGER)
        static member inline integer (max: int) = Bindings.fc.integer(max)
        /// For integers between min (included) and max (included)
        /// Lower bound for the generated integers (eg.: 0, Number.MIN_SAFE_INTEGER)
        /// Upper bound for the generated integers (eg.: 2147483647, Number.MAX_SAFE_INTEGER)
        static member inline integer (min: int, max: int) = Bindings.fc.integer(min, max)
        
        /// For any JSON strings with a maximal depth
        /// 
        /// Keys and string values rely on string
        /// Maximal depth of the generated objects
        static member inline json (maxDepth: int) = Bindings.fc.json(maxDepth)
        
        /// For any JSON compliant values with a maximal depth
        /// 
        /// Keys and string values rely on string
        /// Maximal depth of the generated values
        static member inline jsonObject (maxDepth: int) = Bindings.fc.jsonObject(maxDepth)
        
        /// For lorem ipsum string of words with maximal number of words
        /// Upper bound of the number of words allowed
        static member inline lorem (maxWordsCount: float) = Bindings.fc.lorem(maxWordsCount)
        /// For lorem ipsum string of words or sentences with maximal number of words or sentences
        /// Upper bound of the number of words/sentences allowed
        /// If enabled, multiple sentences might be generated
        static member inline lorem (maxWordsCount: float, sentencesMode: bool) = 
            Bindings.fc.lorem(maxWordsCount, sentencesMode)
        
        /// For any objects following the constraints defined by `settings`
        /// 
        /// You may use sample to preview the values that will be generated
        /// Constraints to apply when building instances
        static member inline object (constraints: IObjConstraintProperty list) = 
            Bindings.fc.object(constraints)
        
        /// For scheduler of promises
        static member inline scheduler (act: ((unit -> JS.Promise<unit>) -> JS.Promise<unit>)) = 
            Bindings.fc.scheduler(Bindings.SchedulerAct.create act).map(fun s -> new Scheduler(s))

        /// For strings of char
        /// Upper bound of the generated string length
        static member inline string (maxLength: int) = Bindings.fc.string(maxLength)
        /// For strings of char
        /// Lower bound of the generated string length
        /// Upper bound of the generated string length
        static member inline string (minLength: int, maxLength: int) = Bindings.fc.string(minLength, maxLength)
        
        /// For strings of string16bits
        /// Upper bound of the generated string length
        static member inline string16bits (maxLength: int) = Bindings.fc.string16bits(maxLength)
        /// For strings of string16bits
        /// Lower bound of the generated string length
        /// Upper bound of the generated string length
        static member inline string16bits (minLength: int, maxLength: int) = Bindings.fc.string16bits(minLength, maxLength)
        
        /// For any JSON strings with unicode support and a maximal depth
        /// 
        /// Keys and string values rely on unicode
        /// Maximal depth of the generated objects
        static member inline unicodeJson (maxDepth: int) = Bindings.fc.unicodeJson(maxDepth)
        
        /// For any JSON compliant values with unicode support and a maximal depth
        /// 
        /// Keys and string values rely on unicode
        /// Maximal depth of the generated values
        static member inline unicodeJsonObject (maxDepth: int) = Bindings.fc.unicodeJsonObject(maxDepth)
        
        /// For strings of unicode
        /// Upper bound of the generated string length
        static member inline unicodeString (maxLength: int) = Bindings.fc.unicodeString(maxLength)
        /// For strings of unicode
        /// Lower bound of the generated string length
        /// Upper bound of the generated string length
        static member inline unicodeString (minLength: int, maxLength: int) = Bindings.fc.unicodeString(minLength, maxLength)
        
        /// For UUID of a given version (in v1 to v5)
        /// 
        /// According to RFC 4122 - https://tools.ietf.org/html/rfc4122
        /// 
        /// No mixed case, only lower case digits (0-9a-f)
        static member inline uuidV (versionNumber: IUuidVersionConstraintProperty) = Bindings.fc.uuidV(versionNumber)
        
        /// For web authority
        /// 
        /// According to RFC 3986 - https://www.ietf.org/rfc/rfc3986.txt - `authority = [ userinfo "@" ] host [ ":" port ]`
        static member inline webAuthority (constraints: IWebAuthorityConstraintProperty list) = Bindings.fc.webAuthority(constraints)
        
        /// For web url
        /// 
        /// According to RFC 3986 and WHATWG URL Standard
        /// - https://www.ietf.org/rfc/rfc3986.txt
        /// - https://url.spec.whatwg.org/
        static member inline webUrl (constraints: IWebUrlConstraintProperty list) = Bindings.fc.webUrl(constraints)    

    type Defaults =
        /// For any type of values
        /// 
        /// You may use sample to preview the values that will be generated
        static member inline anything = Bindings.fc.anything()

        /// For single ascii characters - char code between 0x00 (included) and 0x7f (included)
        static member inline ascii = Bindings.fc.ascii()

        /// For strings of ascii
        static member inline asciiString = Bindings.fc.asciiString()
        
        /// For single base64 characters - A-Z, a-z, 0-9, + or /
        static member inline base64 = Bindings.fc.base64()
        
        /// For base64 strings
        /// 
        /// A base64 string will always have a length multiple of 4 (padded with =)
        static member inline base64String = Bindings.fc.base64String()
        
        /// For booleans
        static member inline boolean = Bindings.fc.boolean()
        
        /// For single printable ascii characters - char code between 0x20 (included) and 0x7e (included)
        static member inline char = Bindings.fc.char()
        
        /// For single characters - all values in 0x0000-0xffff can be generated
        /// 
        /// WARNING:
        /// 
        /// Some generated characters might appear invalid regarding UCS-2 and UTF-16 encoding.
        /// Indeed values within 0xd800 and 0xdfff constitute surrogate pair characters and are illegal without their paired character.
        static member inline char16bits = Bindings.fc.char16bits()
        
        /// For comparison boolean functions
        /// 
        /// A comparison boolean function returns:
        /// - true whenever a < b
        /// - false otherwise (ie. a = b or a > b)
        static member inline compareBooleanFunc = Bindings.fc.compareBooleanFunc()
        
        /// For comparison functions
        /// 
        /// A comparison function returns:
        /// - negative value whenever a < b
        /// - positive value whenever a > b
        /// - zero whenever a and b are equivalent
        /// 
        /// Comparison functions are transitive: `a < b and b < c => a < c`
        /// 
        /// They also satisfy: `a < b <=> b > a` and `a = b <=> b = a`
        static member inline compareFunc = Bindings.fc.compareFunc()
        
        /// For date between constraints.min or new Date(-8640000000000000) (included) and constraints.max or new Date(8640000000000000) (included)
        static member inline date = Bindings.fc.date()
        
        /// For domains
        /// having an extension with at least two lowercase characters
        /// 
        /// According to RFC 1034, RFC 1123 and WHATWG URL Standard
        /// - https://www.ietf.org/rfc/rfc1034.txt
        /// - https://www.ietf.org/rfc/rfc1123.txt
        /// - https://url.spec.whatwg.org/
        static member inline domain = Bindings.fc.domain()
        
        /// For floating point numbers between 0.0 (included) and 1.0 (excluded) - accuracy of `1 / 2**53`
        static member inline double = Bindings.fc.double()
        
        /// For email address
        /// 
        /// According to RFC 5322 - https://www.ietf.org/rfc/rfc5322.txt
        static member inline emailAddress = Bindings.fc.emailAddress()
        
        /// For floating point numbers between 0.0 (included) and 1.0 (excluded) - accuracy of `1 / 2**24`
        static member inline float = Bindings.fc.float()
        
        /// For single unicode characters - any of the code points defined in the unicode standard
        /// 
        /// WARNING: Generated values can have a length greater than 1.
        static member inline fullUnicode = Bindings.fc.fullUnicode()
        
        /// For strings of fullUnicode
        static member inline fullUnicodeString = Bindings.fc.fullUnicodeString()
        
        /// For single hexadecimal characters - 0-9 or a-f
        static member inline hexa = Bindings.fc.hexa()
        
        /// For strings of hexa
        static member inline hexaString = Bindings.fc.hexaString()
        
        /// For integers between -2147483648 (included) and 2147483647 (included)
        static member integer = Bindings.fc.integer()
        
        /// For valid IP v4
        /// 
        /// Following RFC 3986
        /// https://tools.ietf.org/html/rfc3986#section-3.2.2
        static member inline ipV4 = Bindings.fc.ipV4()
        
        /// For valid IP v4 according to WhatWG
        /// 
        /// Following WhatWG, the specification for web-browsers
        /// https://url.spec.whatwg.org/
        /// 
        /// There is no equivalent for IP v6 according to the IP v6 parser
        /// https://url.spec.whatwg.org/#concept-ipv6-parser
        static member inline ipV4Extended = Bindings.fc.ipV4Extended()
        
        /// For valid IP v6
        /// 
        /// Following RFC 3986
        /// https://tools.ietf.org/html/rfc3986#section-3.2.2
        static member inline ipV6 = Bindings.fc.ipV6()
        
        /// For any JSON strings
        /// 
        /// Keys and string values rely on string
        static member inline json = Bindings.fc.json()

        /// For any JSON compliant values
        /// 
        /// Keys and string values rely on string
        static member inline jsonObject = Bindings.fc.jsonObject()
        
        /// For lorem ipsum strings of words
        static member inline lorem = Bindings.fc.lorem()
        
        /// For integers between Number.MIN_SAFE_INTEGER (included) and Number.MAX_SAFE_INTEGER (included)
        static member inline maxSafeInteger = Bindings.fc.maxSafeInteger()
        
        /// For positive integers between 0 (included) and Number.MAX_SAFE_INTEGER (included)
        static member inline maxSafeNat = Bindings.fc.maxSafeNat()
        
        /// For any objects
        /// 
        /// You may use sample to preview the values that will be generated
        static member inline object = Bindings.fc.object()
        
        /// For scheduler of promises
        static member inline scheduler = Bindings.fc.scheduler().map(fun s -> Scheduler(s))

        /// For strings of char
        static member inline string = Bindings.fc.string()
        
        /// For strings of string16bits
        static member inline string16bits = Bindings.fc.string16bits()
        
        /// For single unicode characters defined in the BMP plan - char code between 0x0000 (included) and 0xffff (included) and without the range 0xd800 to 0xdfff (surrogate pair characters)
        static member inline unicode = Bindings.fc.unicode()
        
        /// For any JSON strings with unicode support
        /// 
        /// Keys and string values rely on unicode
        static member inline unicodeJson = Bindings.fc.unicodeJson()
        
        /// For any JSON compliant values with unicode support
        /// 
        /// Keys and string values rely on unicode
        static member inline unicodeJsonObject = Bindings.fc.unicodeJsonObject()
        
        /// For strings of unicode
        static member inline unicodeString = Bindings.fc.unicodeString()
        
        /// For UUID from v1 to v5
        /// 
        /// According to RFC 4122 - https://tools.ietf.org/html/rfc4122
        /// 
        /// No mixed case, only lower case digits (0-9a-f)
        static member inline uuid = Bindings.fc.uuid()
        
        /// For web authority
        /// 
        /// According to RFC 3986 - https://www.ietf.org/rfc/rfc3986.txt - `authority = [ userinfo "@" ] host [ ":" port ]`
        static member inline webAuthority = Bindings.fc.webAuthority()
        
        /// For fragments of an URI (web included)
        /// 
        /// According to RFC 3986 - https://www.ietf.org/rfc/rfc3986.txt
        /// 
        /// eg.: In the url `https://domain/plop?page=1#hello=1&world=2`, `?hello=1&world=2` are query parameters
        static member inline webFragments = Bindings.fc.webFragments()
        
        /// For query parameters of an URI (web included)
        /// 
        /// According to RFC 3986 - https://www.ietf.org/rfc/rfc3986.txt
        /// 
        /// eg.: In the url `https://domain/plop/?hello=1&world=2`, `?hello=1&world=2` are query parameters
        static member inline webQueryParameters = Bindings.fc.webQueryParameters()
        
        /// For internal segment of an URI (web included)
        /// 
        /// According to RFC 3986 - https://www.ietf.org/rfc/rfc3986.txt
        /// 
        /// eg.: In the url `https://github.com/dubzzz/fast-check/`, `dubzzz` and `fast-check` are segments
        static member inline webSegment = Bindings.fc.webSegment()
        
        /// For web url
        /// 
        /// According to RFC 3986 and WHATWG URL Standard
        /// - https://www.ietf.org/rfc/rfc3986.txt
        /// - https://url.spec.whatwg.org/
        static member inline webUrl = Bindings.fc.webUrl()

    let inline apply (arbF: Arbitrary<'T -> 'U>, arb: Arbitrary<'T>) =
        arbF.bind(fun f -> arb.map f)

    let inline bind (f: 'A -> Arbitrary<'B>) (arb: Arbitrary<'A>) = arb.bind(f)
    
    let inline bind2 (f: 'A -> 'B -> Arbitrary<'C>) (a: Arbitrary<'A>) (b: Arbitrary<'B>) = 
        apply(a.map(f), b) |> bind id

    /// For `value`
    /// The value to produce
    let inline clonedConstant (value: 'T) = Bindings.fc.clonedConstant(value)
        
    /// For `value`
    /// The value to produce
    let inline constant (value: 'T) = Bindings.fc.constant(value)
                
    /// For arrays of AsyncCommand to be executed by asyncModelRun
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than array for AsyncCommand arrays.
    /// Arbitraries responsible to build commands
    /// Maximal number of commands to build
    let inline asyncCommands (commandArbs: Arbitrary<IAsyncCommand<'Model,'Real>> list) = 
        Bindings.fc.commands(ResizeArray commandArbs, ?maxCommands = None)

    /// For arrays of AsyncCommand to be executed by asyncModelRun
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than array for AsyncCommand arrays.
    /// Arbitraries responsible to build commands
    /// Maximal number of commands to build
    let inline asyncCommandsOfMax (maxCommands: int) (commandArbs: Arbitrary<IAsyncCommand<'Model,'Real>> list) = 
        Bindings.fc.commands(ResizeArray commandArbs, maxCommands = maxCommands)

    /// For arrays of AsyncCommand to be executed by asyncModelRun
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than array for AsyncCommand arrays.
    /// Arbitraries responsible to build commands
    let inline asyncCommandsOfSettings (settings: ICommandConstraintProperty list) (commandArbs: Arbitrary<IAsyncCommand<'Model,'Real>> list) = 
        Bindings.fc.commands(ResizeArray commandArbs, settings = createObj !!(settings))

    /// For arrays of Command to be executed by modelRun
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than array for Command arrays.
    /// Arbitraries responsible to build commands
    /// Maximal number of commands to build
    let inline commands (commandArbs: Arbitrary<ICommand<'Model,'Real>> list) = 
        Bindings.fc.commands(ResizeArray commandArbs, ?maxCommands = None)
    
    /// For arrays of AsyncCommand to be executed by asyncModelRun
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than array for AsyncCommand arrays.
    /// Arbitraries responsible to build commands
    /// Maximal number of commands to build
    let inline commandsOfMax (maxCommands: int) (commandArbs: Arbitrary<ICommand<'Model,'Real>> list) = 
        Bindings.fc.commands(ResizeArray commandArbs, maxCommands = maxCommands)

    /// For arrays of AsyncCommand to be executed by asyncModelRun
    /// 
    /// This implementation comes with a shrinker adapted for commands.
    /// It should shrink more efficiently than array for AsyncCommand arrays.
    /// Arbitraries responsible to build commands
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

    let inline filter f (a: Arbitrary<'T>) = a.filter f

    let inline fresh fv = arbitrary { let a = fv() in return a }
    
    let inline func (arb: Arbitrary<'TOut>) = Bindings.fc.func(arb)

    /// Produce an infinite stream of values
    /// 
    /// WARNING: Requires Object.assign
    /// Arbitrary used to generate the values
    let inline infiniteStream (arb: Arbitrary<'T>) = 
        Bindings.fc.infiniteStream(arb)

    let inline map (f: 'A -> 'B) (a: Arbitrary<'A>) = a.map(f)
    
    let inline map2 (f: 'A -> 'B -> 'C) (a: Arbitrary<'A>) (b: Arbitrary<'B>) =
        apply(map f a, b)
    
    let inline map3 (f: 'A -> 'B -> 'C -> 'D) (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>) =
        apply(apply(map f a, b), c)
    
    let inline map4 (f: 'A -> 'B -> 'C -> 'D -> 'E) (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>) (d: Arbitrary<'D>) =
        apply(apply(apply(map f a, b), c), d)
    
    let inline map5 (f: 'A -> 'B -> 'C -> 'D -> 'E -> 'G) (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>) (d: Arbitrary<'D>) (e: Arbitrary<'E>) =
        apply(apply(apply(apply(map f a, b), c), d), e)
    
    let inline map6 (f: 'A -> 'B -> 'C -> 'D -> 'E -> 'G -> 'H) (a: Arbitrary<'A>) (b: Arbitrary<'B>) (c: Arbitrary<'C>) (d: Arbitrary<'D>) (e: Arbitrary<'E>) (g: Arbitrary<'G>) =
        apply(apply(apply(apply(apply(map f a, b), c), d), e), g)
    
    /// Randomly switch the case of characters generated by `stringArb` (upper/lower)
    /// 
    /// WARNING:
    /// Require any support.
    /// Under-the-hood the arbitrary relies on any to compute the flags that should be toggled or not.
    /// Arbitrary able to build string values
    /// Constraints to be applied when computing upper/lower case version
    let inline mixedCase (stringArb: Arbitrary<string>) = 
        Bindings.fc.mixedCase(stringArb)

    /// Randomly switch the case of characters generated by `stringArb` (upper/lower)
    /// 
    /// WARNING:
    /// Require any support.
    /// Under-the-hood the arbitrary relies on any to compute the flags that should be toggled or not.
    /// Arbitrary able to build string values
    /// Constraints to be applied when computing upper/lower case version
    let inline mixedCaseWithToggle (toggleCase: bool) (stringArb: Arbitrary<string>) = 
        Bindings.fc.mixedCase(stringArb, toggleCase)

    /// For either null or a value coming from `arb`
    /// Arbitrary that will be called to generate a non null value
    let inline option (arb: Arbitrary<'T>) = Bindings.fc.option(arb)

    /// For either null or a value coming from `arb` with custom frequency
    /// Arbitrary that will be called to generate a non null value
    /// The probability to build a null value is of `1 / freq`
    let inline optionOfFreq (freq: float) (arb: Arbitrary<'T>) = 
        Bindings.fc.option(arb, freq)

    /// For records following the `recordModel` schema
    /// Schema of the record
    let inline record (recordModel: Map<string,'T>) = 
        Bindings.fc.record(createObj !!(recordModel |> Map.toList))

    /// For records following the `recordModel` schema
    /// Schema of the record
    /// Contraints on the generated record
    let inline recordWithDeletedKeys (recordModel: Map<string,'T>) = 
        Bindings.fc.record(createObj !!(recordModel |> Map.toList), true)

    /// For strings using the characters produced by `charArb`
    let inline stringOf (charArb: Arbitrary<char>) = 
        Bindings.fc.stringOf(charArb)

    /// For strings using the characters produced by `charArb`
    /// Upper bound of the generated string length
    let inline stringOfMaxSize (maxLength: int) (charArb: Arbitrary<char>) = 
        Bindings.fc.stringOf(charArb, maxLength)

    /// For strings using the characters produced by `charArb`
    /// Lower bound of the generated string length
    /// Upper bound of the generated string length
    let inline stringOfSize (minLength: int) (maxLength: int)  (charArb: Arbitrary<char>) = 
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
        let inline traverse f (arbs: Arbitrary<'T> []) =
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

        let inline shuffle (xs: 'T []) =
            let xs = xs |> Seq.toArray
            Array.copy xs
            |> yatesShuffle

        let inline piles k sum =
            if k <= 0 then constant [||]
            else 
                arbitrary {
                    let result = Array.zeroCreate<int> k
                    let! n' = clonedConstant sum
                    let mutable n = n'

                    let! m' = clonedConstant sum
                    let mutable m = m'
                    
                    for i in k .. -1 .. 1 do
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

        let inline twoDimOfDim (rows: int) (cols: int) (arb: Arbitrary<'T>) =
            arbitrary {
                let! arr1 = ofLength (rows * cols) arb
                return Array2D.init rows cols (fun r c -> arr1.[cols * r + c])
            }

        let inline twoDimOf (arb: Arbitrary<'T>) =
            arbitrary {
                let! rows = ConstrainedDefaults.integer(0, 200)
                let! cols = ConstrainedDefaults.integer(0, 200)
                return! twoDimOfDim rows cols arb 
            }

        /// For subarrays of `originalArray`
        /// Original array
        let inline shuffledSub (originalArray: 'T []) = 
            Bindings.fc.shuffledSubarray(originalArray)
            |> map Array.ofSeq

        /// For subarrays of `originalArray`
        /// Original array
        /// Lower bound of the generated array size
        /// Upper bound of the generated array size
        let inline shuffledSubOfSize (minLength: int) (maxLength: int) (xs: 'T []) = 
            Bindings.fc.shuffledSubarray(xs, minLength, maxLength)
            |> map Array.ofSeq

        /// For subarrays of `originalArray` (keeps ordering)
        /// Original array
        let inline sub (xs: 'T []) = 
            Bindings.fc.subarray(ResizeArray xs)
            |> map Array.ofSeq

        /// For subarrays of `originalArray` (keeps ordering)
        /// Original array
        /// Lower bound of the generated array size
        /// Upper bound of the generated array size
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

        let inline shuffle (xs: 'T list) =
            let xs = xs |> Seq.toArray
            Array.copy xs
            |> Array.yatesShuffle
            |> map List.ofArray

        let inline piles k sum = 
            Array.piles k sum
            |> map List.ofArray

        /// For subarrays of `originalArray`
        /// Original array
        let inline shuffledSub (originalArray: 'T list) = 
            Bindings.fc.shuffledSubarray(originalArray)
            |> map List.ofSeq

        /// For subarrays of `originalArray`
        /// Original array
        /// Lower bound of the generated array size
        /// Upper bound of the generated array size
        let inline shuffledSubOfSize (minLength: int) (maxLength: int) (xs: 'T list) = 
            Bindings.fc.shuffledSubarray(xs, minLength, maxLength)
            |> map List.ofSeq

        /// For subarrays of `originalArray` (keeps ordering)
        /// Original array
        let inline sub (xs: 'T list) = 
            Bindings.fc.subarray(ResizeArray xs)
            |> map List.ofSeq

        /// For subarrays of `originalArray` (keeps ordering)
        /// Original array
        /// Lower bound of the generated array size
        /// Upper bound of the generated array size
        let inline subOfSize (minLength: int) (maxLength: int) (xs: 'T list) = 
            Bindings.fc.subarray(ResizeArray xs, minLength, maxLength)
            |> map List.ofSeq

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

        let inline shuffle (xs: ResizeArray<'T>) =
            let xs = xs |> Seq.toArray
            Array.copy xs
            |> Array.yatesShuffle
            |> map ResizeArray

        let inline piles k sum = 
            Array.piles k sum
            |> map ResizeArray

        /// For subarrays of `originalArray`
        /// Original array
        let inline shuffledSub (originalArray: ResizeArray<'T>) = 
            Bindings.fc.shuffledSubarray(originalArray)

        /// For subarrays of `originalArray`
        /// Original array
        /// Lower bound of the generated array size
        /// Upper bound of the generated array size
        let inline shuffledSubOfSize (minLength: int, maxLength: int) (xs: ResizeArray<'T>) = 
            Bindings.fc.shuffledSubarray(xs, minLength, maxLength)

        /// For subarrays of `originalArray` (keeps ordering)
        /// Original array
        let inline sub (xs: ResizeArray<'T>) = Bindings.fc.subarray(xs)

        /// For subarrays of `originalArray` (keeps ordering)
        /// Original array
        /// Lower bound of the generated array size
        /// Upper bound of the generated array size
        let inline subOfSize (minLength: int) (maxLength: int) (xs: ResizeArray<'T>) = 
            Bindings.fc.subarray(xs, minLength, maxLength)
    
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
    
        let inline shuffle (xs: 'T seq) =
            let xs = xs |> Seq.toArray
            Array.copy xs
            |> Array.yatesShuffle
            |> map Seq.ofArray

        let inline piles k sum = 
            Array.piles k sum
            |> map Seq.ofArray

        /// For subarrays of `originalArray`
        /// Original array
        let inline shuffledSub (originalArray: 'T seq) = 
            Bindings.fc.shuffledSubarray(originalArray)
            |> map (fun r -> r :> seq<'T>)
        
        /// For subarrays of `originalArray`
        /// Original array
        /// Lower bound of the generated array size
        /// Upper bound of the generated array size
        let inline shuffledSubOfSize (minLength: int) (maxLength: int) (xs: 'T seq) = 
            Bindings.fc.shuffledSubarray(xs, minLength, maxLength)
            |> map (fun r -> r :> seq<'T>)

        /// For subarrays of `originalArray` (keeps ordering)
        /// Original array
        let inline sub (xs: 'T seq) = 
            Bindings.fc.subarray(ResizeArray xs)
            |> map (fun r -> r :> seq<'T>)
            
        /// For subarrays of `originalArray` (keeps ordering)
        /// Original array
        /// Lower bound of the generated array size
        /// Upper bound of the generated array size
        let inline subOfSize (minLength: int) (maxLength: int) (xs: 'T seq) = 
            Bindings.fc.subarray(ResizeArray xs, minLength, maxLength)
            |> map (fun r -> r :> seq<'T>)

type Arbitrary =
    static member elmish (init: 'Model * Elmish.Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, assertions: ('Msg * ('Model -> 'Model -> unit)) list) =
        let model = Model<'Model,'Msg>(init, update)
        let real = Model<'Model,'Msg>(init, update)
        let cmds = 
            assertions
            |> List.map (fun (msg, assertion) -> 
                Msg<'Model,'Msg>(msg, assertion) :> ICommand<Model<'Model,'Msg>,Model<'Model,'Msg>>
                |> Arbitrary.constant)
            |> Arbitrary.commands
        
        Arbitrary.zip3 (Arbitrary.clonedConstant model) (Arbitrary.clonedConstant real) cmds
    static member elmish (init: 'Model, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, assertions: ('Msg * ('Model -> 'Model -> unit)) list) =
        let model = Model<'Model,'Msg>((init, Elmish.Cmd.none), update)
        let real = Model<'Model,'Msg>((init, Elmish.Cmd.none), update)
        let cmds = 
            assertions
            |> List.map (fun (msg, assertion) -> 
                Msg<'Model,'Msg>(msg, assertion) :> ICommand<Model<'Model,'Msg>,Model<'Model,'Msg>>
                |> Arbitrary.constant)
            |> Arbitrary.commands
        
        Arbitrary.zip3 (Arbitrary.clonedConstant model) (Arbitrary.clonedConstant real) cmds
    static member elmish (init: 'Model, update: 'Msg -> 'Model -> 'Model, assertions: ('Msg * ('Model -> 'Model -> unit)) list) =
        let model = Model<'Model,'Msg>((init, Elmish.Cmd.none), (fun msg model -> update msg model, Elmish.Cmd.none))
        let real = Model<'Model,'Msg>((init, Elmish.Cmd.none), (fun msg model -> update msg model, Elmish.Cmd.none))
        let cmds = 
            assertions
            |> List.map (fun (msg, assertion) -> 
                Msg<'Model,'Msg>(msg, assertion) :> ICommand<Model<'Model,'Msg>,Model<'Model,'Msg>>
                |> Arbitrary.constant)
            |> Arbitrary.commands
        
        Arbitrary.zip3 (Arbitrary.clonedConstant model) (Arbitrary.clonedConstant real) cmds
