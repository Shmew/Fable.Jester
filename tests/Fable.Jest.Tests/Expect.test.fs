module ExpectTests

open Fable.Jest
open System.Text.RegularExpressions

Jest.describe("expect tests", (fun () ->
    Jest.test("stringMatching string", (fun () ->
        Jest.expect("test").toEqual(expect.stringMatching("test"))
    ))
    Jest.test("not stringMatching string", (fun () ->
        Jest.expect("test").not.toEqual(expect.stringMatching("somethingElse"))
    ))
    Jest.test("stringMatching regex", (fun () ->
        Jest.expect("test").toEqual(expect.stringMatching(Regex("test")))
    ))
    Jest.test("not stringMatching regex", (fun () ->
        Jest.expect("test").not.toEqual(expect.stringMatching(Regex("somethingElse")))
    ))
    Jest.test("stringContaining string", (fun () ->
        Jest.expect("test").toEqual(expect.stringContaining("te"))
    ))
    Jest.test("not stringContaining string", (fun () ->
        Jest.expect("test").not.toEqual(expect.stringContaining("somethingElse"))
    ))

    Jest.test("objectContaining value", (fun () ->
        let actual = {| someValue = "test"; someOtherValue = "testValue" |} |> Fable.Core.JsInterop.toPlainJsObj

        let expected = {| someValue = "test" |} |> Fable.Core.JsInterop.toPlainJsObj

        Jest.expect(actual).toEqual(expect.objectContaining(expected))
    ))
    Jest.test("not objectContaining value", (fun () ->
        let actual = {| someValue = "test"; someOtherValue = "testValue" |} |> Fable.Core.JsInterop.toPlainJsObj

        let expected = {| somethingElse = "test" |} |> Fable.Core.JsInterop.toPlainJsObj

        Jest.expect(actual).toEqual(expect.objectContaining(expected))
    ))
))

