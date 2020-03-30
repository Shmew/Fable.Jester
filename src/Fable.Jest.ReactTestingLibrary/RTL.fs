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
        Bindings.fireEvent.custom(element, event)

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

    /// Queries bound to the document.body
    static member screen = RTL.within(Browser.Dom.document.body)

    /// When in need to wait for any period of time you can use waitFor, to wait for your expectations to pass.
    static member waitFor (callback: unit -> 'T) = Bindings.waitForImport.invoke callback //|> Async.AwaitPromise
    /// When in need to wait for any period of time you can use waitFor, to wait for your expectations to pass.
    static member waitFor (callback: unit -> 'T, waitForOptions: IWaitOption list) = 
        Bindings.waitForImport.invoke(callback, unbox<IWaitOptions> (createObj !!waitForOptions)) 
        //|> Async.AwaitPromise

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
    type createEvent =
        static member abort (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEvent.abort(element, (createObj !!eventProperties))
        static member abort (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEvent.abort(element, (createObj !!eventProperties))
        static member animationEnd (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationEnd(element, (createObj !!eventProperties))
        static member animationIteration (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationIteration(element, (createObj !!eventProperties))
        static member animationStart (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationStart(element, (createObj !!eventProperties))
        static member blur (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.blur(element, (createObj !!eventProperties))
        static member canPlay (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlay(element, (createObj !!eventProperties))
        static member canPlayThrough (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlayThrough(element, (createObj !!eventProperties))
        static member change (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.change(element, (createObj !!eventProperties))
        static member click (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.click(element, (createObj !!eventProperties))
        static member compositionEnd (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionEnd(element, (createObj !!eventProperties))
        static member compositionStart (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionStart(element, (createObj !!eventProperties))
        static member compositionUpdate (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionUpdate(element, (createObj !!eventProperties))
        static member contextMenu (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.contextMenu(element, (createObj !!eventProperties))
        static member copy (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.copy(element, (createObj !!eventProperties))
        static member cut (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.cut(element, (createObj !!eventProperties))
        static member dblClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.dblClick(element, (createObj !!eventProperties))
        static member doubleClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.doubleClick(element, (createObj !!eventProperties))
        static member drag (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drag(element, (createObj !!eventProperties))
        static member dragEnd (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnd(element, (createObj !!eventProperties))
        static member dragEnter (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnter(element, (createObj !!eventProperties))
        static member dragExit (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragExit(element, (createObj !!eventProperties))
        static member dragLeave (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragLeave(element, (createObj !!eventProperties))
        static member dragOver (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragOver(element, (createObj !!eventProperties))
        static member dragStart (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragStart(element, (createObj !!eventProperties))
        static member drop (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drop(element, (createObj !!eventProperties))
        static member durationChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.durationChange(element, (createObj !!eventProperties))
        static member emptied (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.emptied(element, (createObj !!eventProperties))
        static member encrypted (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.encrypted(element, (createObj !!eventProperties))
        static member ended (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.ended(element, (createObj !!eventProperties))
        static member error (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEvent.error(element, (createObj !!eventProperties))
        static member error (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEvent.error(element, (createObj !!eventProperties))
        static member focus (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focus(element, (createObj !!eventProperties))
        static member focusIn (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusIn(element, (createObj !!eventProperties))
        static member focusOut (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusOut(element, (createObj !!eventProperties))
        static member gotPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.gotPointerCapture(element, (createObj !!eventProperties))
        static member input (element: HTMLElement, ?eventProperties: #IInputEventProperty list) = Bindings.createEvent.input(element, (createObj !!eventProperties))
        static member invalid (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.invalid(element, (createObj !!eventProperties))
        static member keyDown (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyDown(element, (createObj !!eventProperties))
        static member keyPress (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyPress(element, (createObj !!eventProperties))
        static member keyUp (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyUp(element, (createObj !!eventProperties))
        static member load (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEvent.load(element, (createObj !!eventProperties))
        static member load (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEvent.load(element, (createObj !!eventProperties))
        static member loadedData (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedData(element, (createObj !!eventProperties))
        static member loadedMetadata (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedMetadata(element, (createObj !!eventProperties))
        static member loadStart (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.loadStart(element, (createObj !!eventProperties))
        static member lostPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.lostPointerCapture(element, (createObj !!eventProperties))
        static member mouseDown (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseDown(element, (createObj !!eventProperties))
        static member mouseEnter (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseEnter(element, (createObj !!eventProperties))
        static member mouseLeave (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseLeave(element, (createObj !!eventProperties))
        static member mouseMove (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseMove(element, (createObj !!eventProperties))
        static member mouseOut (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOut(element, (createObj !!eventProperties))
        static member mouseOver (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOver(element, (createObj !!eventProperties))
        static member mouseUp (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseUp(element, (createObj !!eventProperties))
        static member paste (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.paste(element, (createObj !!eventProperties))
        static member pause (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.pause(element, (createObj !!eventProperties))
        static member play (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.play(element, (createObj !!eventProperties))
        static member playing (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.playing(element, (createObj !!eventProperties))
        static member pointerCancel (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerCancel(element, (createObj !!eventProperties))
        static member pointerDown (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerDown(element, (createObj !!eventProperties))
        static member pointerEnter (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerEnter(element, (createObj !!eventProperties))
        static member pointerLeave (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerLeave(element, (createObj !!eventProperties))
        static member pointerMove (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerMove(element, (createObj !!eventProperties))
        static member pointerOut (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOut(element, (createObj !!eventProperties))
        static member pointerOver (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOver(element, (createObj !!eventProperties))
        static member pointerUp (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerUp(element, (createObj !!eventProperties))
        static member popState (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.popState(element, (createObj !!eventProperties))        
        static member progress (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.progress(element, (createObj !!eventProperties))
        static member rateChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.rateChange(element, (createObj !!eventProperties))
        static member reset (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.reset(element, (createObj !!eventProperties))
        static member scroll (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.scroll(element, (createObj !!eventProperties))
        static member seeked (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.seeked(element, (createObj !!eventProperties))
        static member seeking (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.seeking(element, (createObj !!eventProperties))
        static member select (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.select(element, (createObj !!eventProperties))
        static member stalled (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.stalled(element, (createObj !!eventProperties))
        static member submit (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.submit(element, (createObj !!eventProperties))
        static member suspend (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.suspend(element, (createObj !!eventProperties))
        static member timeUpdate (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.timeUpdate(element, (createObj !!eventProperties))
        static member touchCancel (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchCancel(element, (createObj !!eventProperties))
        static member touchEnd (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchEnd(element, (createObj !!eventProperties))
        static member touchMove (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchMove(element, (createObj !!eventProperties))
        static member touchStart (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchStart(element, (createObj !!eventProperties))
        static member transitionEnd (element: HTMLElement, ?eventProperties: #ITransitionEventProperty list) = Bindings.createEvent.transitionEnd(element, (createObj !!eventProperties))
        static member volumeChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.volumeChange(element, (createObj !!eventProperties))
        static member waiting (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.waiting(element, (createObj !!eventProperties))
        static member wheel (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.wheel(element, (createObj !!eventProperties))

    /// Convenience methods for firing DOM events.
    type fireEvent =
        static member abort (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.abort(element, (createObj !!eventProperties))
        static member abort (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEvent.abort(element, (createObj !!eventProperties))
        static member animationEnd (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationEnd(element, (createObj !!eventProperties))
        static member animationIteration (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationIteration(element, (createObj !!eventProperties))
        static member animationStart (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationStart(element, (createObj !!eventProperties))
        static member blur (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.blur(element, (createObj !!eventProperties))
        static member canPlay (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlay(element, (createObj !!eventProperties))
        static member canPlayThrough (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlayThrough(element, (createObj !!eventProperties))
        static member change (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.change(element, (createObj !!eventProperties))
        static member click (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.click(element, (createObj !!eventProperties))
        static member compositionEnd (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionEnd(element, (createObj !!eventProperties))
        static member compositionStart (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionStart(element, (createObj !!eventProperties))
        static member compositionUpdate (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionUpdate(element, (createObj !!eventProperties))
        static member contextMenu (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.contextMenu(element, (createObj !!eventProperties))
        static member copy (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.copy(element, (createObj !!eventProperties))
        static member cut (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.cut(element, (createObj !!eventProperties))
        static member dblClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.dblClick(element, (createObj !!eventProperties))
        static member doubleClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.doubleClick(element, (createObj !!eventProperties))
        static member drag (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drag(element, (createObj !!eventProperties))
        static member dragEnd (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnd(element, (createObj !!eventProperties))
        static member dragEnter (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnter(element, (createObj !!eventProperties))
        static member dragExit (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragExit(element, (createObj !!eventProperties))
        static member dragLeave (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragLeave(element, (createObj !!eventProperties))
        static member dragOver (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragOver(element, (createObj !!eventProperties))
        static member dragStart (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragStart(element, (createObj !!eventProperties))
        static member drop (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drop(element, (createObj !!eventProperties))
        static member durationChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.durationChange(element, (createObj !!eventProperties))
        static member emptied (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.emptied(element, (createObj !!eventProperties))
        static member encrypted (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.encrypted(element, (createObj !!eventProperties))
        static member ended (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.ended(element, (createObj !!eventProperties))
        static member error (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.error(element, (createObj !!eventProperties))
        static member error (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEvent.error(element, (createObj !!eventProperties))
        static member focus (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focus(element, (createObj !!eventProperties))
        static member focusIn (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusIn(element, (createObj !!eventProperties))
        static member focusOut (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusOut(element, (createObj !!eventProperties))
        static member gotPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.gotPointerCapture(element, (createObj !!eventProperties))
        static member input (element: HTMLElement, ?eventProperties: #IInputEventProperty list) = Bindings.fireEvent.input(element, (createObj !!eventProperties))
        static member invalid (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.invalid(element, (createObj !!eventProperties))
        static member keyDown (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyDown(element, (createObj !!eventProperties))
        static member keyPress (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyPress(element, (createObj !!eventProperties))
        static member keyUp (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyUp(element, (createObj !!eventProperties))
        static member load (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.load(element, (createObj !!eventProperties))
        static member load (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEvent.load(element, (createObj !!eventProperties))
        static member loadedData (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedData(element, (createObj !!eventProperties))
        static member loadedMetadata (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedMetadata(element, (createObj !!eventProperties))
        static member loadStart (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.loadStart(element, (createObj !!eventProperties))
        static member lostPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.lostPointerCapture(element, (createObj !!eventProperties))
        static member mouseDown (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseDown(element, (createObj !!eventProperties))
        static member mouseEnter (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseEnter(element, (createObj !!eventProperties))
        static member mouseLeave (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseLeave(element, (createObj !!eventProperties))
        static member mouseMove (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseMove(element, (createObj !!eventProperties))
        static member mouseOut (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOut(element, (createObj !!eventProperties))
        static member mouseOver (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOver(element, (createObj !!eventProperties))
        static member mouseUp (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseUp(element, (createObj !!eventProperties))
        static member paste (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.paste(element, (createObj !!eventProperties))
        static member pause (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.pause(element, (createObj !!eventProperties))
        static member play (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.play(element, (createObj !!eventProperties))
        static member playing (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.playing(element, (createObj !!eventProperties))
        static member pointerCancel (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerCancel(element, (createObj !!eventProperties))
        static member pointerDown (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerDown(element, (createObj !!eventProperties))
        static member pointerEnter (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerEnter(element, (createObj !!eventProperties))
        static member pointerLeave (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerLeave(element, (createObj !!eventProperties))
        static member pointerMove (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerMove(element, (createObj !!eventProperties))
        static member pointerOut (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOut(element, (createObj !!eventProperties))
        static member pointerOver (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOver(element, (createObj !!eventProperties))
        static member pointerUp (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerUp(element, (createObj !!eventProperties))
        static member popState (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.popState(element, (createObj !!eventProperties))        
        static member progress (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.progress(element, (createObj !!eventProperties))
        static member rateChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.rateChange(element, (createObj !!eventProperties))
        static member reset (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.reset(element, (createObj !!eventProperties))
        static member scroll (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.scroll(element, (createObj !!eventProperties))
        static member seeked (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeked(element, (createObj !!eventProperties))
        static member seeking (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeking(element, (createObj !!eventProperties))
        static member select (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.select(element, (createObj !!eventProperties))
        static member stalled (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.stalled(element, (createObj !!eventProperties))
        static member submit (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.submit(element, (createObj !!eventProperties))
        static member suspend (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.suspend(element, (createObj !!eventProperties))
        static member timeUpdate (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.timeUpdate(element, (createObj !!eventProperties))
        static member touchCancel (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchCancel(element, (createObj !!eventProperties))
        static member touchEnd (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchEnd(element, (createObj !!eventProperties))
        static member touchMove (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchMove(element, (createObj !!eventProperties))
        static member touchStart (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchStart(element, (createObj !!eventProperties))
        static member transitionEnd (element: HTMLElement, ?eventProperties: #ITransitionEventProperty list) = Bindings.fireEvent.transitionEnd(element, (createObj !!eventProperties))
        static member volumeChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.volumeChange(element, (createObj !!eventProperties))
        static member waiting (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.waiting(element, (createObj !!eventProperties))
        static member wheel (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.wheel(element, (createObj !!eventProperties))

    type userEvent =
        /// Clicks element, depending on what element is it can have different side effects.
        static member click (element: HTMLElement) : unit = Bindings.userEvent.click(element)
        /// Clicks element twice, depending on what element is it can have different side effects.
        static member dblClick (element: HTMLElement) : unit = Bindings.userEvent.dblClick(element)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        static member selectOptions (element: HTMLElement, values: 'T []) : unit = Bindings.userEvent.selectOptions(element, values)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        static member selectOptions (element: HTMLElement, values: 'T list) : unit = Bindings.userEvent.selectOptions(element, values)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        static member selectOptions (element: HTMLElement, values: ResizeArray<'T>) : unit = Bindings.userEvent.selectOptions(element, values)
        /// Fires a tab event changing the document.activeElement in the same way the browser does.
        static member tab (shift: bool, focusTrap: HTMLElement) : unit = Bindings.userEvent.tab(shift, focusTrap)
        /// Writes text inside an <input> or a <textarea>.
        static member type' (element: HTMLElement, text: string) : JS.Promise<unit> = Bindings.userEvent.typeInternal(element, text)
        /// Writes text inside an <input> or a <textarea>.
        static member type' (element: HTMLElement, text: string, allAtOnce: bool) : JS.Promise<unit> = 
            Bindings.userEvent.typeInternal(element, text, toPlainJsObj {| allAtOnce = allAtOnce |})
        /// Writes text inside an <input> or a <textarea>.
        static member type' (element: HTMLElement, text: string, delay: int) : JS.Promise<unit> = 
            Bindings.userEvent.typeInternal(element, text, toPlainJsObj {| delay = delay |})
        /// Writes text inside an <input> or a <textarea>.
        static member type' (element: HTMLElement, text: string, allAtOnce: bool, delay: int) : JS.Promise<unit> = 
            Bindings.userEvent.typeInternal(element, text, toPlainJsObj {| allAtOnce = allAtOnce; delay = delay |})

[<AutoOpen>]
module RTLExtensions =
    [<NoComparison>]
    [<NoEquality>]
    type HTMLElementCreateEvent (element: HTMLElement) =
        member _.abort (?eventProperties: IProgressEventProperty list) = Bindings.createEvent.abort(element, (createObj !!eventProperties))
        member _.abort (?eventProperties: IUIEventProperty list) = Bindings.createEvent.abort(element, (createObj !!eventProperties))
        member _.animationEnd (?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationEnd(element, (createObj !!eventProperties))
        member _.animationIteration (?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationIteration(element, (createObj !!eventProperties))
        member _.animationStart (?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationStart(element, (createObj !!eventProperties))
        member _.blur (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.blur(element, (createObj !!eventProperties))
        member _.canPlay (?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlay(element, (createObj !!eventProperties))
        member _.canPlayThrough (?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlayThrough(element, (createObj !!eventProperties))
        member _.change (?eventProperties: #IEventProperty list) = Bindings.createEvent.change(element, (createObj !!eventProperties))
        member _.click (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.click(element, (createObj !!eventProperties))
        member _.compositionEnd (?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionEnd(element, (createObj !!eventProperties))
        member _.compositionStart (?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionStart(element, (createObj !!eventProperties))
        member _.compositionUpdate (?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionUpdate(element, (createObj !!eventProperties))
        member _.contextMenu (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.contextMenu(element, (createObj !!eventProperties))
        member _.copy (?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.copy(element, (createObj !!eventProperties))
        member _.cut (?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.cut(element, (createObj !!eventProperties))
        member _.dblClick (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.dblClick(element, (createObj !!eventProperties))
        member _.doubleClick (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.doubleClick(element, (createObj !!eventProperties))
        member _.drag (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drag(element, (createObj !!eventProperties))
        member _.dragEnd (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnd(element, (createObj !!eventProperties))
        member _.dragEnter (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnter(element, (createObj !!eventProperties))
        member _.dragExit (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragExit(element, (createObj !!eventProperties))
        member _.dragLeave (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragLeave(element, (createObj !!eventProperties))
        member _.dragOver (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragOver(element, (createObj !!eventProperties))
        member _.dragStart (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragStart(element, (createObj !!eventProperties))
        member _.drop (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drop(element, (createObj !!eventProperties))
        member _.durationChange (?eventProperties: #IEventProperty list) = Bindings.createEvent.durationChange(element, (createObj !!eventProperties))
        member _.emptied (?eventProperties: #IEventProperty list) = Bindings.createEvent.emptied(element, (createObj !!eventProperties))
        member _.encrypted (?eventProperties: #IEventProperty list) = Bindings.createEvent.encrypted(element, (createObj !!eventProperties))
        member _.ended (?eventProperties: #IEventProperty list) = Bindings.createEvent.ended(element, (createObj !!eventProperties))
        member _.error (?eventProperties: IProgressEventProperty list) = Bindings.createEvent.error(element, (createObj !!eventProperties))
        member _.error (?eventProperties: IUIEventProperty list) = Bindings.createEvent.error(element, (createObj !!eventProperties))
        member _.focus (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focus(element, (createObj !!eventProperties))
        member _.focusIn (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusIn(element, (createObj !!eventProperties))
        member _.focusOut (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusOut(element, (createObj !!eventProperties))
        member _.gotPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.gotPointerCapture(element, (createObj !!eventProperties))
        member _.input (?eventProperties: #IInputEventProperty list) = Bindings.createEvent.input(element, (createObj !!eventProperties))
        member _.invalid (?eventProperties: #IEventProperty list) = Bindings.createEvent.invalid(element, (createObj !!eventProperties))
        member _.keyDown (?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyDown(element, (createObj !!eventProperties))
        member _.keyPress (?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyPress(element, (createObj !!eventProperties))
        member _.keyUp (?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyUp(element, (createObj !!eventProperties))
        member _.load (?eventProperties: IProgressEventProperty list) = Bindings.createEvent.load(element, (createObj !!eventProperties))
        member _.load (?eventProperties: IUIEventProperty list) = Bindings.createEvent.load(element, (createObj !!eventProperties))
        member _.loadedData (?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedData(element, (createObj !!eventProperties))
        member _.loadedMetadata (?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedMetadata(element, (createObj !!eventProperties))
        member _.loadStart (?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.loadStart(element, (createObj !!eventProperties))
        member _.lostPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.lostPointerCapture(element, (createObj !!eventProperties))
        member _.mouseDown (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseDown(element, (createObj !!eventProperties))
        member _.mouseEnter (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseEnter(element, (createObj !!eventProperties))
        member _.mouseLeave (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseLeave(element, (createObj !!eventProperties))
        member _.mouseMove (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseMove(element, (createObj !!eventProperties))
        member _.mouseOut (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOut(element, (createObj !!eventProperties))
        member _.mouseOver (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOver(element, (createObj !!eventProperties))
        member _.mouseUp (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseUp(element, (createObj !!eventProperties))
        member _.paste (?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.paste(element, (createObj !!eventProperties))
        member _.pause (?eventProperties: #IEventProperty list) = Bindings.createEvent.pause(element, (createObj !!eventProperties))
        member _.play (?eventProperties: #IEventProperty list) = Bindings.createEvent.play(element, (createObj !!eventProperties))
        member _.playing (?eventProperties: #IEventProperty list) = Bindings.createEvent.playing(element, (createObj !!eventProperties))
        member _.pointerCancel (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerCancel(element, (createObj !!eventProperties))
        member _.pointerDown (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerDown(element, (createObj !!eventProperties))
        member _.pointerEnter (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerEnter(element, (createObj !!eventProperties))
        member _.pointerLeave (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerLeave(element, (createObj !!eventProperties))
        member _.pointerMove (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerMove(element, (createObj !!eventProperties))
        member _.pointerOut (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOut(element, (createObj !!eventProperties))
        member _.pointerOver (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOver(element, (createObj !!eventProperties))
        member _.pointerUp (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerUp(element, (createObj !!eventProperties))
        member _.popState (?eventProperties: #IEventProperty list) = Bindings.createEvent.popState(element, (createObj !!eventProperties))        
        member _.progress (?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.progress(element, (createObj !!eventProperties))
        member _.rateChange (?eventProperties: #IEventProperty list) = Bindings.createEvent.rateChange(element, (createObj !!eventProperties))
        member _.reset (?eventProperties: #IEventProperty list) = Bindings.createEvent.reset(element, (createObj !!eventProperties))
        member _.scroll (?eventProperties: #IEventProperty list) = Bindings.createEvent.scroll(element, (createObj !!eventProperties))
        member _.seeked (?eventProperties: #IEventProperty list) = Bindings.createEvent.seeked(element, (createObj !!eventProperties))
        member _.seeking (?eventProperties: #IEventProperty list) = Bindings.createEvent.seeking(element, (createObj !!eventProperties))
        member _.select (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.select(element, (createObj !!eventProperties))
        member _.stalled (?eventProperties: #IEventProperty list) = Bindings.createEvent.stalled(element, (createObj !!eventProperties))
        member _.submit (?eventProperties: #IEventProperty list) = Bindings.createEvent.submit(element, (createObj !!eventProperties))
        member _.suspend (?eventProperties: #IEventProperty list) = Bindings.createEvent.suspend(element, (createObj !!eventProperties))
        member _.timeUpdate (?eventProperties: #IEventProperty list) = Bindings.createEvent.timeUpdate(element, (createObj !!eventProperties))
        member _.touchCancel (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchCancel(element, (createObj !!eventProperties))
        member _.touchEnd (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchEnd(element, (createObj !!eventProperties))
        member _.touchMove (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchMove(element, (createObj !!eventProperties))
        member _.touchStart (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchStart(element, (createObj !!eventProperties))
        member _.transitionEnd (?eventProperties: #ITransitionEventProperty list) = Bindings.createEvent.transitionEnd(element, (createObj !!eventProperties))
        member _.volumeChange (?eventProperties: #IEventProperty list) = Bindings.createEvent.volumeChange(element, (createObj !!eventProperties))
        member _.waiting (?eventProperties: #IEventProperty list) = Bindings.createEvent.waiting(element, (createObj !!eventProperties))
        member _.wheel (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.wheel(element, (createObj !!eventProperties))

    [<NoComparison>]
    [<NoEquality>]
    type HTMLElementFireEvent (element: HTMLElement) =
        member _.abort (?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.abort(element, (createObj !!eventProperties))
        member _.abort (?eventProperties: IUIEventProperty list) = Bindings.fireEvent.abort(element, (createObj !!eventProperties))
        member _.animationEnd (?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationEnd(element, (createObj !!eventProperties))
        member _.animationIteration (?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationIteration(element, (createObj !!eventProperties))
        member _.animationStart (?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationStart(element, (createObj !!eventProperties))
        member _.blur (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.blur(element, (createObj !!eventProperties))
        member _.canPlay (?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlay(element, (createObj !!eventProperties))
        member _.canPlayThrough (?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlayThrough(element, (createObj !!eventProperties))
        member _.change (?eventProperties: #IEventProperty list) = Bindings.fireEvent.change(element, (createObj !!eventProperties))
        member _.click (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.click(element, (createObj !!eventProperties))
        member _.compositionEnd (?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionEnd(element, (createObj !!eventProperties))
        member _.compositionStart (?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionStart(element, (createObj !!eventProperties))
        member _.compositionUpdate (?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionUpdate(element, (createObj !!eventProperties))
        member _.contextMenu (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.contextMenu(element, (createObj !!eventProperties))
        member _.copy (?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.copy(element, (createObj !!eventProperties))
        member _.cut (?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.cut(element, (createObj !!eventProperties))
        member _.dblClick (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.dblClick(element, (createObj !!eventProperties))
        member _.doubleClick (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.doubleClick(element, (createObj !!eventProperties))
        member _.drag (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drag(element, (createObj !!eventProperties))
        member _.dragEnd (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnd(element, (createObj !!eventProperties))
        member _.dragEnter (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnter(element, (createObj !!eventProperties))
        member _.dragExit (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragExit(element, (createObj !!eventProperties))
        member _.dragLeave (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragLeave(element, (createObj !!eventProperties))
        member _.dragOver (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragOver(element, (createObj !!eventProperties))
        member _.dragStart (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragStart(element, (createObj !!eventProperties))
        member _.drop (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drop(element, (createObj !!eventProperties))
        member _.durationChange (?eventProperties: #IEventProperty list) = Bindings.fireEvent.durationChange(element, (createObj !!eventProperties))
        member _.emptied (?eventProperties: #IEventProperty list) = Bindings.fireEvent.emptied(element, (createObj !!eventProperties))
        member _.encrypted (?eventProperties: #IEventProperty list) = Bindings.fireEvent.encrypted(element, (createObj !!eventProperties))
        member _.ended (?eventProperties: #IEventProperty list) = Bindings.fireEvent.ended(element, (createObj !!eventProperties))
        member _.error (?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.error(element, (createObj !!eventProperties))
        member _.error (?eventProperties: IUIEventProperty list) = Bindings.fireEvent.error(element, (createObj !!eventProperties))
        member _.focus (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focus(element, (createObj !!eventProperties))
        member _.focusIn (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusIn(element, (createObj !!eventProperties))
        member _.focusOut (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusOut(element, (createObj !!eventProperties))
        member _.gotPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.gotPointerCapture(element, (createObj !!eventProperties))
        member _.input (?eventProperties: #IInputEventProperty list) = Bindings.fireEvent.input(element, (createObj !!eventProperties))
        member _.invalid (?eventProperties: #IEventProperty list) = Bindings.fireEvent.invalid(element, (createObj !!eventProperties))
        member _.keyDown (?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyDown(element, (createObj !!eventProperties))
        member _.keyPress (?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyPress(element, (createObj !!eventProperties))
        member _.keyUp (?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyUp(element, (createObj !!eventProperties))
        member _.load (?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.load(element, (createObj !!eventProperties))
        member _.load (?eventProperties: IUIEventProperty list) = Bindings.fireEvent.load(element, (createObj !!eventProperties))
        member _.loadedData (?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedData(element, (createObj !!eventProperties))
        member _.loadedMetadata (?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedMetadata(element, (createObj !!eventProperties))
        member _.loadStart (?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.loadStart(element, (createObj !!eventProperties))
        member _.lostPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.lostPointerCapture(element, (createObj !!eventProperties))
        member _.mouseDown (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseDown(element, (createObj !!eventProperties))
        member _.mouseEnter (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseEnter(element, (createObj !!eventProperties))
        member _.mouseLeave (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseLeave(element, (createObj !!eventProperties))
        member _.mouseMove (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseMove(element, (createObj !!eventProperties))
        member _.mouseOut (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOut(element, (createObj !!eventProperties))
        member _.mouseOver (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOver(element, (createObj !!eventProperties))
        member _.mouseUp (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseUp(element, (createObj !!eventProperties))
        member _.paste (?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.paste(element, (createObj !!eventProperties))
        member _.pause (?eventProperties: #IEventProperty list) = Bindings.fireEvent.pause(element, (createObj !!eventProperties))
        member _.play (?eventProperties: #IEventProperty list) = Bindings.fireEvent.play(element, (createObj !!eventProperties))
        member _.playing (?eventProperties: #IEventProperty list) = Bindings.fireEvent.playing(element, (createObj !!eventProperties))
        member _.pointerCancel (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerCancel(element, (createObj !!eventProperties))
        member _.pointerDown (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerDown(element, (createObj !!eventProperties))
        member _.pointerEnter (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerEnter(element, (createObj !!eventProperties))
        member _.pointerLeave (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerLeave(element, (createObj !!eventProperties))
        member _.pointerMove (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerMove(element, (createObj !!eventProperties))
        member _.pointerOut (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOut(element, (createObj !!eventProperties))
        member _.pointerOver (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOver(element, (createObj !!eventProperties))
        member _.pointerUp (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerUp(element, (createObj !!eventProperties))
        member _.popState (?eventProperties: #IEventProperty list) = Bindings.fireEvent.popState(element, (createObj !!eventProperties))        
        member _.progress (?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.progress(element, (createObj !!eventProperties))
        member _.rateChange (?eventProperties: #IEventProperty list) = Bindings.fireEvent.rateChange(element, (createObj !!eventProperties))
        member _.reset (?eventProperties: #IEventProperty list) = Bindings.fireEvent.reset(element, (createObj !!eventProperties))
        member _.scroll (?eventProperties: #IEventProperty list) = Bindings.fireEvent.scroll(element, (createObj !!eventProperties))
        member _.seeked (?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeked(element, (createObj !!eventProperties))
        member _.seeking (?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeking(element, (createObj !!eventProperties))
        member _.select (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.select(element, (createObj !!eventProperties))
        member _.stalled (?eventProperties: #IEventProperty list) = Bindings.fireEvent.stalled(element, (createObj !!eventProperties))
        member _.submit (?eventProperties: #IEventProperty list) = Bindings.fireEvent.submit(element, (createObj !!eventProperties))
        member _.suspend (?eventProperties: #IEventProperty list) = Bindings.fireEvent.suspend(element, (createObj !!eventProperties))
        member _.timeUpdate (?eventProperties: #IEventProperty list) = Bindings.fireEvent.timeUpdate(element, (createObj !!eventProperties))
        member _.touchCancel (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchCancel(element, (createObj !!eventProperties))
        member _.touchEnd (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchEnd(element, (createObj !!eventProperties))
        member _.touchMove (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchMove(element, (createObj !!eventProperties))
        member _.touchStart (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchStart(element, (createObj !!eventProperties))
        member _.transitionEnd (?eventProperties: #ITransitionEventProperty list) = Bindings.fireEvent.transitionEnd(element, (createObj !!eventProperties))
        member _.volumeChange (?eventProperties: #IEventProperty list) = Bindings.fireEvent.volumeChange(element, (createObj !!eventProperties))
        member _.waiting (?eventProperties: #IEventProperty list) = Bindings.fireEvent.waiting(element, (createObj !!eventProperties))
        member _.wheel (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.wheel(element, (createObj !!eventProperties))

    [<NoComparison>]
    [<NoEquality>]
    type HTMLElementUserEvent (element: HTMLElement) =
        /// Clicks element, depending on what element is it can have different side effects.
        member _.click () : unit = Bindings.userEvent.click(element)
        /// Clicks element twice, depending on what element is it can have different side effects.
        member _.dblClick () : unit = Bindings.userEvent.dblClick(element)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        member _.selectOptions (values: 'T []) : unit = Bindings.userEvent.selectOptions(element, values)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        member _.selectOptions (values: 'T list) : unit = Bindings.userEvent.selectOptions(element, values)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        member _.selectOptions (values: ResizeArray<'T>) : unit = Bindings.userEvent.selectOptions(element, values)
        /// Fires a tab event changing the document.activeElement in the same way the browser does.
        member _.tab (shift: bool, focusTrap: HTMLElement) : unit = Bindings.userEvent.tab(shift, focusTrap)
        /// Writes text inside an <input> or a <textarea>.
        member _.type' (text: string) : JS.Promise<unit> = Bindings.userEvent.typeInternal(element, text)
        /// Writes text inside an <input> or a <textarea>.
        member _.type' (text: string, allAtOnce: bool) : JS.Promise<unit> = 
            Bindings.userEvent.typeInternal(element, text, toPlainJsObj {| allAtOnce = allAtOnce |})
        /// Writes text inside an <input> or a <textarea>.
        member _.type' (text: string, delay: int) : JS.Promise<unit> = 
            Bindings.userEvent.typeInternal(element, text, toPlainJsObj {| delay = delay |})
        /// Writes text inside an <input> or a <textarea>.
        member _.type' (text: string, allAtOnce: bool, delay: int) : JS.Promise<unit> = 
            Bindings.userEvent.typeInternal(element, text, toPlainJsObj {| allAtOnce = allAtOnce; delay = delay |})

    type Browser.Types.HTMLElement with
        member this.createEvent = HTMLElementCreateEvent(this)
        member this.fireEvent = HTMLElementFireEvent(this)
        member this.userEvent = HTMLElementUserEvent(this)
