namespace Fable.Mocha.ReactTestingLibrary.Tests

module Tests =
    open Fable.Mocha
    open Fable.Mocha.ReactTestingLibrary
    open Feliz

    let labelTextElement = React.functionComponent (fun () ->
        Html.div [
            Html.label [
                prop.for' "username-input"
                prop.text "Username"
            ]
            Html.input [
                prop.id "username-input"
            ]
            Html.label [
                prop.id "username-label"
                prop.text "Username"
            ]
            Html.input [
                prop.ariaLabelledBy "username-label"
            ]
            Html.section [
                prop.ariaLabelledBy "section-one-header"
                prop.children [
                    Html.h3 [
                        prop.id "section-one-header"
                        prop.text "Section One"
                    ]
                    Html.p [
                        prop.text "some content"
                    ]
                ]
            ]
            Html.label [
                prop.text "Username"
                prop.children [
                    Html.label []
                ]
            ]
            Html.input [
                prop.ariaLabel "username"
            ]
        ])

    let labelTextQueries =
        testList "*ByLabelText query tests" [
            testCase "getByLabelText returns the correct element" <| fun _ ->
                let elem = labelTextElement()
                let actual = RTL.render(elem).getByLabelText "Username"
                
                
                Expect.toBeInTheDocument actual "Should find an element"
        ]

    let queryTests =
        testList "RTL query tests" [
            labelTextQueries
        ]
