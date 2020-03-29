namespace Fable.Jest.ReactTestingLibrary

open Browser.Types
open Fable.Core
open System

[<AutoOpen>]
module ExpectExtensions =
    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expectedHtml<'Return> =
        inherit Fable.Jest.Expect.expected<'Return>

        /// Inverts the pass/fail status of a matcher.
        member _.not : expectedHtml<'Return> = jsNative

        /// Check whether the given element is checked. 
        ///
        /// It accepts an input of type checkbox or radio and elements with 
        /// a role of checkbox or radio with a valid aria-checked attribute 
        /// of "true" or "false".
        member _.toBeChecked () : 'Return = jsNative

        /// Check whether an element is disabled from the 
        /// user's perspective.
        ///
        /// It matches if the element is a form control and the disabled 
        /// attribute is specified on this element or the element is a 
        /// descendant of a form element with a disabled attribute.
        ///
        /// According to the specification, the following elements can be 
        /// actually disabled: button, input, select, textarea, optgroup, 
        /// option, and fieldset.
        member _.toBeDisabled () : 'Return = jsNative

        /// Check whether an element is not disabled from the user's perspective.
        member _.toBeEnabled () : 'Return = jsNative

        /// Check whether an element has content or not.
        member _.toBeEmpty () : 'Return = jsNative

        /// Check whether an element is present in the document or not.
        member _.toBeInTheDocument () : 'Return = jsNative

        /// Check if a form element, or the entire form, is currently invalid.
        ///
        /// An input, select, textarea, or form element is invalid if it has an 
        /// aria-invalid attribute with no value or a value of "true", or if the 
        /// result of checkValidity() is false.
        member _.toBeInvalid () : 'Return = jsNative

        /// Check if a form element is currently required.
        ///
        /// An element is required if it is having a required or 
        /// aria-required="true" attribute.
        member _.toBeRequired () : 'Return = jsNative

        /// Check if the value of a form element, or the entire form, is currently valid.
        ///
        /// An input, select, textarea, or form element is valid if it has no aria-invalid 
        /// attribute or an attribute value of "false". The result of checkValidity() must 
        /// also be true.
        member _.toBeValid () : 'Return = jsNative

        /// This allows you to check if an element is currently visible to the user.
        ///
        /// An element is visible if all the following conditions are met:
        ///
        /// Does not have its css property display set to none.
        ///
        /// Does not have its css property visibility set to either hidden or collapse.
        ///
        /// Does not have its css property opacity set to 0.
        ///
        /// The parent element is also visible (and so on up to the top of the DOM tree).
        ///
        /// Does not have the hidden attribute.
        ///
        /// If <details /> it has the open attribute.
        member _.toBeVisible () : 'Return = jsNative

        /// Check whether an element contains another element as a descendant or not.
        member _.toContainElement (element: HTMLElement) : 'Return = jsNative

        /// Check whether a string representing a HTML element is contained in another element
        member _.toContainHTML (htmlText: string) : 'Return = jsNative

        /// Check whether the given element has an attribute or not. 
        ///
        /// You can also optionally check that the attribute has a specific expected value 
        /// or partial match using expect.stringContaining or expect.stringMatching.
        member _.toHaveAttribute (attr: string, ?value: obj) : 'Return = jsNative

        /// check whether the given element has certain classes within its class attribute.
        ///
        /// You must provide at least one class, unless you are asserting that an element does 
        /// not have any classes.
        member _.toHaveClass ([<ParamArray>] classNames: string []) : 'Return = jsNative

        /// Check whether an element has focus or not.
        member _.toHaveFocus () : 'Return = jsNative

        /// Check if a form or fieldset contains form controls for each given name, and having the specified value.
        ///
        /// Note that this matcher can *only* be invoked on a form or fieldset element.
        member _.toHaveFormValues (expectedValues: obj) : 'Return = jsNative

        /// Check if a certain element has some specific css properties with specific values applied. 
        /// 
        /// It matches only if the element has all the expected properties applied, not just some of them.
        member _.toHaveStyle (css: obj) : 'Return = jsNative

        /// Check if a certain element has some specific css properties with specific values applied. 
        /// 
        /// It matches only if the element has all the expected properties applied, not just some of them.
        member _.toHaveStyle (css: string) : 'Return = jsNative

        /// Check whether the given element has a text content or not.
        /// 
        /// When a string argument is passed through, it will perform a partial case-sensitive match to 
        /// the element content.
        ///
        /// To perform a case-insensitive match, you can use a RegExp with the /i modifier.
        ///
        /// If you want to match the whole content, you can use a RegExp to do it.
        member _.toHaveTextContent (text: U2<string, System.Text.RegularExpressions.Regex>, ?options: obj) : 'Return = jsNative

        /// Check whether the given form element has the specified value. 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of of <input type="checkbox"> 
        /// and <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
        member _.toHaveValue (value: U4<string, ResizeArray<string>, float, int>) : 'Return = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expectedHtmlPromise =
        /// Inverts the pass/fail status of a matcher.
        member _.not : expectedHtmlPromise = jsNative

        /// Unwrap the value of a fulfilled promise so any other 
        /// matcher can be chained. If the promise is rejected 
        /// the assertion fails.
        ///
        /// This is automatically applied for `Async<'T>` values.
        member _.rejects : expectedHtml<JS.Promise<unit>> = jsNative

        /// Unwrap the reason of a rejected promise so any other 
        /// matcher can be chained. If the promise is fulfilled 
        /// the assertion fails.
        member _.resolves : expectedHtml<JS.Promise<unit>> = jsNative

    type Fable.Jest.Jest with
        /// The expect function is used every time you want to test a value.
        ///
        /// The argument to expect should be the value that your code produces, 
        /// and any argument to the matcher should be the correct value. If you 
        /// mix them up, your tests will still work, but the error messages on 
        /// failing tests will look strange.
        [<Global>]
        static member expect (value: HTMLElement) : expectedHtml<unit> = jsNative
        /// The expect function is used every time you want to test a value.
        ///
        /// The argument to expect should be the value that your code produces, 
        /// and any argument to the matcher should be the correct value. If you 
        /// mix them up, your tests will still work, but the error messages on 
        /// failing tests will look strange.
        [<Global>]
        static member expect (value: HTMLElement option) : expectedHtml<unit> = jsNative
        /// The expect function is used every time you want to test a value.
        ///
        /// The argument to expect should be the value that your code produces, 
        /// and any argument to the matcher should be the correct value. If you 
        /// mix them up, your tests will still work, but the error messages on 
        /// failing tests will look strange.
        [<Global>]
        static member expect (value: JS.Promise<HTMLElement>) : expectedHtmlPromise = jsNative
        /// The expect function is used every time you want to test a value.
        ///
        /// The argument to expect should be the value that your code produces, 
        /// and any argument to the matcher should be the correct value. If you 
        /// mix them up, your tests will still work, but the error messages on 
        /// failing tests will look strange.
        static member inline expect (value: Async<HTMLElement>) = 
            Fable.Jest.Jest.expect(Async.StartAsPromise value).resolves
