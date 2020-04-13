module FastCheckTests

open Fable.Jester
open Fable.FastCheck
open Fable.FastCheck.Jest

let add x = x + 1

let positiveInt =
    Arbitrary.Defaults.integer.filter(fun i -> i > 0)

let arbTest =
    arbitrary {
        let! i = Arbitrary.Defaults.integer
        let! i2 = Arbitrary.Defaults.integer
        return i,i2
    }

let moreComplexArb =
    Arbitrary.List.ofRange 5 10 Arbitrary.Defaults.string
    
Jest.describe("test", (fun () ->
    Jest.test("testing", (fun () ->
        FastCheck.assert'(FastCheck.property(Arbitrary.Defaults.integer, fun i -> Jest.expect(add i).toEqual(i + 1)))
        FastCheck.assert'(FastCheck.property(positiveInt, fun i -> Jest.expect(i).toBeGreaterThan(0)))
    ))
    Jest.test("CE", (fun () ->
        FastCheck.assert'(FastCheck.property(arbTest, fun (i,i2) ->
            Jest.expect(i+1).toEqual(i+1)
        ))
        FastCheck.assert'(FastCheck.property(moreComplexArb, fun xs ->
            Jest.expect(xs.Length).toBeLessThanOrEqual(10)
        ))
    ))
    Jest.test.prop("testing", positiveInt, (fun i ->
        Jest.expect(i).toBeGreaterThan(0)
    ))
    Jest.test.propSkip("testing", positiveInt, (fun i ->
        Jest.expect(i).toBeLessThan(0)
    ))
))
