namespace PixelRain.Application.UseCases

open PixelRain.Application.Interfaces

type IImageIngestionService =
    abstract member Ingest :  IImageStream -> unit