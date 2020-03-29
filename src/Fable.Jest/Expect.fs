namespace Fable.Jest

open Fable.Core
open System.Text.RegularExpressions

[<AutoOpen>]
module Expect =
    /// The response structure of matcher extensions.
    type MatcherResponse =
        abstract pass: bool
        abstract message: unit -> string

    [<NoComparison>]
    [<NoEquality>]
    [<Global>]
    type expect =
        /// Add a module that formats application-specific data structures.
        ///
        /// `expect.addSnapshotSerializer(import "serializer" "my-serializer-module")`
        member _.addSnapshotSerializer (serializer: obj) = jsNative
        
        /// Matches anything that was created with the given constructor.
        member _.any (value: 'Constructor) = jsNative
        
        /// Matches anything but null or undefined.
        member _.anything () = jsNative

        /// Matches a received collection which contains all of the elements 
        /// in the expected array. That is, the expected collection is a 
        /// subset of the received collection. Therefore, it matches a 
        /// received collection which contains elements that are not in the 
        /// expected collection.
        member _.arrayContaining (values: ResizeArray<'T>) = jsNative
        /// Matches a received collection which contains all of the elements 
        /// in the expected array. That is, the expected collection is a 
        /// subset of the received collection. Therefore, it matches a 
        /// received collection which contains elements that are not in the 
        /// expected collection.
        [<Emit("$0.arrayContaining(Array.from($1))")>]
        member _.arrayContaining (values: 'T []) = jsNative
        /// Matches a received collection which contains all of the elements 
        /// in the expected array. That is, the expected collection is a 
        /// subset of the received collection. Therefore, it matches a 
        /// received collection which contains elements that are not in the 
        /// expected collection.
        [<Emit("$0.arrayContaining(Array.from($1))")>]
        member _.arrayContaining (values: 'T list) = jsNative
        /// Matches a received collection which contains all of the elements 
        /// in the expected array. That is, the expected collection is a 
        /// subset of the received collection. Therefore, it matches a 
        /// received collection which contains elements that are not in the 
        /// expected collection.
        [<Emit("$0.arrayContaining(Array.from($1))")>]
        member _.arrayContaining (values: 'T seq) = jsNative

        /// Verifies that a certain number of assertions are called 
        /// during a test.
        member _.assertions (number: int) = jsNative

        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: unit -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> 'd -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> 'd -> 'e -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> 'd -> 'e -> 'f -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> 'd -> 'e -> 'f -> 'g -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> 'd -> 'e -> 'f -> 'g -> 'h -> MatcherResponse) : 'Return = jsNative

        /// Verifies that at least one assertion is called during a test.
        member _.hasAssertions () : 'Return = jsNative

        /// Inverts the pass/fail status of a matcher.
        member _.not : expect = jsNative

        /// Matches any received object that recursively matches the 
        /// expected properties. That is, the expected object is a 
        /// subset of the received object. Therefore, it matches a 
        /// received object which contains properties that are 
        /// present in the expected object.
        member _.objectContaining (value: obj) = jsNative

        /// Matches the received value if it is a string that 
        /// contains the exact expected string.
        member _.stringContaining (value: string) = jsNative

        /// Matches the received value if it is a string that matches 
        /// the expected string or regular expression.
        member _.stringMatching (value: string) = jsNative
        /// Matches the received value if it is a string that matches 
        /// the expected string or regular expression.
        member _.stringMatching (value: Regex) = jsNative

    [<Global>]
    let expect : expect = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expected<'Return> =
        /// Inverts the pass/fail status of a matcher.
        member _.not : expected<'Return> = jsNative

        /// Compare primitive values or to check referential identity 
        /// of object instances. It calls Object.is to compare values, 
        /// which is even better for testing than === strict equality 
        /// operator.
        member _.toBe (value: 'T) : 'Return = jsNative
        
        /// Check that an object has a .length property and it is set 
        /// to a certain numeric value.
        member _.toHaveLength (length: int) : 'Return = jsNative
        
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        member _.toHaveProperty (keyPath: string, ?value: 'T) : 'Return = jsNative
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        [<Emit("$0.toHaveProperty((Array.from($1).join('.')) ...)")>]
        member _.toHaveProperty (keyPath: string list) : 'Return = jsNative
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        [<Emit("$0.toHaveProperty((Array.from($1).join('.')), $2)")>]
        member _.toHaveProperty (keyPath: string list, value: 'T) : 'Return = jsNative

        /// Compare floating point numbers for approximate equality.
        member _.toBeCloseTo(number: float, ?numDigits: int) : 'Return = jsNative
        
        /// Check that a variable is not undefined.
        member _.toBeDefined () : 'Return = jsNative

        /// Matcher for when you don't care what a value is and you want to 
        /// ensure a value is false in a boolean context.
        member _.toBeFalsy () : 'Return = jsNative

        /// To compare received > expected for int or floats.
        member _.toBeGreaterThan (number: float) : 'Return = jsNative
        /// To compare received > expected for int or floats.
        member _.toBeGreaterThan (number: int) : 'Return = jsNative

        /// To compare received >= expected for int or floats.
        member _.toBeGreaterThanOrEqual (number: float) : 'Return = jsNative
        /// To compare received >= expected for int or floats.
        member _.toBeGreaterThanOrEqual (number: int) : 'Return = jsNative

        /// To compare received < expected for int or floats.
        member _.toBeLessThan (number: float) : 'Return = jsNative
        /// To compare received < expected for int or floats.
        member _.toBeLessThan (number: int) : 'Return = jsNative

        /// To compare received <= expected for int or floats.
        member _.toBeLessThanOrEqual (number: float) : 'Return = jsNative
        /// To compare received <= expected for int or floats.
        member _.toBeLessThanOrEqual (number: int) : 'Return = jsNative

        /// Check that something is null.
        member _.toBeNull () : 'Return = jsNative

        /// Matcher for when you don't care what a value is and you want to 
        /// ensure a value is true in a boolean context.
        member _.toBeTruthy () : 'Return = jsNative

        /// Check that a variable is undefined.
        member _.toBeUndefined () : 'Return = jsNative

        /// Check that a value is NaN.
        member _.toBeNaN () : 'Return = jsNative

        /// Check that an item is in a collection.
        ///
        /// Note that this matcher will check *both* the 
        /// index and values if given a int or float. 
        ///
        /// These will *both* pass:
        ///
        /// expect([1;2;5]).toContain(5) 
        /// 
        /// expect([1;2;5]).toContain(3)
        ///
        /// If you do not want this, see `toContainEqual`.
        member _.toContain (item: 'T) : 'Return = jsNative

        /// Check that an item with a specific structure and 
        /// values is contained in a collection.
        member _.toContainEqual (item: 'T) : 'Return = jsNative

        /// Compare recursively all properties of object instances 
        /// (also known as "deep" equality). It calls Object.is to 
        /// compare primitive values, which is even better for 
        /// testing than === strict equality operator.
        member _.toEqual (value: 'T) : 'Return = jsNative

        /// Check that a string matches a string or regular expression.
        ///
        /// When using a string it is the same as doing "mystring".Contains(value)
        member _.toMatch (value: string) : 'Return = jsNative
        /// Check that a string matches a string or regular expression.
        ///
        /// When using a string it is the same as doing "mystring".Contains(value)
        member _.toMatch (value: Regex) : 'Return = jsNative
        
        /// Check that a JavaScript object matches a subset of the properties of an object.
        member _.toMatchObject (object: 'T) : 'Return = jsNative

        /// Ensures that a value matches the most recent snapshot.
        member _.toMatchSnapshot (?propertyMatchers, ?hint) : 'Return = jsNative

        /// Ensures that a value matches the most recent snapshot.
        ///
        /// You can provide an optional propertyMatchers object argument, which has 
        /// asymmetric matchers as values of a subset of expected properties, if the 
        /// received value will be an object instance. It is like toMatchObject with 
        /// flexible criteria for a subset of properties, followed by a snapshot test 
        /// as exact criteria for the rest of the properties.
        ///
        /// Jest adds the inlineSnapshot string argument to the matcher in the test 
        /// file (instead of an external .snap file) the first time that the test runs.
        member _.toMatchInlineSnapshot inlineSnapshot : 'Return = jsNative
        /// Ensures that a value matches the most recent snapshot.
        ///
        /// You can provide an optional propertyMatchers object argument, which has 
        /// asymmetric matchers as values of a subset of expected properties, if the 
        /// received value will be an object instance. It is like toMatchObject with 
        /// flexible criteria for a subset of properties, followed by a snapshot test 
        /// as exact criteria for the rest of the properties.
        ///
        /// Jest adds the inlineSnapshot string argument to the matcher in the test file 
        /// (instead of an external .snap file) the first time that the test runs.
        [<Emit("$0($2, $1)")>]
        member _.toMatchInlineSnapshot (inlineSnapshot, propertyMatchers) : 'Return = jsNative
        
        /// Check that an object has the same types as well as structure.
        ///
        /// Differences from .toEqual:
        ///
        /// Keys with undefined properties are checked. e.g. {a: undefined, b: 2} does 
        /// not match {b: 2} when using .toStrictEqual.
        ///
        /// Array sparseness is checked. e.g. [, 1] does not match [undefined, 1] when 
        /// using .toStrictEqual.
        ///
        /// Object types are checked to be equal. e.g. A class instance with fields a 
        /// and b will not equal a literal object with fields a and b.
        member _.toStrictEqual (value: 'T) : 'Return = jsNative

        /// Check that a function throws when called.
        member _.toThrow () : 'Return = jsNative
        /// Check that a function throws when called.
        member _.toThrow (err: exn) : 'Return = jsNative
        /// Check that a function throws when called.
        member _.toThrow (err: Regex) : 'Return = jsNative
        /// Check that a function throws when called.
        member _.toThrow (err: string) : 'Return = jsNative

        /// Check that a function throws an error matching the most recent snapshot 
        /// when it is called.
        ///
        /// You can provide an optional hint string argument that is appended to the 
        /// test name. Although Jest always appends a number at the end of a snapshot 
        /// name, short descriptive hints might be more useful than numbers to 
        /// differentiate multiple snapshots in a single it or test block. Jest sorts 
        /// snapshots by name in the corresponding .snap file.
        member _.toThrowErrorMatchingSnapshot (?hint) : 'Return = jsNative

        /// Check that a function throws an error matching the most recent snapshot 
        /// when it is called.
        ///
        /// Jest adds the inlineSnapshot string argument to the matcher in the test 
        /// file (instead of an external .snap file) the first time that the test runs.
        member _.toThrowErrorMatchingInlineSnapshot (inlineSnapshot) : 'Return = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expectedPromise =
        /// Inverts the pass/fail status of a matcher.
        member _.not : expectedPromise = jsNative

        /// Unwrap the value of a fulfilled promise so any other 
        /// matcher can be chained. If the promise is rejected 
        /// the assertion fails.
        ///
        /// This is automatically applied for `Async<'T>` values.
        member _.rejects : expected<JS.Promise<unit>> = jsNative

        /// Unwrap the reason of a rejected promise so any other 
        /// matcher can be chained. If the promise is fulfilled 
        /// the assertion fails.
        member _.resolves : expected<JS.Promise<unit>> = jsNative
