namespace FSharpReadFile

open System

module DomainMessage =
    
    type DomainMessage =
        | CommandLineParseFailed of Exception
        | CommandLineInputFileNotFound

    let getDomainMessage result =
        match result with
        | Ok _ -> "Success"
        | Error err ->
            match err with
            | CommandLineParseFailed (ex) -> sprintf "CLI parsed failed. %s" ex.Message
            | CommandLineInputFileNotFound -> sprintf "Input file not found."
            