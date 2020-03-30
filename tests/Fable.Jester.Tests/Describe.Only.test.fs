module DescribeOnlyTests

open Fable.Jester

Jest.describe.only("tests with only modifier get run", (fun () ->
    Jest.test.only("adds", (fun () ->
        Jest.expect(true).toEqual(true)
    ))
    Jest.test("this shouldn't execute", (fun () ->
        Jest.expect(true).toEqual(false)
    ))
))