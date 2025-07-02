open Argu
open PixelRain.Infrastructure.IO.FileSystem
open PixelRain.Infrastructure
open PixelRain.Application.UseCases
open PixelRain.Application.Services

type CLIArguments =
    | [<Mandatory>] ImageFolder of string
    | [<Mandatory>] OutputDirectory of string
    | Partitions of int
    interface IArgParserTemplate with
        member this.Usage = "Specify the folder containing images to ingest."

let parser = ArgumentParser.Create<CLIArguments>(programName = "pr.exe")
let cliArguments = parser.ParseCommandLine()
let partitionRouter = 
    let partitionsCount = cliArguments.TryGetResult Partitions |> Option.defaultValue 1
    let partitionWorker = PartitionWorker.createPartitionWorker (fun image -> ()) // Replace with actual processing logic
    PartitionRouter(partitionsCount, partitionWorker)

do
    let ingestionService: IImageIngestionService = StreamingImageIngestionService(partitionRouter) 
    cliArguments.GetResult ImageFolder
        |> FileSystemImageStream
        |> ingestionService.Ingest

partitionRouter.CompleteAll()

//let zero = map[{ X = LanguagePrimitives.Int32WithMeasure 0; Y = LanguagePrimitives.Int32WithMeasure 0 }] // Example access to a specific pixel coordinate]
//let csv = System.IO.File.WriteAllText("t:\\output.csv", zero.Values |> Seq.map string |> String.concat ",")

//map.Count
