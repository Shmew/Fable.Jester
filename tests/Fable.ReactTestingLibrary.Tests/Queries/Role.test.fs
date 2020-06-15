module RoleTests

open Fable.Jester
open Fable.ReactTestingLibrary
open Feliz

let roleElement = React.functionComponent (fun () ->
    Html.div [
        prop.role.dialog
        prop.text "Username"
    ])
    
let otherRoleElement = React.functionComponent (fun () ->
    Html.div [
        prop.role.alert
        prop.text "somethingElse"
    ])

Jest.describe("*ByRole query tests", fun () ->
    Jest.test("getByRole an element", fun () ->
        let actual = RTL.render(roleElement()).getByRole(prop.role.dialog)
            
        Jest.expect(actual).toBeInTheDocument()
    )
    Jest.test("getByRole throws when no element matches", fun () ->
        let actual () = RTL.render(otherRoleElement()).getByRole(prop.role.dialog)
            
        Jest.expect(actual).toThrow()
    )

    Jest.test("getAllByRole an element", fun () ->
        let actual = RTL.render(roleElement()).getAllByRole(prop.role.dialog)
        
        Jest.expect(actual).toHaveLength(1)
    )
    Jest.test("getAllByRole throws when no element matches", fun () ->
        let actual () = RTL.render(otherRoleElement()).getAllByRole(prop.role.dialog)
            
        Jest.expect(actual).toThrow()
    )

    Jest.test("queryByRole an element", fun () ->
        let actual = RTL.render(roleElement()).queryByRole(prop.role.dialog)
        
        Jest.expect(actual).toBeInTheDocument()
    )
    Jest.test("queryByRole no element matches", fun () ->
        let actual = RTL.render(otherRoleElement()).queryByRole(prop.role.dialog)
            
        Jest.expect(actual).toBeNull()
    )

    Jest.test("queryAllByRole an element", fun () ->
        let actual = RTL.render(roleElement()).queryAllByRole(prop.role.dialog)
        
        Jest.expect(actual).toHaveLength(1)
    )
    Jest.test("queryAllByRole no element matches", fun () ->
        let actual = RTL.render(otherRoleElement()).queryAllByRole(prop.role.dialog)
            
        Jest.expect(actual).toHaveLength(0)
    )

    Jest.test("findByRole an element", promise {
        let actual = RTL.render(roleElement()).findByRole(prop.role.dialog)
            
        do! Jest.expect(actual).resolves.toBeInTheDocument()
    })
    Jest.test("findByRole throws when no element matches", promise {
        let actual = RTL.render(otherRoleElement()).findByRole(prop.role.dialog)
        
        do! Jest.expect(actual).rejects.toThrow()
    })

    Jest.test("findAllByRole an element", promise {
        let actual = RTL.render(roleElement()).findAllByRole(prop.role.dialog)
            
        do! Jest.expect(actual).resolves.toHaveLength(1)
    })
    Jest.test("findAllByRole no element matches", promise {
        let actual = RTL.render(otherRoleElement()).findAllByRole(prop.role.dialog)
            
        do! Jest.expect(actual).rejects.toThrow()
    })
)
