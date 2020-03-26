namespace Fable.Mocha.ReactTestingLibrary

[<RequireQualifiedAccess>]
module Expect =
    open Browser.Types
    open Fable.Core.JsInterop
    open Fable.Core.Testing

    let private appendMsg (result: Bindings.ExpectReturn) (msg: string) =
        sprintf "%s%s%s" (result.message()) System.Environment.NewLine msg

    let private fromExpect b msg (result: Bindings.ExpectReturn) =
        Assert.AreEqual(result.pass, b, appendMsg result msg)

    /// Assert that the given element is checked. It accepts an input of 
    /// type checkbox or radio and elements with a role of checkbox or 
    /// radio with a valid aria-checked attribute of "true" or "false".
    let toBeChecked (element: HTMLElement) (msg: string) =
        Bindings.expectImport.toBeChecked element
        |> fromExpect true msg

    /// Assert that the given element is not checked. It accepts an input of 
    /// type checkbox or radio and elements with a role of checkbox or 
    /// radio with a valid aria-checked attribute of "true" or "false".
    let toNotBeChecked (element: HTMLElement) (msg: string) =
        Bindings.expectImport.toBeChecked element
        |> fromExpect false msg

    /// Assert that an element is disabled from the user's perspective.
    ///
    /// It matches if the element is a form control and the disabled attribute 
    /// is specified on this element or the element is a descendant of a form 
    /// element with a disabled attribute.
    ///
    /// According to the specification, the following elements can be actually 
    /// disabled: button, input, select, textarea, optgroup, option, fieldset.
    let toBeDisabled (element: HTMLElement) (msg: string) =
        Bindings.expectImport.toBeDisabled element
        |> fromExpect true msg

    /// Assert that an element is not disabled from the user's perspective.
    let toBeEnabled (element: HTMLElement) (msg: string) =
        Bindings.expectImport.toBeEnabled element
        |> fromExpect true msg

    /// Assert that an element has no content.
    let toBeEmpty (element: HTMLElement) (msg: string) = 
        Bindings.expectImport.toBeEmpty element
        |> fromExpect true msg

    /// Assert that an element has content.
    let toNotBeEmpty (element: HTMLElement) (msg: string) = 
        Bindings.expectImport.toBeEmpty element
        |> fromExpect false msg

    /// Assert that an element is present in the document.
    let toBeInTheDocument (element: HTMLElement) (msg: string) = 
        Bindings.expectImport.toBeInTheDocument element
        |> fromExpect true msg

    /// Assert that an element is not present in the document.
    let toNotBeInTheDocument (element: HTMLElement) (msg: string) = 
        Bindings.expectImport.toBeInTheDocument element
        |> fromExpect false msg

    /// Assert if a form element, or the entire form, is currently invalid.
    ///
    /// An input, select, textarea, or form element is invalid if it has an 
    /// aria-invalid attribute with no value or a value of "true", or if the 
    /// result of checkValidity is false. 
    let toBeInvalid (element: HTMLElement) (msg: string) = 
        Bindings.expectImport.toBeInvalid element
        |> fromExpect true msg

    /// Assert if a form element is currently required.
    ///
    /// An element is required if it is having a required or aria-required="true" attribute. 
    let toBeRequired (element: HTMLElement) (msg: string) = 
        Bindings.expectImport.toBeRequired element
        |> fromExpect true msg

    /// Assert if a form element is not currently required.
    ///
    /// An element is required if it is having a required or aria-required="true" attribute. 
    let toNotBeRequired (element: HTMLElement) (msg: string) = 
        Bindings.expectImport.toBeRequired element
        |> fromExpect false msg

    /// Assert if the value of a form element, or the entire form, is currently valid.
    /// 
    /// An input, select, textarea, or form element is valid if it has no aria-invalid 
    /// attribute or an attribute value of "false". 
    ///
    /// The result of checkValidity must also be true.
    let toBeValid (element: HTMLElement) (msg: string) = 
        Bindings.expectImport.toBeValid element
        |> fromExpect true msg

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
    let toBeVisible (element: HTMLElement) (msg: string) =
        Bindings.expectImport.toBeVisible element
        |> fromExpect true msg

    /// Assert if an element is currently not visible to the user.
    ///
    /// An element is visible if all the following conditions are met:
    /// 
    /// it does not have its css property display set to none
    /// it does not have its css property visibility set to either hidden or collapse
    /// it does not have its css property opacity set to 0
    /// its parent element is also visible (and so on up to the top of the DOM tree)
    /// it does not have the hidden attribute
    /// if <details /> it has the open attribute
    let toNotBeVisible (element: HTMLElement) (msg: string) =
        Bindings.expectImport.toBeVisible element
        |> fromExpect false msg

    /// Assert that an element contains another element as a descendant.
    let toContainElement (parent: HTMLElement) (element: HTMLElement option) (msg: string) =
        Bindings.expectImport.toContainElement(parent, element)
        |> fromExpect true msg

    /// Assert that an element does not contain another element as a descendant.
    let toNotContainElement (parent: HTMLElement) (element: HTMLElement option) (msg: string) =
        Bindings.expectImport.toContainElement(parent, element)
        |> fromExpect false msg

    /// Assert that a string representing a HTML element is contained in another element:
    let toContainHTML (element: HTMLElement) (htmlText: string) (msg: string) = 
        Bindings.expectImport.toContainHTML(element, htmlText)
        |> fromExpect true msg

    /// Assert that a string representing a HTML element is not contained in another element:
    let toNotContainHTML (element: HTMLElement) (htmlText: string) (msg: string) = 
        Bindings.expectImport.toContainHTML(element, htmlText)
        |> fromExpect false msg

    /// Assert that the given element has an attribute.
    let toHaveAttribute (element: HTMLElement) (attribute: string) (msg: string) =
        Bindings.expectImport.toHaveAttribute(element, attribute)
        |> fromExpect true msg

    /// Assert that the given element does not have an attribute.
    let toNotHaveAttribute (element: HTMLElement) (attribute: string) (msg: string) =
        Bindings.expectImport.toHaveAttribute(element, attribute)
        |> fromExpect false msg

    /// Assert that the given element has an attribute and matching value.
    let toHaveAttributeWithValue (element: HTMLElement) (attribute: string) (value: 'T) (msg: string) =
        Bindings.expectImport.toHaveAttribute(element, attribute, value)
        |> fromExpect true msg

    /// Assert that the given element does not have an attribute and matching value.
    let toNotHaveAttributeWithValue (element: HTMLElement) (attribute: string) (value: 'T) (msg: string) =
        Bindings.expectImport.toHaveAttribute(element, attribute, value)
        |> fromExpect false msg

    /// Assert that the given element has an attribute and matching value from a value predicate.
    let toHaveAttributeWithValueFun (element: HTMLElement) (attribute: string) (value: 'T -> bool) (msg: string) =
        Bindings.expectImport.toHaveAttribute(element, attribute, value)
        |> fromExpect true msg

    /// Assert that the given element does not have an attribute and matching value from a value predicate.
    let toNotHaveAttributeWithValueFun (element: HTMLElement) (attribute: string) (value: 'T -> bool) (msg: string) =
        Bindings.expectImport.toHaveAttribute(element, attribute, value)
        |> fromExpect false msg

    /// Assert that the given element has a certain class within its class attribute.
    ///
    /// You must provide at least one class, unless you are asserting that an element 
    /// does not have any classes.
    let toHaveClass (element: HTMLElement) (className: string option) (msg: string) =
        let className = className |> Option.map Array.singleton |> Option.defaultValue [||]
        Bindings.expectImport.toHaveClass(element, className)
        |> fromExpect true msg

    /// Assert that the given element does not have a certain class within its class attribute.
    ///
    /// You must provide at least one class, unless you are asserting that an element 
    /// does not have any classes.
    let toNotHaveClass (element: HTMLElement) (className: string option) (msg: string) =
        let className = className |> Option.map Array.singleton |> Option.defaultValue [||]
        Bindings.expectImport.toHaveClass(element, className)
        |> fromExpect false msg

    /// Assert that the given element has the given classes within its class attribute.
    ///
    /// You must provide at least one class, unless you are asserting that an element 
    /// does not have any classes.
    let toHaveClasses (element: HTMLElement) (classes: string list) (msg: string) = 
        Bindings.expectImport.toHaveClass(element, (Array.ofList classes))
        |> fromExpect true msg

    /// Assert that the given element does not have the classes within its class attribute.
    ///
    /// You must provide at least one class, unless you are asserting that an element 
    /// does not have any classes.
    let toNotHaveClasses (element: HTMLElement) (classes: string list) (msg: string) = 
        Bindings.expectImport.toHaveClass(element, (Array.ofList classes))
        |> fromExpect false msg

    /// Assert that an element has focus.
    let toHaveFocus (element: HTMLElement) (msg: string) = 
        Bindings.expectImport.toHaveFocus element
        |> fromExpect true msg

    /// Assert that an element does not have focus.
    let toNotHaveFocus (element: HTMLElement) (msg: string) = 
        Bindings.expectImport.toHaveFocus element
        |> fromExpect false msg

    /// Assert if a form or fieldset contains form controls for each given name, and 
    /// having the specified value.
    /// 
    /// It is important to stress that this matcher can only be invoked on a form or 
    /// a fieldset element.
    let toHaveFormValues (element: HTMLElement) (forms: (string * 'T) list) (msg: string) = 
        Bindings.expectImport.toHaveFormValues(element, createObj !!forms)
        |> fromExpect true msg

    /// Assert if a form or fieldset does not contain form controls for each given name, and 
    /// having the specified value.
    /// 
    /// It is important to stress that this matcher can only be invoked on a form or 
    /// a fieldset element.
    let toNotHaveFormValues (element: HTMLElement) (forms: (string * 'T) list) (msg: string) = 
        Bindings.expectImport.toHaveFormValues(element, createObj !!forms)
        |> fromExpect false msg

    /// Assert if a certain element has a specific css property with specific 
    /// values applied. 
    ///
    /// It matches only if the element has all the expected properties applied, not just some of them.
    let toHaveStyle (element: HTMLElement) (styles: Feliz.IStyleAttribute) (msg: string) = 
        Bindings.expectImport.toHaveStyle(element, createObj !!styles)
        |> fromExpect true msg

    /// Assert if a certain element does not have a specific css property with specific 
    /// values applied. 
    ///
    /// It matches only if the element has all the expected properties applied, not just some of them.
    let toNotHaveStyle (element: HTMLElement) (styles: Feliz.IStyleAttribute) (msg: string) = 
        Bindings.expectImport.toHaveStyle(element, createObj !!styles)
        |> fromExpect false msg

    /// Assert if a certain element has some specific css properties with specific 
    /// values applied. 
    ///
    /// It matches only if the element has all the expected properties applied, not just some of them.
    let toHaveStyles (element: HTMLElement) (styles: Feliz.IStyleAttribute list) (msg: string) = 
        Bindings.expectImport.toHaveStyle(element, createObj !!styles)
        |> fromExpect true msg

    /// Assert if a certain element does not have some specific css properties with specific 
    /// values applied. 
    ///
    /// It matches only if the element has all the expected properties applied, not just some of them.
    let toNotHaveStyles (element: HTMLElement) (styles: Feliz.IStyleAttribute list) (msg: string) = 
        Bindings.expectImport.toHaveStyle(element, createObj !!styles)
        |> fromExpect false msg

    /// Assert that the given element has the text content.
    let toHaveTextContent (element: HTMLElement) (text: string) (msg: string) = 
        Bindings.expectImport.toHaveTextContent(element, !^text)
        |> fromExpect true msg

    /// Assert that the given element does not have a matching text content.
    let toNotHaveTextContent (element: HTMLElement) (text: string) (msg: string) = 
        Bindings.expectImport.toHaveTextContent(element, !^text)
        |> fromExpect false msg

    /// Assert that the given element has text that matches the given regular expression.
    let toHaveTextPattern (element: HTMLElement) (pattern: System.Text.RegularExpressions.Regex) (msg: string) = 
        Bindings.expectImport.toHaveTextContent(element, !^pattern)
        |> fromExpect true msg

    /// Assert that the given element does not have text that matches the given regular expression.
    let toNotHaveTextPattern (element: HTMLElement) (pattern: System.Text.RegularExpressions.Regex) (msg: string) = 
        Bindings.expectImport.toHaveTextContent(element, !^pattern)
        |> fromExpect false msg

    /// Assert that the given form element has the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    let toHaveStringValue (element: HTMLElement) (value: string) (msg: string) = 
        Bindings.expectImport.toHaveValue(element, !^value)
        |> fromExpect true msg

    /// Assert that the given form element does not have the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    let toNotHaveStringValue (element: HTMLElement) (value: string) (msg: string) = 
        Bindings.expectImport.toHaveValue(element, !^value)
        |> fromExpect false msg

    /// Assert that the given form element has the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    let toHaveStringValues (element: HTMLElement) (value: string list) (msg: string) = 
        Bindings.expectImport.toHaveValue(element, !^(ResizeArray value))
        |> fromExpect true msg

    /// Assert that the given form element does not have the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    let toNotHaveStringValues (element: HTMLElement) (value: string list) (msg: string) = 
        Bindings.expectImport.toHaveValue(element, !^(ResizeArray value))
        |> fromExpect false msg

    /// Assert that the given form element has the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    let toHaveIntValue (element: HTMLElement) (value: int) (msg: string) = 
        Bindings.expectImport.toHaveValue(element, !^value)
        |> fromExpect true msg

    /// Assert that the given form element does not have the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    let toNotHaveIntValue (element: HTMLElement) (value: int) (msg: string) = 
        Bindings.expectImport.toHaveValue(element, !^value)
        |> fromExpect false msg

    /// Assert that the given form element has the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    let toHaveFloatValue (element: HTMLElement) (value: float) (msg: string) = 
        Bindings.expectImport.toHaveValue(element, !^value)
        |> fromExpect true msg

    /// Assert that the given form element does not have the specified value. It accepts <input>, <select> 
    /// and <textarea> elements with the exception of of <input type="checkbox"> and 
    /// <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
    /// 
    /// For all other form elements, the value is matched using the same algorithm as in toHaveFormValues does.
    let toNotHaveFloatValue (element: HTMLElement) (value: float) (msg: string) = 
        Bindings.expectImport.toHaveValue(element, !^value)
        |> fromExpect false msg
