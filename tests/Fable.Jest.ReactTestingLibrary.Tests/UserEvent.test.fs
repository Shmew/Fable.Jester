module UserEventTests

open Fable.Jest
open Fable.Jest.ReactTestingLibrary
open Feliz

let inputTestElement = React.functionComponent (fun () ->
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

let buttonTestElement = React.functionComponent (fun () ->
    let value, setValue = React.useState "Hello"
    Html.div [
        Html.button [
            prop.custom("data-testid", "test-button")
            prop.onClick (fun _ -> setValue "Howdy!")
            prop.onDoubleClick (fun _ -> setValue "Bonjour!")
        ]
        Html.h1 [
            prop.text value
            prop.custom("data-testid", "header")
        ]
    ])

Jest.describe("UserEvent tests", (fun () ->
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

    Jest.test("dispatch button click", (fun () ->
        let elem = RTL.render(buttonTestElement()).getByTestId("test-button")

        elem.userEvent.click()

        Jest.expect(RTL.screen.getByTestId("header")).toHaveTextContent("Howdy!")
    ))
    Jest.test("dispatch button click", (fun () ->
        let elem = RTL.render(buttonTestElement()).getByTestId("test-button")
        
        elem.userEvent.click()

        Jest.expect(RTL.screen.getByTestId("header")).not.toHaveTextContent("somethingElse")
    ))


    Jest.test("dispatch button double click", (fun () ->
        let elem = RTL.render(buttonTestElement()).getByTestId("test-button")

        elem.userEvent.dblClick()

        Jest.expect(RTL.screen.getByTestId("header")).toHaveTextContent("Bonjour!")
    ))
    Jest.test("dispatch button double click", (fun () ->
        let elem = RTL.render(buttonTestElement()).getByTestId("test-button")
        
        elem.userEvent.dblClick()

        Jest.expect(RTL.screen.getByTestId("header")).not.toHaveTextContent("somethingElse")
    ))
))
