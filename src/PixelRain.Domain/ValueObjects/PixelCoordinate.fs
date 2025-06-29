namespace PixelRain.Domain

[<Struct>]
type PixelCoordinate = { X: int; Y: int }
    with
        override pixelCoordinate.ToString() = $"({pixelCoordinate.X},{pixelCoordinate.Y})"
