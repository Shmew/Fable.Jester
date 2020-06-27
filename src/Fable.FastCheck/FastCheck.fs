namespace Fable.FastCheck

open Fable.Core
open Fable.Core.JsInterop

type FastCheck =
    /// Run the property, throw in case of failure.
    /// 
    /// It can be called directly from describe/it blocks of Mocha and Jest.
    static member assert' (prop: AsyncProperty<'T>, ?fastCheckOptions: IFastCheckOptionsProperty list) = 
        Bindings.fc.assert'(prop, ?parameters = (fastCheckOptions |> Option.map (fun p -> createObj !!p)))
    /// Run the property, throw in case of failure.
    /// 
    /// It can be called directly from describe/it blocks of Mocha and Jest.
    static member assert' (prop: Property<'T>, ?fastCheckOptions: IFastCheckOptionsProperty list) = 
        Bindings.fc.assert'(prop, ?parameters = (fastCheckOptions |> Option.map (fun p -> createObj !!p)))
    
    /// Run the property, does not throw contrary to assert'.
    static member asyncCheck (prop: AsyncProperty<'T>, ?fastCheckOptions: IFastCheckOptionsProperty list) = 
        Bindings.fc.check(prop, ?parameters = (fastCheckOptions |> Option.map (fun p -> createObj !!p)))
        |> Promise.map (fun res -> RunDetails(res))
        |> Async.AwaitPromise

    /// Run asynchronous commands over a Model and the Real system.
    ///
    /// Throw in case of inconsistency.
    static member asyncModelRun (initialModel: 'Model, real: 'Real, commandIter: seq<IAsyncCommand<'Model,'Real>>) = 
        let commandIter =
            commandIter
            |> Seq.map (fun cmd -> AsyncCommand(cmd) :> IPromiseCommand<'Model,'Real>)

        Bindings.fc.asyncModelRun((fun () -> Bindings.Setup.create initialModel real), commandIter)
    /// Run asynchronous commands over a Model and the Real system.
    ///
    /// Throw in case of inconsistency.
    static member asyncModelRun (initialModel: 'Model, real: 'Real, commandIter: IAsyncCommandSeq<'Model,'Real>) = 
        Bindings.fc.asyncModelRun((fun () -> Bindings.Setup.create initialModel real), AsyncCommandSeq(commandIter) :> IPromiseCommandSeq<'Model,'Real>)
    
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, predicate: ('T0 -> Async<bool>)) = 
        Bindings.fc.asyncProperty(arb0, predicate >> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, predicate: ('T0 -> Async<unit>)) = 
        Bindings.fc.asyncProperty(arb0, predicate >> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> Async<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, fun a1 a2 -> predicate a1 a2 |> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> Async<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, fun a1 a2 -> predicate a1 a2 |> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> Async<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, fun a1 a2 a3 -> predicate a1 a2 a3 |> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> Async<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, fun a1 a2 a3 -> predicate a1 a2 a3 |> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> Async<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, fun a1 a2 a3 a4 -> predicate a1 a2 a3 a4 |> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> Async<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, fun a1 a2 a3 a4 -> predicate a1 a2 a3 a4 |> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> Async<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, fun a1 a2 a3 a4 a5 -> predicate a1 a2 a3 a4 a5 |> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> Async<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, fun a1 a2 a3 a4 a5 -> predicate a1 a2 a3 a4 a5 |> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> Async<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, fun a1 a2 a3 a4 a5 a6 -> predicate a1 a2 a3 a4 a5 a6|> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> Async<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, fun a1 a2 a3 a4 a5 a6 -> predicate a1 a2 a3 a4 a5 a6 |> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> Async<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, fun a1 a2 a3 a4 a5 a6 a7 -> predicate a1 a2 a3 a4 a5 a6 a7|> Async.StartAsPromise)
    /// Instantiate a new AsyncProperty.
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> Async<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, fun a1 a2 a3 a4 a5 a6 a7 -> predicate a1 a2 a3 a4 a5 a6 a7 |> Async.StartAsPromise)

    /// Creates a custom scheduler with predefined resolution order.
    ///
    /// The custom scheduler will neither check that all the referred asyncs have 
    /// been scheduled nor that they resolved with the same status and value.
    static member asyncSchedulerFor (ordering: int list) =
        Bindings.fc.schedulerFor(ResizeArray ordering) 
        |> PromiseScheduler 
        |> AsyncScheduler
    /// Creates a custom scheduler with predefined resolution order.
    ///
    /// The custom scheduler will neither check that all the referred asyncs have 
    /// been scheduled nor that they resolved with the same status and value.
    static member asyncSchedulerFor (ordering: int list, act: ((unit -> Async<unit>) -> Async<unit>)) =
        let act (f: unit -> JS.Promise<unit>) =
            (fun () -> f() |> Async.AwaitPromise)
            |> act
            |> Async.StartAsPromise

        Bindings.fc.schedulerFor(ResizeArray ordering, Bindings.SchedulerAct.create act) 
        |> PromiseScheduler 
        |> AsyncScheduler

    /// Run the property, does not throw contrary to assert'.
    static member check (prop: Property<'T>, ?fastCheckOptions: IFastCheckOptionsProperty list) = 
        RunDetails(Bindings.fc.check(prop, ?parameters = (fastCheckOptions |> Option.map (fun p -> createObj !!p))))

    /// Produces a string containing the formated error in case of failed run.
    static member defaultReportMessage (runDetails: RunDetails<'T>) = Bindings.fc.defaultReportMessage(runDetails.runDetails)

    /// Run synchronous commands over a Model and the Real system.
    ///
    /// Throw in case of inconsistency.
    static member inline modelRun (initialModel: 'Model, real: 'Real, commandIter: seq<ICommand<'Model,'Real>>) = 
        Bindings.fc.modelRun((fun () -> Bindings.Setup.create initialModel real), commandIter)
    /// Run synchronous commands over a Model and the Real system.
    ///
    /// Throw in case of inconsistency.
    static member inline modelRun (initialModel: 'Model, real: 'Real, commandIter: ICommandSeq<'Model,'Real>) = 
        Bindings.fc.modelRun((fun () -> Bindings.Setup.create initialModel real), commandIter)

    /// Run the property, does not throw contrary to assert'.
    static member promiseCheck (prop: AsyncProperty<'T>, ?fastCheckOptions: IFastCheckOptionsProperty list) = 
        Bindings.fc.check(prop, ?parameters = (fastCheckOptions |> Option.map (fun p -> createObj !!p)))
        |> Promise.map (fun res -> RunDetails(res))

    /// Run asynchronous commands over a Model and the Real system.
    ///
    /// Throw in case of inconsistency.
    static member promiseModelRun (initialModel: 'Model, real: 'Real, commandIter: seq<IPromiseCommand<'Model,'Real>>) = 
        Bindings.fc.asyncModelRun((fun () -> Bindings.Setup.create initialModel real), commandIter)
    /// Run asynchronous commands over a Model and the Real system.
    ///
    /// Throw in case of inconsistency.
    static member promiseModelRun (initialModel: 'Model, real: 'Real, commandIter: IPromiseCommandSeq<'Model,'Real>) = 
        Bindings.fc.asyncModelRun((fun () -> Bindings.Setup.create initialModel real), commandIter)

    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, predicate: ('T0 -> JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate)
    /// Instantiate a new AsyncProperty.
    static member inline promiseProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate)

    /// Creates a custom scheduler with predefined resolution order.
    ///
    /// The custom scheduler will neither check that all the referred promises have 
    /// been scheduled nor that they resolved with the same status and value.
    static member promiseSchedulerFor (ordering: int list) =
        Bindings.fc.schedulerFor(ResizeArray ordering) 
        |> PromiseScheduler
    /// Creates a custom scheduler with predefined resolution order.
    ///
    /// The custom scheduler will neither check that all the referred promises have 
    /// been scheduled nor that they resolved with the same status and value.
    static member promiseSchedulerFor (ordering: int list, act: ((unit -> JS.Promise<unit>) -> JS.Promise<unit>)) =
        Bindings.fc.schedulerFor(ResizeArray ordering, Bindings.SchedulerAct.create act) 
        |> PromiseScheduler

    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, predicate: ('T0 -> bool)) = 
        Bindings.fc.property(arb0, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, predicate: ('T0 -> unit)) = 
        Bindings.fc.property(arb0, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> bool)) = 
        Bindings.fc.property(arb0, arb1, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> unit)) = 
        Bindings.fc.property(arb0, arb1, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> bool)) = 
        Bindings.fc.property(arb0, arb1, arb2, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> unit)) = 
        Bindings.fc.property(arb0, arb1, arb2, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate)
    /// Instantiate a new Property.
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate)

    /// Generate a list containing all the values that would have been generated during assert' or check.
    static member inline sample (arb: Arbitrary<'T>) = 
        Bindings.fc.sample(arb) |> List.ofSeq
    /// Generate a list containing all the values that would have been generated during assert' or check.
    static member inline sample (arb: Arbitrary<'T>, fastCheckOptions: IFastCheckOptionsProperty list) = 
        Bindings.fc.sample(arb, createObj !!fastCheckOptions) |> List.ofSeq
    /// Generate a list containing all the values that would have been generated during assert' or check.
    static member inline sample (arb: Arbitrary<'T>, numValues: int) = 
        Bindings.fc.sample(arb, numValues) |> List.ofSeq
    /// Generate a list containing all the values that would have been generated during assert' or check.
    static member inline sample (arb: IProperty<'T,'Return>, fastCheckOptions: IFastCheckOptionsProperty list) = 
        Bindings.fc.sample(arb, createObj !!fastCheckOptions) |> List.ofSeq
    /// Generate a list containing all the values that would have been generated during assert' or check.
    static member inline sample (arb: IProperty<'T,'Return>, numValues: int) = 
        Bindings.fc.sample(arb, numValues) |> List.ofSeq    

    /// Run asynchronous and scheduled commands over a Model and the Real system.
    ///
    /// Throw in case of inconsistency.
    static member scheduledModelRun (scheduler: AsyncScheduler<'Metadata>, initialModel: 'Model, real: 'Real, commandIter: seq<IAsyncCommand<'Model,'Real>>) = 
        Bindings.fc.scheduledModelRun(scheduler.scheduler, Bindings.Setup.create initialModel real, commandIter)
    /// Run asynchronous and scheduled commands over a Model and the Real system.
    ///
    /// Throw in case of inconsistency.
    static member scheduledModelRun (scheduler: AsyncScheduler<'Metadata>, initialModel: 'Model, real: 'Real, commandIter: IAsyncCommandSeq<'Model,'Real>) = 
        Bindings.fc.scheduledModelRun(scheduler.scheduler, Bindings.Setup.create initialModel real, commandIter)
    /// Run asynchronous and scheduled commands over a Model and the Real system.
    ///
    /// Throw in case of inconsistency.
    static member scheduledModelRun (scheduler: PromiseScheduler<'Metadata>, initialModel: 'Model, real: 'Real, commandIter: seq<IPromiseCommand<'Model,'Real>>) = 
        Bindings.fc.scheduledModelRun(scheduler.scheduler, Bindings.Setup.create initialModel real, commandIter)
    /// Run asynchronous and scheduled commands over a Model and the Real system.
    ///
    /// Throw in case of inconsistency.
    static member scheduledModelRun (scheduler: PromiseScheduler<'Metadata>, initialModel: 'Model, real: 'Real, commandIter: IPromiseCommandSeq<'Model,'Real>) = 
        Bindings.fc.scheduledModelRun(scheduler.scheduler, Bindings.Setup.create initialModel real, commandIter)

    /// Gather useful statistics concerning generated values.
    /// 
    /// Prints the result in `console.log` or `params.logger` (if defined).
    ///
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels).
    static member inline statistics (arb: Arbitrary<'T>, classify: 'T -> string) = 
        Bindings.fc.statistics(arb, classify)
    /// Gather useful statistics concerning generated values.
    /// 
    /// Prints the result in `console.log` or `params.logger` (if defined).
    ///
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels).
    static member inline statistics (arb: Arbitrary<'T>, classify: 'T -> string, fastCheckOptions: IFastCheckOptionsProperty list) = 
        Bindings.fc.statistics(arb, classify, createObj !!fastCheckOptions)
    /// Gather useful statistics concerning generated values.
    /// 
    /// Prints the result in `console.log` or `params.logger` (if defined).
    ///
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels).
    static member inline statistics (arb: Arbitrary<'T>, classify: 'T -> string, numValues: int) = 
        Bindings.fc.statistics(arb, classify, numValues)
    /// Gather useful statistics concerning generated values.
    /// 
    /// Prints the result in `console.log` or `params.logger` (if defined).
    ///
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels).
    static member inline statistics (arb: Arbitrary<'T>, classify: 'T -> seq<string>, fastCheckOptions: IFastCheckOptionsProperty list) = 
        Bindings.fc.statistics(arb, classify >> ResizeArray, createObj !!fastCheckOptions)
    /// Gather useful statistics concerning generated values.
    /// 
    /// Prints the result in `console.log` or `params.logger` (if defined).
    ///
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels).
    static member inline statistics (arb: Arbitrary<'T>, classify: 'T -> seq<string>, numValues: int) = 
        Bindings.fc.statistics(arb, classify >> ResizeArray, numValues)
    /// Gather useful statistics concerning generated values.
    /// 
    /// Prints the result in `console.log` or `params.logger` (if defined).
    ///
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels).
    static member inline statistics (prop: IProperty<'T,'Return>, classify: 'T -> string, fastCheckOptions: IFastCheckOptionsProperty list) = 
        Bindings.fc.statistics(prop, classify, createObj !!fastCheckOptions)
    /// Gather useful statistics concerning generated values.
    /// 
    /// Prints the result in `console.log` or `params.logger` (if defined).
    ///
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels).
    static member inline statistics (prop: IProperty<'T,'Return>, classify: 'T -> string, numValues: int) = 
        Bindings.fc.statistics(prop, classify, numValues)
    /// Gather useful statistics concerning generated values.
    /// 
    /// Prints the result in `console.log` or `params.logger` (if defined).
    ///
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels).
    static member inline statistics (prop: IProperty<'T,'Return>, classify: 'T -> seq<string>, fastCheckOptions: IFastCheckOptionsProperty list) = 
        Bindings.fc.statistics(prop, classify >> ResizeArray, createObj !!fastCheckOptions)
    /// Gather useful statistics concerning generated values.
    /// 
    /// Prints the result in `console.log` or `params.logger` (if defined).
    ///
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels).
    static member inline statistics (prop: IProperty<'T,'Return>, classify: 'T -> seq<string>, numValues: int) = 
        Bindings.fc.statistics(prop, classify >> ResizeArray, numValues)
    
    /// Convert any value to its fast-check string representation.
    static member inline stringify (value: 'T) = Bindings.fc.stringify(value)
    