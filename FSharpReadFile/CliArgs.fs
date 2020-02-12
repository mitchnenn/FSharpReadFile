namespace FSharpReadFile

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
            let parser = ArgumentParser.Create<CliArgs>(progName)
            let parsed = parser.Parse argv
            Ok parsed
        with
            | :? ArguParseException as ex -> Error (CommandLineParseFailed ex)

    let getInputFile progName argv =
        let argListResult = parsedArgs progName argv
        match argListResult with
        | Ok args -> args.GetResult Input_File
        | Error _ -> getDomainMessage argListResult
