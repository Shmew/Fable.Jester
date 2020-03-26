namespace Fable.Mocha.ReactTestingLibrary.Tests

module RunTests =
    open Fable.Mocha

    let allTests = 
        testList "All Tests" [
            Tests.queryTests
        ]

    [<EntryPoint>]
    let main _ =
        Mocha.runTests allTests
