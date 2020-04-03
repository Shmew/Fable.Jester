module MatcherTests

open Fable.Core.JsInterop
open Fable.Jester
open System.Text.RegularExpressions

Jest.describe("matcher tests", (fun () ->
    Jest.test("toBe", (fun () ->
        Jest.expect("test").toBe("test")
    ))
    Jest.test("not toBe", (fun () ->
        Jest.expect("test").not.toBe("somethingElse")
    ))

    Jest.test("toHaveLength", (fun () ->
        Jest.expect("hi").toHaveLength(2)
    ))
    Jest.test("not toHaveLength", (fun () ->
        Jest.expect("hi").not.toHaveLength(3)
    ))

    Jest.test("toHaveProperty from pojo", (fun () ->
        let actual = {| test = "testValue" |} |> toPlainJsObj
        Jest.expect(actual).toHaveProperty("test")
    ))
    Jest.test("not toHaveProperty from pojo", (fun () ->
        let actual = {| test = "testValue" |} |> toPlainJsObj
        Jest.expect(actual).not.toHaveProperty("somethingElse")
    ))
    Jest.test("toHaveProperty from record", (fun () ->
        let actual = {| test = "testValue" |} 
        Jest.expect(actual).toHaveProperty("test")
    ))
    Jest.test("not toHaveProperty from record", (fun () ->
        let actual = {| test = "testValue" |} 
        Jest.expect(actual).not.toHaveProperty("somethingElse")
    ))
    Jest.test("toHaveProperty from record", (fun () ->
        let actual = {| test = "testValue" |} 
        Jest.expect(actual).toHaveProperty("test", "testValue")
    ))
    Jest.test("not toHaveProperty from record", (fun () ->
        let actual = {| test = "testValue" |} 
        Jest.expect(actual).not.toHaveProperty("test", "someOtherValue")
    ))
    Jest.test("toHaveProperty from record", (fun () ->
        let actual = {| test = {| testNested = "testValue" |} |} 
        Jest.expect(actual).toHaveProperty(["test"; "testNested"], "testValue")
    ))
    Jest.test("not toHaveProperty from record", (fun () ->
        let actual = {| test = {| testNested = "testValue" |} |} 
        Jest.expect(actual).not.toHaveProperty(["test"; "testNested"], "someOtherValue")
    ))
    
    Jest.test("toBeCloseTo", (fun () ->
        let actual = System.Math.PI
        Jest.expect(actual).toBeCloseTo(3.14, 2)
    ))
    Jest.test("toBeCloseTo", (fun () ->
        let actual = System.Math.PI
        Jest.expect(actual).not.toBeCloseTo(3.14, 10)
    ))
    
    Jest.test("toBeDefined", (fun () ->
        let actual = "hi"
        Jest.expect(actual).toBeDefined()
    ))
    Jest.test("not toBeDefined", (fun () ->
        Jest.expect(()).not.toBeDefined()
    ))
    
    Jest.test("toBeFalsy", (fun () ->
        Jest.expect(()).toBeFalsy()
    ))
    Jest.test("not toBeFalsy", (fun () ->
        let actual = "hi"
        Jest.expect(actual).not.toBeFalsy()
    ))

    Jest.test("toBeGreaterThan", (fun () ->
        Jest.expect(3).toBeGreaterThan(2)
    ))
    Jest.test("not toBeGreaterThan", (fun () ->
        Jest.expect(2.).not.toBeGreaterThan(3.)
    ))
    
    Jest.test("toBeGreaterThanOrEqual", (fun () ->
        Jest.expect(3).toBeGreaterThanOrEqual(3)
    ))
    Jest.test("not toBeGreaterThanOrEqual", (fun () ->
        Jest.expect(2.).not.toBeGreaterThanOrEqual(3.)
    ))
    
    Jest.test("toBeLessThan", (fun () ->
        Jest.expect(2).toBeLessThan(3)
    ))
    Jest.test("not toBeLessThan", (fun () ->
        Jest.expect(4.).not.toBeLessThan(3.)
    ))

    Jest.test("toBeLessThanOrEqual", (fun () ->
        Jest.expect(3).toBeLessThanOrEqual(3)
    ))
    Jest.test("not toBeLessThanOrEqual", (fun () ->
        Jest.expect(4.).not.toBeLessThanOrEqual(3.)
    ))
    
    Jest.test("toBeNull", (fun () ->
        let myString : string = null
        Jest.expect(myString).toBeNull()
    ))
    Jest.test("not toBeNull", (fun () ->
        Jest.expect(Some "hi").not.toBeNull()
    ))

    Jest.test("toBeTruthy", (fun () ->
        Jest.expect([|1;2;3|]).toBeTruthy()
    ))
    Jest.test("not toBeTruthy", (fun () ->
        Jest.expect("").not.toBeTruthy()
    ))

    Jest.test("toBeUndefined", (fun () ->
        let objTest : obj = (unbox<obj> "")?hi
        Jest.expect(objTest).toBeUndefined()
    ))
    Jest.test("not toBeUndefined", (fun () ->
        Jest.expect(Some "hi").not.toBeUndefined()
    ))

    Jest.test("toBeNaN", (fun () ->
        Jest.expect(Fable.Core.JS.NaN).toBeNaN()
    ))
    Jest.test("not toBeNaN", (fun () ->
        Jest.expect(1).not.toBeNaN()
    ))

    Jest.test("toContain", (fun () ->
        Jest.expect([1;2;3]).toContain(1)
        Jest.expect([1;2;8]).toContain(8)
        Jest.expect(["I";"Like";"Pie"]).toContain("Pie")
        
        let asyncList = async { return [1;2;3] }

        Jest.expect(asyncList).toContain(3)
    ))
    Jest.test("toContain", (fun () ->
        let promiseList = promise { return [1;2;3] }

        Jest.expect(promiseList).resolves.toContain(3)
    ))
    Jest.test("not toContain", (fun () ->
        Jest.expect([1;2;3]).not.toContain(5)
    ))

    Jest.test("toContainEqual", (fun () ->
        let testList = [
            {| One = 1
               Two = 2
               Three = 3 |}
            {| One = 4
               Two = 5
               Three = 6 |}
        ]
        
        Jest.expect(testList).toContainEqual({| One = 1; Two = 2; Three = 3 |})
    ))
    Jest.test("not toContainEqual", (fun () ->
        let testList = [
            {| One = 1
               Two = 2
               Three = 3 |}
            {| One = 4
               Two = 5
               Three = 6 |}
        ]
        Jest.expect(testList).not.toContainEqual({| One = 8 |})
    ))

    Jest.test("toEqual", (fun () ->
        Jest.expect(true).toEqual(true)
    ))
    Jest.test("not toEqual", (fun () ->
        Jest.expect(false).not.toEqual(true)
    ))

    Jest.test("toMatch of string", (fun () ->
        Jest.expect("test").toMatch("test")
    ))
    Jest.test("not toMatch of string", (fun () ->
        Jest.expect("test").not.toMatch("somethingElse")
    ))
    Jest.test("toMatch of Regex", (fun () ->
        Jest.expect("test").toMatch(Regex("tes"))
    ))
    Jest.test("not toEqual of Regex", (fun () ->
        Jest.expect("test").not.toMatch(Regex("somethingElse"))
    ))

    Jest.test("toMatchObject", (fun () ->
        let actual = {| test = "hi" |}
        let expected = {| test = "hi" |}

        Jest.expect(actual).toMatchObject(expected)
    ))
    Jest.test("not toMatchObject", (fun () ->
        let actual = {| test = "hi" |}
        let expected = {| somethingElse = "howdy!" |}

        Jest.expect(actual).not.toMatchObject(expected)
    ))

    Jest.test("toStrictEqual", (fun () ->
        Jest.expect(1).toStrictEqual(1)
    ))
    Jest.test("not toStrictEqual", (fun () ->
        let actual = {| test = "hi" |}
        let expected = {| test = "hiya" |}

        Jest.expect(actual).not.toStrictEqual(expected)
    ))

    let myFailingFunction () =
        if 1 = 2 then 1
        else failwith "uh oh!"

    let myNotFailingFunction () = "hi!"

    Jest.test("toThrow", (fun () ->
        Jest.expect(myFailingFunction).toThrow()
    ))
    Jest.test("not toThrow", (fun () ->
        Jest.expect(myNotFailingFunction).not.toThrow()
    ))
    Jest.test("toThrow", (fun () ->
        Jest.expect(myFailingFunction).toThrow(System.Exception("uh oh!"))
    ))
    Jest.test("not toThrow", (fun () ->
        Jest.expect(myNotFailingFunction).not.toThrow(System.Exception("somethingElse"))
    ))
    Jest.test("toThrow", (fun () ->
        Jest.expect(myFailingFunction).toThrow("uh oh!")
    ))
    Jest.test("not toThrow", (fun () ->
        Jest.expect(myNotFailingFunction).not.toThrow("somethingElse")
    ))
    Jest.test("toThrow", (fun () ->
        Jest.expect(myFailingFunction).toThrow(Regex("^uh.*$"))
    ))
    Jest.test("not toThrow", (fun () ->
        Jest.expect(myNotFailingFunction).not.toThrow(Regex("^something.*$"))
    ))
))
