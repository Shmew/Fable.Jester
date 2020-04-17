namespace Fable.FastCheck

open Fable.Core.JsInterop
open System

module Constraints =
    type Command =
        /// Maximum number of commands to execute on the model.
        static member maxCommands (value: int) = Interop.mkCommandConstraintAttr "maxCommands" value

        /// Disable replaying of the model test.
        static member disableReplayLog (value: bool) = Interop.mkCommandConstraintAttr "disableReplayLog" value
        
        /// Set the reply path.
        static member replayPath (value: string) = Interop.mkCommandConstraintAttr "replayPath" value
    
    type Date =
        /// Minimum value for date (inclusive).
        static member min (value: DateTime) = Interop.mkDateConstraintAttr "min" value

        /// Maximum value for date (inclusive).
        static member max (value: DateTime) = Interop.mkDateConstraintAttr "max" value

    type Obj<'T> =
        /// Maximal depth allowed.
        static member maxDepth (value: int) = Interop.mkObjConstraintAttr "maxDepth" value

        /// Maximal number of keys.
        static member maxKeys (value: int) = Interop.mkObjConstraintAttr "maxKeys" value

        /// Arbitrary for keys.
        /// 
        /// Default for `key` is: `Arbitrary.Defaults.string`
        static member key (value: Arbitrary<string>) = Interop.mkObjConstraintAttr "key" value

        /// Arbitrary for values.
        static member values (value: Arbitrary<'T> []) = Interop.mkObjConstraintAttr "values" (ResizeArray value)
        /// Arbitrary for values.
        static member values (value: Arbitrary<'T> list) = Interop.mkObjConstraintAttr "values" (ResizeArray value)
        /// Arbitrary for values.
        static member values (value: Arbitrary<'T> seq) = Interop.mkObjConstraintAttr "values" (ResizeArray value)
        /// Arbitrary for values.
        static member values (value: ResizeArray<Arbitrary<'T>>) = Interop.mkObjConstraintAttr "values" (value)

        /// Also generate boxed versions of values.
        static member withBoxedValues (value: bool) = Interop.mkObjConstraintAttr "withBoxedValues" value

        /// Also generate Set.
        static member withSet (value: bool) = Interop.mkObjConstraintAttr "withSet" value

        /// Also generate Map.
        static member withMap (value: bool) = Interop.mkObjConstraintAttr "withMap" value

        /// Also generate string representations of object instances.
        static member withObjectString (value: bool) = Interop.mkObjConstraintAttr "withObjectString" value

        /// Also generate object with null prototype.
        static member withNullPrototype (value: bool) = Interop.mkObjConstraintAttr "withNullPrototype" value

    module Uuid =
        type VersionNumber =
            static member N1 = unbox<IUuidVersionConstraintProperty> 1
            static member N2 = unbox<IUuidVersionConstraintProperty> 2
            static member N3 = unbox<IUuidVersionConstraintProperty> 3
            static member N4 = unbox<IUuidVersionConstraintProperty> 4
            static member N5 = unbox<IUuidVersionConstraintProperty> 5

    type WebAuthority =
        /// Enable IPv4 in host.
        static member withIPv4 (value: bool) = Interop.mkWebAuthorityConstraintAttr "withIPv4" value

        /// Enable extended IPv4 format.
        static member withIPv4Extended (value: bool) = Interop.mkWebAuthorityConstraintAttr "withIPv4Extended" value
        
        /// Enable IPv6 in host.
        static member withIPv6 (value: bool) = Interop.mkWebAuthorityConstraintAttr "withIPv6" value
        
        /// Enable port suffix.
        static member withPort (value: bool) = Interop.mkWebAuthorityConstraintAttr "withPort" value
        
        /// Enable user information prefix.
        static member withUserInfo (value: bool) = Interop.mkWebAuthorityConstraintAttr "withUserInfo" value

    type WebUrl =
        /// Enforce specific schemes, eg.: http, https.
        static member validSchemes (value: string list) = Interop.mkWebUrlConstraintAttr "validSchemes" (ResizeArray value)

        /// Settings for webAuthority.
        static member authoritySettings (properties: IWebAuthorityConstraintProperty list) = Interop.mkWebUrlConstraintAttr "authoritySettings" (createObj !!properties)

        /// Enable query parameters in the generated url.
        static member withQueryParameters (value: bool) = Interop.mkWebUrlConstraintAttr "withQueryParameters" value

        /// Enable fragments in the generated url.
        static member withFragments (value: bool) = Interop.mkWebUrlConstraintAttr "withFragments" value
