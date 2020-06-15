module DisplayValueTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let displayValueElement = React.functionComponent (fun () ->
    Html.div [
        Html.input [
            prop.value "Username"
            prop.onChange (fun (input: string) -> ())
        ]
    ])
    
let otherDisplayValueElement = React.functionComponent (fun () ->
    Html.div [
        Html.input [
            prop.value "somethingElse"
            prop.onChange (fun (input: string) -> ())
        ]
    ])

Jest.describe("*ByDisplayValue query tests", fun () ->
    Jest.test("getByDisplayValue an element", fun () ->
        let actual = RTL.render(displayValueElement()).getByDisplayValue("Username")
            
        Jest.expect(actual).toBeInTheDocument()
    )
    Jest.test("getByDisplayValue throws when no element matches", fun () ->
        let actual () = RTL.render(otherDisplayValueElement()).getByDisplayValue("Username")
            
        Jest.expect(actual).toThrow()
    )

    Jest.test("getAllByDisplayValue an element", fun () ->
        let actual = RTL.render(displayValueElement()).getAllByDisplayValue("Username")
        
        Jest.expect(actual).toHaveLength(1)
    )
    Jest.test("getAllByDisplayValue throws when no element matches", fun () ->
        let actual () = RTL.render(otherDisplayValueElement()).getAllByDisplayValue("Username")
            
        Jest.expect(actual).toThrow()
    )

    Jest.test("queryByDisplayValue an element", fun () ->
        let actual = RTL.render(displayValueElement()).queryByDisplayValue("Username")
        
        Jest.expect(actual).toBeInTheDocument()
    )
    Jest.test("queryByDisplayValue no element matches", fun () ->
        let actual = RTL.render(otherDisplayValueElement()).queryByDisplayValue("Username")
            
        Jest.expect(actual).toBeNull()
    )

    Jest.test("queryAllByDisplayValue an element", fun () ->
        let actual = RTL.render(displayValueElement()).queryAllByDisplayValue("Username")
        
        Jest.expect(actual).toHaveLength(1)
    )
    Jest.test("queryAllByDisplayValue no element matches", fun () ->
        let actual = RTL.render(otherDisplayValueElement()).queryAllByDisplayValue("Username")
            
        Jest.expect(actual).toHaveLength(0)
    )

    Jest.test("findByDisplayValue an element", promise {
        let actual = RTL.render(displayValueElement()).findByDisplayValue("Username")
            
        do! Jest.expect(actual).resolves.toBeInTheDocument()
    })
    Jest.test("findByDisplayValue throws when no element matches", promise {
        let actual = RTL.render(otherDisplayValueElement()).findByDisplayValue("Username")
        
        do! Jest.expect(actual).rejects.toThrow()
    })

    Jest.test("findAllByDisplayValue an element", promise {
        let actual = RTL.render(displayValueElement()).findAllByDisplayValue("Username")
            
        do! Jest.expect(actual).resolves.toHaveLength(1)
    })
    Jest.test("findAllByDisplayValue no element matches", promise {
        let actual = RTL.render(otherDisplayValueElement()).findAllByDisplayValue("Username")
            
        do! Jest.expect(actual).rejects.toThrow()
    })
)
