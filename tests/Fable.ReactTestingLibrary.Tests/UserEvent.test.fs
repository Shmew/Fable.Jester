module UserEventTests

open Browser.Blob
open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let inputTestElement = React.functionComponent(fun () ->
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

let buttonTestElement = React.functionComponent(fun () ->
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

let uploadTestElement = React.functionComponent(fun (input: {| isMultiple: bool |}) ->
    Html.input [
        prop.type'.file
        prop.testId "upload"
        prop.multiple input.isMultiple
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
    
    Jest.test("can upload a file", fun () ->
        let elem : HTMLInputElement = RTL.render(uploadTestElement {| isMultiple = false |}).getByTestId("upload") |> unbox

        let myFile = 
            let propBag = 
                JsInterop.jsOptions<BlobPropertyBag>(fun o -> o.``type`` <- "image/png")
             
            let file = Blob.Create([| "hello" :> obj |], propBag) :?> File
                
            file?name <- "hello.png"
            
            file

        elem.userEvent.upload(myFile)
        
        Jest.expect(elem.files.[0]).toStrictEqual(myFile)
        Jest.expect(elem.files.item(0)).toStrictEqual(myFile)
        Jest.expect(elem.files).toHaveLength(1)
    )
    Jest.test("can upload multiple files", fun () ->
        let elem : HTMLInputElement = RTL.render(uploadTestElement {| isMultiple = true |}).getByTestId("upload") |> unbox

        let myFiles = 
            let propBag = 
                JsInterop.jsOptions<BlobPropertyBag>(fun o -> o.``type`` <- "image/png")
             
            let file = 
                Blob.Create([| "hello" :> obj |], propBag) :?> File
                |> fun file -> 
                    file?name <- "hello.png"
                    file

            let file2 =
                Blob.Create([| "there" :> obj |], propBag) :?> File
                |> fun file -> 
                    file?name <- "there.png"
                    file
            
            [ file; file2 ]

        elem.userEvent.upload(myFiles)
        
        Jest.expect(elem.files.[0]).toStrictEqual(myFiles.[0])
        Jest.expect(elem.files.[1]).toStrictEqual(myFiles.[1])
        Jest.expect(elem.files).toHaveLength(2)
    )
)
