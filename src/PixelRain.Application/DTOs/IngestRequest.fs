namespace PixelRain.Application.DTOs

open PixelRain.Domain.ValueObjects

type IngestRequest =
    {
        Width: int
        Height: int
        FrameCount: int
        Pixels: Map<PixelCoordinate, byte[]>  // all time series
    }

    // member this.ToDomain() : IImageSequence = 
