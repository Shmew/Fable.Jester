namespace Fable.FastCheck

open Fable.Core
open Fable.Core.JsInterop

type FastCheck =
    /// Run the property, throw in case of failure
    /// 
    /// It can be called directly from describe/it blocks of Mocha.
    /// It does not return anything in case of success.
    /// 
    /// WARNING: Has to be awaited
    /// Asynchronous property to be checked
    /// Optional parameters to customize the execution
    static member inline assert' (prop: AsyncProperty<'T>, ?parameters: IParametersOptionProperty list) = 
        Bindings.fc.assert'(prop, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))
    /// Run the property, throw in case of failure
    /// 
    /// It can be called directly from describe/it blocks of Mocha.
    /// It does not return anything in case of success.
    /// Synchronous property to be checked
    /// Optional parameters to customize the execution
    static member inline assert' (prop: Property<'T>, ?parameters: IParametersOptionProperty list) = 
        Bindings.fc.assert'(prop, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))
    
    /// Run asynchronous commands over a Model and the Real system
    ///
    /// Throw in case of inconsistency
    static member inline asyncModelRun (initialModel: 'Model, real: 'Real, commandIter: seq<IAsyncCommand<'Model,'Real>>) = 
        Bindings.fc.asyncModelRun((fun () -> Bindings.Setup.create initialModel real), commandIter)
    /// Run asynchronous commands over a Model and the Real system
    ///
    /// Throw in case of inconsistency
    static member inline asyncModelRun (initialModel: 'Model, real: 'Real, commandIter: IAsyncCommandSeq<'Model,'Real>) = 
        Bindings.fc.asyncModelRun((fun () -> Bindings.Setup.create initialModel real), commandIter)

    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, predicate: ('T0 ->JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, predicate: ('T0 ->JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 ->JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 ->JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 ->JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 ->JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 ->JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 ->JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 ->JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 ->JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 ->JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 ->JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 ->JS.Promise<bool>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate)
    /// Instantiate a new AsyncProperty
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline asyncProperty (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 ->JS.Promise<unit>)) = 
        Bindings.fc.asyncProperty(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate)
    
    /// Run the property, do not throw contrary to assert'
    /// 
    /// WARNING: Has to be awaited
    /// Asynchronous property to be checked
    /// Optional parameters to customize the execution
    static member inline check (prop: AsyncProperty<'T>, ?parameters: IParametersOptionProperty list) = 
        Bindings.fc.check(prop, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))
    /// Run the property, do not throw contrary to assert'
    /// Synchronous property to be checked
    /// Optional parameters to customize the execution
    static member inline check (prop: Property<'T>, ?parameters: IParametersOptionProperty list) = 
        Bindings.fc.check(prop, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))

    /// Run synchronous commands over a Model and the Real system
    ///
    /// Throw in case of inconsistency
    static member inline modelRun (initialModel: 'Model, real: 'Real, commandIter: seq<ICommand<'Model,'Real>>) = 
        Bindings.fc.modelRun((fun () -> Bindings.Setup.create initialModel real), commandIter)
    /// Run synchronous commands over a Model and the Real system
    ///
    /// Throw in case of inconsistency
    static member inline modelRun (initialModel: 'Model, real: 'Real, commandIter: ICommandSeq<'Model,'Real>) = 
        Bindings.fc.modelRun((fun () -> Bindings.Setup.create initialModel real), commandIter)

    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, predicate: ('T0 -> bool)) = 
        Bindings.fc.property(arb0, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, predicate: ('T0 -> unit)) = 
        Bindings.fc.property(arb0, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> bool)) = 
        Bindings.fc.property(arb0, arb1, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, predicate: ('T0 -> 'T1 -> unit)) = 
        Bindings.fc.property(arb0, arb1, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> bool)) = 
        Bindings.fc.property(arb0, arb1, arb2, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, predicate: ('T0 -> 'T1 -> 'T2 -> unit)) = 
        Bindings.fc.property(arb0, arb1, arb2, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> bool)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> unit)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> bool)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> unit)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> bool)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> unit)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, arb5, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> bool)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate)
    /// Instantiate a new Property
    /// Assess the success of the property. Would be considered falsy if its throws or if its output evaluates to false
    static member inline property (arb0: Arbitrary<'T0>, arb1: Arbitrary<'T1>, arb2: Arbitrary<'T2>, arb3: Arbitrary<'T3>, arb4: Arbitrary<'T4>, arb5: Arbitrary<'T5>, arb6: Arbitrary<'T6>, predicate: ('T0 -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'T6 -> unit)) = 
        Bindings.fc.property(arb0, arb1, arb2, arb3, arb4, arb5, arb6, predicate)

    /// Generate an array containing all the values that would have been generated during assert' or check
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline sample (generator: Arbitrary<'T>, ?parameters: IParametersOptionProperty list) = 
        Bindings.fc.sample(generator, ?parameters = (parameters |> Option.map (fun p -> createObj !!p))) |> List.ofSeq
    /// Generate an array containing all the values that would have been generated during assert' or check
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline sample (generator: Arbitrary<'T>, ?parameters: int) = 
        Bindings.fc.sample(generator, ?parameters = (parameters |> Option.map (fun p -> createObj !!p))) |> List.ofSeq
    /// Generate an array containing all the values that would have been generated during assert' or check
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline sample (generator: IProperty<'T,'Return>, ?parameters: IParametersOptionProperty list) = 
        Bindings.fc.sample(generator, ?parameters = (parameters |> Option.map (fun p -> createObj !!p))) |> List.ofSeq
    /// Generate an array containing all the values that would have been generated during assert' or check
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline sample (generator: IProperty<'T,'Return>, ?parameters: int) = 
        Bindings.fc.sample(generator, ?parameters = (parameters |> Option.map (fun p -> createObj !!p))) |> List.ofSeq
        
    /// Run asynchronous and scheduled commands over a Model and the Real system
    ///
    /// Throw in case of inconsistency
    static member inline scheduledModelRun (scheduler: Scheduler, initialModel: 'Model, real: 'Real, commandIter: seq<ICommand<'Model,'Real>>) = 
        Bindings.fc.scheduledModelRun(scheduler.scheduler, Bindings.Setup.create initialModel real, commandIter)
    /// Run asynchronous and scheduled commands over a Model and the Real system
    ///
    /// Throw in case of inconsistency
    static member inline scheduledModelRun (scheduler: Scheduler, initialModel: 'Model, real: 'Real, commandIter: ICommandSeq<'Model,'Real>) = 
        Bindings.fc.scheduledModelRun(scheduler.scheduler, Bindings.Setup.create initialModel real, commandIter)

    /// Gather useful statistics concerning generated values
    /// 
    /// Print the result in `console.log` or `params.logger` (if defined)
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels)
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline statistics (generator: Arbitrary<'T>, classify: ('T -> string), ?parameters: IParametersOptionProperty list) = 
        Bindings.fc.statistics(generator, classify, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))
    /// Gather useful statistics concerning generated values
    /// 
    /// Print the result in `console.log` or `params.logger` (if defined)
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels)
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline statistics (generator: Arbitrary<'T>, classify: ('T -> string), ?parameters: int) = 
        Bindings.fc.statistics(generator, classify, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))
    /// Gather useful statistics concerning generated values
    /// 
    /// Print the result in `console.log` or `params.logger` (if defined)
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels)
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline statistics (generator: Arbitrary<'T>, classify: ('T -> seq<string>), ?parameters: IParametersOptionProperty list) = 
        Bindings.fc.statistics(generator, classify >> ResizeArray, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))
    /// Gather useful statistics concerning generated values
    /// 
    /// Print the result in `console.log` or `params.logger` (if defined)
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels)
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline statistics (generator: Arbitrary<'T>, classify: ('T -> seq<string>), ?parameters: int) = 
        Bindings.fc.statistics(generator, classify >> ResizeArray, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))
    /// Gather useful statistics concerning generated values
    /// 
    /// Print the result in `console.log` or `params.logger` (if defined)
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels)
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline statistics (generator: IProperty<'T,'Return>, classify: ('T -> string), ?parameters: IParametersOptionProperty list) = 
        Bindings.fc.statistics(generator, classify, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))
    /// Gather useful statistics concerning generated values
    /// 
    /// Print the result in `console.log` or `params.logger` (if defined)
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels)
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline statistics (generator: IProperty<'T,'Return>, classify: ('T -> string), ?parameters: int) = 
        Bindings.fc.statistics(generator, classify, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))
    /// Gather useful statistics concerning generated values
    /// 
    /// Print the result in `console.log` or `params.logger` (if defined)
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels)
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline statistics (generator: IProperty<'T,'Return>, classify: ('T -> seq<string>), ?parameters: IParametersOptionProperty list) = 
        Bindings.fc.statistics(generator, classify >> ResizeArray, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))
    /// Gather useful statistics concerning generated values
    /// 
    /// Print the result in `console.log` or `params.logger` (if defined)
    /// Classifier function that can classify the generated value in zero, one or more categories (with free labels)
    /// Integer representing the number of values to generate or Parameters as in assert'
    static member inline statistics (generator: IProperty<'T,'Return>, classify: ('T -> seq<string>), ?parameters: int) = 
        Bindings.fc.statistics(generator, classify >> ResizeArray, ?parameters = (parameters |> Option.map (fun p -> createObj !!p)))
    
    /// Convert any value to its fast-check string representation
    /// Value to be converted into a string
    static member inline stringify (value: 'T) = Bindings.fc.stringify(value)
    