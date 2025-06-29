namespace PixelRain.Domain

open System.Collections.Generic

type IImageSequence =
    abstract member Width: int with get
    abstract member Height: int with get
    abstract member FrameCount: int with get

    abstract member GetStream: PixelCoordinate -> IPixelStream
    abstract member QueryRegion: Rectangle * FrameRange -> IEnumerable<(PixelCoordinate * byte[])>
