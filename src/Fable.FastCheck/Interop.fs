namespace Fable.FastCheck

[<RequireQualifiedAccess>]
module Interop =
    let mkCommandConstraintAttr (key: string) (value: obj) : ICommandConstraintProperty = unbox(key, value)
    let mkDateConstraintAttr (key: string) (value: obj) : IDateConstraintProperty = unbox(key, value)
    let mkObjConstraintAttr (key: string) (value: obj) : IObjConstraintProperty = unbox(key, value)
    let mkParametersOptionAttr (key: string) (value: obj) : IParametersOptionProperty = unbox(key, value)
    let mkRecordConstraintAttr (key: string) (value: obj) : IRecordConstraintProperty = unbox(key, value)
    let mkWebAuthorityConstraintAttr (key: string) (value: obj) : IWebAuthorityConstraintProperty = unbox(key, value)
    let mkWebUrlConstraintAttr (key: string) (value: obj) : IWebUrlConstraintProperty = unbox(key, value)
