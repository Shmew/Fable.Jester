module UserEventTests

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

let buttonTestElement = React.functionComponent (fun () ->
    let value, setValue = React.useState "Hello"
    Html.div [
        Html.button [
            prop.testId "test-button"
            prop.onClick (fun _ -> setValue "Howdy!")
            prop.onDoubleClick (fun _ -> setValue "Bonjour!")
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

    Jest.test("clear input element", promise {
        let elem = RTL.render(inputTestElement()).getByTestId("test-input")

        do! elem.userEvent.type'("Hello world")
        do Jest.expect(RTL.screen.getByTestId("header")).toHaveTextContent("Hello world")
        do elem.userEvent.clear()
        
        return! RTL.waitFor(fun () -> Jest.expect(RTL.screen.getByTestId("test-input")).toBeEmpty())
    })

    Jest.test("dispatch button click", fun () ->
        let elem = RTL.render(buttonTestElement()).getByTestId("test-button")

        elem.userEvent.click()

        Jest.expect(RTL.screen.getByTestId("header")).toHaveTextContent("Howdy!")
    )
    Jest.test("dispatch button click", fun () ->
        let elem = RTL.render(buttonTestElement()).getByTestId("test-button")
        
        elem.userEvent.click()

        Jest.expect(RTL.screen.getByTestId("header")).not.toHaveTextContent("somethingElse")
    )

    Jest.test("dispatch button double click", fun () ->
        let elem = RTL.render(buttonTestElement()).getByTestId("test-button")

        elem.userEvent.dblClick()

        Jest.expect(RTL.screen.getByTestId("header")).toHaveTextContent("Bonjour!")
    )
    Jest.test("dispatch button double click", fun () ->
        let elem = RTL.render(buttonTestElement()).getByTestId("test-button")
        
        elem.userEvent.dblClick()

        Jest.expect(RTL.screen.getByTestId("header")).not.toHaveTextContent("somethingElse")
    )
)
