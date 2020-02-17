namespace FSharpReadFile

module CliArgsModule = 

    open System
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

    let getInputFile (result : Result<ParseResults<CliArgs>, DomainMessage>) =
        match result with | Ok args -> args.GetResult(Input_File) | Error _ -> ""
 