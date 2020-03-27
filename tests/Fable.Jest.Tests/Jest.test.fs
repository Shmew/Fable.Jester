module Tests

open Fable.Core
open Fable.Jest

let myPromise =
    async { return 1 + 1 }
    |> Async.StartAsPromise

let myAsync =
    async { return 1 + 1 }

Jest.describe ("can run a test", (fun () ->
    Jest.test ("running a test", (fun () ->
        Jest.expect(1+1).toEqual(2)
    ))

    Jest.test ("running a promise test", (fun () ->
        Jest.expect(myPromise).not.toEqual(1)
    ))

    Jest.test ("running an async test", (fun () ->
        Jest.expect(myAsync).toBe(2)
    ))
))
