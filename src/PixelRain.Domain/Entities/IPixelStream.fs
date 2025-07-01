namespace PixelRain.Domain.Entities

open System.Collections.Generic
open PixelRain.Domain.ValueObjects
open PixelRain.Domain

type IPixelStream =
    abstract member Coordinate: PixelCoordinate with get
    abstract member TotalFrames: int<frame> with get
    abstract member GetValues: FrameRange -> IReadOnlyList<byte>