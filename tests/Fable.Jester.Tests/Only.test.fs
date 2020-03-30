module OnlyTests

open Fable.Jester

Jest.describe("tests with only modifier get run", (fun () ->
    Jest.test.only("adds", (fun () ->
        Jest.expect(1 + 2).toEqual(3)
    ))
    Jest.test("this shouldn't execute", (fun () ->
        Jest.expect(true).toEqual(false)
    ))
))