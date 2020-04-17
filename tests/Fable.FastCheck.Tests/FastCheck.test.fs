module FastCheckTests

open Fable.Jester
open Fable.FastCheck
open Fable.FastCheck.Jest

let add x = x + 1

let positiveInt =
    Arbitrary.Defaults.integer.filter(fun i -> i > 0)

let arbCE =
    arbitrary {
        let! i = Arbitrary.Defaults.integer
        let! i2 = Arbitrary.Defaults.integer
        return i,i2
    }

Jest.describe("FastCheck", fun () ->
    Jest.test("assertion works", fun () ->
        FastCheck.assert'(FastCheck.property(Arbitrary.Defaults.integer, fun i -> Jest.expect(add i).toEqual(i + 1)))
        FastCheck.assert'(FastCheck.property(positiveInt, fun i -> Jest.expect(i).toBeGreaterThan(0)))
    )
    Jest.test("CE works", fun () ->
        FastCheck.assert'(FastCheck.property(arbCE, fun (i,i2) ->
            Jest.expect(i+i2).toEqual(i+i2)
        ))
        FastCheck.assert'(FastCheck.property(arbCE, fun (i,i2) ->
            Jest.expect(i+i2).not.toEqual(i)
        ))
    )
)
Jest.describe("FastCheck Jest Wrapper", fun () ->
    Jest.test.prop("test.prop works", positiveInt, fun i ->
        Jest.expect(i).toBeGreaterThan(0)
    )
    Jest.test.prop.skip("test.skip skips", positiveInt, fun i ->
        Jest.expect(i).toBeLessThan(0)
    )
)

Jest.describe("FastCheck Jest test.only", fun () ->
    Jest.test.prop.only("only this should run", positiveInt, fun i ->
        Jest.expect(i).toBeGreaterThan(0)
    )
    Jest.test.prop("this shouldn't run", positiveInt, fun i ->
        Jest.expect(i).toBeLessThan(0)
    )
)
