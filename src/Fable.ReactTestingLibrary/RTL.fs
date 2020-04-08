namespace Fable.ReactTestingLibrary

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser.Types

type RTL =
    /// This is a light wrapper around the react-dom/test-utils act function. 
    /// All it does is forward all arguments to the act function if your version of react supports act.
    static member act (callback: unit -> unit) = Bindings.act callback

    /// Unmounts React trees that were mounted with render.
    static member cleanup () = Bindings.cleanup()

    /// Set the configuration options.
    static member configure (options: IConfigureOption list) = 
        Bindings.configure(unbox<IConfigureOptions> (createObj !!options))

    /// Fires a DOM event.
    static member fireEvent (element: HTMLElement, event: #Browser.Types.Event) = 
        Bindings.fireEvent.custom(element, event)

    /// Gets the text of the element.
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

    /// Returns a readable representation of the DOM tree of a node.
    static member prettyDOM (element: HTMLElement) =
        Bindings.prettyDOMImport.invoke element

    /// Returns a readable representation of the DOM tree of a node.
    static member prettyDOM (node: Node) =
        Bindings.prettyDOMImport.invoke (unbox<HTMLElement> node)

    /// Returns a readable representation of the DOM tree of a node.
    static member prettyDOM (element: HTMLElement, maxLength: int) =
        Bindings.prettyDOMImport.invoke(element, maxLength = maxLength)

    /// Returns a readable representation of the DOM tree of a node.
    static member prettyDOM (element: HTMLElement, options: IPrettyDOMOption list) =
        Bindings.prettyDOMImport.invoke(element, options = (unbox<IPrettyDOMOptions> (createObj !!options)))

    /// Returns a readable representation of the DOM tree of a node.
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
    static member waitFor (callback: unit -> 'T) = Bindings.waitForImport.invoke callback
    /// When in need to wait for any period of time you can use waitFor, to wait for your expectations to pass.
    static member waitFor (callback: unit -> 'T, waitForOptions: IWaitOption list) = 
        Bindings.waitForImport.invoke(callback, unbox<IWaitOptions> (createObj !!waitForOptions)) 

    /// Wait for the removal of element(s) from the DOM.
    static member waitForElementToBeRemoved (callback: unit -> 'T) = 
        Bindings.waitForElementToBeRemovedImport.invoke callback
    /// Wait for the removal of element(s) from the DOM.
    static member waitForElementToBeRemoved (callback: unit -> 'T, waitForOptions: IWaitOption list) = 
        Bindings.waitForElementToBeRemovedImport.invoke(callback, unbox<IWaitOptions> (createObj !!waitForOptions)) 

    /// Takes a DOM element and binds it to the raw query functions, allowing them to be used without specifying a container. 
    static member within (element: HTMLElement) =
        Bindings.withinImport.invoke element
        |> Bindings.queriesForElement

type configureOption =
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

type prettyDOMOption =
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
module prettyDOMOption =
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
        static member value (value: string) = Interop.mkPrettyDOMOThemeption "value" value

type renderOption =
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

type waitForOption =
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

[<RequireQualifiedAccess>]
module waitForOption =
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

[<RequireQualifiedAccess>]
module RTL =
    /// Convenience methods for creating DOM events that can then be fired by fireEvent, allowing you to have a 
    /// reference to the event created: this might be useful if you need to access event properties that cannot 
    /// be initiated programmatically (such as timeStamp).
    type createEvent =
        static member abort (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEvent.abort(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member abort (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEvent.abort(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member animationEnd (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member animationIteration (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationIteration(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member animationStart (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member blur (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.blur(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member canPlay (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlay(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member canPlayThrough (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlayThrough(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member change (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.change(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member click (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.click(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member compositionEnd (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member compositionStart (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member compositionUpdate (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionUpdate(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member contextMenu (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.contextMenu(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member copy (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.copy(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member cut (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.cut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dblClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.dblClick(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member doubleClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.doubleClick(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member drag (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drag(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragEnd (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragEnter (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragExit (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragExit(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragLeave (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragOver (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragStart (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member drop (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drop(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member durationChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.durationChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member emptied (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.emptied(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member encrypted (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.encrypted(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member ended (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.ended(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member error (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEvent.error(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member error (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEvent.error(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member focus (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focus(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member focusIn (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusIn(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member focusOut (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member gotPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.gotPointerCapture(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member input (element: HTMLElement, ?eventProperties: #IInputEventProperty list) = Bindings.createEvent.input(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member invalid (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.invalid(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member keyDown (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member keyPress (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyPress(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member keyUp (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member load (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEvent.load(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member load (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEvent.load(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member loadedData (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedData(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member loadedMetadata (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedMetadata(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member loadStart (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.loadStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member lostPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.lostPointerCapture(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseDown (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseEnter (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseLeave (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseMove (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseOut (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseOver (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseUp (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member paste (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.paste(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pause (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.pause(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member play (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.play(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member playing (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.playing(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerCancel (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerCancel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerDown (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerEnter (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerLeave (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerMove (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerOut (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerOver (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerUp (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member popState (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.popState(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))        
        static member progress (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.progress(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member rateChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.rateChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member reset (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.reset(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member scroll (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.scroll(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member seeked (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.seeked(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member seeking (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.seeking(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member select (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.select(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member stalled (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.stalled(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member submit (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.submit(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member suspend (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.suspend(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member timeUpdate (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.timeUpdate(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member touchCancel (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchCancel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member touchEnd (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member touchMove (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member touchStart (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member transitionEnd (element: HTMLElement, ?eventProperties: #ITransitionEventProperty list) = Bindings.createEvent.transitionEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member volumeChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.volumeChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member waiting (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.waiting(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member wheel (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.wheel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))

    /// Convenience methods for firing DOM events.
    type fireEvent =
        static member abort (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.abort(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member abort (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEvent.abort(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member animationEnd (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member animationIteration (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationIteration(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member animationStart (element: HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member blur (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.blur(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member canPlay (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlay(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member canPlayThrough (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlayThrough(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member change (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.change(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member click (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.click(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member compositionEnd (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member compositionStart (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member compositionUpdate (element: HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionUpdate(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member contextMenu (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.contextMenu(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member copy (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.copy(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member cut (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.cut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dblClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.dblClick(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member doubleClick (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.doubleClick(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member drag (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drag(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragEnd (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragEnter (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragExit (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragExit(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragLeave (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragOver (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member dragStart (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member drop (element: HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drop(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member durationChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.durationChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member emptied (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.emptied(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member encrypted (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.encrypted(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member ended (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.ended(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member error (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.error(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member error (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEvent.error(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member focus (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focus(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member focusIn (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusIn(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member focusOut (element: HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member gotPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.gotPointerCapture(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member input (element: HTMLElement, ?eventProperties: #IInputEventProperty list) = Bindings.fireEvent.input(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member invalid (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.invalid(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member keyDown (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member keyPress (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyPress(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member keyUp (element: HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member load (element: HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.load(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member load (element: HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEvent.load(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member loadedData (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedData(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member loadedMetadata (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedMetadata(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member loadStart (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.loadStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member lostPointerCapture (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.lostPointerCapture(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseDown (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseEnter (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseLeave (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseMove (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseOut (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseOver (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member mouseUp (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member paste (element: HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.paste(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pause (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.pause(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member play (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.play(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member playing (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.playing(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerCancel (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerCancel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerDown (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerEnter (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerLeave (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerMove (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerOut (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerOver (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member pointerUp (element: HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member popState (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.popState(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))        
        static member progress (element: HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.progress(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member rateChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.rateChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member reset (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.reset(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member scroll (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.scroll(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member seeked (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeked(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member seeking (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeking(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member select (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.select(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member stalled (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.stalled(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member submit (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.submit(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member suspend (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.suspend(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member timeUpdate (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.timeUpdate(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member touchCancel (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchCancel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member touchEnd (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member touchMove (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member touchStart (element: HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member transitionEnd (element: HTMLElement, ?eventProperties: #ITransitionEventProperty list) = Bindings.fireEvent.transitionEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member volumeChange (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.volumeChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member waiting (element: HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.waiting(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        static member wheel (element: HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.wheel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))

    /// Convenience methods for using fireEvent.
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
        member _.abort (?eventProperties: IProgressEventProperty list) = Bindings.createEvent.abort(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.abort (?eventProperties: IUIEventProperty list) = Bindings.createEvent.abort(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.animationEnd (?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.animationIteration (?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationIteration(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.animationStart (?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.blur (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.blur(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.canPlay (?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlay(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.canPlayThrough (?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlayThrough(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.change (?eventProperties: #IEventProperty list) = Bindings.createEvent.change(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.click (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.click(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.compositionEnd (?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.compositionStart (?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.compositionUpdate (?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionUpdate(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.contextMenu (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.contextMenu(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.copy (?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.copy(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.cut (?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.cut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dblClick (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.dblClick(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.doubleClick (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.doubleClick(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.drag (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drag(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragEnd (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragEnter (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragExit (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragExit(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragLeave (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragOver (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragStart (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.drop (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drop(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.durationChange (?eventProperties: #IEventProperty list) = Bindings.createEvent.durationChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.emptied (?eventProperties: #IEventProperty list) = Bindings.createEvent.emptied(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.encrypted (?eventProperties: #IEventProperty list) = Bindings.createEvent.encrypted(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.ended (?eventProperties: #IEventProperty list) = Bindings.createEvent.ended(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.error (?eventProperties: IProgressEventProperty list) = Bindings.createEvent.error(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.error (?eventProperties: IUIEventProperty list) = Bindings.createEvent.error(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.focus (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focus(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.focusIn (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusIn(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.focusOut (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.gotPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.gotPointerCapture(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.input (?eventProperties: #IInputEventProperty list) = Bindings.createEvent.input(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.invalid (?eventProperties: #IEventProperty list) = Bindings.createEvent.invalid(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.keyDown (?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.keyPress (?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyPress(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.keyUp (?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.load (?eventProperties: IProgressEventProperty list) = Bindings.createEvent.load(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.load (?eventProperties: IUIEventProperty list) = Bindings.createEvent.load(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.loadedData (?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedData(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.loadedMetadata (?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedMetadata(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.loadStart (?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.loadStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.lostPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.lostPointerCapture(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseDown (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseEnter (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseLeave (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseMove (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseOut (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseOver (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseUp (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.paste (?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.paste(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pause (?eventProperties: #IEventProperty list) = Bindings.createEvent.pause(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.play (?eventProperties: #IEventProperty list) = Bindings.createEvent.play(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.playing (?eventProperties: #IEventProperty list) = Bindings.createEvent.playing(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerCancel (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerCancel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerDown (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerEnter (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerLeave (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerMove (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerOut (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerOver (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerUp (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.popState (?eventProperties: #IEventProperty list) = Bindings.createEvent.popState(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))        
        member _.progress (?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.progress(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.rateChange (?eventProperties: #IEventProperty list) = Bindings.createEvent.rateChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.reset (?eventProperties: #IEventProperty list) = Bindings.createEvent.reset(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.scroll (?eventProperties: #IEventProperty list) = Bindings.createEvent.scroll(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.seeked (?eventProperties: #IEventProperty list) = Bindings.createEvent.seeked(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.seeking (?eventProperties: #IEventProperty list) = Bindings.createEvent.seeking(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.select (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.select(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.stalled (?eventProperties: #IEventProperty list) = Bindings.createEvent.stalled(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.submit (?eventProperties: #IEventProperty list) = Bindings.createEvent.submit(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.suspend (?eventProperties: #IEventProperty list) = Bindings.createEvent.suspend(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.timeUpdate (?eventProperties: #IEventProperty list) = Bindings.createEvent.timeUpdate(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.touchCancel (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchCancel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.touchEnd (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.touchMove (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.touchStart (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.transitionEnd (?eventProperties: #ITransitionEventProperty list) = Bindings.createEvent.transitionEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.volumeChange (?eventProperties: #IEventProperty list) = Bindings.createEvent.volumeChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.waiting (?eventProperties: #IEventProperty list) = Bindings.createEvent.waiting(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.wheel (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.wheel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))

    [<NoComparison>]
    [<NoEquality>]
    type HTMLElementFireEvent (element: HTMLElement) =
        member _.abort (?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.abort(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.abort (?eventProperties: IUIEventProperty list) = Bindings.fireEvent.abort(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.animationEnd (?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.animationIteration (?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationIteration(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.animationStart (?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.blur (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.blur(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.canPlay (?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlay(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.canPlayThrough (?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlayThrough(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.change (?eventProperties: #IEventProperty list) = Bindings.fireEvent.change(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.click (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.click(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.compositionEnd (?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.compositionStart (?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.compositionUpdate (?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionUpdate(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.contextMenu (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.contextMenu(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.copy (?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.copy(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.cut (?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.cut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dblClick (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.dblClick(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.doubleClick (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.doubleClick(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.drag (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drag(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragEnd (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragEnter (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragExit (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragExit(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragLeave (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragOver (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.dragStart (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.drop (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drop(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.durationChange (?eventProperties: #IEventProperty list) = Bindings.fireEvent.durationChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.emptied (?eventProperties: #IEventProperty list) = Bindings.fireEvent.emptied(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.encrypted (?eventProperties: #IEventProperty list) = Bindings.fireEvent.encrypted(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.ended (?eventProperties: #IEventProperty list) = Bindings.fireEvent.ended(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.error (?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.error(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.error (?eventProperties: IUIEventProperty list) = Bindings.fireEvent.error(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.focus (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focus(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.focusIn (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusIn(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.focusOut (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.gotPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.gotPointerCapture(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.input (?eventProperties: #IInputEventProperty list) = Bindings.fireEvent.input(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.invalid (?eventProperties: #IEventProperty list) = Bindings.fireEvent.invalid(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.keyDown (?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.keyPress (?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyPress(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.keyUp (?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.load (?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.load(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.load (?eventProperties: IUIEventProperty list) = Bindings.fireEvent.load(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.loadedData (?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedData(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.loadedMetadata (?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedMetadata(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.loadStart (?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.loadStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.lostPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.lostPointerCapture(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseDown (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseEnter (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseLeave (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseMove (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseOut (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseOver (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.mouseUp (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.paste (?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.paste(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pause (?eventProperties: #IEventProperty list) = Bindings.fireEvent.pause(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.play (?eventProperties: #IEventProperty list) = Bindings.fireEvent.play(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.playing (?eventProperties: #IEventProperty list) = Bindings.fireEvent.playing(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerCancel (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerCancel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerDown (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerDown(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerEnter (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerEnter(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerLeave (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerLeave(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerMove (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerOut (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOut(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerOver (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOver(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.pointerUp (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerUp(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.popState (?eventProperties: #IEventProperty list) = Bindings.fireEvent.popState(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))        
        member _.progress (?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.progress(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.rateChange (?eventProperties: #IEventProperty list) = Bindings.fireEvent.rateChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.reset (?eventProperties: #IEventProperty list) = Bindings.fireEvent.reset(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.scroll (?eventProperties: #IEventProperty list) = Bindings.fireEvent.scroll(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.seeked (?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeked(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.seeking (?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeking(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.select (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.select(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.stalled (?eventProperties: #IEventProperty list) = Bindings.fireEvent.stalled(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.submit (?eventProperties: #IEventProperty list) = Bindings.fireEvent.submit(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.suspend (?eventProperties: #IEventProperty list) = Bindings.fireEvent.suspend(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.timeUpdate (?eventProperties: #IEventProperty list) = Bindings.fireEvent.timeUpdate(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.touchCancel (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchCancel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.touchEnd (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.touchMove (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchMove(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.touchStart (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchStart(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.transitionEnd (?eventProperties: #ITransitionEventProperty list) = Bindings.fireEvent.transitionEnd(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.volumeChange (?eventProperties: #IEventProperty list) = Bindings.fireEvent.volumeChange(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.waiting (?eventProperties: #IEventProperty list) = Bindings.fireEvent.waiting(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))
        member _.wheel (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.wheel(element, (eventProperties |> Option.map (fun props -> createObj !!props) |> Option.defaultValue (obj())))

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
