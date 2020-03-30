module SnapshotTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let testElement = React.functionComponent(fun () ->
    let (count, setCount) = React.useState(0)

    Html.div [
        Html.h1 count
        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount(count + 1))
        ]
    ])

let testElement2 = React.functionComponent(fun () ->
    let (count, setCount) = React.useState(0)

    Html.div [
        Html.h1 count
        Html.button [
            prop.text "Decrement"
            prop.onClick (fun _ -> setCount(count - 1))
        ]
    ])

Jest.describe("snapshot tests", (fun () ->
    Jest.test("using snap file", (fun () ->
        let render = RTL.render(testElement())

        Jest.expect(render.container.firstChild).toMatchSnapshot()
    ))

    Jest.test("using snap file", (fun () ->
        let render = RTL.render(testElement2())

        Jest.expect(render.container.firstChild).toThrowErrorMatchingSnapshot()
    ))
))
