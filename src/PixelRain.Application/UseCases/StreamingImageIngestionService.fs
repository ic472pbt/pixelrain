namespace PixelRain.Application.UseCases

open PixelRain.Application.UseCases
open PixelRain.Application.Services
open PixelRain.Application.Interfaces

type StreamingImageIngestionService(router: PartitionRouter) =
    interface IImageIngestionService with
        member _.Ingest(imageStream: IImageStream) =
            for image in imageStream.ReadAll() do
                router.Route(image)