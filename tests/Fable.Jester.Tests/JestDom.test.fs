module JestDomTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz
open System.Text.RegularExpressions

let testElement = React.functionComponent(fun (input: {| isDisabled: bool; hasContent: bool; isInvalid: bool |}) ->
    let (count, setCount) = React.useState(0)

    Html.div [
        prop.className "myDiv"
        prop.style [ style.backgroundColor (color.red) ]
        prop.testId "div"
        if input.hasContent then
            prop.children [
                Html.h1 [
                    prop.testId "header"
                    prop.text count
                ]
                Html.div [
                    prop.id "description-button"
                    prop.text "Button description"
                ]
                Html.button [
                    if input.isDisabled then prop.disabled true
                    prop.testId "button"
                    prop.ariaDescribedBy "description-button"
                    prop.text "Increment"
                    prop.onClick (fun _ -> setCount(count + 1))
                    prop.onChange (fun (s: string) -> ())
                ]
                Html.input [
                    prop.testId "input"
                    prop.required true
                    prop.type'.text
                    prop.value "Howdy!"
                    prop.autoFocus true
                    prop.onChange (fun (s: string) -> ())
                ]
                Html.input [
                    prop.style [
                        style.visibility.hidden
                    ]
                    prop.testId "input-2"
                    prop.type'.text
                ]
                Html.input [
                    prop.testId "input-3"
                    prop.type'.checkbox
                    prop.ariaChecked.mixed
                ]
                Html.input [
                    prop.testId "input-4"
                    prop.type'.checkbox
                    prop.ariaChecked true
                ]
                Html.input [
                    prop.testId "input-5"
                    prop.type'.checkbox
                    prop.ariaChecked false
                ]
                Html.input [
                    prop.testId "checkbox"
                    prop.type'.checkbox
                    prop.isChecked true
                    prop.readOnly true
                ]
                Html.form [
                    prop.testId "form"
                    prop.children [
                        Html.input [
                            if input.isInvalid then prop.ariaInvalid true
                            prop.testId "username"
                            prop.type'.text
                            prop.name "username"
                            prop.value "Shmew"
                            prop.readOnly true
                        ]
                        Html.input [
                            prop.testId "password"
                            prop.type'.password
                            prop.name "password"
                            prop.value "hunter2"
                            prop.readOnly true
                        ]
                        Html.input [
                            prop.type'.checkbox
                            prop.name "remember me"
                            prop.isChecked true
                            prop.readOnly true
                        ]
                        Html.button [
                            prop.type'.submit
                            prop.text "sign in"
                        ]
                    ]
                ]
            ]
    ])

let testElemDefaults = {| isDisabled = false; hasContent = true; isInvalid = false |}

Jest.describe("jest-dom tests", (fun () ->
    Jest.test("toBeChecked", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("checkbox")).toBeChecked()
    ))
    Jest.test("not toBeChecked", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("button")).not.toBeChecked()
    ))

    Jest.test("toBeDisabled", (fun () ->
        let render = RTL.render(testElement({| testElemDefaults with isDisabled = true |}))

        Jest.expect(render.getByTestId("button")).toBeDisabled()
    ))

    Jest.test("toBeEmpty", (fun () ->
        let render = RTL.render(testElement({| testElemDefaults with hasContent = false |}))

        Jest.expect(render.getByTestId("div")).toBeEmpty()
    ))
    Jest.test("not toBeEmpty", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("div")).not.toBeEmpty()
    ))

    Jest.test("toBeEnabled", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("div")).toBeEnabled()
    ))

    Jest.test("toBeInTheDocument", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("div")).toBeInTheDocument()
    ))
    Jest.test("not toBeInTheDocument", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        let myElem = render.getByTestId("div")

        render.unmount()

        Jest.expect(myElem).not.toBeInTheDocument()
    ))

    Jest.test("toBeInvalid", (fun () ->
        let render = RTL.render(testElement({| testElemDefaults with isInvalid = true |}))

        Jest.expect(render.getByTestId("username")).toBeInvalid()
    ))

    Jest.test("toBePartiallyChecked", fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("input-3")).toBePartiallyChecked()
    )
    Jest.test("not toBePartiallyChecked", fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("input-4")).not.toBePartiallyChecked()
        Jest.expect(render.getByTestId("input-5")).not.toBePartiallyChecked()
    )

    Jest.test("toBeRequired", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("input")).toBeRequired()
    ))
    Jest.test("not toBeRequired", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("input-2")).not.toBeRequired()
    ))

    Jest.test("toBeValid", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("username")).toBeValid()
    ))

    Jest.test("toBeVisible", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("div")).toBeVisible()
    ))
    Jest.test("not toBeVisible", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("input-2")).not.toBeVisible()
    ))

    Jest.test("toContainElement", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.container).toContainElement(render.getByTestId("button"))
    ))
    Jest.test("not toContainElement", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        let myElem = render.getByTestId("div")

        render.unmount()

        Jest.expect(Browser.Dom.document.body).not.toContainElement(myElem)
    ))

    Jest.test("toContainHTML", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.container).toContainHTML("<h1 data-testid=\"header\">0</h1>")
    ))
    Jest.test("not toContainHTML", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.container).not.toContainHTML("<h1>1</h1>")
    ))

    Jest.test("toHaveAttribute", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("div")).toHaveAttribute("style")
    ))
    Jest.test("not toHaveAttribute", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("div")).not.toHaveAttribute("src")
    ))

    Jest.test("toHaveClass", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("div")).toHaveClass("myDiv")
    ))
    Jest.test("not toHaveClass", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("div")).not.toHaveClass("yourDiv")
    ))

    Jest.test("toHaveDescription", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("button")).toHaveDescription("Button description")
    ))
    Jest.test("not toHaveDescription", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("button")).not.toHaveDescription("somethingElse")
    ))

    Jest.test("toHaveDisplayValue", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("username")).toHaveDisplayValue("Shmew")
        Jest.expect(render.getByTestId("username")).toHaveDisplayValue(Regex("Shme.*?"))
    ))
    Jest.test("not toHaveDisplayValue", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("username")).not.toHaveDisplayValue("somethingElse")
        Jest.expect(render.getByTestId("username")).not.toHaveDisplayValue(Regex("somethi.*?"))
    ))

    Jest.test("toHaveFocus", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("input")).toHaveFocus()
    ))
    Jest.test("not toHaveClass", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("div")).not.toHaveFocus()
    ))

    Jest.test("toHaveFormValues", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        let formValues = [
            "username", box "Shmew"
            "remember me", box true
        ]

        Jest.expect(render.getByTestId("form")).toHaveFormValues(formValues)
    ))
    Jest.test("not toHaveFormValues", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        let formValues = 
            {| yourName = "notMe" |}
            |> Fable.Core.JsInterop.toPlainJsObj

        Jest.expect(render.getByTestId("form")).not.toHaveFormValues(formValues)
    ))

    Jest.test("toHaveStyle", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        let divStyle = style.backgroundColor (color.red)

        Jest.expect(render.getByTestId("div")).toHaveStyle(divStyle)
    ))
    Jest.test("not toHaveStyle", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        let divStyle = style.marginLeft (length.em 1)

        Jest.expect(render.getByTestId("form")).not.toHaveStyle(divStyle)
    ))

    Jest.test("toHaveTextContent", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("header")).toHaveTextContent("0")
    ))
    Jest.test("not toHaveTextContent", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("checkbox")).not.toHaveTextContent(Regex("\\w+?"))
    ))

    Jest.test("toHaveValue", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("password")).toHaveValue("hunter2")
    ))
    Jest.test("not toHaveValue", (fun () ->
        let render = RTL.render(testElement(testElemDefaults))

        Jest.expect(render.getByTestId("password")).not.toHaveValue("Bonjour!")
    ))
))
