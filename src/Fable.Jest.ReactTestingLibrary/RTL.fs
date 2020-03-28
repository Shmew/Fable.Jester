namespace Fable.Jest.ReactTestingLibrary

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser.Types
    
type RTL =
    /// This is a light wrapper around the react-dom/test-utils act function. 
    /// All it does is forward all arguments to the act function if your version of react supports act.
    static member act (callback: unit -> unit) = Bindings.act callback

    /// This is a light wrapper around the react-dom/test-utils act function. All it does is 
    /// forward all arguments to the act function if your version of react supports act.
    /// Unmounts React trees that were mounted with render.
    static member cleanup () = Bindings.cleanup()

    /// Set the configuration options.
    static member configure (options: IConfigureOption list) = 
        Bindings.configure(unbox<IConfigureOptions> (createObj !!options))

    /// Fires a DOM event.
    static member fireEvent (element: HTMLElement, event: #Browser.Types.Event) = 
        Bindings.fireEventImport.custom(element, event)

    static member getNodeText (element: HTMLElement) =
        Bindings.getNodeText element

    /// Allows iteration over the implicit ARIA roles represented 
    /// in a given tree of DOM nodes.
    ///
    /// It returns an object, indexed by role name, with each value being an 
    /// array of elements which have that implicit ARIA role.
    static member getRoles (element: HTMLElement) =
        Bindings.getRoles element

    /// Compute if the given element should be excluded from the accessibility API by the browser. 
    /// 
    /// It implements every MUST criteria from the Excluding Elements from the Accessibility Tree 
    /// section in WAI-ARIA 1.2 with the exception of checking the role attribute.
    static member isInaccessible (element: HTMLElement) =
        Bindings.isInaccessible element

    /// Print out a list of all the implicit ARIA roles within a tree of DOM nodes, each role 
    /// containing a list of all of the nodes which match that role.
    static member logRoles (element: HTMLElement) =
        Bindings.logRoles element

    /// Prints out readable representation of the DOM tree of a node.
    static member prettyDOM (element: HTMLElement) =
        Bindings.prettyDOMImport.invoke element

    /// Prints out readable representation of the DOM tree of a node.
    static member prettyDOM (element: HTMLElement, maxLength: int) =
        Bindings.prettyDOMImport.invoke(element, maxLength = maxLength)

    /// Prints out readable representation of the DOM tree of a node.
    static member prettyDOM (element: HTMLElement, options: IPrettyDOMOption list) =
        Bindings.prettyDOMImport.invoke(element, options = (unbox<IPrettyDOMOptions> (createObj !!options)))

    /// Prints out readable representation of the DOM tree of a node.
    static member prettyDOM (element: HTMLElement, maxLength: int, options: IPrettyDOMOption list) =
        Bindings.prettyDOMImport.invoke(element, maxLength = maxLength, options = (unbox<IPrettyDOMOptions> (createObj !!options)))

    /// Render into a container which is appended to document.body.
    static member render (reactElement: ReactElement) = 
        Bindings.renderImport.invoke reactElement
        |> Bindings.render
    /// Render into a container which is appended to document.body.
    static member render (reactElement: ReactElement, options: IRenderOption list) = 
        Bindings.renderImport.invoke(reactElement, unbox<IRenderOptions> (createObj !!options))
        |> Bindings.render

    /// When in need to wait for any period of time you can use waitFor, to wait for your expectations to pass.
    static member waitFor (callback: unit -> 'T) = Bindings.waitForImport.invoke callback |> Async.AwaitPromise
    /// When in need to wait for any period of time you can use waitFor, to wait for your expectations to pass.
    static member waitFor (callback: unit -> 'T, waitForOptions: IWaitOption list) = 
        Bindings.waitForImport.invoke(callback, unbox<IWaitOptions> (createObj !!waitForOptions)) 
        |> Async.AwaitPromise

    /// To wait for the removal of element(s) from the DOM you can use waitForElementToBeRemoved.
    static member waitForElementToBeRemoved (callback: unit -> 'T) = 
        Bindings.waitForElementToBeRemovedImport.invoke callback |> Async.AwaitPromise
    /// To wait for the removal of element(s) from the DOM you can use waitForElementToBeRemoved.
    static member waitForElementToBeRemoved (callback: unit -> 'T, waitForOptions: IWaitOption list) = 
        Bindings.waitForElementToBeRemovedImport.invoke(callback, unbox<IWaitOptions> (createObj !!waitForOptions)) 
        |> Async.AwaitPromise

    /// Takes a DOM element and binds it to the raw query functions, allowing them to be used without specifying a container. 
    static member within (element: HTMLElement) =
        Bindings.withinImport.invoke element
        |> Bindings.queriesForElement

type configure =
    /// The default value for the hidden option used by getByRole. 
    ///
    /// Defaults to false.
    static member defaultHidden (value: bool) = Interop.mkConfigureOption "defaultHidden" value

    /// A function that returns the error used when getBy* or getAllBy* fail. 
    /// Takes the error message and container object as arguments.
    static member getElementError (handler: string * HTMLElement -> exn) = 
        Interop.mkConfigureOption "getElementError" handler

    /// The attribute used by getByTestId and related queries. 
    ///
    /// Defaults to data-testid.
    static member testIdAttribute (value: string) = Interop.mkConfigureOption "defaultHidden" value

type prettyDOM =
    /// Call toJSON method (if it exists) on objects.
    static member callToJSON (value: bool) = Interop.mkPrettyDOMOption "callToJSON" value
    /// Escape special characters in regular expressions.
    static member escapeRegex (value: bool) = Interop.mkPrettyDOMOption "escapeRegex" value
    /// Escape special characters in strings.
    static member escapeString (value: bool) = Interop.mkPrettyDOMOption "escapeString" value
    /// Highlight syntax with colors in terminal (some plugins).
    static member highlight (value: bool) = Interop.mkPrettyDOMOption "highlight" value
    /// Spaces in each level of indentation.
    static member indent (value: int) = Interop.mkPrettyDOMOption "indent" value
    /// Levels to print in arrays, objects, elements, .. etc.
    static member maxDepth (value: int) = Interop.mkPrettyDOMOption "maxDepth" value
    /// Minimize added space: no indentation nor line breaks.
    static member min (value: bool) = Interop.mkPrettyDOMOption "min" value
    /// Plugins to serialize application-specific data types.
    static member plugins (value: seq<string>) = Interop.mkPrettyDOMOption "plugins" (ResizeArray value)
    /// Include or omit the name of a function.
    static member printFunctionName (value: bool) = Interop.mkPrettyDOMOption "printFunctionName" value
    /// Colors to highlight syntax in terminal.
    static member theme (properties: IPrettyDOMThemeOption list) = Interop.mkPrettyDOMOption "theme" (createObj !!properties)

[<RequireQualifiedAccess>]
module prettyDOM =
    /// PrettyDOM theme options.
    [<Erase>]
    type theme =
        /// Default: "gray"
        static member comment (value: string) = Interop.mkPrettyDOMOThemeption "comment" value
        /// Default: "reset"
        static member content (value: string) = Interop.mkPrettyDOMOThemeption "content" value
        /// Default: "yellow"
        static member prop (value: string) = Interop.mkPrettyDOMOThemeption "prop" value
        /// Default: "cyan"
        static member tag (value: string) = Interop.mkPrettyDOMOThemeption "tag" value
        /// Default: "green"
        static member value (value: string) = Interop.mkPrettyDOMOThemeption "plugins" value

type waitFor =
    /// The default container is the global document. 
    ///
    /// Make sure the elements you wait for are descendants of container.
    static member container (element: HTMLElement) = Interop.mkWaitOption "container" element

    /// The default interval is 50ms. 
    ///
    /// However it will run your callback immediately before starting the intervals.
    static member interval (value: int) = Interop.mkWaitOption "interval" value

    /// Sets the configuration of the mutation observer.
    static member mutationObserver (options: IMutationObserverOption list) = Interop.mkWaitOption "mutationObserverOptions" (createObj !!options)

    /// The default timeout is 1000ms.
    static member timeout (value: int) = Interop.mkWaitOption "timeout" value

module waitFor =
    type mutationObserver =
        /// An array of specific attribute names to be monitored. 
        ///
        /// If this property isn't included, changes to all attributes cause mutation notifications.
        static member attributeFiler (filter: string) = Interop.mkMutationObserverOption "attributeFilter" (filter |> Array.singleton |> ResizeArray)

        /// An array of specific attribute names to be monitored. 
        ///
        /// If this property isn't included, changes to all attributes cause mutation notifications.
        static member attributeFiler (filters: string list) = Interop.mkMutationObserverOption "attributeFilter" (filters |> ResizeArray)

        /// Set to true to record the previous value of any attribute that changes when monitoring the node or nodes for attribute changes.
        ///
        /// The default value is `false` via omission.
        static member attributeOldValue (value: bool) = Interop.mkMutationObserverOption "attributeOldValue" value

        /// Set to true to watch for changes to the value of attributes on the node or nodes being monitored. 
        ///
        /// The default value is false.
        static member attributes (value: bool) = Interop.mkMutationObserverOption "attributes" value

        /// Set to true to monitor the specified target node or subtree for changes to the character data contained within the node or nodes. 
        ///
        /// The default value is `false` via omission.
        static member characterData (value: bool) = Interop.mkMutationObserverOption "characterData" value

        /// Set to true to record the previous value of a node's text whenever the text changes on nodes being monitored.
        ///
        /// The default value is `false` via omission.
        static member characterDataOldValue (value: bool) = Interop.mkMutationObserverOption "characterDataOldValue" value

        /// Set to true to monitor the target node (and, if subtree is true, its descendants) for the addition of 
        /// new child nodes or removal of existing child nodes. 
        ///
        /// The default is false.
        static member childList (value: bool) = Interop.mkMutationObserverOption "childList" value

        /// Set to true to extend monitoring to the entire subtree of nodes rooted at target. All of the other MutationObserverInit properties 
        /// are then extended to all of the nodes in the subtree instead of applying solely to the target node. 
        ///
        /// The default value is false.
        static member subtree (value: bool) = Interop.mkMutationObserverOption "subtree" value

type render =
    /// By default, React Testing Library will create a div and append that div to the document.body and 
    /// this is where your React component will be rendered. If you provide your own HTMLElement container 
    /// via this option, it will not be appended to the document.body automatically.
    static member container (value: HTMLElement) = Interop.mkRenderOption "container" value

    /// If the container is specified, then this defaults to that, otherwise this defaults to document.documentElement. 
    /// This is used as the base element for the queries as well as what is printed when you use debug().
    static member baseElement (value: HTMLElement) = Interop.mkRenderOption "container" value

    /// If hydrate is set to true, then it will render with ReactDOM.hydrate. This may be useful if you 
    /// are using server-side rendering and use ReactDOM.hydrate to mount your components.
    static member hydrate (value: bool) = Interop.mkRenderOption "container" value

    /// Pass a React Component as the wrapper option to have it rendered around the inner element. 
    /// This is most useful for creating reusable custom render functions for common data providers.
    static member wrapper (value: ReactElement) = Interop.mkRenderOption "container" value

[<RequireQualifiedAccess>]
module RTL =
    /// Convenience methods for creating DOM events that can then be fired by fireEvent, allowing you to have a 
    /// reference to the event created: this might be useful if you need to access event properties that cannot 
    /// be initiated programmatically (such as timeStamp).
    [<Erase>]
    type createEvent =
        static member abort (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEventImport.abort(element, (createObj !!eventProperties))
        static member abort (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEventImport.abort(element, (createObj !!eventProperties))
        static member animationEnd (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEventImport.animationEnd(element, (createObj !!eventProperties))
        static member animationIteration (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEventImport.animationIteration(element, (createObj !!eventProperties))
        static member animationStart (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEventImport.animationStart(element, (createObj !!eventProperties))
        static member blur (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEventImport.blur(element, (createObj !!eventProperties))
        static member canPlay (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.canPlay(element, (createObj !!eventProperties))
        static member canPlayThrough (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.canPlayThrough(element, (createObj !!eventProperties))
        static member change (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.change(element, (createObj !!eventProperties))
        static member click (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.click(element, (createObj !!eventProperties))
        static member compositionEnd (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEventImport.compositionEnd(element, (createObj !!eventProperties))
        static member compositionStart (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEventImport.compositionStart(element, (createObj !!eventProperties))
        static member compositionUpdate (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEventImport.compositionUpdate(element, (createObj !!eventProperties))
        static member contextMenu (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.contextMenu(element, (createObj !!eventProperties))
        static member copy (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEventImport.copy(element, (createObj !!eventProperties))
        static member cut (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEventImport.cut(element, (createObj !!eventProperties))
        static member dblClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.dblClick(element, (createObj !!eventProperties))
        static member doubleClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.doubleClick(element, (createObj !!eventProperties))
        static member drag (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.drag(element, (createObj !!eventProperties))
        static member dragEnd (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragEnd(element, (createObj !!eventProperties))
        static member dragEnter (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragEnter(element, (createObj !!eventProperties))
        static member dragExit (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragExit(element, (createObj !!eventProperties))
        static member dragLeave (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragLeave(element, (createObj !!eventProperties))
        static member dragOver (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragOver(element, (createObj !!eventProperties))
        static member dragStart (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragStart(element, (createObj !!eventProperties))
        static member drop (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.drop(element, (createObj !!eventProperties))
        static member durationChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.durationChange(element, (createObj !!eventProperties))
        static member emptied (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.emptied(element, (createObj !!eventProperties))
        static member encrypted (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.encrypted(element, (createObj !!eventProperties))
        static member ended (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.ended(element, (createObj !!eventProperties))
        static member error (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEventImport.error(element, (createObj !!eventProperties))
        static member error (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEventImport.error(element, (createObj !!eventProperties))
        static member focus (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEventImport.focus(element, (createObj !!eventProperties))
        static member focusIn (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEventImport.focusIn(element, (createObj !!eventProperties))
        static member focusOut (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEventImport.focusOut(element, (createObj !!eventProperties))
        static member gotPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.gotPointerCapture(element, (createObj !!eventProperties))
        static member input (element: HTMLElement, ?eventProperties: #IInputEventProperty list) = Bindings.createEventImport.input(element, (createObj !!eventProperties))
        static member invalid (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.invalid(element, (createObj !!eventProperties))
        static member keyDown (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEventImport.keyDown(element, (createObj !!eventProperties))
        static member keyPress (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEventImport.keyPress(element, (createObj !!eventProperties))
        static member keyUp (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEventImport.keyUp(element, (createObj !!eventProperties))
        static member load (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEventImport.load(element, (createObj !!eventProperties))
        static member load (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEventImport.load(element, (createObj !!eventProperties))
        static member loadedData (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.loadedData(element, (createObj !!eventProperties))
        static member loadedMetadata (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.loadedMetadata(element, (createObj !!eventProperties))
        static member loadStart (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.createEventImport.loadStart(element, (createObj !!eventProperties))
        static member lostPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.lostPointerCapture(element, (createObj !!eventProperties))
        static member mouseDown (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseDown(element, (createObj !!eventProperties))
        static member mouseEnter (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseEnter(element, (createObj !!eventProperties))
        static member mouseLeave (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseLeave(element, (createObj !!eventProperties))
        static member mouseMove (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseMove(element, (createObj !!eventProperties))
        static member mouseOut (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseOut(element, (createObj !!eventProperties))
        static member mouseOver (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseOver(element, (createObj !!eventProperties))
        static member mouseUp (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseUp(element, (createObj !!eventProperties))
        static member paste (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEventImport.paste(element, (createObj !!eventProperties))
        static member pause (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.pause(element, (createObj !!eventProperties))
        static member play (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.play(element, (createObj !!eventProperties))
        static member playing (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.playing(element, (createObj !!eventProperties))
        static member pointerCancel (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerCancel(element, (createObj !!eventProperties))
        static member pointerDown (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerDown(element, (createObj !!eventProperties))
        static member pointerEnter (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerEnter(element, (createObj !!eventProperties))
        static member pointerLeave (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerLeave(element, (createObj !!eventProperties))
        static member pointerMove (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerMove(element, (createObj !!eventProperties))
        static member pointerOut (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerOut(element, (createObj !!eventProperties))
        static member pointerOver (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerOver(element, (createObj !!eventProperties))
        static member pointerUp (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerUp(element, (createObj !!eventProperties))
        static member popState (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.popState(element, (createObj !!eventProperties))        
        static member progress (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.createEventImport.progress(element, (createObj !!eventProperties))
        static member rateChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.rateChange(element, (createObj !!eventProperties))
        static member reset (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.reset(element, (createObj !!eventProperties))
        static member scroll (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.scroll(element, (createObj !!eventProperties))
        static member seeked (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.seeked(element, (createObj !!eventProperties))
        static member seeking (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.seeking(element, (createObj !!eventProperties))
        static member select (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.select(element, (createObj !!eventProperties))
        static member stalled (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.stalled(element, (createObj !!eventProperties))
        static member submit (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.submit(element, (createObj !!eventProperties))
        static member suspend (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.suspend(element, (createObj !!eventProperties))
        static member timeUpdate (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.timeUpdate(element, (createObj !!eventProperties))
        static member touchCancel (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEventImport.touchCancel(element, (createObj !!eventProperties))
        static member touchEnd (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEventImport.touchEnd(element, (createObj !!eventProperties))
        static member touchMove (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEventImport.touchMove(element, (createObj !!eventProperties))
        static member touchStart (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEventImport.touchStart(element, (createObj !!eventProperties))
        static member transitionEnd (element: HTMLElement, ?eventProperties: #ITransitionEventProperty list) = Bindings.createEventImport.transitionEnd(element, (createObj !!eventProperties))
        static member volumeChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.volumeChange(element, (createObj !!eventProperties))
        static member waiting (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.waiting(element, (createObj !!eventProperties))
        static member wheel (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.wheel(element, (createObj !!eventProperties))

    /// Convenience methods for firing DOM events.
    [<Erase>]
    type fireEvent =
        static member abort (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEventImport.abort(element, (createObj !!eventProperties))
        static member abort (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEventImport.abort(element, (createObj !!eventProperties))
        static member animationEnd (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEventImport.animationEnd(element, (createObj !!eventProperties))
        static member animationIteration (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEventImport.animationIteration(element, (createObj !!eventProperties))
        static member animationStart (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEventImport.animationStart(element, (createObj !!eventProperties))
        static member blur (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEventImport.blur(element, (createObj !!eventProperties))
        static member canPlay (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.canPlay(element, (createObj !!eventProperties))
        static member canPlayThrough (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.canPlayThrough(element, (createObj !!eventProperties))
        static member change (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.change(element, (createObj !!eventProperties))
        static member click (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.click(element, (createObj !!eventProperties))
        static member compositionEnd (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEventImport.compositionEnd(element, (createObj !!eventProperties))
        static member compositionStart (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEventImport.compositionStart(element, (createObj !!eventProperties))
        static member compositionUpdate (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEventImport.compositionUpdate(element, (createObj !!eventProperties))
        static member contextMenu (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.contextMenu(element, (createObj !!eventProperties))
        static member copy (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEventImport.copy(element, (createObj !!eventProperties))
        static member cut (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEventImport.cut(element, (createObj !!eventProperties))
        static member dblClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.dblClick(element, (createObj !!eventProperties))
        static member doubleClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.doubleClick(element, (createObj !!eventProperties))
        static member drag (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.drag(element, (createObj !!eventProperties))
        static member dragEnd (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragEnd(element, (createObj !!eventProperties))
        static member dragEnter (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragEnter(element, (createObj !!eventProperties))
        static member dragExit (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragExit(element, (createObj !!eventProperties))
        static member dragLeave (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragLeave(element, (createObj !!eventProperties))
        static member dragOver (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragOver(element, (createObj !!eventProperties))
        static member dragStart (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragStart(element, (createObj !!eventProperties))
        static member drop (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.drop(element, (createObj !!eventProperties))
        static member durationChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.durationChange(element, (createObj !!eventProperties))
        static member emptied (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.emptied(element, (createObj !!eventProperties))
        static member encrypted (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.encrypted(element, (createObj !!eventProperties))
        static member ended (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.ended(element, (createObj !!eventProperties))
        static member error (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEventImport.error(element, (createObj !!eventProperties))
        static member error (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEventImport.error(element, (createObj !!eventProperties))
        static member focus (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEventImport.focus(element, (createObj !!eventProperties))
        static member focusIn (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEventImport.focusIn(element, (createObj !!eventProperties))
        static member focusOut (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEventImport.focusOut(element, (createObj !!eventProperties))
        static member gotPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.gotPointerCapture(element, (createObj !!eventProperties))
        static member input (element: HTMLElement, ?eventProperties: #IInputEventProperty list) = Bindings.fireEventImport.input(element, (createObj !!eventProperties))
        static member invalid (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.invalid(element, (createObj !!eventProperties))
        static member keyDown (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEventImport.keyDown(element, (createObj !!eventProperties))
        static member keyPress (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEventImport.keyPress(element, (createObj !!eventProperties))
        static member keyUp (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEventImport.keyUp(element, (createObj !!eventProperties))
        static member load (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEventImport.load(element, (createObj !!eventProperties))
        static member load (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEventImport.load(element, (createObj !!eventProperties))
        static member loadedData (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.loadedData(element, (createObj !!eventProperties))
        static member loadedMetadata (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.loadedMetadata(element, (createObj !!eventProperties))
        static member loadStart (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.fireEventImport.loadStart(element, (createObj !!eventProperties))
        static member lostPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.lostPointerCapture(element, (createObj !!eventProperties))
        static member mouseDown (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseDown(element, (createObj !!eventProperties))
        static member mouseEnter (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseEnter(element, (createObj !!eventProperties))
        static member mouseLeave (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseLeave(element, (createObj !!eventProperties))
        static member mouseMove (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseMove(element, (createObj !!eventProperties))
        static member mouseOut (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseOut(element, (createObj !!eventProperties))
        static member mouseOver (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseOver(element, (createObj !!eventProperties))
        static member mouseUp (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseUp(element, (createObj !!eventProperties))
        static member paste (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEventImport.paste(element, (createObj !!eventProperties))
        static member pause (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.pause(element, (createObj !!eventProperties))
        static member play (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.play(element, (createObj !!eventProperties))
        static member playing (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.playing(element, (createObj !!eventProperties))
        static member pointerCancel (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerCancel(element, (createObj !!eventProperties))
        static member pointerDown (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerDown(element, (createObj !!eventProperties))
        static member pointerEnter (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerEnter(element, (createObj !!eventProperties))
        static member pointerLeave (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerLeave(element, (createObj !!eventProperties))
        static member pointerMove (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerMove(element, (createObj !!eventProperties))
        static member pointerOut (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerOut(element, (createObj !!eventProperties))
        static member pointerOver (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerOver(element, (createObj !!eventProperties))
        static member pointerUp (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerUp(element, (createObj !!eventProperties))
        static member popState (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.popState(element, (createObj !!eventProperties))        
        static member progress (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.fireEventImport.progress(element, (createObj !!eventProperties))
        static member rateChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.rateChange(element, (createObj !!eventProperties))
        static member reset (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.reset(element, (createObj !!eventProperties))
        static member scroll (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.scroll(element, (createObj !!eventProperties))
        static member seeked (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.seeked(element, (createObj !!eventProperties))
        static member seeking (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.seeking(element, (createObj !!eventProperties))
        static member select (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.select(element, (createObj !!eventProperties))
        static member stalled (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.stalled(element, (createObj !!eventProperties))
        static member submit (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.submit(element, (createObj !!eventProperties))
        static member suspend (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.suspend(element, (createObj !!eventProperties))
        static member timeUpdate (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.timeUpdate(element, (createObj !!eventProperties))
        static member touchCancel (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEventImport.touchCancel(element, (createObj !!eventProperties))
        static member touchEnd (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEventImport.touchEnd(element, (createObj !!eventProperties))
        static member touchMove (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEventImport.touchMove(element, (createObj !!eventProperties))
        static member touchStart (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEventImport.touchStart(element, (createObj !!eventProperties))
        static member transitionEnd (element: HTMLElement, ?eventProperties: #ITransitionEventProperty list) = Bindings.fireEventImport.transitionEnd(element, (createObj !!eventProperties))
        static member volumeChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.volumeChange(element, (createObj !!eventProperties))
        static member waiting (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.waiting(element, (createObj !!eventProperties))
        static member wheel (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.wheel(element, (createObj !!eventProperties))
