module WaitTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let waitElement = React.functionComponent (fun () ->
    let value, setValue = React.useState false
    Html.div [
        Html.button [
            prop.testId "wait-button"
            prop.onClick (fun _ -> setValue true)
        ]
        if value then
            Html.div [
                prop.testId "wait-true"
            ]
            Html.div [
                prop.testId "wait-true2"
            ]
        else
            Html.div [
                prop.testId "wait-false"
            ]
            Html.div [
                prop.testId "wait-false2"
            ]
    ])

Jest.describe("Wait tests", fun () ->
    Jest.test("waitFor correctly waits for condition to satisfy", async {
        let render = RTL.render(waitElement())
        
        Jest.expect(render.queryByTestId("wait-false").IsSome).toBe(true)
        Jest.expect(render.queryByTestId("wait-false2").IsSome).toBe(true)
        Jest.expect(render.queryByTestId("wait-true").IsNone).toBe(true)
        Jest.expect(render.queryByTestId("wait-true2").IsNone).toBe(true)

        render.getByTestId("wait-button").click()

        do! RTL.waitFor(fun () -> Jest.expect(render.queryByTestId("wait-false")).not.toBeInTheDocument())

        Jest.expect(render.queryByTestId("wait-false").IsNone).toBe(true)
        Jest.expect(render.queryByTestId("wait-false2").IsNone).toBe(true)
        Jest.expect(render.queryByTestId("wait-true").IsSome).toBe(true)
        Jest.expect(render.queryByTestId("wait-true2").IsSome).toBe(true)
    })

    Jest.test("waitForElementToBeRemoved correctly waits for element callback to be removed", async {
        let render = RTL.render(waitElement())
        
        let clickButton () =
            async {
                do! Async.Sleep 1000
                do render.getByTestId("wait-button").click()
            }

        Jest.expect(render.queryByTestId("wait-false").IsSome).toBe(true)
        Jest.expect(render.queryByTestId("wait-false2").IsSome).toBe(true)
        Jest.expect(render.queryByTestId("wait-true").IsNone).toBe(true)
        Jest.expect(render.queryByTestId("wait-true2").IsNone).toBe(true)

        do clickButton() |> Async.StartImmediate
        do! RTL.waitForElementToBeRemoved(fun () -> render.queryByTestId("wait-false"))

        Jest.expect(render.queryByTestId("wait-false").IsNone).toBe(true)
        Jest.expect(render.queryByTestId("wait-false2").IsNone).toBe(true)
        Jest.expect(render.queryByTestId("wait-true").IsSome).toBe(true)
        Jest.expect(render.queryByTestId("wait-true2").IsSome).toBe(true)
    })

    Jest.test("waitForElementToBeRemoved correctly waits for element list callback to be removed", async {
        let render = RTL.render(waitElement())
        
        let clickButton () =
            async {
                do! Async.Sleep 1000
                do render.getByTestId("wait-button").click()
            }

        Jest.expect(render.queryByTestId("wait-false").IsSome).toBe(true)
        Jest.expect(render.queryByTestId("wait-false2").IsSome).toBe(true)
        Jest.expect(render.queryByTestId("wait-true").IsNone).toBe(true)
        Jest.expect(render.queryByTestId("wait-true2").IsNone).toBe(true)

        do clickButton() |> Async.StartImmediate
        do! RTL.waitForElementToBeRemoved(fun () -> render.queryAllByTestId("wait-false"))

        Jest.expect(render.queryByTestId("wait-false").IsNone).toBe(true)
        Jest.expect(render.queryByTestId("wait-false2").IsNone).toBe(true)
        Jest.expect(render.queryByTestId("wait-true").IsSome).toBe(true)
        Jest.expect(render.queryByTestId("wait-true2").IsSome).toBe(true)
    })
)
