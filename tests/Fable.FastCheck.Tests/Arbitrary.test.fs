module ArbitraryTests

open Fable.Jester
open Fable.FastCheck
open Fable.FastCheck.Jest

Jest.describe("Arbitrary tests", fun () ->
    Jest.test.prop("Can generate default arbitraries", Arbitrary.Defaults.integer, fun i ->
        Jest.expect(i).not.toBeNaN()
        Jest.expect(i).toBeDefined()
        Jest.expect(i).not.toBeNull()
    )
    Jest.test.prop("Can generate arbitraries with constraints", Arbitrary.ConstrainedDefaults.integer(1, 5), fun i ->
        Jest.expect(i).toBeGreaterThanOrEqual(1)
        Jest.expect(i).toBeLessThanOrEqual(5)
    )
    Jest.test.prop("Elements selects an element", Arbitrary.elements [1;2;3], fun i ->
        Jest.expect(i).toBeGreaterThanOrEqual(1)
        Jest.expect(i).toBeLessThanOrEqual(3)
    )
    Jest.test.prop("Shuffle shuffles elements", Arbitrary.List.shuffle [1;2;3], fun xs ->
        Jest.expect(xs).toContain(1)
        Jest.expect(xs).toContain(2)
        Jest.expect(xs).toContain(3)
        Jest.expect(xs).not.toBe([1;2;3])
    )
    Jest.test.prop("Piles correctly makes piles", Arbitrary.List.piles 10 20, fun xs ->
        Jest.expect(xs |> List.sum).toEqual(20)
    )
    Jest.test.prop("Option correctly makes an option", Arbitrary.Defaults.integer |> Arbitrary.option, fun iOpt ->
        match iOpt with
        | Some i -> Jest.expect(iOpt).toBe(Some i)
        | None -> Jest.expect(iOpt).toBe(None)
    )
    Jest.test.prop("StringOf creates a string from char arb", Arbitrary.Defaults.char |> Arbitrary.stringOf, fun c ->
        Jest.expect(c).toBeDefined()
    )
)
