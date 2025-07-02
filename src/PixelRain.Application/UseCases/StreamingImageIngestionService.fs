namespace PixelRain.Application.UseCases

open PixelRain.Application.UseCases
open PixelRain.Application.Services
open PixelRain.Application.Interfaces
open FSharp.Control

type StreamingImageIngestionService(router: PartitionRouter) =
    interface IImageIngestionService with
        member _.IngestAsync(imageStream: IImageStream) = imageStream.ReadAll() |> AsyncSeq.iter router.Route
        member _.Ingest (imageStream: IImageStream): unit = imageStream.ReadAll() |> AsyncSeq.toBlockingSeq |> Seq.iter router.Route
