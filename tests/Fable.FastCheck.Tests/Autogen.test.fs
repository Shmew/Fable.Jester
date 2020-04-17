module AutogenTests

open Fable.Jester
open Fable.FastCheck
open Fable.FastCheck.Jest

type RecordTest2 =
    { Count: int
      Function: (int -> string) }

type RecordTest = 
    { Count: int
      Function: (int -> string)
      Record: RecordTest2 }

type DUTest =
    | Empty
    | SingleValue of int
    | Record of RecordTest
    | Function of (int -> string)

[<Struct>]
type StructTest =
    | One = 1
    | Two = 2

Jest.describe("Autogen tests", fun () ->
    Jest.test.prop("Autogen a record", Arbitrary.auto<RecordTest>(), fun m ->
        Jest.expect(m.Count + 1).toEqual(m.Count + 1)
        Jest.expect(m.Function 1).toEqual(m.Function 1)
        Jest.expect(m.Record.Function 1).toEqual(m.Record.Function 1)
    )
    Jest.test.prop("Autogen a DU", Arbitrary.auto<DUTest>(), fun d ->
        match d with
        | Empty -> Jest.expect(d).toEqual(Empty)
        | SingleValue i -> Jest.expect(d).toEqual(SingleValue i)
        | Record m -> Jest.expect(d).toEqual(Record m)
        | Function f -> Jest.expect(f 1).toEqual(f 1)
    )
    Jest.test.prop("Autogen a tuple", Arbitrary.auto<int * int>(), fun t ->
        let l, r = t
        Jest.expect(t).toEqual((l,r))
    )
    Jest.test.prop("Autogen a function", Arbitrary.auto<int -> int>(), Arbitrary.Defaults.integer, fun f i ->
        Jest.expect(f i).toEqual(f i)
    )
    Jest.test.prop("Autogen a struct", Arbitrary.auto<StructTest>(), fun i ->
        Jest.expect(int i).toBeGreaterThanOrEqual(1)
        Jest.expect(int i).toBeLessThanOrEqual(2)
    )
    Jest.test.prop("Autogen an array", Arbitrary.auto<int []>(), fun arr ->
        Jest.expect(arr |> Array.sum).toBeDefined()
    )
    Jest.test.prop("Autogen an array of arrays", Arbitrary.auto<int [][]>(), fun arr ->
        Jest.expect(arr |> Array.map Array.sum |> Array.sum).toBeDefined()
    )
    Jest.test.prop("Autogen a list of lists", Arbitrary.auto<int list>(), fun lst ->
        Jest.expect(lst |> List.sum).toBeDefined()
    )
    Jest.test.prop("Autogen an array of arrays", Arbitrary.auto<int list list>(), fun lst ->
        Jest.expect(lst |> List.map List.sum |> List.sum).toBeDefined()
    )
    Jest.test.prop("Autogen a seq", Arbitrary.auto<int seq>(), fun sq ->
        Jest.expect(sq |> Seq.sum).toBeDefined()
    )
    Jest.test.prop("Autogen an seq of seqs", Arbitrary.auto<int seq seq>(), fun sq ->
        Jest.expect(sq |> Seq.map Seq.sum |> Seq.sum).toBeDefined()
    )
    Jest.test.prop("Autogen an option", Arbitrary.auto<int option>(), fun iOpt ->
        match iOpt with
        | Some i -> Jest.expect(iOpt).toEqual(Some i)
        | None -> Jest.expect(iOpt).toEqual(None)
    )
    Jest.test.prop("Autogen a result", Arbitrary.auto<Result<int,string>>(), fun iOpt ->
        match iOpt with
        | Ok i -> Jest.expect(iOpt).toEqual(Ok i)
        | Error err -> Jest.expect(iOpt).toEqual(Error err)
    )
    Jest.test.prop("Autogen a map", Arbitrary.auto<Map<int,string>>(), fun mp ->
        Jest.expect(mp.Add(1, "Test").TryFind(1)).toEqual(Some "Test")
    )
    Jest.test.prop("Autogen a set", Arbitrary.auto<Set<int>>(), fun set ->
        Jest.expect(set).toBeDefined()
    )
)
