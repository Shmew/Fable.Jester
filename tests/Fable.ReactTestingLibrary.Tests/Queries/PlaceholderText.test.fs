module PlaceholderTextTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let placeholderTextElement = React.functionComponent (fun () ->
    Html.div [
        Html.input [
            prop.placeholder "Username"
        ]
    ])
    
let otherPlaceholderTextElement = React.functionComponent (fun () ->
    Html.div [
        Html.input [
            prop.placeholder "someOtherName"
        ]
    ])

Jest.describe("*ByPlaceholderText query tests", fun () ->
    Jest.test("getByPlaceholderText an element", fun () ->
        let actual = RTL.render(placeholderTextElement()).getByPlaceholderText("Username")
            
        Jest.expect(actual).toBeInTheDocument()
    )
    Jest.test("getByPlaceholderText throws when no element matches", fun () ->
        let actual () = RTL.render(otherPlaceholderTextElement()).getByPlaceholderText("Username")
            
        Jest.expect(actual).toThrow()
    )

    Jest.test("getAllByPlaceholderText an element", fun () ->
        let actual = RTL.render(placeholderTextElement()).getAllByPlaceholderText("Username")
        
        Jest.expect(actual).toHaveLength(1)
    )
    Jest.test("getAllByPlaceholderText throws when no element matches", fun () ->
        let actual () = RTL.render(otherPlaceholderTextElement()).getAllByPlaceholderText("Username")
            
        Jest.expect(actual).toThrow()
    )

    Jest.test("queryByPlaceholderText an element", fun () ->
        let actual = RTL.render(placeholderTextElement()).queryByPlaceholderText("Username")
        
        Jest.expect(actual).toBeInTheDocument()
    )
    Jest.test("queryByPlaceholderText no element matches", fun () ->
        let actual = RTL.render(otherPlaceholderTextElement()).queryByPlaceholderText("Username")
            
        Jest.expect(actual).toBeNull()
    )

    Jest.test("queryAllByPlaceholderText an element", fun () ->
        let actual = RTL.render(placeholderTextElement()).queryAllByPlaceholderText("Username")
        
        Jest.expect(actual).toHaveLength(1)
    )
    Jest.test("queryAllByPlaceholderText no element matches", fun () ->
        let actual = RTL.render(otherPlaceholderTextElement()).queryAllByPlaceholderText("Username")
            
        Jest.expect(actual).toHaveLength(0)
    )

    Jest.test("findByPlaceholderText an element", promise {
        let actual = RTL.render(placeholderTextElement()).findByPlaceholderText("Username")
            
        do! Jest.expect(actual).resolves.toBeInTheDocument()
    })
    Jest.test("findByPlaceholderText throws when no element matches", promise {
        let actual = RTL.render(otherPlaceholderTextElement()).findByPlaceholderText("Username")
        
        do! Jest.expect(actual).rejects.toThrow()
    })

    Jest.test("findAllByPlaceholderText an element", promise {
        let actual = RTL.render(placeholderTextElement()).findAllByPlaceholderText("Username")
            
        do! Jest.expect(actual).resolves.toHaveLength(1)
    })
    Jest.test("findAllByPlaceholderText no element matches", promise {
        let actual = RTL.render(otherPlaceholderTextElement()).findAllByPlaceholderText("Username")
            
        do! Jest.expect(actual).rejects.toThrow()
    })
)
