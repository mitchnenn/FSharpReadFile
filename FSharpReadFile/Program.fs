// Learn more about F# at http://fsharp.org

open FSharpReadFile.CliArgsModule

[<EntryPoint>]
let main argv =
    printfn "Read a file F#!"

    let inputFile = getInputFile "CSharpReadFile" argv

    printf "%s" inputFile
    
    0 // return an integer exit code
