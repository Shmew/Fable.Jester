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


Jest.describe("snapshot tests", (fun () ->
    Jest.test("using snap file", (fun () ->
        let render = RTL.render(testElement())

        Jest.expect(render.container.firstChild).toMatchSnapshot()
    ))
))
