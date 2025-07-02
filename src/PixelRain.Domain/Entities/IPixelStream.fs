namespace PixelRain.Domain.Entities

open PixelRain.Domain.ValueObjects

type IPixelStream =
    abstract member Coordinate: PixelCoordinate with get
