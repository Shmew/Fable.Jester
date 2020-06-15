module OnlyTests

open Fable.Jester

Jest.describe("only tests with only modifier get run", (fun () ->
    Jest.test.only("only this should execute", (fun () ->
        Jest.expect(1 + 2).toEqual(3)
    ))
    Jest.test("this shouldn't execute", (fun () ->
        Jest.expect(true).toEqual(false)
    ))
))

Jest.describe("only tests with only modifier get run", (fun () ->
    Jest.test.only("only this should execute", async {
        do Jest.expect(1 + 2).toEqual(3)
    })
    Jest.test("this shouldn't execute", (fun () ->
        Jest.expect(true).toEqual(false)
    ))
))
