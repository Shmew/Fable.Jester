module SchedulerTests

open Fable.Jester
open Fable.FastCheck
open Fable.FastCheck.Jest

Jest.describe("Scheduler tests", fun () ->
    Jest.test.prop("Scheduler runs promises", Arbitrary.Defaults.scheduler, fun s ->
        promise {
            let one = s.schedule(promise { return 1 })
            let two = s.schedule(promise { return 2 })

            do! s.waitAll()

            do! Jest.expect(one).resolves.toBe(1)
            do! Jest.expect(two).resolves.toBe(2)
        }
    )
)
