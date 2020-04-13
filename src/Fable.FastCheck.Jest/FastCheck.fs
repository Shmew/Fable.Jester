namespace Fable.FastCheck.Jest

open Fable.Core
open Fable.FastCheck
open Fable.Jester

[<AutoOpen>]
module JestExtensions =
    type Jest.test with
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<bool>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<unit>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> bool)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> unit)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<bool>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<unit>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> bool)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> unit)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<bool>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<unit>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> bool)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> unit)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<bool>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<unit>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<bool>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<unit>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<bool>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<unit>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<bool>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<unit>)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit)) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))

        static member propOnly (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<bool>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<unit>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> bool)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> unit)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<bool>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<unit>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> bool)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> unit)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<bool>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<unit>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> bool)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> unit)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<bool>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<unit>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<bool>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<unit>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<bool>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<unit>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<bool>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<unit>)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit)) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))

        static member propSkip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<bool>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<unit>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> bool)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> unit)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<bool>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<unit>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> bool)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> unit)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<bool>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<unit>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> bool)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> unit)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<bool>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<unit>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<bool>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<unit>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<bool>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<unit>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<bool>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<unit>)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit)) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate))
            ))
