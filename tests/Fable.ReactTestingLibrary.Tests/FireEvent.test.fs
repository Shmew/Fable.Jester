module FireEventTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let testElement = React.functionComponent (fun () ->
    let value, setValue = React.useState "Hello"
    Html.div [
        Html.input [
            prop.type'.text
            prop.custom("data-testid", "test-input")
            prop.onChange setValue
        ]
        Html.h1 [
            prop.text value
            prop.custom("data-testid", "header")
        ]
    ])

Jest.describe("FireEvent tests", (fun () ->
    Jest.test("dispatch input change", (fun () ->
        let elem = RTL.render(testElement()).getByTestId("test-input")

        RTL.fireEvent.change(elem, [ event.target [ prop.value "Hello world" ] ])

        Jest.expect(RTL.screen.getByTestId("header")).toHaveTextContent("Hello world")
    ))

    Jest.test("dispatch input change", (fun () ->
        let elem = RTL.render(testElement()).getByTestId("test-input")

        RTL.fireEvent.change(elem, [ event.target [ prop.value "Hello world" ] ])

        Jest.expect(RTL.screen.getByTestId("header")).not.toHaveTextContent("somethingElse")
    ))
))
