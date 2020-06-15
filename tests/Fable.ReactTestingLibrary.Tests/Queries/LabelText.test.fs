module LabelTextTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let labelTextElement = React.functionComponent (fun () ->
    Html.div [
        Html.label [
            prop.htmlFor "username-input"
            prop.text "Username"
        ]
        Html.input [
            prop.id "username-input"
        ]
    ])
    
let otherLabelTextElement = React.functionComponent (fun () ->
    Html.div [
        Html.label [
            prop.htmlFor "somethingElse-input"
            prop.text "somethingElse"
        ]
        Html.input [
            prop.id "somethingElse-input"
        ]
    ])

Jest.describe("*ByLabelText query tests", fun () ->
    Jest.test("getByLabelText an element", fun () ->
        let actual = RTL.render(labelTextElement()).getByLabelText("Username")
            
        Jest.expect(actual).toBeInTheDocument()
    )
    Jest.test("getByLabelText throws when no element matches", fun () ->
        let actual () = RTL.render(otherLabelTextElement()).getByLabelText("Username")
            
        Jest.expect(actual).toThrow()
    )

    Jest.test("getAllByLabelText an element", fun () ->
        let actual = RTL.render(labelTextElement()).getAllByLabelText("Username")
        
        Jest.expect(actual).toHaveLength(1)
    )
    Jest.test("getAllByLabelText throws when no element matches", fun () ->
        let actual () = RTL.render(otherLabelTextElement()).getAllByLabelText("Username")
            
        Jest.expect(actual).toThrow()
    )

    Jest.test("queryByLabelText an element", fun () ->
        let actual = RTL.render(labelTextElement()).queryByLabelText("Username")
        
        Jest.expect(actual).toBeInTheDocument()
    )
    Jest.test("queryByLabelText no element matches", fun () ->
        let actual = RTL.render(otherLabelTextElement()).queryByLabelText("Username")
            
        Jest.expect(actual).toBeNull()
    )

    Jest.test("queryAllByLabelText an element", fun () ->
        let actual = RTL.render(labelTextElement()).queryAllByLabelText("Username")
        
        Jest.expect(actual).toHaveLength(1)
    )
    Jest.test("queryAllByLabelText no element matches", fun () ->
        let actual = RTL.render(otherLabelTextElement()).queryAllByLabelText("Username")
            
        Jest.expect(actual).toHaveLength(0)
    )

    Jest.test("findByLabelText an element", promise {
        let actual = RTL.render(labelTextElement()).findByLabelText("Username")
            
        do! Jest.expect(actual).resolves.toBeInTheDocument()
    })
    Jest.test("findByLabelText throws when no element matches", promise {
        let actual = RTL.render(otherLabelTextElement()).findByLabelText("Username")
        
        do! Jest.expect(actual).rejects.toThrow()
    })

    Jest.test("findAllByLabelText an element", promise {
        let actual = RTL.render(labelTextElement()).findAllByLabelText("Username")
            
        do! Jest.expect(actual).resolves.toHaveLength(1)
    })
    Jest.test("findAllByLabelText no element matches", promise {
        let actual = RTL.render(otherLabelTextElement()).findAllByLabelText("Username")
            
        do! Jest.expect(actual).rejects.toThrow()
    })
)
