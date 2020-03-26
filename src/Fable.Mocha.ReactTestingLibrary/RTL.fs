namespace Fable.Mocha.ReactTestingLibrary

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser.Types
    
[<Erase>]
type RTL =
    /// This is a light wrapper around the react-dom/test-utils act function. 
    /// All it does is forward all arguments to the act function if your version of react supports act.
    static member inline act (callback: unit -> unit) = Bindings.actImport.invoke callback

    /// This is a light wrapper around the react-dom/test-utils act function. All it does is 
    /// forward all arguments to the act function if your version of react supports act.
    /// Unmounts React trees that were mounted with render.
    static member inline cleanup () = Bindings.cleanupImport.invoke()

    /// Set the configuration options.
    static member inline configure (options: IConfigureOption list) = 
        Bindings.configureImport.invoke(unbox<IConfigureOptions> (createObj !!options))

    /// Fires a DOM event.
    static member inline fireEvent (element: HTMLElement, event: #Browser.Types.Event) = 
        Bindings.fireEventImport.custom(element, event)

    static member inline getNodeText (element: HTMLElement) =
        Bindings.getNodeTextImport.invoke element

    /// Allows iteration over the implicit ARIA roles represented 
    /// in a given tree of DOM nodes.
    ///
    /// It returns an object, indexed by role name, with each value being an 
    /// array of elements which have that implicit ARIA role.
    static member inline getRoles (element: HTMLElement) =
        Bindings.getRolesImport.invoke element

    /// Compute if the given element should be excluded from the accessibility API by the browser. 
    /// 
    /// It implements every MUST criteria from the Excluding Elements from the Accessibility Tree 
    /// section in WAI-ARIA 1.2 with the exception of checking the role attribute.
    static member inline isInaccessible (element: HTMLElement) =
        Bindings.isInaccessibleImport.invoke element

    /// Print out a list of all the implicit ARIA roles within a tree of DOM nodes, each role 
    /// containing a list of all of the nodes which match that role.
    static member inline logRoles (element: HTMLElement) =
        Bindings.logRolesImport.invoke element

    /// Prints out readable representation of the DOM tree of a node.
    static member inline prettyDOM (element: HTMLElement) =
        Bindings.prettyDOMImport.invoke element

    /// Prints out readable representation of the DOM tree of a node.
    static member inline prettyDOM (element: HTMLElement, maxLength: int) =
        Bindings.prettyDOMImport.invoke(element, maxLength = maxLength)

    /// Prints out readable representation of the DOM tree of a node.
    static member inline prettyDOM (element: HTMLElement, options: IPrettyDOMOption list) =
        Bindings.prettyDOMImport.invoke(element, options = (unbox<IPrettyDOMOptions> (createObj !!options)))

    /// Prints out readable representation of the DOM tree of a node.
    static member inline prettyDOM (element: HTMLElement, maxLength: int, options: IPrettyDOMOption list) =
        Bindings.prettyDOMImport.invoke(element, maxLength = maxLength, options = (unbox<IPrettyDOMOptions> (createObj !!options)))

    /// Render into a container which is appended to document.body.
    static member inline render (reactElement: ReactElement) = 
        Bindings.renderImport.invoke reactElement
        |> Bindings.render
    /// Render into a container which is appended to document.body.
    static member inline render (reactElement: ReactElement, options: IRenderOption list) = 
        Bindings.renderImport.invoke(reactElement, unbox<IRenderOptions> (createObj !!options))
        |> Bindings.render

    /// When in need to wait for any period of time you can use waitFor, to wait for your expectations to pass.
    static member inline waitFor (callback: unit -> 'T) = Bindings.waitForImport.invoke callback |> Async.AwaitPromise
    /// When in need to wait for any period of time you can use waitFor, to wait for your expectations to pass.
    static member inline waitFor (callback: unit -> 'T, waitForOptions: IWaitOption list) = 
        Bindings.waitForImport.invoke(callback, unbox<IWaitOptions> (createObj !!waitForOptions)) 
        |> Async.AwaitPromise

    /// To wait for the removal of element(s) from the DOM you can use waitForElementToBeRemoved.
    static member inline waitForElementToBeRemoved (callback: unit -> 'T) = 
        Bindings.waitForElementToBeRemovedImport.invoke callback |> Async.AwaitPromise
    /// To wait for the removal of element(s) from the DOM you can use waitForElementToBeRemoved.
    static member inline waitForElementToBeRemoved (callback: unit -> 'T, waitForOptions: IWaitOption list) = 
        Bindings.waitForElementToBeRemovedImport.invoke(callback, unbox<IWaitOptions> (createObj !!waitForOptions)) 
        |> Async.AwaitPromise

    /// Takes a DOM element and binds it to the raw query functions, allowing them to be used without specifying a container. 
    static member inline within (element: HTMLElement) =
        Bindings.withinImport.invoke element
        |> Bindings.queriesForElement

[<Erase>]
type configure =
    /// The default value for the hidden option used by getByRole. 
    ///
    /// Defaults to false.
    static member inline defaultHidden (value: bool) = Interop.mkConfigureOption "defaultHidden" value

    /// A function that returns the error used when getBy* or getAllBy* fail. 
    /// Takes the error message and container object as arguments.
    static member inline getElementError (handler: string * HTMLElement -> exn) = 
        Interop.mkConfigureOption "getElementError" handler

    /// The attribute used by getByTestId and related queries. 
    ///
    /// Defaults to data-testid.
    static member inline testIdAttribute (value: string) = Interop.mkConfigureOption "defaultHidden" value

[<Erase>]
type prettyDOM =
    /// Call toJSON method (if it exists) on objects.
    static member inline callToJSON (value: bool) = Interop.mkPrettyDOMOption "callToJSON" value
    /// Escape special characters in regular expressions.
    static member inline escapeRegex (value: bool) = Interop.mkPrettyDOMOption "escapeRegex" value
    /// Escape special characters in strings.
    static member inline escapeString (value: bool) = Interop.mkPrettyDOMOption "escapeString" value
    /// Highlight syntax with colors in terminal (some plugins).
    static member inline highlight (value: bool) = Interop.mkPrettyDOMOption "highlight" value
    /// Spaces in each level of indentation.
    static member inline indent (value: int) = Interop.mkPrettyDOMOption "indent" value
    /// Levels to print in arrays, objects, elements, .. etc.
    static member inline maxDepth (value: int) = Interop.mkPrettyDOMOption "maxDepth" value
    /// Minimize added space: no indentation nor line breaks.
    static member inline min (value: bool) = Interop.mkPrettyDOMOption "min" value
    /// Plugins to serialize application-specific data types.
    static member inline plugins (value: seq<string>) = Interop.mkPrettyDOMOption "plugins" (ResizeArray value)
    /// Include or omit the name of a function.
    static member inline printFunctionName (value: bool) = Interop.mkPrettyDOMOption "printFunctionName" value
    /// Colors to highlight syntax in terminal.
    static member inline theme (properties: IPrettyDOMThemeOption list) = Interop.mkPrettyDOMOption "theme" (createObj !!properties)

[<RequireQualifiedAccess>]
module prettyDOM =
    /// PrettyDOM theme options.
    [<Erase>]
    type theme =
        /// Default: "gray"
        static member inline comment (value: string) = Interop.mkPrettyDOMOThemeption "comment" value
        /// Default: "reset"
        static member inline content (value: string) = Interop.mkPrettyDOMOThemeption "content" value
        /// Default: "yellow"
        static member inline prop (value: string) = Interop.mkPrettyDOMOThemeption "prop" value
        /// Default: "cyan"
        static member inline tag (value: string) = Interop.mkPrettyDOMOThemeption "tag" value
        /// Default: "green"
        static member inline value (value: string) = Interop.mkPrettyDOMOThemeption "plugins" value

[<Erase>]
type waitFor =
    /// The default container is the global document. 
    ///
    /// Make sure the elements you wait for are descendants of container.
    static member inline container (element: HTMLElement) = Interop.mkWaitOption "container" element

    /// The default interval is 50ms. 
    ///
    /// However it will run your callback immediately before starting the intervals.
    static member inline interval (value: int) = Interop.mkWaitOption "interval" value

    /// Sets the configuration of the mutation observer.
    static member inline mutationObserver (options: IMutationObserverOption list) = Interop.mkWaitOption "mutationObserverOptions" (createObj !!options)

    /// The default timeout is 1000ms.
    static member inline timeout (value: int) = Interop.mkWaitOption "timeout" value

module waitFor =
    [<Erase>]
    type mutationObserver =
        /// An array of specific attribute names to be monitored. 
        ///
        /// If this property isn't included, changes to all attributes cause mutation notifications.
        static member inline attributeFiler (filter: string) = Interop.mkMutationObserverOption "attributeFilter" (filter |> Array.singleton |> ResizeArray)

        /// An array of specific attribute names to be monitored. 
        ///
        /// If this property isn't included, changes to all attributes cause mutation notifications.
        static member inline attributeFiler (filters: string list) = Interop.mkMutationObserverOption "attributeFilter" (filters |> ResizeArray)

        /// Set to true to record the previous value of any attribute that changes when monitoring the node or nodes for attribute changes.
        ///
        /// The default value is `false` via omission.
        static member inline attributeOldValue (value: bool) = Interop.mkMutationObserverOption "attributeOldValue" value

        /// Set to true to watch for changes to the value of attributes on the node or nodes being monitored. 
        ///
        /// The default value is false.
        static member inline attributes (value: bool) = Interop.mkMutationObserverOption "attributes" value

        /// Set to true to monitor the specified target node or subtree for changes to the character data contained within the node or nodes. 
        ///
        /// The default value is `false` via omission.
        static member inline characterData (value: bool) = Interop.mkMutationObserverOption "characterData" value

        /// Set to true to record the previous value of a node's text whenever the text changes on nodes being monitored.
        ///
        /// The default value is `false` via omission.
        static member inline characterDataOldValue (value: bool) = Interop.mkMutationObserverOption "characterDataOldValue" value

        /// Set to true to monitor the target node (and, if subtree is true, its descendants) for the addition of 
        /// new child nodes or removal of existing child nodes. 
        ///
        /// The default is false.
        static member inline childList (value: bool) = Interop.mkMutationObserverOption "childList" value

        /// Set to true to extend monitoring to the entire subtree of nodes rooted at target. All of the other MutationObserverInit properties 
        /// are then extended to all of the nodes in the subtree instead of applying solely to the target node. 
        ///
        /// The default value is false.
        static member inline subtree (value: bool) = Interop.mkMutationObserverOption "subtree" value

[<Erase>]
type render =
    /// By default, React Testing Library will create a div and append that div to the document.body and 
    /// this is where your React component will be rendered. If you provide your own HTMLElement container 
    /// via this option, it will not be appended to the document.body automatically.
    static member inline container (value: HTMLElement) = Interop.mkRenderOption "container" value

    /// If the container is specified, then this defaults to that, otherwise this defaults to document.documentElement. 
    /// This is used as the base element for the queries as well as what is printed when you use debug().
    static member inline baseElement (value: HTMLElement) = Interop.mkRenderOption "container" value

    /// If hydrate is set to true, then it will render with ReactDOM.hydrate. This may be useful if you 
    /// are using server-side rendering and use ReactDOM.hydrate to mount your components.
    static member inline hydrate (value: bool) = Interop.mkRenderOption "container" value

    /// Pass a React Component as the wrapper option to have it rendered around the inner element. 
    /// This is most useful for creating reusable custom render functions for common data providers.
    static member inline wrapper (value: ReactElement) = Interop.mkRenderOption "container" value

[<RequireQualifiedAccess>]
module RTL =
    /// Convenience methods for creating DOM events that can then be fired by fireEvent, allowing you to have a 
    /// reference to the event created: this might be useful if you need to access event properties that cannot 
    /// be initiated programmatically (such as timeStamp).
    [<Erase>]
    type createEvent =
        static member inline abort (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEventImport.abort(element, (createObj !!eventProperties))
        static member inline abort (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEventImport.abort(element, (createObj !!eventProperties))
        static member inline animationEnd (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEventImport.animationEnd(element, (createObj !!eventProperties))
        static member inline animationIteration (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEventImport.animationIteration(element, (createObj !!eventProperties))
        static member inline animationStart (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEventImport.animationStart(element, (createObj !!eventProperties))
        static member inline blur (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEventImport.blur(element, (createObj !!eventProperties))
        static member inline canPlay (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.canPlay(element, (createObj !!eventProperties))
        static member inline canPlayThrough (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.canPlayThrough(element, (createObj !!eventProperties))
        static member inline change (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.change(element, (createObj !!eventProperties))
        static member inline click (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.click(element, (createObj !!eventProperties))
        static member inline compositionEnd (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEventImport.compositionEnd(element, (createObj !!eventProperties))
        static member inline compositionStart (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEventImport.compositionStart(element, (createObj !!eventProperties))
        static member inline compositionUpdate (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEventImport.compositionUpdate(element, (createObj !!eventProperties))
        static member inline contextMenu (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.contextMenu(element, (createObj !!eventProperties))
        static member inline copy (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEventImport.copy(element, (createObj !!eventProperties))
        static member inline cut (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEventImport.cut(element, (createObj !!eventProperties))
        static member inline dblClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.dblClick(element, (createObj !!eventProperties))
        static member inline doubleClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.doubleClick(element, (createObj !!eventProperties))
        static member inline drag (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.drag(element, (createObj !!eventProperties))
        static member inline dragEnd (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragEnd(element, (createObj !!eventProperties))
        static member inline dragEnter (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragEnter(element, (createObj !!eventProperties))
        static member inline dragExit (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragExit(element, (createObj !!eventProperties))
        static member inline dragLeave (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragLeave(element, (createObj !!eventProperties))
        static member inline dragOver (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragOver(element, (createObj !!eventProperties))
        static member inline dragStart (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.dragStart(element, (createObj !!eventProperties))
        static member inline drop (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEventImport.drop(element, (createObj !!eventProperties))
        static member inline durationChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.durationChange(element, (createObj !!eventProperties))
        static member inline emptied (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.emptied(element, (createObj !!eventProperties))
        static member inline encrypted (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.encrypted(element, (createObj !!eventProperties))
        static member inline ended (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.ended(element, (createObj !!eventProperties))
        static member inline error (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEventImport.error(element, (createObj !!eventProperties))
        static member inline error (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEventImport.error(element, (createObj !!eventProperties))
        static member inline focus (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEventImport.focus(element, (createObj !!eventProperties))
        static member inline focusIn (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEventImport.focusIn(element, (createObj !!eventProperties))
        static member inline focusOut (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEventImport.focusOut(element, (createObj !!eventProperties))
        static member inline gotPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.gotPointerCapture(element, (createObj !!eventProperties))
        static member inline input (element: HTMLElement, ?eventProperties: #IInputEventProperty list) = Bindings.createEventImport.input(element, (createObj !!eventProperties))
        static member inline invalid (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.invalid(element, (createObj !!eventProperties))
        static member inline keyDown (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEventImport.keyDown(element, (createObj !!eventProperties))
        static member inline keyPress (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEventImport.keyPress(element, (createObj !!eventProperties))
        static member inline keyUp (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEventImport.keyUp(element, (createObj !!eventProperties))
        static member inline load (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEventImport.load(element, (createObj !!eventProperties))
        static member inline load (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEventImport.load(element, (createObj !!eventProperties))
        static member inline loadedData (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.loadedData(element, (createObj !!eventProperties))
        static member inline loadedMetadata (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.loadedMetadata(element, (createObj !!eventProperties))
        static member inline loadStart (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.createEventImport.loadStart(element, (createObj !!eventProperties))
        static member inline lostPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.lostPointerCapture(element, (createObj !!eventProperties))
        static member inline mouseDown (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseDown(element, (createObj !!eventProperties))
        static member inline mouseEnter (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseEnter(element, (createObj !!eventProperties))
        static member inline mouseLeave (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseLeave(element, (createObj !!eventProperties))
        static member inline mouseMove (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseMove(element, (createObj !!eventProperties))
        static member inline mouseOut (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseOut(element, (createObj !!eventProperties))
        static member inline mouseOver (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseOver(element, (createObj !!eventProperties))
        static member inline mouseUp (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.mouseUp(element, (createObj !!eventProperties))
        static member inline paste (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEventImport.paste(element, (createObj !!eventProperties))
        static member inline pause (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.pause(element, (createObj !!eventProperties))
        static member inline play (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.play(element, (createObj !!eventProperties))
        static member inline playing (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.playing(element, (createObj !!eventProperties))
        static member inline pointerCancel (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerCancel(element, (createObj !!eventProperties))
        static member inline pointerDown (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerDown(element, (createObj !!eventProperties))
        static member inline pointerEnter (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerEnter(element, (createObj !!eventProperties))
        static member inline pointerLeave (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerLeave(element, (createObj !!eventProperties))
        static member inline pointerMove (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerMove(element, (createObj !!eventProperties))
        static member inline pointerOut (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerOut(element, (createObj !!eventProperties))
        static member inline pointerOver (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerOver(element, (createObj !!eventProperties))
        static member inline pointerUp (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEventImport.pointerUp(element, (createObj !!eventProperties))
        static member inline popState (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.popState(element, (createObj !!eventProperties))        
        static member inline progress (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.createEventImport.progress(element, (createObj !!eventProperties))
        static member inline rateChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.rateChange(element, (createObj !!eventProperties))
        static member inline reset (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.reset(element, (createObj !!eventProperties))
        static member inline scroll (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.scroll(element, (createObj !!eventProperties))
        static member inline seeked (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.seeked(element, (createObj !!eventProperties))
        static member inline seeking (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.seeking(element, (createObj !!eventProperties))
        static member inline select (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.select(element, (createObj !!eventProperties))
        static member inline stalled (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.stalled(element, (createObj !!eventProperties))
        static member inline submit (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.submit(element, (createObj !!eventProperties))
        static member inline suspend (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.suspend(element, (createObj !!eventProperties))
        static member inline timeUpdate (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.timeUpdate(element, (createObj !!eventProperties))
        static member inline touchCancel (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEventImport.touchCancel(element, (createObj !!eventProperties))
        static member inline touchEnd (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEventImport.touchEnd(element, (createObj !!eventProperties))
        static member inline touchMove (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEventImport.touchMove(element, (createObj !!eventProperties))
        static member inline touchStart (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEventImport.touchStart(element, (createObj !!eventProperties))
        static member inline transitionEnd (element: HTMLElement, ?eventProperties: #ITransitionEventProperty list) = Bindings.createEventImport.transitionEnd(element, (createObj !!eventProperties))
        static member inline volumeChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.volumeChange(element, (createObj !!eventProperties))
        static member inline waiting (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEventImport.waiting(element, (createObj !!eventProperties))
        static member inline wheel (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEventImport.wheel(element, (createObj !!eventProperties))

    /// Convenience methods for firing DOM events.
    [<Erase>]
    type fireEvent =
        static member inline abort (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEventImport.abort(element, (createObj !!eventProperties))
        static member inline abort (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEventImport.abort(element, (createObj !!eventProperties))
        static member inline animationEnd (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEventImport.animationEnd(element, (createObj !!eventProperties))
        static member inline animationIteration (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEventImport.animationIteration(element, (createObj !!eventProperties))
        static member inline animationStart (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEventImport.animationStart(element, (createObj !!eventProperties))
        static member inline blur (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEventImport.blur(element, (createObj !!eventProperties))
        static member inline canPlay (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.canPlay(element, (createObj !!eventProperties))
        static member inline canPlayThrough (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.canPlayThrough(element, (createObj !!eventProperties))
        static member inline change (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.change(element, (createObj !!eventProperties))
        static member inline click (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.click(element, (createObj !!eventProperties))
        static member inline compositionEnd (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEventImport.compositionEnd(element, (createObj !!eventProperties))
        static member inline compositionStart (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEventImport.compositionStart(element, (createObj !!eventProperties))
        static member inline compositionUpdate (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEventImport.compositionUpdate(element, (createObj !!eventProperties))
        static member inline contextMenu (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.contextMenu(element, (createObj !!eventProperties))
        static member inline copy (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEventImport.copy(element, (createObj !!eventProperties))
        static member inline cut (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEventImport.cut(element, (createObj !!eventProperties))
        static member inline dblClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.dblClick(element, (createObj !!eventProperties))
        static member inline doubleClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.doubleClick(element, (createObj !!eventProperties))
        static member inline drag (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.drag(element, (createObj !!eventProperties))
        static member inline dragEnd (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragEnd(element, (createObj !!eventProperties))
        static member inline dragEnter (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragEnter(element, (createObj !!eventProperties))
        static member inline dragExit (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragExit(element, (createObj !!eventProperties))
        static member inline dragLeave (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragLeave(element, (createObj !!eventProperties))
        static member inline dragOver (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragOver(element, (createObj !!eventProperties))
        static member inline dragStart (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.dragStart(element, (createObj !!eventProperties))
        static member inline drop (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEventImport.drop(element, (createObj !!eventProperties))
        static member inline durationChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.durationChange(element, (createObj !!eventProperties))
        static member inline emptied (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.emptied(element, (createObj !!eventProperties))
        static member inline encrypted (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.encrypted(element, (createObj !!eventProperties))
        static member inline ended (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.ended(element, (createObj !!eventProperties))
        static member inline error (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEventImport.error(element, (createObj !!eventProperties))
        static member inline error (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEventImport.error(element, (createObj !!eventProperties))
        static member inline focus (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEventImport.focus(element, (createObj !!eventProperties))
        static member inline focusIn (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEventImport.focusIn(element, (createObj !!eventProperties))
        static member inline focusOut (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEventImport.focusOut(element, (createObj !!eventProperties))
        static member inline gotPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.gotPointerCapture(element, (createObj !!eventProperties))
        static member inline input (element: HTMLElement, ?eventProperties: #IInputEventProperty list) = Bindings.fireEventImport.input(element, (createObj !!eventProperties))
        static member inline invalid (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.invalid(element, (createObj !!eventProperties))
        static member inline keyDown (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEventImport.keyDown(element, (createObj !!eventProperties))
        static member inline keyPress (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEventImport.keyPress(element, (createObj !!eventProperties))
        static member inline keyUp (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEventImport.keyUp(element, (createObj !!eventProperties))
        static member inline load (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEventImport.load(element, (createObj !!eventProperties))
        static member inline load (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEventImport.load(element, (createObj !!eventProperties))
        static member inline loadedData (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.loadedData(element, (createObj !!eventProperties))
        static member inline loadedMetadata (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.loadedMetadata(element, (createObj !!eventProperties))
        static member inline loadStart (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.fireEventImport.loadStart(element, (createObj !!eventProperties))
        static member inline lostPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.lostPointerCapture(element, (createObj !!eventProperties))
        static member inline mouseDown (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseDown(element, (createObj !!eventProperties))
        static member inline mouseEnter (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseEnter(element, (createObj !!eventProperties))
        static member inline mouseLeave (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseLeave(element, (createObj !!eventProperties))
        static member inline mouseMove (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseMove(element, (createObj !!eventProperties))
        static member inline mouseOut (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseOut(element, (createObj !!eventProperties))
        static member inline mouseOver (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseOver(element, (createObj !!eventProperties))
        static member inline mouseUp (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.mouseUp(element, (createObj !!eventProperties))
        static member inline paste (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEventImport.paste(element, (createObj !!eventProperties))
        static member inline pause (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.pause(element, (createObj !!eventProperties))
        static member inline play (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.play(element, (createObj !!eventProperties))
        static member inline playing (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.playing(element, (createObj !!eventProperties))
        static member inline pointerCancel (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerCancel(element, (createObj !!eventProperties))
        static member inline pointerDown (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerDown(element, (createObj !!eventProperties))
        static member inline pointerEnter (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerEnter(element, (createObj !!eventProperties))
        static member inline pointerLeave (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerLeave(element, (createObj !!eventProperties))
        static member inline pointerMove (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerMove(element, (createObj !!eventProperties))
        static member inline pointerOut (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerOut(element, (createObj !!eventProperties))
        static member inline pointerOver (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerOver(element, (createObj !!eventProperties))
        static member inline pointerUp (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEventImport.pointerUp(element, (createObj !!eventProperties))
        static member inline popState (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.popState(element, (createObj !!eventProperties))        
        static member inline progress (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.fireEventImport.progress(element, (createObj !!eventProperties))
        static member inline rateChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.rateChange(element, (createObj !!eventProperties))
        static member inline reset (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.reset(element, (createObj !!eventProperties))
        static member inline scroll (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.scroll(element, (createObj !!eventProperties))
        static member inline seeked (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.seeked(element, (createObj !!eventProperties))
        static member inline seeking (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.seeking(element, (createObj !!eventProperties))
        static member inline select (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.select(element, (createObj !!eventProperties))
        static member inline stalled (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.stalled(element, (createObj !!eventProperties))
        static member inline submit (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.submit(element, (createObj !!eventProperties))
        static member inline suspend (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.suspend(element, (createObj !!eventProperties))
        static member inline timeUpdate (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.timeUpdate(element, (createObj !!eventProperties))
        static member inline touchCancel (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEventImport.touchCancel(element, (createObj !!eventProperties))
        static member inline touchEnd (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEventImport.touchEnd(element, (createObj !!eventProperties))
        static member inline touchMove (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEventImport.touchMove(element, (createObj !!eventProperties))
        static member inline touchStart (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEventImport.touchStart(element, (createObj !!eventProperties))
        static member inline transitionEnd (element: HTMLElement, ?eventProperties: #ITransitionEventProperty list) = Bindings.fireEventImport.transitionEnd(element, (createObj !!eventProperties))
        static member inline volumeChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.volumeChange(element, (createObj !!eventProperties))
        static member inline waiting (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEventImport.waiting(element, (createObj !!eventProperties))
        static member inline wheel (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEventImport.wheel(element, (createObj !!eventProperties))
