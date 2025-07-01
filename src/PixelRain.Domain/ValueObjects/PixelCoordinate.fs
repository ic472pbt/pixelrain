namespace PixelRain.Domain.ValueObjects

open PixelRain.Domain

[<Struct>]
type PixelCoordinate = { X: int<px>; Y: int<px> }
    with
        override pixelCoordinate.ToString() = $"({pixelCoordinate.X},{pixelCoordinate.Y})"
