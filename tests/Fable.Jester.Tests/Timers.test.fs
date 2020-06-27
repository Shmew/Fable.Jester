module TimerTests

open Fable.Core
open Fable.Jester
open System

Jest.useFakeTimers()

Jest.describe("timer tests", fun () ->
    Jest.test("Can correctly set and use mocked datetime", fun () ->
        Jest.setSystemTime(0)

        Jest.expect(JS.Constructors.Date.now()).toEqual(0)
        Jest.expect(Jest.getRealSystemTime()).not.toEqual(0L)
    )
    Jest.test("Can correctly set and use mocked datetime from DateTime", fun () ->
        Jest.setSystemTime(DateTime.MinValue)

        Jest.expect(DateTime.Now).toEqual(DateTime.MinValue)
        Jest.expect(Jest.getRealSystemTime()).not.toEqual(DateTime.MinValue.Ticks)
    )
)
