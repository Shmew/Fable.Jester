namespace Fable.Jester

open Fable.Core.JsInterop
open Node.Api

module SnapshotLoader =
    type FS =
        inherit Node.Fs.IExports
        abstract copyFileSync: string * string -> unit
    
    let fs = unbox<FS> Node.Api.fs

    let copySnaps testDir destDir =
        let testDir = 
            if path.isAbsolute testDir then testDir
            else path.join(__dirname, testDir)

        let destDir =
            if path.isAbsolute testDir then destDir
            else path.join(__dirname, destDir)

        let snapDir = path.join(destDir, "__snapshots__")

        if fs.existsSync(!^snapDir) |> not then
            fs.mkdirSync(snapDir)

        let copyItem (src: string) (dst: string) =
            if src.TrimEnd().EndsWith(".js.snap") then
                fs.copyFileSync(src, dst)

        let rec copyToSnap (item: string) =
            if fs.lstatSync(!^item).isDirectory() then
                for file in fs.readdirSync(!^item) do
                    let currentItem = path.join(item, file)

                    if fs.lstatSync(!^currentItem).isDirectory() then copyToSnap currentItem
                    else copyItem currentItem (path.join(snapDir, file))
            else copyItem item (path.join(snapDir, path.basename(item)))

        copyToSnap testDir
        
