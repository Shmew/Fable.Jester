module TextTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let textElement = React.functionComponent (fun () ->
    Html.div [
        prop.text "Username"
    ])
    
let otherTextElement = React.functionComponent (fun () ->
    Html.div [
        prop.text "somethingElse"
    ])

Jest.describe("*ByText query tests", fun () ->
    Jest.test("getByText an element", fun () ->
        let actual = RTL.render(textElement()).getByText("Username")
            
        Jest.expect(actual).toBeInTheDocument()
    )
    Jest.test("getByText throws when no element matches", fun () ->
        let actual () = RTL.render(otherTextElement()).getByText("Username")
            
        Jest.expect(actual).toThrow()
    )

    Jest.test("getAllByText an element", fun () ->
        let actual = RTL.render(textElement()).getAllByText("Username")
        
        Jest.expect(actual).toHaveLength(1)
    )
    Jest.test("getAllByText throws when no element matches", fun () ->
        let actual () = RTL.render(otherTextElement()).getAllByText("Username")
            
        Jest.expect(actual).toThrow()
    )

    Jest.test("queryByText an element", fun () ->
        let actual = RTL.render(textElement()).queryByText("Username")
        
        Jest.expect(actual).toBeInTheDocument()
    )
    Jest.test("queryByText no element matches", fun () ->
        let actual = RTL.render(otherTextElement()).queryByText("Username")
            
        Jest.expect(actual).toBeNull()
    )

    Jest.test("queryAllByText an element", fun () ->
        let actual = RTL.render(textElement()).queryAllByText("Username")
        
        Jest.expect(actual).toHaveLength(1)
    )
    Jest.test("queryAllByText no element matches", fun () ->
        let actual = RTL.render(otherTextElement()).queryAllByText("Username")
            
        Jest.expect(actual).toHaveLength(0)
    )

    Jest.test("findByText an element", promise {
        let actual = RTL.render(textElement()).findByText("Username")
            
        do! Jest.expect(actual).resolves.toBeInTheDocument()
    })
    Jest.test("findByText throws when no element matches", promise {
        let actual = RTL.render(otherTextElement()).findByText("Username")
        
        do! Jest.expect(actual).rejects.toThrow()
    })

    Jest.test("findAllByText an element", promise {
        let actual = RTL.render(textElement()).findAllByText("Username")
            
        do! Jest.expect(actual).resolves.toHaveLength(1)
    })
    Jest.test("findAllByText no element matches", promise {
        let actual = RTL.render(otherTextElement()).findAllByText("Username")
            
        do! Jest.expect(actual).rejects.toThrow()
    })
)
