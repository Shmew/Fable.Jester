namespace Fable.FastCheck.Jest

open Fable.Core
open Fable.FastCheck
open Fable.Jester

[<AutoOpen>]
module JestExtensions =
    type Jest.test with
        static member elmish (name: string, init: 'Model * Elmish.Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, assertions: ('Msg * ('Model -> 'Model -> unit)) list, ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, assertions), fun (model, real, cmds) ->
                    FastCheck.modelRun(model, real, cmds)
                ), ?parameters = parameters)
            ), ?timeout = timeout)
        static member elmish (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, assertions: ('Msg * ('Model -> 'Model -> unit)) list, ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, assertions), fun (model, real, cmds) ->
                    FastCheck.modelRun(model, real, cmds)
                ), ?parameters = parameters)
            ), ?timeout = timeout)
        static member elmish (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model, assertions: ('Msg * ('Model -> 'Model -> unit)) list, ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, assertions), fun (model, real, cmds) ->
                    FastCheck.modelRun(model, real, cmds)
                ), ?parameters = parameters)
            ), ?timeout = timeout)

        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ), ?timeout = timeout)

        static member propOnly (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ), ?timeout = timeout)
        static member propOnly (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit), ?parameters: IParametersOptionProperty list, ?timeout: int) =
            Jest.test.only(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ), ?timeout = timeout)

        static member propSkip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> bool), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> unit), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> bool), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> unit), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> bool), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> unit), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<bool>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<unit>), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ))
        static member propSkip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit), ?parameters: IParametersOptionProperty list) =
            Jest.test.skip(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?parameters = parameters)
            ))
