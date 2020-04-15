module FireEventTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let testElement = React.functionComponent (fun () ->
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

let counter = React.functionComponent(fun () ->
    let (count, setCount) = React.useState(0)
    React.fragment [
        Html.h1 [
            prop.testId "header"
            prop.text count
        ]

        Html.button [
            prop.testId "button-increment"
            prop.onClick (fun _ -> setCount(count + 1))
            prop.text "Increment"
        ]
    ])

Jest.describe("FireEvent tests", (fun () ->

    Jest.test("RTL.fireEvent.click without event properties works", (fun () -> 
        let elem = RTL.render(counter())
        let header = elem.getByTestId "header"
        let button = elem.getByTestId "button-increment"
        Jest.expect(header).toHaveTextContent("0")
        RTL.fireEvent.click(button)
        Jest.expect(header).toHaveTextContent("1")
    ))

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
