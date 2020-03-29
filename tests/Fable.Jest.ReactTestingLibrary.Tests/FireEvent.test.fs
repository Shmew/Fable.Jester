module FireEventTests

open Fable.Jest
open Fable.Jest.ReactTestingLibrary
open Fable.Core.JsInterop
open Feliz
open System

let testElement = React.functionComponent (fun () ->
    let value, setValue = React.useState 1

    Html.div [
        Html.label [
            prop.htmlFor "int-input"
            prop.text "Int Test"
        ]
        Html.input [
            prop.id "int-input"
            prop.type'.text
            prop.valueOrDefault value
            prop.onInput (fun ev ->
                ev.preventDefault()
                printfn "%s" (ev.target?value)
                setValue (value + (unbox<int> ev.target?value))
            )
            prop.onChange (fun (s: string) ->
                printfn "%s" s
                setValue (int s))
        ]
    ])

Jest.describe("FireEvent tests", (fun () ->
    Jest.test("dispatch input change", (fun () ->
        let render = RTL.render(testElement())
        let elem = render.getByLabelText("Int Test")

        RTL.fireEvent.change(elem, [
            event.target [ prop.value 1 ]
        ])

        elem.fireEvent.change([ inputEvent.target [ prop.value 1 ] ])

        elem.fireEvent.input([ inputEvent.target [ prop.value 1 ] ])

        Jest.expect(render.getByLabelText("Int Test")).toHaveValue(3)
    ))
))
