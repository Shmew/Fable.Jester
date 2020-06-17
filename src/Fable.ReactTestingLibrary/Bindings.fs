namespace Fable.ReactTestingLibrary

open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open System.ComponentModel
open System.Text.RegularExpressions

[<RequireQualifiedAccess>]
module Bindings =
    type Matcher =
        U3<string, Regex, string * HTMLElement -> bool>

    type MatcherOptions =
        abstract exact: bool option with get, set
        abstract normalizer: (string -> string) option with get, set

    [<RequireQualifiedAccess>]
    module MatcherOptions =
        let create exact normalizer =
            jsOptions<MatcherOptions> <| fun o ->
                o.exact <- exact
                o.normalizer <- normalizer

    type LabelTextMatcher =
        inherit MatcherOptions
        abstract selector: string option with get, set

    [<RequireQualifiedAccess>]
    module LabelTextMatcher =
        let create selector exact normalizer =
            jsOptions<LabelTextMatcher> <| fun o ->
                o.selector <- selector
                o.exact <- exact
                o.normalizer <- normalizer

    type TextMatcher =
        inherit MatcherOptions
        abstract selector: string option with get, set
        abstract ignore: U2<string, bool> option with get, set

    [<RequireQualifiedAccess>]
    module TextMatcher =
        let create selector ignore exact normalizer =
            jsOptions<TextMatcher> <| fun o ->
                o.selector <- selector
                o.ignore <- ignore
                o.exact <- exact
                o.normalizer <- normalizer

    type RoleMatcher =
        inherit MatcherOptions
        abstract hidden: bool option with get, set
        abstract name: Matcher option with get, set

    [<RequireQualifiedAccess>]
    module RoleMatcher =
        let create hidden name exact normalizer =
            jsOptions<RoleMatcher> <| fun o ->
                o.hidden <- hidden
                o.name <- name
                o.exact <- exact
                o.normalizer <- normalizer
    
    let act : (unit -> unit) -> unit  = import "act" "@testing-library/react"

    let configure : IConfigureOptions -> unit = import "configure" "@testing-library/react"

    let cleanup : unit -> unit = import "cleanup" "@testing-library/react"

    type CreateEvent =
        abstract abort: node: #HTMLElement * ?eventProperties:obj -> ProgressEvent
        abstract animationEnd: node: #HTMLElement * ?eventProperties:obj -> UIEvent
        abstract animationIteration: node: #HTMLElement * ?eventProperties:obj -> AnimationEvent
        abstract animationStart: node: #HTMLElement * ?eventProperties:obj -> AnimationEvent
        abstract blur: node: #HTMLElement * ?eventProperties:obj -> AnimationEvent
        abstract canPlay: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract canPlayThrough: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract change: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract click: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract compositionEnd: node: #HTMLElement * ?eventProperties:obj -> CompositionEvent
        abstract compositionStart: node: #HTMLElement * ?eventProperties:obj -> CompositionEvent
        abstract compositionUpdate: node: #HTMLElement * ?eventProperties:obj -> CompositionEvent
        abstract contextMenu: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract copy: node: #HTMLElement * ?eventProperties:obj -> ClipboardEvent
        abstract cut: node: #HTMLElement * ?eventProperties:obj -> ClipboardEvent
        abstract dblClick: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract doubleClick: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract drag: node: #HTMLElement * ?eventProperties:obj -> DragEvent
        abstract dragEnd: node: #HTMLElement * ?eventProperties:obj -> DragEvent
        abstract dragEnter: node: #HTMLElement * ?eventProperties:obj -> DragEvent
        abstract dragExit: node: #HTMLElement * ?eventProperties:obj -> DragEvent
        abstract dragLeave: node: #HTMLElement * ?eventProperties:obj -> DragEvent
        abstract dragOver: node: #HTMLElement * ?eventProperties:obj -> DragEvent
        abstract dragStart: node: #HTMLElement * ?eventProperties:obj -> DragEvent
        abstract drop: node: #HTMLElement * ?eventProperties:obj -> DragEvent
        abstract durationChange: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract emptied: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract encrypted: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract ended: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract error: node: #HTMLElement * ?eventProperties:obj -> U2<ProgressEvent, UIEvent>
        abstract focus: node: #HTMLElement * ?eventProperties:obj -> FocusEvent
        abstract focusIn: node: #HTMLElement * ?eventProperties:obj -> FocusEvent
        abstract focusOut: node: #HTMLElement * ?eventProperties:obj -> FocusEvent
        abstract gotPointerCapture: node: #HTMLElement * ?eventProperties:obj -> PointerEvent
        abstract input: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract invalid: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract keyDown: node: #HTMLElement * ?eventProperties:obj -> KeyboardEvent
        abstract keyPress: node: #HTMLElement * ?eventProperties:obj -> KeyboardEvent
        abstract keyUp: node: #HTMLElement * ?eventProperties:obj -> KeyboardEvent
        abstract load: node: #HTMLElement * ?eventProperties:obj -> U2<ProgressEvent,UIEvent>
        abstract loadedData: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract loadedMetadata: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract loadStart: node: #HTMLElement * ?eventProperties:obj -> ProgressEvent
        abstract lostPointerCapture: node: #HTMLElement * ?eventProperties:obj -> PointerEvent
        abstract mouseDown: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract mouseEnter: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract mouseLeave: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract mouseMove: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract mouseOut: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract mouseOver: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract mouseUp: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract paste: node: #HTMLElement * ?eventProperties:obj -> ClipboardEvent
        abstract pause: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract play: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract playing: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract pointerCancel: node: #HTMLElement * ?eventProperties:obj -> PointerEvent
        abstract pointerDown: node: #HTMLElement * ?eventProperties:obj -> PointerEvent
        abstract pointerEnter: node: #HTMLElement * ?eventProperties:obj -> PointerEvent
        abstract pointerLeave: node: #HTMLElement * ?eventProperties:obj -> PointerEvent
        abstract pointerMove: node: #HTMLElement * ?eventProperties:obj -> PointerEvent
        abstract pointerOut: node: #HTMLElement * ?eventProperties:obj -> PointerEvent
        abstract pointerOver: node: #HTMLElement * ?eventProperties:obj -> PointerEvent
        abstract pointerUp: node: #HTMLElement * ?eventProperties:obj -> PointerEvent
        abstract popState: node: #HTMLElement * ?eventProperties:obj -> Event        
        abstract progress: node: #HTMLElement * ?eventProperties:obj -> ProgressEvent
        abstract rateChange: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract reset: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract scroll: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract seeked: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract seeking: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract select: node: #HTMLElement * ?eventProperties:obj -> MouseEvent
        abstract stalled: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract submit: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract suspend: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract timeUpdate: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract touchCancel: node: #HTMLElement * ?eventProperties:obj -> Touch
        abstract touchEnd: node: #HTMLElement * ?eventProperties:obj -> Touch
        abstract touchMove: node: #HTMLElement * ?eventProperties:obj -> Touch
        abstract touchStart: node: #HTMLElement * ?eventProperties:obj -> Touch
        abstract transitionEnd: node: #HTMLElement * ?eventProperties:obj -> TransitionEvent
        abstract volumeChange: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract waiting: node: #HTMLElement * ?eventProperties:obj -> Event
        abstract wheel: node: #HTMLElement * ?eventProperties:obj -> MouseEvent

    let createEvent: CreateEvent = import "createEvent" "@testing-library/react"

    type FireEvent =
        [<Emit("$0($1,$2)")>]
        abstract custom: node:HTMLElement * event:#Browser.Types.Event -> unit

        abstract abort: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract animationEnd: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract animationIteration: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract animationStart: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract blur: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract canPlay: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract canPlayThrough: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract change: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract click: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract compositionEnd: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract compositionStart: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract compositionUpdate: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract contextMenu: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract copy: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract cut: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract dblClick: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract doubleClick: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract drag: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract dragEnd: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract dragEnter: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract dragExit: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract dragLeave: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract dragOver: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract dragStart: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract drop: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract durationChange: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract emptied: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract encrypted: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract ended: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract error: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract focus: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract focusIn: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract focusOut: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract gotPointerCapture: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract input: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract invalid: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract keyDown: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract keyPress: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract keyUp: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract load: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract loadedData: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract loadedMetadata: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract loadStart: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract lostPointerCapture: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract mouseDown: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract mouseEnter: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract mouseLeave: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract mouseMove: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract mouseOut: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract mouseOver: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract mouseUp: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract paste: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract pause: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract play: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract playing: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract pointerCancel: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract pointerDown: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract pointerEnter: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract pointerLeave: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract pointerMove: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract pointerOut: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract pointerOver: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract pointerUp: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract popState: node: #HTMLElement * ?eventProperties:obj -> unit        
        abstract progress: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract rateChange: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract reset: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract scroll: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract seeked: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract seeking: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract select: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract stalled: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract submit: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract suspend: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract timeUpdate: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract touchCancel: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract touchEnd: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract touchMove: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract touchStart: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract transitionEnd: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract volumeChange: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract waiting: node: #HTMLElement * ?eventProperties:obj -> unit
        abstract wheel: node: #HTMLElement * ?eventProperties:obj -> unit
        
    let fireEvent : FireEvent = import "fireEvent" "@testing-library/react"

    let getNodeText<'Element when 'Element :> HTMLElement> : 'Element -> string = import "getNodeText" "@testing-library/react"

    let getRoles<'Element when 'Element :> HTMLElement> : 'Element -> obj = import "getRoles" "@testing-library/react"

    let isInaccessible<'Element when 'Element :> HTMLElement> : 'Element -> bool = import "isInaccessible" "@testing-library/react"

    let logRoles<'Element when 'Element :> HTMLElement> : 'Element -> unit = import "logRoles" "@testing-library/react"

    type PrettyDOM =
        [<Emit("$0($1)")>]
        abstract invoke<'Element when 'Element :> HTMLElement> : node:'Element * ?maxLength: int * ?options:IPrettyDOMOptions -> string

    let prettyDOMImport : PrettyDOM = import "prettyDOM" "@testing-library/react"

    type QueriesForElement =
        abstract getByLabelText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: LabelTextMatcher -> 'Element
        abstract getAllByLabelText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: LabelTextMatcher -> ResizeArray<'Element>
        abstract queryByLabelText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: LabelTextMatcher -> 'Element option
        abstract queryAllByLabelText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: LabelTextMatcher -> ResizeArray<'Element>
        abstract findByLabelText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: LabelTextMatcher -> JS.Promise<'Element>
        abstract findAllByLabelText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: LabelTextMatcher -> JS.Promise<ResizeArray<'Element>>
    
        abstract getByPlaceholderText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> 'Element
        abstract getAllByPlaceholderText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> ResizeArray<'Element>
        abstract queryByPlaceholderText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> 'Element option
        abstract queryAllByPlaceholderText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> ResizeArray<'Element>
        abstract findByPlaceholderText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> JS.Promise<'Element>
        abstract findAllByPlaceholderText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> JS.Promise<ResizeArray<'Element>>
    
        abstract getByText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> 'Element
        abstract getAllByText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> ResizeArray<'Element>
        abstract queryByText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> 'Element option
        abstract queryAllByText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> ResizeArray<'Element>
        abstract findByText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> JS.Promise<'Element>
        abstract findAllByText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> JS.Promise<ResizeArray<'Element>>
    
        abstract getByAltText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> 'Element
        abstract getAllByAltText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> ResizeArray<'Element>
        abstract queryByAltText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> 'Element option
        abstract queryAllByAltText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> ResizeArray<'Element>
        abstract findByAltText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> JS.Promise<'Element>
        abstract findAllByAltText<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: TextMatcher -> JS.Promise<ResizeArray<'Element>>

        abstract getByTitle<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> 'Element
        abstract getAllByTitle<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> ResizeArray<'Element>
        abstract queryByTitle<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> 'Element option
        abstract queryAllByTitle<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> ResizeArray<'Element>
        abstract findByTitle<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> JS.Promise<'Element>
        abstract findAllByTitle<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> JS.Promise<ResizeArray<'Element>>

        abstract getByDisplayValue<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> 'Element
        abstract getAllByDisplayValue<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> ResizeArray<'Element>
        abstract queryByDisplayValue<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> 'Element option
        abstract queryAllByDisplayValue<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> ResizeArray<'Element>
        abstract findByDisplayValue<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> JS.Promise<'Element>
        abstract findAllByDisplayValue<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> JS.Promise<ResizeArray<'Element>>

        abstract getByRole<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> 'Element
        abstract getAllByRole<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> ResizeArray<'Element>
        abstract queryByRole<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> 'Element option
        abstract queryAllByRole<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> ResizeArray<'Element>
        abstract findByRole<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> JS.Promise<'Element>
        abstract findAllByRole<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> JS.Promise<ResizeArray<'Element>>

        abstract getByTestId<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> 'Element
        abstract getAllByTestId<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> ResizeArray<'Element>
        abstract queryByTestId<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> 'Element option
        abstract queryAllByTestId<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> ResizeArray<'Element>
        abstract findByTestId<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> JS.Promise<'Element>
        abstract findAllByTestId<'Element when 'Element :> HTMLElement> : matcher:Matcher * ?options: MatcherOptions -> JS.Promise<ResizeArray<'Element>>

    let createRenderOptions (baseElement: #HTMLElement option) (container: #HTMLElement option) (hydrate: bool option) (wrapper: ReactElement option) =
        [ if baseElement.IsSome then "baseElement" ==> baseElement.Value
          if container.IsSome then "container" ==> container.Value
          if hydrate.IsSome then "hydrate" ==> hydrate.Value
          if wrapper.IsSome then "wrapper" ==> wrapper.Value ]
        |> fun res -> createObj !!res

    type Render<'BaseElement, 'Container when 'BaseElement :> HTMLElement and 'Container :> HTMLElement> =
        inherit QueriesForElement
        abstract baseElement: 'BaseElement with get
        abstract container: 'Container with get

        abstract act: unit -> unit
        abstract asFragment: unit -> DocumentFragment
        abstract debug: unit -> unit
        abstract rerender: ReactElement -> unit
        abstract unmount: unit -> unit

    type queriesForElement (queryApi: QueriesForElement) =
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByLabelTextAs")>]
        member _.getByLabelText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getByLabelText<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByLabelTextAs")>]
        member _.getByLabelText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getByLabelText<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByLabelTextAs")>]
        member _.getByLabelText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getByLabelText<'Element>(!^matcher, options)
        
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByLabelTextAs")>]
        member _.getAllByLabelText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getAllByLabelText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByLabelTextAs")>]
        member _.getAllByLabelText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getAllByLabelText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByLabelTextAs")>]
        member _.getAllByLabelText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getAllByLabelText<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByLabelTextAs")>]
        member _.queryByLabelText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryByLabelText<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByLabelTextAs")>]
        member _.queryByLabelText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryByLabelText<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByLabelTextAs")>]
        member _.queryByLabelText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryByLabelText<'Element>(!^matcher, options)
        
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByLabelTextAs")>]
        member _.queryAllByLabelText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryAllByLabelText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByLabelTextAs")>]
        member _.queryAllByLabelText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryAllByLabelText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByLabelTextAs")>]
        member _.queryAllByLabelText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryAllByLabelText<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByLabelTextAs")>]
        member _.findByLabelText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findByLabelText<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByLabelTextAs")>]
        member _.findByLabelText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findByLabelText<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByLabelTextAs")>]
        member _.findByLabelText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findByLabelText<'Element>(!^matcher, options)
        
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByLabelTextAs")>]
        member _.findAllByLabelText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findAllByLabelText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByLabelTextAs")>]
        member _.findAllByLabelText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findAllByLabelText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByLabelTextAs")>]
        member _.findAllByLabelText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findAllByLabelText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
            
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByPlaceholderTextAs")>]
        member _.getByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByPlaceholderText<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByPlaceholderTextAs")>]
        member _.getByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByPlaceholderText<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByPlaceholderTextAs")>]
        member _.getByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByPlaceholderText<'Element>(!^matcher, options)
            
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByPlaceholderTextAs")>]
        member _.getAllByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByPlaceholderText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByPlaceholderTextAs")>]
        member _.getAllByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByPlaceholderText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByPlaceholderTextAs")>]
        member _.getAllByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByPlaceholderText<'Element>(!^matcher, options)
            |> List.ofSeq
            
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByPlaceholderTextAs")>]
        member _.queryByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByPlaceholderText<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByPlaceholderTextAs")>]
        member _.queryByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByPlaceholderText<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByPlaceholderTextAs")>]
        member _.queryByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByPlaceholderText<'Element>(!^matcher, options)
            
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByPlaceholderTextAs")>]
        member _.queryAllByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByPlaceholderText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByPlaceholderTextAs")>]
        member _.queryAllByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByPlaceholderText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByPlaceholderTextAs")>]
        member _.queryAllByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByPlaceholderText<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByPlaceholderTextAs")>]
        member _.findByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByPlaceholderText<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByPlaceholderTextAs")>]
        member _.findByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByPlaceholderText<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByPlaceholderTextAs")>]
        member _.findByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByPlaceholderText<'Element>(!^matcher, options)
        
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByPlaceholderTextAs")>]
        member _.findAllByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByPlaceholderText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByPlaceholderTextAs")>]
        member _.findAllByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByPlaceholderText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByPlaceholderTextAs")>]
        member _.findAllByPlaceholderText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByPlaceholderText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
            
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByAltTextAs")>]
        member _.getByAltText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByAltText<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByAltTextAs")>]
        member _.getByAltText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByAltText<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByAltTextAs")>]
        member _.getByAltText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByAltText<'Element>(!^matcher, options)
        
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByAltTextAs")>]
        member _.getAllByAltText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByAltText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByAltTextAs")>]
        member _.getAllByAltText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByAltText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByAltTextAs")>]
        member _.getAllByAltText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByAltText<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByAltTextAs")>]
        member _.queryByAltText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByAltText<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByAltTextAs")>]
        member _.queryByAltText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByAltText<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByAltTextAs")>]
        member _.queryByAltText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByAltText<'Element>(!^matcher, options)
        
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByAltTextAs")>]
        member _.queryAllByAltText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByAltText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByAltTextAs")>]
        member _.queryAllByAltText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByAltText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByAltTextAs")>]
        member _.queryAllByAltText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByAltText<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByAltTextAs")>]
        member _.findByAltText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByAltText<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByAltTextAs")>]
        member _.findByAltText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByAltText<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByAltTextAs")>]
        member _.findByAltText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByAltText<'Element>(!^matcher, options)
        
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByAltTextAs")>]
        member _.findAllByAltText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByAltText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByAltTextAs")>]
        member _.findAllByAltText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByAltText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByAltTextAs")>]
        member _.findAllByAltText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByAltText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq

        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByTextAs")>]
        member _.getByText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByText<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByTextAs")>]
        member _.getByText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByText<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByTextAs")>]
        member _.getByText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByText<'Element>(!^matcher, options)
        
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByTextAs")>]
        member _.getAllByText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByTextAs")>]
        member _.getAllByText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByTextAs")>]
        member _.getAllByText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByText<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByTextAs")>]
        member _.queryByText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByText<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByTextAs")>]
        member _.queryByText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByText<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByTextAs")>]
        member _.queryByText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByText<'Element>(!^matcher, options)
        
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByTextAs")>]
        member _.queryAllByText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByTextAs")>]
        member _.queryAllByText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByText<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByTextAs")>]
        member _.queryAllByText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByText<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByTextAs")>]
        member _.findByText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByText<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByTextAs")>]
        member _.findByText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByText<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByTextAs")>]
        member _.findByText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByText<'Element>(!^matcher, options)
        
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByTextAs")>]
        member _.findAllByText<'Element when 'Element :> HTMLElement> (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByTextAs")>]
        member _.findAllByText<'Element when 'Element :> HTMLElement> (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByTextAs")>]
        member _.findAllByText<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByText<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
            
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByTitleAs")>]
        member _.getByTitle<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTitle<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByTitleAs")>]
        member _.getByTitle<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTitle<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByTitleAs")>]
        member _.getByTitle<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTitle<'Element>(!^matcher, options)
        
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByTitleAs")>]
        member _.getAllByTitle<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTitle<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByTitleAs")>]
        member _.getAllByTitle<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTitle<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByTitleAs")>]
        member _.getAllByTitle<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTitle<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByTitleAs")>]
        member _.queryByTitle<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTitle<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByTitleAs")>]
        member _.queryByTitle<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTitle<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByTitleAs")>]
        member _.queryByTitle<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTitle<'Element>(!^matcher, options)
        
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByTitleAs")>]
        member _.queryAllByTitle<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTitle<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByTitleAs")>]
        member _.queryAllByTitle<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTitle<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByTitleAs")>]
        member _.queryAllByTitle<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTitle<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByTitleAs")>]
        member _.findByTitle<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTitle<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByTitleAs")>]
        member _.findByTitle<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTitle<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByTitleAs")>]
        member _.findByTitle<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTitle<'Element>(!^matcher, options)
        
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByTitleAs")>]
        member _.findAllByTitle<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTitle<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByTitleAs")>]
        member _.findAllByTitle<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTitle<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByTitleAs")>]
        member _.findAllByTitle<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTitle<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByDisplayValueAs")>]
        member _.getByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByDisplayValue<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByDisplayValueAs")>]
        member _.getByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByDisplayValue<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByDisplayValueAs")>]
        member _.getByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByDisplayValue<'Element>(!^matcher, options)
        
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByDisplayValueAs")>]
        member _.getAllByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByDisplayValue<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByDisplayValueAs")>]
        member _.getAllByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByDisplayValue<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByDisplayValueAs")>]
        member _.getAllByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByDisplayValue<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByDisplayValueAs")>]
        member _.queryByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByDisplayValue<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByDisplayValueAs")>]
        member _.queryByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByDisplayValue<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByDisplayValueAs")>]
        member _.queryByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByDisplayValue<'Element>(!^matcher, options)
        
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByDisplayValueAs")>]
        member _.queryAllByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByDisplayValue<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByDisplayValueAs")>]
        member _.queryAllByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByDisplayValue<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByDisplayValueAs")>]
        member _.queryAllByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByDisplayValue<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByDisplayValueAs")>]
        member _.findByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByDisplayValue<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByDisplayValueAs")>]
        member _.findByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByDisplayValue<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByDisplayValueAs")>]
        member _.findByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByDisplayValue<'Element>(!^matcher, options)
        
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByDisplayValueAs")>]
        member _.findAllByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByDisplayValue<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByDisplayValueAs")>]
        member _.findAllByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByDisplayValue<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByDisplayValueAs")>]
        member _.findAllByDisplayValue<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByDisplayValue<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
            
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByRoleAs")>]
        member _.getByRole<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByRole<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByRoleAs")>]
        member _.getByRole<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByRole<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByRoleAs")>]
        member _.getByRole<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByRole<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByRoleAs")>]
        member _.getByRole<'Element when 'Element :> HTMLElement> (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.getByRole<'Element>(!^role, options)
        
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByRoleAs")>]
        member _.getAllByRole<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByRole<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByRoleAs")>]
        member _.getAllByRole<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByRole<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByRoleAs")>]
        member _.getAllByRole<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByRole<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByRoleAs")>]
        member _.getAllByRole<'Element when 'Element :> HTMLElement> (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.getAllByRole<'Element>(!^role, options)
        
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByRoleAs")>]
        member _.queryByRole<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByRole<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByRoleAs")>]
        member _.queryByRole<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByRole<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByRoleAs")>]
        member _.queryByRole<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByRole<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByRoleAs")>]
        member _.queryByRole<'Element when 'Element :> HTMLElement> (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.queryByRole<'Element>(!^role, options)
        
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByRoleAs")>]
        member _.queryAllByRole<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByRole<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByRoleAs")>]
        member _.queryAllByRole<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByRole<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByRoleAs")>]
        member _.queryAllByRole<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByRole<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByRoleAs")>]
        member _.queryAllByRole<'Element when 'Element :> HTMLElement> (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.queryAllByRole<'Element>(!^role, options)
        
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByRoleAs")>]
        member _.findByRole<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByRole<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByRoleAs")>]
        member _.findByRole<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByRole<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByRoleAs")>]
        member _.findByRole<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByRole<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByRoleAs")>]
        member _.findByRole<'Element when 'Element :> HTMLElement> (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.findByRole<'Element>(!^role, options)
        
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByRoleAs")>]
        member _.findAllByRole<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByRole<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByRoleAs")>]
        member _.findAllByRole<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByRole<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByRoleAs")>]
        member _.findAllByRole<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByRole<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByRoleAs")>]
        member _.findAllByRole<'Element when 'Element :> HTMLElement> (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.findAllByRole<'Element>(!^role, options)
            
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByTestIdAs")>]
        member _.getByTestId<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTestId<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByTestIdAs")>]
        member _.getByTestId<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTestId<'Element>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<CompiledName("getByTestIdAs")>]
        member _.getByTestId<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTestId<'Element>(!^matcher, options)
        
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByTestIdAs")>]
        member _.getAllByTestId<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTestId<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByTestIdAs")>]
        member _.getAllByTestId<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTestId<'Element>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<CompiledName("getAllByTestIdAs")>]
        member _.getAllByTestId<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTestId<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByTestIdAs")>]
        member _.queryByTestId<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTestId<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByTestIdAs")>]
        member _.queryByTestId<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTestId<'Element>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<CompiledName("queryByTestIdAs")>]
        member _.queryByTestId<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTestId<'Element>(!^matcher, options)
        
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByTestIdAs")>]
        member _.queryAllByTestId<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTestId<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByTestIdAs")>]
        member _.queryAllByTestId<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTestId<'Element>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<CompiledName("queryAllByTestIdAs")>]
        member _.queryAllByTestId<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTestId<'Element>(!^matcher, options)
            |> List.ofSeq
        
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByTestIdAs")>]
        member _.findByTestId<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTestId<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByTestIdAs")>]
        member _.findByTestId<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTestId<'Element>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<CompiledName("findByTestIdAs")>]
        member _.findByTestId<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTestId<'Element>(!^matcher, options)
        
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByTestIdAs")>]
        member _.findAllByTestId<'Element when 'Element :> HTMLElement> (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTestId<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByTestIdAs")>]
        member _.findAllByTestId<'Element when 'Element :> HTMLElement> (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTestId<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<CompiledName("findAllByTestIdAs")>]
        member _.findAllByTestId<'Element when 'Element :> HTMLElement> (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTestId<'Element>(!^matcher, options)
            |> Promise.map List.ofSeq

        // Generics
        // _____________________________________

        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByLabelText (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getByLabelText<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByLabelText (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getByLabelText<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByLabelText (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getByLabelText<HTMLElement>(!^matcher, options)

        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByLabelText (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getAllByLabelText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByLabelText (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getAllByLabelText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByLabelText (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.getAllByLabelText<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByLabelText (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryByLabelText<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByLabelText (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryByLabelText<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByLabelText (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryByLabelText<HTMLElement>(!^matcher, options)

        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByLabelText (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryAllByLabelText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByLabelText (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryAllByLabelText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByLabelText (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.queryAllByLabelText<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByLabelText (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findByLabelText<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByLabelText (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findByLabelText<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByLabelText (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findByLabelText<HTMLElement>(!^matcher, options)

        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByLabelText (matcher: string, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findAllByLabelText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByLabelText (matcher: Regex, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findAllByLabelText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByLabelText (matcher: string * HTMLElement -> bool, ?selector : string, ?exact: bool, ?normalizer: string -> string) = 
            LabelTextMatcher.create selector exact normalizer
            |> fun options -> queryApi.findAllByLabelText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
    
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByPlaceholderText (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByPlaceholderText<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByPlaceholderText (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByPlaceholderText<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByPlaceholderText (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByPlaceholderText<HTMLElement>(!^matcher, options)
    
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByPlaceholderText (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByPlaceholderText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByPlaceholderText (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByPlaceholderText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByPlaceholderText (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByPlaceholderText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
    
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByPlaceholderText (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByPlaceholderText<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByPlaceholderText (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByPlaceholderText<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByPlaceholderText (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByPlaceholderText<HTMLElement>(!^matcher, options)
    
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByPlaceholderText (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByPlaceholderText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByPlaceholderText (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByPlaceholderText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByPlaceholderText (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByPlaceholderText<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByPlaceholderText (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByPlaceholderText<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByPlaceholderText (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByPlaceholderText<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByPlaceholderText (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByPlaceholderText<HTMLElement>(!^matcher, options)

        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByPlaceholderText (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByPlaceholderText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByPlaceholderText (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByPlaceholderText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByPlaceholderText (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByPlaceholderText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
    
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByAltText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByAltText<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByAltText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByAltText<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByAltText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByAltText<HTMLElement>(!^matcher, options)

        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByAltText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByAltText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByAltText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByAltText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByAltText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByAltText<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByAltText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByAltText<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByAltText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByAltText<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByAltText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByAltText<HTMLElement>(!^matcher, options)

        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByAltText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByAltText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByAltText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByAltText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByAltText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByAltText<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByAltText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByAltText<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByAltText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByAltText<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByAltText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByAltText<HTMLElement>(!^matcher, options)

        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByAltText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByAltText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByAltText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByAltText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByAltText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByAltText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq

        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByText<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByText<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getByText<HTMLElement>(!^matcher, options)

        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.getAllByText<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByText<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByText<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryByText<HTMLElement>(!^matcher, options)

        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByText<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.queryAllByText<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByText<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByText<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findByText<HTMLElement>(!^matcher, options)

        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByText (matcher: string, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByText (matcher: Regex, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByText (matcher: string * HTMLElement -> bool, ?selector : string, ?ignore: string, ?exact: bool, ?normalizer: string -> string) = 
            TextMatcher.create selector (ignore |> Option.map (!^)) exact normalizer
            |> fun options -> queryApi.findAllByText<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
    
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByTitle (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTitle<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByTitle (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTitle<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByTitle (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTitle<HTMLElement>(!^matcher, options)

        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByTitle (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTitle<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByTitle (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTitle<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByTitle (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTitle<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByTitle (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTitle<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByTitle (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTitle<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByTitle (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTitle<HTMLElement>(!^matcher, options)

        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByTitle (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTitle<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByTitle (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTitle<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByTitle (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTitle<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByTitle (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTitle<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByTitle (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTitle<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByTitle (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTitle<HTMLElement>(!^matcher, options)

        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByTitle (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTitle<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByTitle (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTitle<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByTitle (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTitle<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq

        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByDisplayValue (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByDisplayValue<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByDisplayValue (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByDisplayValue<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByDisplayValue (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByDisplayValue<HTMLElement>(!^matcher, options)

        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByDisplayValue (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByDisplayValue<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByDisplayValue (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByDisplayValue<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByDisplayValue (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByDisplayValue<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByDisplayValue (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByDisplayValue<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByDisplayValue (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByDisplayValue<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByDisplayValue (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByDisplayValue<HTMLElement>(!^matcher, options)

        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByDisplayValue (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByDisplayValue<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByDisplayValue (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByDisplayValue<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByDisplayValue (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByDisplayValue<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByDisplayValue (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByDisplayValue<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByDisplayValue (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByDisplayValue<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByDisplayValue (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByDisplayValue<HTMLElement>(!^matcher, options)

        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByDisplayValue (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByDisplayValue<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByDisplayValue (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByDisplayValue<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByDisplayValue (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByDisplayValue<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
    
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByRole (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByRole<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByRole (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByRole<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByRole (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByRole<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByRole (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.getByRole<HTMLElement>(!^role, options)

        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByRole (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByRole<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByRole (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByRole<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByRole (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByRole<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByRole (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.getAllByRole<HTMLElement>(!^role, options)

        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByRole (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByRole<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByRole (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByRole<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByRole (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByRole<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByRole (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.queryByRole<HTMLElement>(!^role, options)

        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByRole (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByRole<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByRole (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByRole<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByRole (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByRole<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByRole (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.queryAllByRole<HTMLElement>(!^role, options)

        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByRole (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByRole<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByRole (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByRole<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByRole (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByRole<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByRole (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.findByRole<HTMLElement>(!^role, options)

        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByRole (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByRole<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByRole (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByRole<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByRole (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByRole<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByRole (property: IReactProperty) =
            let _,role = unbox<string * string> property
            MatcherOptions.create None None
            |> fun options -> queryApi.findAllByRole<HTMLElement>(!^role, options)
    
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByTestId (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTestId<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByTestId (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTestId<HTMLElement>(!^matcher, options)
        /// getBy* queries return the first matching node for a query, and throw an error if no elements match or if more than 
        /// one match is found (use getAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getByTestId (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getByTestId<HTMLElement>(!^matcher, options)

        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByTestId (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTestId<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByTestId (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTestId<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// getAllBy* queries return a list of all matching nodes for a query, and throw an error if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.getAllByTestId (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.getAllByTestId<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByTestId (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTestId<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByTestId (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTestId<HTMLElement>(!^matcher, options)
        /// queryBy* queries return the first matching node for a query, and return null if no elements match. This is useful for asserting an element that is not present. 
        ///
        /// This throws if more than one match is found (use queryAllBy instead).
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryByTestId (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryByTestId<HTMLElement>(!^matcher, options)

        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByTestId (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTestId<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByTestId (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTestId<HTMLElement>(!^matcher, options)
            |> List.ofSeq
        /// queryAllBy* queries return a list of all matching nodes for a query, and return an empty list if no elements match.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.queryAllByTestId (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.queryAllByTestId<HTMLElement>(!^matcher, options)
            |> List.ofSeq

        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByTestId (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTestId<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByTestId (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTestId<HTMLElement>(!^matcher, options)
        /// findBy* queries return a promise which resolves when an element is found which matches the given query. 
        ///
        /// The promise is rejected if no element is found or if more than one element is found after a default timeout of 4500ms. 
        ///
        /// If you need to find more than one element, then use findAllBy.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findByTestId (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findByTestId<HTMLElement>(!^matcher, options)

        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByTestId (matcher: string, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTestId<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByTestId (matcher: Regex, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTestId<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq
        /// findAllBy* queries return a promise which resolves to an array of elements when any elements are found which match the given query.
        ///
        /// The promise is rejected if no elements are found after a default timeout of 4500ms.
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        member _.findAllByTestId (matcher: string * HTMLElement -> bool, ?exact: bool, ?normalizer: string -> string) = 
            MatcherOptions.create exact normalizer
            |> fun options -> queryApi.findAllByTestId<HTMLElement>(!^matcher, options)
            |> Promise.map List.ofSeq

    type RenderImport =
        [<Emit("$0($1)")>]
        abstract invoke<'BaseElement, 'Container when 'BaseElement :> HTMLElement and 'Container :> HTMLElement> : reactElement:ReactElement * ?options:obj -> Render<'BaseElement,'Container>

    let renderImport : RenderImport = import "render" "@testing-library/react"

    type render<'BaseElement, 'Container when 'BaseElement :> HTMLElement and 'Container :> HTMLElement> (render: Render<'BaseElement,'Container>) =
        inherit queriesForElement(render)

        /// The containing DOM node where your React Element is rendered in the container. 
        /// If you don't specify the baseElement in the options of render, it will default to document.body.
        ///
        /// This is useful when the component you want to test renders something outside the container div, e.g. 
        /// when you want to snapshot test your portal component which renders its HTML directly in the body.
        member _.baseElement = render.baseElement

        /// The containing DOM node where your React Element is rendered in the container. 
        /// If you don't specify the baseElement in the options of render, it will default to document.body.
        ///
        /// This is useful when the component you want to test renders something outside the container div, e.g. 
        /// when you want to snapshot test your portal component which renders its HTML directly in the body.
        member _.baseElementAs<'Element when 'Element :> HTMLElement> () = unbox<'Element> render.baseElement

        /// The containing DOM node of your rendered React Element (rendered using ReactDOM.render). 
        /// It's a div. This is a regular DOM node, so you can call container.querySelector etc. to inspect the children.
        member _.container = render.container

        /// The containing DOM node of your rendered React Element (rendered using ReactDOM.render). 
        /// It's a div. This is a regular DOM node, so you can call container.querySelector etc. to inspect the children.
        member _.containerAs<'Element when 'Element :> HTMLElement> () = unbox<'Element> render.container

        /// Returns a DocumentFragment of your rendered component. This can be useful if you need to avoid live bindings 
        /// and see how your component reacts to events.
        member _.asFragment () = render.asFragment()

        /// This method is a shortcut for console.log(prettyDOM(baseElement))
        member _.debug () = render.debug()

        /// It'd probably be better if you test the component that's doing the prop updating to ensure that the props are being 
        /// updated correctly (see the Guiding Principles section). That said, if you'd prefer to update the props of a rendered 
        /// component in your test, this function can be used to update props of the rendered component.
        member _.rerender (reactElement: ReactElement) = render.rerender reactElement

        /// This will cause the rendered component to be unmounted. This is useful for testing what happens when your component 
        /// is removed from the page (like testing that you don't leave event handlers hanging around causing memory leaks).
        member _.unmount () = render.unmount()
        
    let createClickOptions (cc: int option) (sh: bool option) =
        match cc, sh with
        | Some cc, Some sh -> {| clickCount = cc; skipHover = sh |} |> toPlainJsObj |> Some
        | Some cc, None -> {| clickCount = cc |} |> toPlainJsObj |> Some
        | None, Some sh -> {| skipHover = sh |} |> toPlainJsObj |> Some
        | None, None -> None

    let createTabOptions (shift: bool option) (focusTrap: #HTMLElement option) =
        match shift, focusTrap with
        | Some s, Some ft -> {| shift = s; focusTrap = ft |} |> toPlainJsObj |> Some
        | Some s, None -> {| shift = s |} |> toPlainJsObj |> Some
        | None, Some ft -> {| focusTrap = ft |} |> toPlainJsObj |> Some
        | None, None -> None

    let createTypeOptions (sc: bool option) (sac: bool option) (delay: int option) (iss: int option) (ise: int option) =
        [ if sc.IsSome then "skipClick" ==> sc.Value
          if sac.IsSome then "skipAutoClose" ==> sac.Value
          if delay.IsSome then "delay" ==> delay.Value
          if iss.IsSome then "initialSelectionStart" ==> iss.Value
          if ise.IsSome then "initialSelectionEnd" ==> ise.Value ]
        |> fun res -> createObj !!res

    let createUploadEventInit (clickEventProps: #IMouseEventProperty list option) (changeEventProps: #IEventProperty list option) =
        match clickEventProps, changeEventProps with
        | Some clickProps, Some changeProps -> {| clickInit = createObj !!clickProps; changeInit = createObj !!changeProps |} |> toPlainJsObj |> Some
        | Some clickProps, None -> {| clickInit = createObj !!clickProps |} |> toPlainJsObj |> Some
        | None, Some changeProps -> {| changeInit = createObj !!changeProps |} |> toPlainJsObj |> Some
        | None, None -> None

    type UserEventImport =
        abstract clear: element:#HTMLElement -> unit
        abstract click: element:#HTMLElement * ?eventInit:obj * ?options:obj -> unit
        abstract dblClick: element:#HTMLElement * ?eventInit:obj -> unit
        [<Emit("$0.deselectOptions($1, Array.from($2))")>]
        abstract deselectOptions: element:#HTMLElement * values:'T [] -> unit
        [<Emit("$0.deselectOptions($1, Array.from($2))")>]
        abstract deselectOptions: element:#HTMLElement * values:'T list -> unit
        abstract deselectOptions: element:#HTMLElement * values:ResizeArray<'T> -> unit
        abstract hover: element:#HTMLElement -> unit
        abstract paste: element:#HTMLElement * text:string * ?eventInit:obj * ?options:obj -> unit
        [<Emit("$0.selectOptions($1, Array.from($2))")>]
        abstract selectOptions: element:#HTMLElement * values:'T [] -> unit
        [<Emit("$0.selectOptions($1, Array.from($2))")>]
        abstract selectOptions: element:#HTMLElement * values:'T list -> unit
        abstract selectOptions: element:#HTMLElement * values:ResizeArray<'T> -> unit
        abstract tab: ?options:obj -> unit
        [<Emit("$0.type($1...)")>]
        abstract typeInternal: #HTMLElement * string * ?options: obj -> unit
        abstract unhover: #HTMLElement -> unit
        abstract upload: #HTMLElement * Browser.Types.File * ?options: obj -> unit
        abstract upload: #HTMLElement * ResizeArray<Browser.Types.File> * ?options: obj -> unit

    let userEvent : UserEventImport = importDefault "@testing-library/user-event"

    type WaitFor =
        [<Emit("$0($1)")>]
        abstract invoke: callback: (unit -> unit) * ?options: IWaitOptions -> JS.Promise<unit>

    let waitForImport : WaitFor = import "waitFor" "@testing-library/react"

    type WaitForElementToBeRemoved =
        [<Emit("$0($1...)")>]
        abstract invoke: callback: (unit -> #HTMLElement option) * ?options: IWaitOptions -> JS.Promise<unit>
        [<Emit("$0($1...)")>]
        abstract invoke: callback: (unit -> ResizeArray<#HTMLElement>) * ?options: IWaitOptions -> JS.Promise<unit>

    let waitForElementToBeRemovedImport : WaitForElementToBeRemoved = import "waitForElementToBeRemoved" "@testing-library/react"

    type Within =
        [<Emit("$0($1)")>]
        abstract invoke<'Element when 'Element :> HTMLElement> : node:'Element -> QueriesForElement

    let withinImport : Within = import "within" "@testing-library/react"
