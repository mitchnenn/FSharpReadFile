namespace FSharpReadFile

open System

module CliArgsModule = 

    open Argu
    open DomainMessage

    type CliArgs =
        | [<Mandatory>] [<First>] Input_File of path:string
    with
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | Input_File _ -> "Specify an input file."
                
    let parsedArgs progName argv =
        try
            let errorHandler = ProcessExiter(colorizer = function ErrorCode.HelpText -> None | _ -> Some ConsoleColor.Red)
            let parser = ArgumentParser.Create<CliArgs>(progName, errorHandler = errorHandler)
            let parsed = parser.Parse argv
            Ok parsed
        with
            | :? ArguParseException as ex -> Error (CommandLineParseFailed ex)

    let getInputFile (parseResult : Result<ParseResults<CliArgs>, DomainMessage>) =
        let someResults = match parseResult with | Ok p -> Some(p) | Error _ -> None
        if (someResults.IsSome) then
            let results = someResults.Value
            match results with
            | p when p.Contains(Input_File) -> Ok (p.GetResult Input_File)
            | _ -> Error CommandLineInputFileNotFound
        else
            Error CommandLineInputFileNotFound
