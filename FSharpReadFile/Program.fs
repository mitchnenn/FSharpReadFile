// Learn more about F# at http://fsharp.org

open FSharpReadFile.CliArgsModule

let programResult result =
    match result with
    | Ok _ -> 0
    | Error _ -> 1

[<EntryPoint>]
let main argv =
    printfn "Read a file F#!"

    let result =
        parsedArgs "CSharpReadFile" argv
    
    printfn "%s" (getInputFile result)
        
    programResult result // return an integer exit code
