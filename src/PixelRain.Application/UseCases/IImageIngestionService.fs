namespace PixelRain.Application.UseCases
open PixelRain.Application.Interfaces
open PixelRain.Domain.ValueObjects

type IImageIngestionService =
    abstract member Ingest : IImageStream -> Map<PixelCoordinate, PixelTimeSeries>