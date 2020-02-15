// Learn more about F# at http://fsharp.org

open FSharpReadFile
open FSharpReadFile.CliArgsModule

let programResult result =
    match result with
    | Ok _ -> 0
    | Error _ -> 1

[<EntryPoint>]
let main argv =
    printfn "Read a file F#!"

    let inputFileResult =
        parsedArgs "CSharpReadFile" argv
        |> getInputFile
    
    let inputFile = match inputFileResult with | Ok f -> f | Error _ -> (DomainMessage.getDomainMessage inputFileResult)
    
    printfn "%s" inputFile
        
    programResult inputFileResult // return an integer exit code
