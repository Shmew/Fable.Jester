module AltTextTests

open Fable.Jest
open Fable.Jest.ReactTestingLibrary
open Feliz

let altTextElement = React.functionComponent (fun () ->
    Html.div [
        Html.img [
            prop.src "something.png"
            prop.alt "Username"
        ]
    ])
    
let otherAltTextElement = React.functionComponent (fun () ->
    Html.div [
        prop.src "somethingElse.png"
        prop.alt "somethingElse"
    ])

Jest.describe("*ByAltText query tests", (fun () ->
    Jest.test("getByAltText an element", (fun () ->
        let actual = RTL.render(altTextElement()).getByAltText("Username")
            
        Jest.expect(actual).toBeInTheDocument()
    ))
    Jest.test("getByAltText throws when no element matches", (fun () ->
        let actual () = RTL.render(otherAltTextElement()).getByAltText("Username")
            
        Jest.expect(actual).toThrow()
    ))

    Jest.test("getAllByAltText an element", (fun () ->
        let actual = RTL.render(altTextElement()).getAllByAltText("Username")
        
        Jest.expect(actual).toHaveLength(1)
    ))
    Jest.test("getAllByAltText throws when no element matches", (fun () ->
        let actual () = RTL.render(otherAltTextElement()).getAllByAltText("Username")
            
        Jest.expect(actual).toThrow()
    ))

    Jest.test("queryByAltText an element", (fun () ->
        let actual = RTL.render(altTextElement()).queryByAltText("Username")
        
        Jest.expect(actual).toBeInTheDocument()
    ))
    Jest.test("queryByAltText no element matches", (fun () ->
        let actual = RTL.render(otherAltTextElement()).queryByAltText("Username")
            
        Jest.expect(actual).toBeNull()
    ))

    Jest.test("queryAllByAltText an element", (fun () ->
        let actual = RTL.render(altTextElement()).queryAllByAltText("Username")
        
        Jest.expect(actual).toHaveLength(1)
    ))
    Jest.test("queryAllByAltText no element matches", (fun () ->
        let actual = RTL.render(otherAltTextElement()).queryAllByAltText("Username")
            
        Jest.expect(actual).toHaveLength(0)
    ))

    Jest.test("findByAltText an element", (fun () ->
        let actual = RTL.render(altTextElement()).findByAltText("Username")
            
        Jest.expect(actual).resolves.toBeInTheDocument()
    ))
    Jest.test("findByAltText throws when no element matches", (fun () ->
        let actual = RTL.render(otherAltTextElement()).findByAltText("Username")
        
        Jest.expect(actual).rejects.toThrow()
    ))

    Jest.test("findAllByAltText an element", (fun () ->
        let actual = RTL.render(altTextElement()).findAllByAltText("Username")
            
        Jest.expect(actual).resolves.toHaveLength(1)
    ))
    Jest.test("findAllByAltText no element matches", (fun () ->
        let actual = RTL.render(otherAltTextElement()).findAllByAltText("Username")
            
        Jest.expect(actual).rejects.toThrow()
    ))
))
