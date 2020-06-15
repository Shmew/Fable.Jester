module ExpectTests

open Fable.Core
open Fable.Jester
open System.Text.RegularExpressions

expect.extend("toRunSuccessfully", fun (x: int) -> { pass = x >= 1; message = fun () -> "You did it!" })

expect.extend("toRunSuccessfullyWithArg", fun (x: int) (y: int) (z: int) -> { pass = (x + y + z) >= 5; message = fun () -> "You did it!" })

expect.extend("toRunSuccessfullyAsync", fun (x: Async<int>) -> 
    async {
        let! x = x
        return { pass = x >= 1; message = fun () -> "You did it!" }
    })

type expected<'Return> with
    [<Emit("$0.toRunSuccessfully()")>]
    member _.toRunSuccessfully () : 'Return = jsNative

    [<Emit("$0.toRunSuccessfullyWithArg($1, $2)")>]
    member _.toRunSuccessfullyWithArg (y: int, z: int) : 'Return = jsNative

    [<Emit("$0.toRunSuccessfully()")>]
    member _.toRunSuccessfullyAsync () : 'Return = jsNative

Jest.describe("expect tests", fun () ->
    Jest.test("stringMatching string", fun () ->
        Jest.expect("test").toEqual(expect.stringMatching("test"))
    )
    Jest.test("not stringMatching string", fun () ->
        Jest.expect("test").not.toEqual(expect.stringMatching("somethingElse"))
    )
    Jest.test("stringMatching regex", fun () ->
        Jest.expect("test").toEqual(expect.stringMatching(Regex("test")))
    )
    Jest.test("not stringMatching regex", fun () ->
        Jest.expect("test").not.toEqual(expect.stringMatching(Regex("somethingElse")))
    )
    Jest.test("stringContaining string", fun () ->
        Jest.expect("test").toEqual(expect.stringContaining("te"))
    )
    Jest.test("not stringContaining string", fun () ->
        Jest.expect("test").not.toEqual(expect.stringContaining("somethingElse"))
    )

    Jest.test("objectContaining value", fun () ->
        let actual = {| someValue = "test"; someOtherValue = "testValue" |} |> Fable.Core.JsInterop.toPlainJsObj

        let expected = {| someValue = "test" |} |> Fable.Core.JsInterop.toPlainJsObj

        Jest.expect(actual).toEqual(expect.objectContaining(expected))
    )
    Jest.test("not objectContaining value", fun () ->
        let actual = {| someValue = "test"; someOtherValue = "testValue" |} |> Fable.Core.JsInterop.toPlainJsObj

        let expected = {| somethingElse = "test" |} |> Fable.Core.JsInterop.toPlainJsObj

        Jest.expect(actual).not.toEqual(expect.objectContaining(expected))
    )

    Jest.test("anything confirms option values", fun () ->
        let actual = 
            {| someValue = "test"; someOtherValue = "testValue" |} 
            |> Fable.Core.JsInterop.toPlainJsObj
            |> Some

        Jest.expect(actual).toEqual(expect.anything())
    )
    Jest.test("not anything option values", fun () ->
        let actual : obj option = None

        Jest.expect(actual).not.toEqual(expect.anything())
    )

    let arraySample = [| 1;2;3;4;5;6;7 |] |> ResizeArray

    Jest.test("array containing of Resize", fun () ->
        Jest.expect(arraySample).toEqual(expect.arrayContaining(ResizeArray [| 2;3;4 |]))
    )
    Jest.test("not array containing of resize", fun () ->
        Jest.expect(arraySample).not.toEqual(expect.arrayContaining(ResizeArray [| 8;9;10 |]))
    )
    Jest.test("array containing of array", fun () ->
        Jest.expect(arraySample).toEqual(expect.arrayContaining([| 2;3;4 |]))
    )
    Jest.test("not array containing of array", fun () ->
        Jest.expect(arraySample).not.toEqual(expect.arrayContaining([| 8;9;10 |]))
    )
    Jest.test("array containing of list", fun () ->
        Jest.expect(arraySample).toEqual(expect.arrayContaining([ 2;3;4 ]))
    )
    Jest.test("not array containing of list", fun () ->
        Jest.expect(arraySample).not.toEqual(expect.arrayContaining([| 8;9;10 |]))
    )
    Jest.test("array containing of seq", fun () ->
        Jest.expect(arraySample).toEqual(expect.arrayContaining(seq { 2..4 }))
    )
    Jest.test("not array containing of seq", fun () ->
        Jest.expect(arraySample).not.toEqual(expect.arrayContaining([| 8;9;10 |]))
    )

    Jest.test("can extend jest matchers", fun () ->
        Jest.expect(1).toRunSuccessfully()
        Jest.expect(0).not.toRunSuccessfully()
        Jest.expect(1).toRunSuccessfullyWithArg(2, 4)
        Jest.expect(0).not.toRunSuccessfullyWithArg(0, -1)
    )

    Jest.test("can extend async jest matchers", async {
        do! Jest.expect(async { return 1 }).toRunSuccessfullyAsync()
        do! Jest.expect(async { return 0 }).not.toRunSuccessfullyAsync()
    })
)
