module TitleTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let titleElement = React.functionComponent (fun () ->
    Html.div [
        Html.title [
            prop.title "Username"
        ]
    ])
    
let otherTitleElement = React.functionComponent (fun () ->
    Html.div [
        Html.title [
            prop.title "somethingElse"
        ]
    ])

Jest.describe("*ByTitle query tests", (fun () ->
    Jest.test("getByTitle an element", (fun () ->
        let actual = RTL.render(titleElement()).getByTitle("Username")
            
        Jest.expect(actual).toBeInTheDocument()
    ))
    Jest.test("getByTitle throws when no element matches", (fun () ->
        let actual () = RTL.render(otherTitleElement()).getByTitle("Username")
            
        Jest.expect(actual).toThrow()
    ))

    Jest.test("getAllByTitle an element", (fun () ->
        let actual = RTL.render(titleElement()).getAllByTitle("Username")
        
        Jest.expect(actual).toHaveLength(1)
    ))
    Jest.test("getAllByTitle throws when no element matches", (fun () ->
        let actual () = RTL.render(otherTitleElement()).getAllByTitle("Username")
            
        Jest.expect(actual).toThrow()
    ))

    Jest.test("queryByTitle an element", (fun () ->
        let actual = RTL.render(titleElement()).queryByTitle("Username")
        
        Jest.expect(actual).toBeInTheDocument()
    ))
    Jest.test("queryByTitle no element matches", (fun () ->
        let actual = RTL.render(otherTitleElement()).queryByTitle("Username")
            
        Jest.expect(actual).toBeNull()
    ))

    Jest.test("queryAllByTitle an element", (fun () ->
        let actual = RTL.render(titleElement()).queryAllByTitle("Username")
        
        Jest.expect(actual).toHaveLength(1)
    ))
    Jest.test("queryAllByTitle no element matches", (fun () ->
        let actual = RTL.render(otherTitleElement()).queryAllByTitle("Username")
            
        Jest.expect(actual).toHaveLength(0)
    ))

    Jest.test("findByTitle an element", (fun () ->
        let actual = RTL.render(titleElement()).findByTitle("Username")
            
        Jest.expect(actual).resolves.toBeInTheDocument()
    ))
    Jest.test("findByTitle throws when no element matches", (fun () ->
        let actual = RTL.render(otherTitleElement()).findByTitle("Username")
        
        Jest.expect(actual).rejects.toThrow()
    ))

    Jest.test("findAllByTitle an element", (fun () ->
        let actual = RTL.render(titleElement()).findAllByTitle("Username")
            
        Jest.expect(actual).resolves.toHaveLength(1)
    ))
    Jest.test("findAllByTitle no element matches", (fun () ->
        let actual = RTL.render(otherTitleElement()).findAllByTitle("Username")
            
        Jest.expect(actual).rejects.toThrow()
    ))
))
