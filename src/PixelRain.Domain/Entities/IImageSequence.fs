namespace PixelRain.Domain.Entities

open PixelRain.Domain.ValueObjects
open PixelRain.Domain

type IImageSequence =
    abstract member Width: int<px> with get
    abstract member Height: int<px> with get

    abstract member GetStream: PixelCoordinate -> IPixelStream
