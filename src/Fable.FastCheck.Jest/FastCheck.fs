namespace Fable.FastCheck.Jest

open Fable.Core
open Fable.FastCheck
open Fable.Jester

[<AutoOpen>]
module JestExtensions =
    type Jest.test with
        /// Executes a model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
        ///
        /// The assertions list is where your Jest.expect assertion(s) should be located.
        static member inline elmish (name: string, init: 'Model * Elmish.Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter), fun (model, real, cmds) ->
                    FastCheck.modelRun(model, real, cmds)
                ), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Executes a model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
        ///
        /// The assertions list is where your Jest.expect assertion(s) should be located.
        static member inline elmish (name: string, init: 'Model * Elmish.Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, msgs: Arbitrary<'Msg list>, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter, msgs), fun (model, real, cmds) ->
                    FastCheck.modelRun(model, real, cmds)
                ), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Executes a model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
        ///
        /// The assertions list is where your Jest.expect assertion(s) should be located.
        static member inline elmish (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter), fun (model, real, cmds) ->
                    FastCheck.modelRun(model, real, cmds)
                ), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Executes a model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
        ///
        /// The assertions list is where your Jest.expect assertion(s) should be located.
        static member inline elmish (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, msgs: Arbitrary<'Msg list>, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter, msgs), fun (model, real, cmds) ->
                    FastCheck.modelRun(model, real, cmds)
                ), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Executes a model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
        ///
        /// The assertions list is where your Jest.expect assertion(s) should be located.
        static member inline elmish (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model, asserter: 'Msg -> 'Model -> 'Model -> unit, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter), fun (model, real, cmds) ->
                    FastCheck.modelRun(model, real, cmds)
                ), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Executes a model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
        ///
        /// The assertions list is where your Jest.expect assertion(s) should be located.
        static member inline elmish (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model, asserter: 'Msg -> 'Model -> 'Model -> unit, msgs: Arbitrary<'Msg list>, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter, msgs), fun (model, real, cmds) ->
                    FastCheck.modelRun(model, real, cmds)
                ), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)

        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)
        /// Runs a test using the provided arbitraries and predicate function.
        static member prop (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
            Jest.test(name, (fun () ->
                FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
            ), ?timeout = timeout)

    module Jest =
        module test =
            type elmish =
                /// Executes only this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline only (name: string, init: 'Model * Elmish.Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Executes only this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline only (name: string, init: 'Model * Elmish.Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, msgs: Arbitrary<'Msg list>, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter, msgs), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Executes only this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline only (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Executes only this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline only (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, msgs: Arbitrary<'Msg list>, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter, msgs), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Executes only this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline only (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model, asserter: 'Msg -> 'Model -> 'Model -> unit, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Executes only this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline only (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model, asserter: 'Msg -> 'Model -> 'Model -> unit, msgs: Arbitrary<'Msg list>, ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter, msgs), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)

                /// Skips this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline skip (name: string, init: 'Model * Elmish.Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline skip (name: string, init: 'Model * Elmish.Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, msgs: Arbitrary<'Msg list>, ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter, msgs), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline skip (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline skip (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model * Elmish.Cmd<'Msg>, asserter: 'Msg -> 'Model -> 'Model -> unit, msgs: Arbitrary<'Msg list>, ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter, msgs), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline skip (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model, asserter: 'Msg -> 'Model -> 'Model -> unit, ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this model-based test using the init and update functions of an elmish application, performs checks based on the given message via the paired assertion.
                ///
                /// The assertions list is where your Jest.expect assertion(s) should be located.
                static member inline skip (name: string, init: 'Model, update: 'Msg -> 'Model -> 'Model, asserter: 'Msg -> 'Model -> 'Model -> unit, msgs: Arbitrary<'Msg list>, ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(Arbitrary.elmish(init, update, asserter, msgs), fun (model, real, cmds) ->
                            FastCheck.modelRun(model, real, cmds)
                        ), ?fastCheckOptions = fastCheckOptions)
                    ))

            type prop =
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)
                /// Runs only this test using the provided arbitraries and predicate function.
                static member only (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list, ?timeout: int) =
                    Jest.test.only(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ), ?timeout = timeout)

                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, predicate: ('T0 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> Async<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> Async<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<bool>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<unit>), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.promiseProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
                /// Skips this test using the provided arbitraries and predicate function.
                static member skip (name: string, arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit), ?fastCheckOptions: IFastCheckOptionsProperty list) =
                    Jest.test.skip(name, (fun () ->
                        FastCheck.assert'(FastCheck.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate), ?fastCheckOptions = fastCheckOptions)
                    ))
