namespace Fable.FastCheck

open Elmish

module ElmishModel =
    type Model<'Model,'Msg> (init: 'Model * Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Cmd<'Msg>) =
        let mutable model = fst init

        member _.Dispatch (msg: 'Msg) =
            let model',_ = update msg model
            model <- model'

        member _.Model = model

    type Msg<'Model,'Msg> (msg: 'Msg, assertion: 'Model -> 'Model -> unit) =
        interface ICommand<Model<'Model,'Msg>,Model<'Model,'Msg>> with
            member _.check (m: Model<'Model,'Msg>) = true

            member _.run (m: Model<'Model,'Msg>, r: Model<'Model,'Msg>) =
                r.Dispatch(msg)
                assertion m.Model r.Model
                m.Dispatch(msg)
                
            member _.toString () = msg.ToString()
