namespace Fable.Jest

open Fable.Core
open Fable.Core.JsInterop
open System
open System.Text.RegularExpressions

[<AutoOpen>]
module Expect =
    [<Global>]
    type expect =
        member _.addSnapshotSerializer (serializer: obj) = jsNative
        
        member _.any (value: obj) = jsNative
        
        member _.anything () = jsNative

        member _.arrayContaining (values: ResizeArray<'T>) = jsNative
        [<Emit("$0.arrayContaining(Array.from($1))")>]
        member _.arrayContaining (values: 'T []) = jsNative
        [<Emit("$0.arrayContaining(Array.from($1))")>]
        member _.arrayContaining (values: 'T list) = jsNative
        [<Emit("$0.arrayContaining(Array.from($1))")>]
        member _.arrayContaining (values: 'T seq) = jsNative

        member _.assertions (number: int) = jsNative

        member _.extend (matchers: obj) = jsNative
        
        member _.hasAssertions () = jsNative

        member _.not : expect = jsNative

        member _.objectContaining (value: obj) = jsNative

        member _.stringContaining (value: string) = jsNative

        member _.stringMatching (value: string) = jsNative
        member _.stringMatching (value: Regex) = jsNative

    [<Global>]
    let expect : expect = jsNative

    [<Global("expect")>]
    type expected<'Return> =
        member _.not : expected<'Return> = jsNative

        member _.toBe (value: 'T) : 'Return = jsNative
        
        member _.toHaveLength (length: int) : 'Return = jsNative
        
        member _.toHaveProperty (keyPath: string, ?value: 'T) : 'Return = jsNative
        [<Emit("$0.toHaveProperty((Array.from($1).join('.')) ...)")>]
        member _.toHaveProperty (keyPath: string list) : 'Return = jsNative
        [<Emit("$0.toHaveProperty((Array.from($1).join('.')), $2)")>]
        member _.toHaveProperty (keyPath: string list, value: 'T) : 'Return = jsNative

        member _.toBeCloseTo(number: float, ?numDigits: int) : 'Return = jsNative
        
        member _.toBeDefined () : 'Return = jsNative

        member _.toBeFalsy () : 'Return = jsNative

        member _.toBeGreaterThan (number: float) : 'Return = jsNative
        member _.toBeGreaterThan (number: int) : 'Return = jsNative

        member _.toBeGreaterThanOrEqual (number: float) : 'Return = jsNative
        member _.toBeGreaterThanOrEqual (number: int) : 'Return = jsNative

        member _.toBeLessThan (number: float) : 'Return = jsNative
        member _.toBeLessThan (number: int) : 'Return = jsNative

        member _.toBeLessThanOrEqual (number: float) : 'Return = jsNative
        member _.toBeLessThanOrEqual (number: int) : 'Return = jsNative

        member _.toBeNull () : 'Return = jsNative

        member _.toBeTruthy () : 'Return = jsNative

        member _.toBeUndefined () : 'Return = jsNative

        member _.toBeNaN () : 'Return = jsNative

        member _.toContain (item: 'T) : 'Return = jsNative

        member _.toContainEqual (item: 'T) : 'Return = jsNative

        member _.toEqual (value: 'T) : 'Return = jsNative

        member _.toMatch (value: string) : 'Return = jsNative
        member _.toMatch (value: Regex) : 'Return = jsNative

        member _.toMatchObject (object: 'T) : 'Return = jsNative

        member _.toMatchSnapshot (?propertyMatchers, ?hint) : 'Return = jsNative

        member _.toMatchInlineSnapshot inlineSnapshot : 'Return = jsNative
        [<Emit("$0($2, $1)")>]
        member _.toMatchInlineSnapshot (inlineSnapshot, propertyMatchers) : 'Return = jsNative
        
        member _.toStrictEqual (value: 'T) : 'Return = jsNative

        member _.toThrow () : 'Return = jsNative
        member _.toThrow (err: exn) : 'Return = jsNative
        member _.toThrow (err: Regex) : 'Return = jsNative
        member _.toThrow (err: string) : 'Return = jsNative

        member _.toThrowErrorMatchingSnapshot (?hint) = jsNative

        member _.toThrowErrorMatchingInlineSnapshot inlineSnapshot : 'Return = jsNative

    [<Global("expect")>]
    type expectedPromise =
        inherit expected<JS.Promise<unit>>

        member _.rejects : expectedPromise = jsNative

        member _.resolves : expectedPromise = jsNative
