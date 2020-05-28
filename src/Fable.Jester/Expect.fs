namespace Fable.Jester

open Browser.Types
open Fable.Core
open Feliz
open System
open System.Text.RegularExpressions

[<AutoOpen>]
module Expect =
    /// The response structure of matcher extensions.
    type MatcherResponse =
        abstract pass: bool
        abstract message: unit -> string

    [<NoComparison>]
    [<NoEquality>]
    [<Global>]
    type expect =
        /// Add a module that formats application-specific data structures.
        ///
        /// `expect.addSnapshotSerializer(import "serializer" "my-serializer-module")`
        member _.addSnapshotSerializer (serializer: obj) = jsNative
        
        /// Matches anything that was created with the given constructor.
        member _.any (value: 'Constructor) = jsNative
        
        /// Matches anything but null or undefined.
        member _.anything () = jsNative

        /// Matches a received collection which contains all of the elements 
        /// in the expected array. That is, the expected collection is a 
        /// subset of the received collection. Therefore, it matches a 
        /// received collection which contains elements that are not in the 
        /// expected collection.
        member _.arrayContaining (values: ResizeArray<'T>) = jsNative
        /// Matches a received collection which contains all of the elements 
        /// in the expected array. That is, the expected collection is a 
        /// subset of the received collection. Therefore, it matches a 
        /// received collection which contains elements that are not in the 
        /// expected collection.
        [<Emit("$0.arrayContaining(Array.from($1))")>]
        member _.arrayContaining (values: 'T []) = jsNative
        /// Matches a received collection which contains all of the elements 
        /// in the expected array. That is, the expected collection is a 
        /// subset of the received collection. Therefore, it matches a 
        /// received collection which contains elements that are not in the 
        /// expected collection.
        [<Emit("$0.arrayContaining(Array.from($1))")>]
        member _.arrayContaining (values: 'T list) = jsNative
        /// Matches a received collection which contains all of the elements 
        /// in the expected array. That is, the expected collection is a 
        /// subset of the received collection. Therefore, it matches a 
        /// received collection which contains elements that are not in the 
        /// expected collection.
        [<Emit("$0.arrayContaining(Array.from($1))")>]
        member _.arrayContaining (values: 'T seq) = jsNative

        /// Verifies that a certain number of assertions are called 
        /// during a test.
        member _.assertions (number: int) = jsNative

        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: unit -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> 'd -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> 'd -> 'e -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> 'd -> 'e -> 'f -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> 'd -> 'e -> 'f -> 'g -> MatcherResponse) : 'Return = jsNative
        /// Adds custom matchers to Jest.
        ///
        /// See docs for list of `this` properties and methods 
        /// https://jestjs.io/docs/en/expect
        member _.extend (matchers: 'a -> 'b -> 'c -> 'd -> 'e -> 'f -> 'g -> 'h -> MatcherResponse) : 'Return = jsNative

        /// Verifies that at least one assertion is called during a test.
        member _.hasAssertions () : 'Return = jsNative

        /// Inverts the pass/fail status of a matcher.
        member _.not : expect = jsNative

        /// Matches any received object that recursively matches the 
        /// expected properties. That is, the expected object is a 
        /// subset of the received object. Therefore, it matches a 
        /// received object which contains properties that are 
        /// present in the expected object.
        member _.objectContaining (value: obj) = jsNative

        /// Matches the received value if it is a string that 
        /// contains the exact expected string.
        member _.stringContaining (value: string) = jsNative

        /// Matches the received value if it is a string that matches 
        /// the expected string or regular expression.
        member _.stringMatching (value: string) = jsNative
        /// Matches the received value if it is a string that matches 
        /// the expected string or regular expression.
        member _.stringMatching (value: Regex) = jsNative

    [<Global>]
    let expect : expect = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expected<'Return> =
        /// Inverts the pass/fail status of a matcher.
        member _.not : expected<'Return> = jsNative

        /// Compare primitive values or to check referential identity 
        /// of object instances. It calls Object.is to compare values, 
        /// which is even better for testing than === strict equality 
        /// operator.
        member _.toBe (value: 'T) : 'Return = jsNative
        
        /// Check that an object has a .length property and it is set 
        /// to a certain numeric value.
        member _.toHaveLength (length: int) : 'Return = jsNative
        
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        member _.toHaveProperty (keyPath: string, ?value: 'T) : 'Return = jsNative
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        [<Emit("$0.toHaveProperty($1.join('.')))")>]
        member _.toHaveProperty (keyPath: ResizeArray<string>) : 'Return = jsNative
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        [<Emit("$0.toHaveProperty($1.join('.')), $2)")>]
        member _.toHaveProperty (keyPath: ResizeArray<string>, value: 'T) : 'Return = jsNative
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        [<Emit("$0.toHaveProperty(Array.from($1).join('.'))")>]
        member _.toHaveProperty (keyPath: string []) : 'Return = jsNative
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        [<Emit("$0.toHaveProperty((Array.from($1).join('.')), $2)")>]
        member _.toHaveProperty (keyPath: string [], value: 'T) : 'Return = jsNative
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        [<Emit("$0.toHaveProperty((Array.from($1).join('.')))")>]
        member _.toHaveProperty (keyPath: string list) : 'Return = jsNative
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        [<Emit("$0.toHaveProperty((Array.from($1).join('.')), $2)")>]
        member _.toHaveProperty (keyPath: string list, value: 'T) : 'Return = jsNative
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        [<Emit("$0.toHaveProperty(Array.from($1).join('.'))")>]
        member _.toHaveProperty (keyPath: string seq) : 'Return = jsNative
        /// Check if property at provided reference keyPath exists for an object.
        ///
        /// You can provide an optional value argument to compare the received 
        /// property value (recursively for all properties of object instances, 
        /// also known as deep equality, like the toEqual matcher).
        [<Emit("$0.toHaveProperty((Array.from($1).join('.')), $2)")>]
        member _.toHaveProperty (keyPath: string seq, value: 'T) : 'Return = jsNative
        
        /// Check that a variable is not undefined.
        member _.toBeDefined () : 'Return = jsNative

        /// Matcher for when you don't care what a value is and you want to 
        /// ensure a value is false in a boolean context.
        member _.toBeFalsy () : 'Return = jsNative

        /// Check that something is null.
        member _.toBeNull () : 'Return = jsNative

        /// Matcher for when you don't care what a value is and you want to 
        /// ensure a value is true in a boolean context.
        member _.toBeTruthy () : 'Return = jsNative

        /// Check that a variable is undefined.
        member _.toBeUndefined () : 'Return = jsNative

        /// Check that a value is NaN.
        member _.toBeNaN () : 'Return = jsNative

        /// Check that an item is in a collection.
        ///
        /// Note that this matcher will check *both* the 
        /// index and values if given a int or float. 
        ///
        /// These will *both* pass:
        ///
        /// expect([1;2;5]).toContain(5) 
        /// 
        /// expect([1;2;5]).toContain(3)
        ///
        /// If you do not want this, see `toContainEqual`.
        member _.toContain (item: 'T) : 'Return = jsNative

        /// Check that an item with a specific structure and 
        /// values is contained in a collection.
        member _.toContainEqual (item: 'T) : 'Return = jsNative

        /// Compare recursively all properties of object instances 
        /// (also known as "deep" equality). It calls Object.is to 
        /// compare primitive values, which is even better for 
        /// testing than === strict equality operator.
        member _.toEqual (value: 'T) : 'Return = jsNative
        
        /// Check that a JavaScript object matches a subset of the properties of an object.
        member _.toMatchObject (object: 'T) : 'Return = jsNative
        
        /// Check that an object has the same types as well as structure.
        ///
        /// Differences from .toEqual:
        ///
        /// Keys with undefined properties are checked. e.g. {a: undefined, b: 2} does 
        /// not match {b: 2} when using .toStrictEqual.
        ///
        /// Array sparseness is checked. e.g. [, 1] does not match [undefined, 1] when 
        /// using .toStrictEqual.
        ///
        /// Object types are checked to be equal. e.g. A class instance with fields a 
        /// and b will not equal a literal object with fields a and b.
        member _.toStrictEqual (value: 'T) : 'Return = jsNative

        /// Check that a function throws when called.
        member _.toThrow () : 'Return = jsNative
        /// Check that a function throws when called.
        member _.toThrow (err: exn) : 'Return = jsNative
        /// Check that a function throws when called.
        member _.toThrow (err: Regex) : 'Return = jsNative
        /// Check that a function throws when called.
        member _.toThrow (err: string) : 'Return = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expectedPromise =
        /// Inverts the pass/fail status of a matcher.
        member _.not : expectedPromise = jsNative

        /// Unwrap the reason of a rejected promise so any other 
        /// matcher can be chained. If the promise is fulfilled 
        /// the assertion fails.
        member _.rejects : expected<JS.Promise<unit>> = jsNative
        
        /// Unwrap the value of a fulfilled promise so any other 
        /// matcher can be chained. If the promise is rejected 
        /// the assertion fails.
        ///
        /// This is automatically applied for `Async<'T>` values.
        member _.resolves : expected<JS.Promise<unit>> = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type unexpectedHtml<'Return> =
        inherit expected<'Return>

        /// Check whether the given element is checked. 
        ///
        /// It accepts an input of type checkbox or radio and elements with 
        /// a role of checkbox, radio, or switch with a valid aria-checked 
        /// attribute of "true" or "false".
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
        member _.toBeEmptyDOMElement () : 'Return = jsNative

        /// Check whether an element is present in the document or not.
        member _.toBeInTheDocument () : 'Return = jsNative

        /// Check if a form element, or the entire form, is currently invalid.
        ///
        /// An input, select, textarea, or form element is invalid if it has an 
        /// aria-invalid attribute with no value or a value of "true", or if the 
        /// result of checkValidity() is false.
        member _.toBeInvalid () : 'Return = jsNative

        /// Check whether the given element is partially checked. 
        ///
        /// It accepts an input of type checkbox and elements with a role of 
        /// checkbox with an aria-checked="mixed", or input of type checkbox with 
        /// indeterminate set to true.
        member _.toBePartiallyChecked () : 'Return = jsNative

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
        /// Check whether an element contains another element as a descendant or not.
        member _.toContainElement (element: Node) : 'Return = jsNative

        /// Check whether a string representing a HTML element is contained in another element
        member _.toContainHTML (htmlText: string) : 'Return = jsNative

        /// Check whether the given element has an attribute or not. 
        ///
        /// You can also optionally check that the attribute has a specific expected value 
        /// or partial match using expect.stringContaining or expect.stringMatching.
        member _.toHaveAttribute (attr: string, ?value: obj) : 'Return = jsNative

        /// Check whether the given element has certain classes within its class attribute.
        ///
        /// You must provide at least one class, unless you are asserting that an element does 
        /// not have any classes.
        member _.toHaveClass ([<ParamArray>] classNames: string []) : 'Return = jsNative

        /// Check whether the given element has a description or not.
        ///
        /// An element gets its description via the aria-describedby attribute. Set this to 
        /// the id of one or more other elements. These elements may be nested inside, be 
        /// outside, or a sibling of the passed in element.
        ///
        /// Whitespace is normalized. Using multiple ids will join the referenced elements’ 
        /// text content separated by a space.
        member _.toHaveDescription (value: Regex) : 'Return = jsNative
        /// Check whether the given element has a description or not.
        ///
        /// An element gets its description via the aria-describedby attribute. Set this to 
        /// the id of one or more other elements. These elements may be nested inside, be 
        /// outside, or a sibling of the passed in element.
        ///
        /// Whitespace is normalized. Using multiple ids will join the referenced elements’ 
        /// text content separated by a space.
        member _.toHaveDescription (value: string) : 'Return = jsNative
        
        /// Check whether the given form element has the specified displayed value (the 
        /// one the end user will see). 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of 
        /// <input type="checkbox"> and <input type="radio">, which can be meaningfully 
        /// matched only using toBeChecked or toHaveFormValues.
        member _.toHaveDisplayValue (value: Regex) : 'Return = jsNative
        /// Check whether the given form element has the specified displayed value (the 
        /// one the end user will see). 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of 
        /// <input type="checkbox"> and <input type="radio">, which can be meaningfully 
        /// matched only using toBeChecked or toHaveFormValues.
        member _.toHaveDisplayValue (value: string) : 'Return = jsNative
        /// Check whether the given form element has the specified displayed value (the 
        /// one the end user will see). 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of 
        /// <input type="checkbox"> and <input type="radio">, which can be meaningfully 
        /// matched only using toBeChecked or toHaveFormValues.
        member _.toHaveDisplayValue (values: ResizeArray<Regex>) : 'Return = jsNative
        /// Check whether the given form element has the specified displayed value (the 
        /// one the end user will see). 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of 
        /// <input type="checkbox"> and <input type="radio">, which can be meaningfully 
        /// matched only using toBeChecked or toHaveFormValues.
        member _.toHaveDisplayValue (values: ResizeArray<string>) : 'Return = jsNative
        /// Check whether the given form element has the specified displayed value (the 
        /// one the end user will see). 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of 
        /// <input type="checkbox"> and <input type="radio">, which can be meaningfully 
        /// matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveDisplayValue(Array.from($1))")>]
        member _.toHaveDisplayValue (values: Regex []) : 'Return = jsNative
        /// Check whether the given form element has the specified displayed value (the 
        /// one the end user will see). 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of 
        /// <input type="checkbox"> and <input type="radio">, which can be meaningfully 
        /// matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveDisplayValue(Array.from($1))")>]
        member _.toHaveDisplayValue (values: string []) : 'Return = jsNative
        /// Check whether the given form element has the specified displayed value (the 
        /// one the end user will see). 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of 
        /// <input type="checkbox"> and <input type="radio">, which can be meaningfully 
        /// matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveDisplayValue(Array.from($1))")>]
        member _.toHaveDisplayValue (values: Regex list) : 'Return = jsNative
        /// Check whether the given form element has the specified displayed value (the 
        /// one the end user will see). 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of 
        /// <input type="checkbox"> and <input type="radio">, which can be meaningfully 
        /// matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveDisplayValue(Array.from($1))")>]
        member _.toHaveDisplayValue (values: string list) : 'Return = jsNative
        /// Check whether the given form element has the specified displayed value (the 
        /// one the end user will see). 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of 
        /// <input type="checkbox"> and <input type="radio">, which can be meaningfully 
        /// matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveDisplayValue(Array.from($1))")>]
        member _.toHaveDisplayValue (values: Regex seq) : 'Return = jsNative
        /// Check whether the given form element has the specified displayed value (the 
        /// one the end user will see). 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of 
        /// <input type="checkbox"> and <input type="radio">, which can be meaningfully 
        /// matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveDisplayValue(Array.from($1))")>]
        member _.toHaveDisplayValue (values: string seq) : 'Return = jsNative

        /// Check whether an element has focus or not.
        member _.toHaveFocus () : 'Return = jsNative

        /// Check if a form or fieldset contains form controls for each given name, and having the specified value.
        ///
        /// Note that this matcher can *only* be invoked on a form or fieldset element.
        member _.toHaveFormValues (expectedValues: obj) : 'Return = jsNative
        /// Check if a form or fieldset contains form controls for each given name, and having the specified value.
        ///
        /// Note that this matcher can *only* be invoked on a form or fieldset element.
        [<Emit("$0.toHaveFormValues(Object.fromEntries($1))")>]
        member _.toHaveFormValues (expectedValues: ResizeArray<string * obj>) : 'Return = jsNative
        /// Check if a form or fieldset contains form controls for each given name, and having the specified value.
        ///
        /// Note that this matcher can *only* be invoked on a form or fieldset element.
        [<Emit("$0.toHaveFormValues(Object.fromEntries(Array.from($1)))")>]
        member _.toHaveFormValues (expectedValues: (string * obj) []) : 'Return = jsNative
        /// Check if a form or fieldset contains form controls for each given name, and having the specified value.
        ///
        /// Note that this matcher can *only* be invoked on a form or fieldset element.
        [<Emit("$0.toHaveFormValues(Object.fromEntries(Array.from($1)))")>]
        member _.toHaveFormValues (expectedValues: (string * obj) list) : 'Return = jsNative
        /// Check if a form or fieldset contains form controls for each given name, and having the specified value.
        ///
        /// Note that this matcher can *only* be invoked on a form or fieldset element.
        [<Emit("$0.toHaveFormValues(Object.fromEntries(Array.from($1)))")>]
        member _.toHaveFormValues (expectedValues: (string * obj) seq) : 'Return = jsNative

        /// Check if a certain element has some specific css properties with specific values applied. 
        /// 
        /// It matches only if the element has all the expected properties applied, not just some of them.
        member _.toHaveStyle (css: obj) : 'Return = jsNative
        /// Check if a certain element has some specific css properties with specific values applied. 
        /// 
        /// It matches only if the element has all the expected properties applied, not just some of them.
        member _.toHaveStyle (css: string) : 'Return = jsNative
        /// Check if a certain element has some specific css properties with specific values applied. 
        /// 
        /// It matches only if the element has all the expected properties applied, not just some of them.
        [<Emit("$0.toHaveStyle(Object.fromEntries([$1]))")>]
        member _.toHaveStyle (css: IStyleAttribute) : 'Return = jsNative
        /// Check if a certain element has some specific css properties with specific values applied. 
        /// 
        /// It matches only if the element has all the expected properties applied, not just some of them.
        [<Emit("$0.toHaveStyle(Object.fromEntries(Array.from($1)))")>]
        member _.toHaveStyle (css: IStyleAttribute list) : 'Return = jsNative

        /// Check whether the given element has a text content or not.
        /// 
        /// When a string argument is passed through, it will perform a partial case-sensitive match to 
        /// the element content.
        ///
        /// To perform a case-insensitive match, you can use a RegExp with the /i modifier.
        ///
        /// If you want to match the whole content, you can use a RegExp to do it.
        member _.toHaveTextContent (text: string) : 'Return = jsNative
        /// Check whether the given element has a text content or not.
        /// 
        /// When a string argument is passed through, it will perform a partial case-sensitive match to 
        /// the element content.
        ///
        /// To perform a case-insensitive match, you can use a RegExp with the /i modifier.
        ///
        /// If you want to match the whole content, you can use a RegExp to do it.
        [<Emit("$0.toHaveTextContent($1, { normalizeWhitespace: $2 })")>]
        member _.toHaveTextContent (text: string, ?normalizeWhitespace: bool) : 'Return = jsNative
        /// Check whether the given element has a text content or not.
        /// 
        /// When a string argument is passed through, it will perform a partial case-sensitive match to 
        /// the element content.
        ///
        /// To perform a case-insensitive match, you can use a RegExp with the /i modifier.
        ///
        /// If you want to match the whole content, you can use a RegExp to do it.
        member _.toHaveTextContent (text: Regex) : 'Return = jsNative
        /// Check whether the given element has a text content or not.
        /// 
        /// When a string argument is passed through, it will perform a partial case-sensitive match to 
        /// the element content.
        ///
        /// To perform a case-insensitive match, you can use a RegExp with the /i modifier.
        ///
        /// If you want to match the whole content, you can use a RegExp to do it.
        [<Emit("$0.toHaveTextContent($1, { normalizeWhitespace: $2 })")>]
        member _.toHaveTextContent (text: Regex, ?normalizeWhitespace: bool) : 'Return = jsNative

        /// Check whether the given form element has the specified value. 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of of <input type="checkbox"> 
        /// and <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveValue(String($1))")>]
        member _.toHaveValue (value: bool) : 'Return = jsNative
        /// Check whether the given form element has the specified value. 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of of <input type="checkbox"> 
        /// and <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveValue(String($1))")>]
        member _.toHaveValue (value: float) : 'Return = jsNative
        /// Check whether the given form element has the specified value. 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of of <input type="checkbox"> 
        /// and <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
        member _.toHaveValue (value: System.Guid) : 'Return = jsNative
        /// Check whether the given form element has the specified value. 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of of <input type="checkbox"> 
        /// and <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveValue(String($1))")>]
        member _.toHaveValue (value: int) : 'Return = jsNative
        /// Check whether the given form element has the specified value. 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of of <input type="checkbox"> 
        /// and <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
        member _.toHaveValue (value: string) : 'Return = jsNative
        /// Check whether the given form element has the specified value. 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of of <input type="checkbox"> 
        /// and <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveValue(Array.from($1))")>]
        member _.toHaveValue (value: ResizeArray<string>) : 'Return = jsNative
        /// Check whether the given form element has the specified value. 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of of <input type="checkbox"> 
        /// and <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveValue(Array.from($1))")>]
        member _.toHaveValue (value: string []) : 'Return = jsNative
        /// Check whether the given form element has the specified value. 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of of <input type="checkbox"> 
        /// and <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveValue(Array.from($1))")>]
        member _.toHaveValue (value: string list) : 'Return = jsNative
        /// Check whether the given form element has the specified value. 
        ///
        /// It accepts <input>, <select> and <textarea> elements with the exception of of <input type="checkbox"> 
        /// and <input type="radio">, which can be meaningfully matched only using toBeChecked or toHaveFormValues.
        [<Emit("$0.toHaveValue(Array.from($1))")>]
        member _.toHaveValue (value: string seq) : 'Return = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expectedHtml<'Return> =
        inherit unexpectedHtml<'Return>
        /// Inverts the pass/fail status of a matcher.
        member _.not : expectedHtml<'Return> = jsNative

        /// Ensures that a value matches the most recent snapshot.
        member _.toMatchSnapshot (?propertyMatchers, ?hint) : 'Return = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expectedHtmlPromise =
        /// Inverts the pass/fail status of a matcher.
        member _.not : expectedHtmlPromise = jsNative

        /// Unwrap the reason of a rejected promise so any other 
        /// matcher can be chained. If the promise is fulfilled 
        /// the assertion fails.
        member _.rejects : expectedHtml<JS.Promise<unit>> = jsNative

        /// Unwrap the value of a fulfilled promise so any other 
        /// matcher can be chained. If the promise is rejected 
        /// the assertion fails.
        ///
        /// This is automatically applied for `Async<'T>` values.
        member _.resolves : expectedHtml<JS.Promise<unit>> = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type unexpectedNumber<'Return> =
        inherit expected<'Return>

        /// Compare floats or decimals for approximate equality.
        member _.toBeCloseTo(number: decimal, ?numDigits: int) : 'Return = jsNative
        /// Compare floats or decimals for approximate equality.
        member _.toBeCloseTo(number: float, ?numDigits: int) : 'Return = jsNative

        /// To compare received > expected.
        member _.toBeGreaterThan (number: decimal) : 'Return = jsNative
        /// To compare received > expected.
        member _.toBeGreaterThan (number: float) : 'Return = jsNative
        /// To compare received > expected.
        member _.toBeGreaterThan (number: int) : 'Return = jsNative
        /// To compare received > expected.
        member _.toBeGreaterThan (number: int64) : 'Return = jsNative
        
        /// To compare received >= expected.
        member _.toBeGreaterThanOrEqual (number: decimal) : 'Return = jsNative
        /// To compare received >= expected.
        member _.toBeGreaterThanOrEqual (number: float) : 'Return = jsNative
        /// To compare received >= expected.
        member _.toBeGreaterThanOrEqual (number: int) : 'Return = jsNative
        /// To compare received >= expected.
        member _.toBeGreaterThanOrEqual (number: int64) : 'Return = jsNative
        
        /// To compare received < expected.
        member _.toBeLessThan (number: decimal) : 'Return = jsNative
        /// To compare received < expected.
        member _.toBeLessThan (number: float) : 'Return = jsNative
        /// To compare received < expected.
        member _.toBeLessThan (number: int) : 'Return = jsNative
        
        /// To compare received <= expected.
        member _.toBeLessThanOrEqual (number: decimal) : 'Return = jsNative
        /// To compare received <= expected.
        member _.toBeLessThanOrEqual (number: float) : 'Return = jsNative
        /// To compare received <= expected.
        member _.toBeLessThanOrEqual (number: int) : 'Return = jsNative
        /// To compare received <= expected.
        member _.toBeLessThanOrEqual (number: int64) : 'Return = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expectedNumber<'Return> =
        inherit unexpectedNumber<'Return>
        /// Inverts the pass/fail status of a matcher.
        member _.not : expectedNumber<'Return> = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expectedNumberPromise =
        /// Inverts the pass/fail status of a matcher.
        member _.not : expectedNumberPromise = jsNative

        /// Unwrap the reason of a rejected promise so any other 
        /// matcher can be chained. If the promise is fulfilled 
        /// the assertion fails.
        member _.rejects : expectedNumber<JS.Promise<unit>> = jsNative
        
        /// Unwrap the value of a fulfilled promise so any other 
        /// matcher can be chained. If the promise is rejected 
        /// the assertion fails.
        ///
        /// This is automatically applied for `Async<'T>` values.
        member _.resolves : expectedNumber<JS.Promise<unit>> = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type unexpectedString<'Return> =
        inherit expected<'Return>

        /// Check that a string matches a string or regular expression.
        ///
        /// When using a string it is the same as doing "mystring".Contains(value)
        member _.toMatch (value: string) : 'Return = jsNative
        /// Check that a string matches a string or regular expression.
        ///
        /// When using a string it is the same as doing "mystring".Contains(value)
        member _.toMatch (value: Regex) : 'Return = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expectedString<'Return> =
        inherit unexpectedString<'Return>
        /// Inverts the pass/fail status of a matcher.
        member _.not : expectedString<'Return> = jsNative

    [<NoComparison>]
    [<NoEquality>]
    [<Global("expect")>]
    type expectedStringPromise =
        /// Inverts the pass/fail status of a matcher.
        member _.not : expectedStringPromise = jsNative

        /// Unwrap the value of a fulfilled promise so any other 
        /// matcher can be chained. If the promise is rejected 
        /// the assertion fails.
        ///
        /// This is automatically applied for `Async<'T>` values.
        member _.rejects : expectedString<JS.Promise<unit>> = jsNative

        /// Unwrap the reason of a rejected promise so any other 
        /// matcher can be chained. If the promise is fulfilled 
        /// the assertion fails.
        member _.resolves : expectedString<JS.Promise<unit>> = jsNative
