open Argu
open PixelRain.Infrastructure.IO.FileSystem
open PixelRain.Application.UseCases
open PixelRain.Application.Services

type CLIArguments =
    | [<Mandatory>] ImageFolder of string
    interface IArgParserTemplate with
        member this.Usage = "Specify the folder containing images to ingest."

let parser = ArgumentParser.Create<CLIArguments>(programName = "pr.exe")
let cliArguments = parser.ParseCommandLine()

let map = 
    let service: IImageIngestionService = ImageIngestionService()
    ImageFolder
        |> cliArguments.GetResult
        |> FileSystemImageStream
        |> service.Ingest
map.Count
