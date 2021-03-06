# queriesForElement

The `queriesForElement` type exposes many methods of querying
the DOM for elements to test/compare against.

There are six different categories of queries:
 * [getBy](#getby)
 * [getAll](#getall)
 * [queryBy](#queryby)
 * [queryAll](#queryall)
 * [findBy](#findby)
 * [findAll](#findall)

Each of the query types have different targets for the attribute 
you want to query for:
 * [AltText](#alttext)
 * [DisplayValue](#displayvalue)
 * [LabelText](#labeltext)
 * [PlaceholderText](#placeholdertext)
 * [Role](#role)
 * [Text](#text)
 * [TestId](#testid)
 * [Title](#title)

## Query Types

### getBy

The getBy query type returns the first matching node for a
query. 
 
This will throw an error if no elements match, or
if more than one match is found.

### getAll

The getAll query type returns a list of all matching nodes
of the query. 
 
This will throw an error if no elements match.

### queryBy

The queryBy query type returns the first matching node for a
query. 
 
This will return an `Option` for the element.

### queryAll

The queryAll query type returns a list of all matching nodes
of the query. 
 
This will return an empty list if there are no matches.

### findBy

The findBy query type returns the first matching node for a
query. 
 
This returns a `JS.Promise` for the element which will reject
if no matches are found after the default timeout of 4500ms.

### findAll

The findAll query type returns a list of all matching nodes
of the query. 
 
This returns a `JS.Promise` for the matches which will reject
if no matches are found after the default timeout of 4500ms.

## Query Options

There are a number of different options that you can set to customize
query behavior:

All queries support `exact`, `normalizer`, and `suggest`.

This means any query that takes a option type other than `IMatcherOption`
will still accept those options.

In addition, any query that accepts a `ITextMatcherOption` will also
accept `ILabelTextMatcherOption` properties.

```fsharp
type queryOption =
    /// If true, only includes elements in the query set that are marked as
    /// checked in the accessibility tree, i.e., `aria-checked="true"`
    member checked' (value: bool) : IRoleMatcherOption

    /// Requires an exact match.
    /// 
    /// Defaults to true.
    member exact (value: bool) : IMatcherOption
    
    /// If set to true, elements that are normally excluded from the
    /// accessibility tree are considered for the query as well.
    ///
    /// Defaults to false.
    member hidden (value: bool) : IRoleMatcherOption

    /// Disables selector exclusions.
    ///
    /// Defaults to true.
    member ignore (value: bool) : ITextMatcherOption
    /// Specify selectors to exclude from matches.
    ///
    /// Such as if you had two elements with the same testId, if one is an input,
    /// you could use queryOption.selector "input" to exclude that input element.
    ///
    /// Defaults to "script".
    member ignore (value: string) : ITextMatcherOption
    
    /// Adds a query condition based on a match of the level.
    ///
    /// Such as a h1-h6 element, or aria-level.
    member level (value: int) : IRoleMatcherOption

    /// Adds a query condition based on a match of the accessible name.
    ///
    /// Such as a label element, label attribute, or aria-label.
    member name (value: string) : IRoleMatcherOption
    member name (value: Regex) : IRoleMatcherOption
    member name (fn: #HTMLElement -> bool) : IRoleMatcherOption
    
    /// If true, only includes elements in the query set that are marked as
    /// pressed in the accessibility tree, i.e., `aria-pressed="true"`
    member pressed (value: bool) : IRoleMatcherOption

    /// Allows transforming the text before the match.
    member normalizer (fn: string -> string) : IMatcherOption
    
    /// Adds a query condition based on if the element is selected.
    ///
    /// Such as a selected attribute or aria-selected.
    member selected (value: bool) : IRoleMatcherOption
    
    /// Specify a selector to reduce matches.
    ///
    /// Such as if you had two elements with the same testId, if one is an input,
    /// you could use queryOption.selector "input" to get that input element.
    ///
    /// Defaults to "*".
    member selector (value: string) : ILabelTextMatcherOption
    
    /// Allows disabling query suggestions if the global setting is enabled.
    ///
    /// Defaults to true.
    member suggest (value: bool) : IMatcherOption
```

## Query Targets

All targets can accept a type restriction to cast to the
type of HTMLElement you're expecting.

For example:
```fsharp
RTL.screen.getByTestId<HTMLOptionElement>("val1")).selected
```

### AltText

Signature:
```fsharp
(matcher: string, ?options: ITextMatcherOption list)
(matcher: int, ?options: ITextMatcherOption list)
(matcher: float, ?options: ITextMatcherOption list)
(matcher: Regex, ?options: ITextMatcherOption list)
(matcher: string * HTMLElement -> bool, ?options: ITextMatcherOption list)
```

Usage:
```fsharp
RTL.screen.getByAltText("howdy!")
```

### DisplayValue

Signature:
```fsharp
(matcher: string, ?options: IMatcherOption list)
(matcher: int, ?options: IMatcherOption list)
(matcher: float, ?options: IMatcherOption list)
(matcher: Regex, ?options: IMatcherOption list)
(matcher: string * HTMLElement -> bool, ?options: IMatcherOption list)
```

Usage:
```fsharp
RTL.screen.getAllByDisplayValue("howdy!")
```

### LabelText

Signature:
```fsharp
(matcher: string, ?options: ILabelTextMatcherOption list)
(matcher: int, ?options: ILabelTextMatcherOption list)
(matcher: float, ?options: ILabelTextMatcherOption list)
(matcher: Regex, ?options: ILabelTextMatcherOption list)
(matcher: string * HTMLElement -> bool, ?options: ILabelTextMatcherOption list)
```

Usage:
```fsharp
RTL.screen.queryByLabelText("howdy!")
```

### PlaceholderText

Signature:
```fsharp
(matcher: string, ?options: IMatcherOption list)
(matcher: int, ?options: IMatcherOption list)
(matcher: float, ?options: IMatcherOption list)
(matcher: Regex, ?options: IMatcherOption list)
(matcher: string * HTMLElement -> bool, ?options: IMatcherOption list)
```

Usage:
```fsharp
RTL.screen.queryAllByPlaceholderText("howdy!")
```

### Role

Signature:
```fsharp
(matcher: string, ?options: IRoleMatcherOption list)
(matcher: int, ?options: IRoleMatcherOption list)
(matcher: float, ?options: IRoleMatcherOption list)
(matcher: Regex, ?options: IMatcherOption list)
(matcher: string * HTMLElement -> bool, ?options: IMatcherOption list)
```

Usage:
```fsharp
RTL.screen.findByRole("howdy!")
```

### Text

Signature:
```fsharp
(matcher: string, ?options: ITextMatcherOption list)
(matcher: int, ?options: ITextMatcherOption list)
(matcher: float, ?options: ITextMatcherOption list)
(matcher: Regex, ?options: ITextMatcherOption list)
(matcher: string * HTMLElement -> bool, ?options: ITextMatcherOption list)
```

Usage:
```fsharp
RTL.screen.findAllByText("howdy!")
```

### TestId

Signature:
```fsharp
(matcher: string, ?options: IMatcherOption list)
(matcher: int, ?options: IMatcherOption list)
(matcher: float, ?options: IMatcherOption list)
(matcher: Regex, ?options: IMatcherOption list)
(matcher: string * HTMLElement -> bool, ?options: IMatcherOption list)
```

Usage:
```fsharp
RTL.screen.getByTestId("howdy!")
```

### Title

Signature:
```fsharp
(matcher: string, ?options: IMatcherOption list)
(matcher: int, ?options: IMatcherOption list)
(matcher: float, ?options: IMatcherOption list)
(matcher: Regex, ?options: IMatcherOption list)
(matcher: string * HTMLElement -> bool, ?options: IMatcherOption list)
```

Usage:
```fsharp
RTL.screen.getAllByTitle("howdy!")
```

