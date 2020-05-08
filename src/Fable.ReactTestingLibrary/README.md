# Fable.ReactTestingLibrary [![Nuget](https://img.shields.io/nuget/v/Fable.ReactTestingLibrary.svg?maxAge=0&colorB=brightgreen&label=Fable.ReactTestingLibrary)](https://www.nuget.org/packages/Fable.ReactTestingLibrary)

Fable bindings for [react-testing-library](https://github.com/testing-library/react-testing-library) and [user-event](https://github.com/testing-library/user-event).

A quick look:

```fsharp
open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let inputTestElement = React.functionComponent (fun () ->
    let value, setValue = React.useState "Hello"
    Html.div [
        Html.input [
            prop.type'.text
            prop.testId "test-input"
            prop.onChange setValue
        ]
        Html.h1 [
            prop.text value
            prop.testId "header"
        ]
    ])

Jest.describe("UserEvent tests", fun () ->
    Jest.test("dispatch input change", promise {
        let elem = RTL.render(inputTestElement()).getByTestId("test-input")

        do! elem.userEvent.type'("Hello world")

        return Jest.expect(RTL.screen.getByTestId("header")).toHaveTextContent("Hello world")
    })
    Jest.test("dispatch input change", promise {
        let elem = RTL.render(inputTestElement()).getByTestId("test-input")
        
        do! elem.userEvent.type'("Hello world")

        return Jest.expect(RTL.screen.getByTestId("header")).not.toHaveTextContent("somethingElse")
    })
)
```

Full documentation can be found [here](https://shmew.github.io/Fable.Jester).
