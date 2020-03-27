namespace Fable.Jest.ReactTestingLibrary

open Browser.Types
open Fable.Core.JsInterop
open Fable.Core.Testing

type ExpectElement (element: HTMLElement, isInverted: bool) =
    let appendMsg (result: Bindings.ExpectDomReturn) (msg: string) =
        sprintf "%s%s%s" (result.message()) System.Environment.NewLine msg
    
    let fromExpect (msg: string option) (result: Bindings.ExpectDomReturn) =
        let resultMsg =
            match msg with
            | Some addMsg -> appendMsg result addMsg
            | None -> result.message()

        Assert.AreEqual(result.pass, (not isInverted), resultMsg)

    do Bindings.toBeInTheDocumentTest()

    new (element: HTMLElement) = ExpectElement(element, true)

    /// Invert the test case
    member _.not = ExpectElement(element, false)

    /// Assert that the given element is checked. It accepts an input of 
    /// type checkbox or radio and elements with a role of checkbox or 
    /// radio with a valid aria-checked attribute of "true" or "false".
    member _.toBeChecked (?msg: string) =
        Bindings.ExpectDom.toBeChecked element
        |> fromExpect msg

    /// Assert that an element is disabled from the user's perspective.
    ///
    /// It matches if the element is a form control and the disabled attribute 
    /// is specified on this element or the element is a descendant of a form 
    /// element with a disabled attribute.
    ///
    /// According to the specification, the following elements can be actually 
    /// disabled: button, input, select, textarea, optgroup, option, fieldset.
    member _.toBeDisabled (?msg: string) =
        Bindings.ExpectDom.toBeDisabled element
        |> fromExpect msg

    /// Assert that an element is not disabled from the user's perspective.
    member _.toBeEnabled (?msg: string) =
        Bindings.ExpectDom.toBeEnabled element
        |> fromExpect msg

    /// Assert that an element has no content.
    member _.toBeEmpty (?msg: string) =
        Bindings.ExpectDom.toBeEmpty element
        |> fromExpect msg

    /// Assert that an element is present in the document.
    member _.toBeInTheDocument (?msg: string) =
        //Bindings.ExpectDom.toBeInTheDocument element
        Bindings.expect.invoke(element).toBeInTheDocument()
        |> fromExpect msg

    /// Assert if a form element, or the entire form, is currently invalid.
    ///
    /// An input, select, textarea, or form element is invalid if it has an 
    /// aria-invalid attribute with no value or a value of "true", or if the 
    /// result of checkValidity is false. 
    member _.toBeInvalid (?msg: string) =
        Bindings.ExpectDom.toBeInvalid element
        |> fromExpect msg

    /// Assert if a form element is currently required.
    ///
    /// An element is required if it is having a required or aria-required="true" attribute. 
    member _.toBeRequired (?msg: string) =
        Bindings.ExpectDom.toBeRequired element
        |> fromExpect msg

    /// Assert if the value of a form element, or the entire form, is currently valid.
    /// 
    /// An input, select, textarea, or form element is valid if it has no aria-invalid 
    /// attribute or an attribute value of "false". 
    ///
    /// The result of checkValidity must also be true.
    member _.toBeValid (?msg: string) =
        Bindings.ExpectDom.toBeValid element
        |> fromExpect msg

    /// Assert if an element is currently visible to the user.
    ///
    /// An element is visible if all the following conditions are met:
    /// 
    /// it does not have its css property display set to none
    /// it does not have its css property visibility set to either hidden or collapse
    /// it does not have its css property opacity set to 0
    /// its parent element is also visible (and so on up to the top of the DOM tree)
    /// it does not have the hidden attribute
    /// if <details /> it has the open attribute
    member _.toBeVisible (?msg: string) =
        Bindings.ExpectDom.toBeVisible element
        |> fromExpect msg

    /// Assert that an element contains another element as a descendant.
    member _.toContainElement (childElement: HTMLElement option, ?msg: string) =
        Bindings.ExpectDom.toContainElement(element, childElement)
        |> fromExpect msg

    /// Assert that a string representing a HTML element is contained in another element:
    member _.toContainHTML (htmlText: string, ?msg: string) =
        Bindings.ExpectDom.toContainHTML(element, htmlText)
        |> fromExpect msg

    /// Assert that the given element has an attribute.
    member _.toHaveAttribute (attribute: string, ?msg: string) =
        Bindings.ExpectDom.toHaveAttribute(element, attribute)
        |> fromExpect msg

    /// Assert that the given element has an attribute and matching value.
    member _.toHaveAttribute (attribute: string, value: 'T, ?msg: string) =
        Bindings.ExpectDom.toHaveAttribute(element, attribute, value)
        |> fromExpect msg

    /// Assert that the given element has an attribute and matching value from a value predicate.
    member _.toHaveAttribute (attribute: string, value: 'T -> bool, ?msg: string) =
        Bindings.ExpectDom.toHaveAttribute(element, attribute, value)
        |> fromExpect msg

    /// Assert that the given element has a certain class within its class attribute.
    ///
    /// You must provide at least one class, unless you are asserting that an element 
    /// does not have any classes.
    member _.toHaveClass (className: string option, ?msg: string) =
        let className = className |> Option.map Array.singleton |> Option.defaultValue [||]
        Bindings.ExpectDom.toHaveClass(element, className)
        |> fromExpect msg

    /// Assert that the given element has the given classes within its class attribute.
    ///
    /// You must provide at least one class, unless you are asserting that an element 
    /// does not have any classes.
    member _.toHaveClass (classes: string list, ?msg: string) = 
        Bindings.ExpectDom.toHaveClass(element, (Array.ofList classes))
        |> fromExpect msg

    /// Assert that an element has focus.
    member _.toHaveFocus (?msg: string) =
        Bindings.ExpectDom.toHaveFocus element
        |> fromExpect msg

    /// Assert if a form or fieldset contains form controls for each given name, and 
    /// having the specified value.
    /// 
    /// It is important to stress that this matcher can only be invoked on a form or 
    /// a fieldset element.
    member _.toHaveFormValues (forms: (string * 'T) list, ?msg: string) =
        Bindings.ExpectDom.toHaveFormValues(element, createObj !!forms)
        |> fromExpect msg

    /// Assert if a certain element has a specific css property with specific 
    /// values applied. 
    ///
    /// It matches only if the element has all the expected properties applied, not just some of them.
    member _.toHaveStyle (styles: Feliz.IStyleAttribute, ?msg: string) =
        Bindings.ExpectDom.toHaveStyle(element, createObj !!styles)
        |> fromExpect msg

    /// Assert if a certain element has some specific css properties with specific 
    /// values applied. 
    ///
    /// It matches only if the element has all the expected properties applied, not just some of them.
    member _.toHaveStyles (styles: Feliz.IStyleAttribute list, ?msg: string) =
        Bindings.ExpectDom.toHaveStyle(element, createObj !!styles)
        |> fromExpect msg

    /// Assert that the given element has the text content.
    member _.toHaveTextContent (text: string, ?msg: string) =
        Bindings.ExpectDom.toHaveTextContent(element, !^text)
        |> fromExpect msg

    /// Assert that the given element has text that matches the given regular expression.
    member _.toHaveTextPattern (pattern: System.Text.RegularExpressions.Regex, ?msg: string) =
        Bindings.ExpectDom.toHaveTextContent(element, !^pattern)
        |> fromExpect msg

    /// Assert that the given form element has the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    member _.toHaveStringValue (value: string, ?msg: string) =
        Bindings.ExpectDom.toHaveValue(element, !^value)
        |> fromExpect msg

    /// Assert that the given form element has the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    member _.toHaveStringValues (value: string list, ?msg: string) =
        Bindings.ExpectDom.toHaveValue(element, !^(ResizeArray value))
        |> fromExpect msg

    /// Assert that the given form element has the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    member _.toHaveIntValue (value: int, ?msg: string) =
        Bindings.ExpectDom.toHaveValue(element, !^value)
        |> fromExpect msg

    /// Assert that the given form element has the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    member _.toHaveFloatValue (value: float, ?msg: string) =
        Bindings.ExpectDom.toHaveValue(element, !^value)
        |> fromExpect msg

[<RequireQualifiedAccess>]
module Expect =
    let element (elem: HTMLElement) = ExpectElement(elem)
