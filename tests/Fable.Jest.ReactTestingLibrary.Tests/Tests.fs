module Tests

open Fable.Mocha
open Fable.Mocha.ReactTestingLibrary
open Feliz

let labelTextQueries =
    testList "*ByLabelText query tests" [
        testCase "getByLabelText returns the correct element" <| fun _ ->
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

            let actual = RTL.render(labelTextElement()).getByLabelText "Username"
                
            Expect.element(actual).toBeInTheDocument()
    ]

let queryTests =
    testList "RTL query tests" [
        labelTextQueries
    ]
