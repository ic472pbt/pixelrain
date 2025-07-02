namespace PixelRain.Application.UseCases

open PixelRain.Application.Interfaces

type IImageIngestionService =
    abstract member Ingest :  IImageStream -> unit
    abstract member IngestAsync :  IImageStream -> Async<unit>