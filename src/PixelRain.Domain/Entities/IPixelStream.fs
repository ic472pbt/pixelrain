namespace PixelRain.Domain

open System.Collections.Generic

type IPixelStream =
    abstract member Coordinate: PixelCoordinate with get
    abstract member TotalFrames: int with get
    abstract member GetValues: FrameRange -> IReadOnlyList<byte>