namespace PixelRain.Domain.Entities

open System.Collections.Generic
open PixelRain.Domain.ValueObjects
open PixelRain.Domain

type IImageSequence =
    abstract member Width: int<px> with get
    abstract member Height: int<px> with get
    abstract member FrameCount: int<frame> with get

    abstract member GetStream: PixelCoordinate -> IPixelStream
    abstract member QueryRegion: Rectangle * FrameRange -> IEnumerable<(PixelCoordinate * byte[])>
