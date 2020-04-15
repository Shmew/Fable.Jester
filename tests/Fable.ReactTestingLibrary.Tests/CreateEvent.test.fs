module CreateEventTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz
open System

let testElement = React.functionComponent (fun (dateTime: DateTime) ->
    let value, setValue = React.useState dateTime
    Html.div [
        Html.input [
            prop.type'.text
            prop.testId "test-input"
            prop.onChange (DateTime.Parse >> setValue)
        ]
        Html.h1 [
            prop.text (value.ToString())
            prop.testId "header"
        ]
    ])

Jest.describe("FireEvent tests", (fun () ->
    Jest.test("dispatch input change", (fun () ->
        let elem = RTL.render(testElement(DateTime.Now)).getByTestId("test-input")

        let newTime = DateTime(1990, 01, 01).ToString()

        let myEvent =
            elem.createEvent.change([ 
                event.target [ 
                    prop.value newTime 
                ] 
            ])

        RTL.fireEvent(elem, myEvent)

        Jest.expect(RTL.screen.getByTestId("header")).toHaveTextContent(newTime)
    ))

    Jest.test("dispatch input change", (fun () ->
        let now = DateTime.Now
        let elem = RTL.render(testElement(now)).getByTestId("test-input")

        let newTime = DateTime(1990, 01, 01).ToString()

        let myEvent =
            elem.createEvent.change([ 
                event.target [ 
                    prop.value newTime 
                ] 
            ])

        RTL.fireEvent(elem, myEvent)

        Jest.expect(RTL.screen.getByTestId("header")).not.toHaveTextContent(now.ToString())
    ))
))
