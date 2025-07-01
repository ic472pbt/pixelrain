namespace PixelRain.Application.Interfaces

open PixelRain.Domain.Entities
open PixelRain.Domain.ValueObjects

type IImageStorage =
    abstract member StoreSequence : IImageSequence -> unit
    abstract member QueryRegion : Rectangle -> FrameRange -> seq<PixelCoordinate * byte[]>
   // abstract member QueryDownscaledRegion : Rectangle -> FrameRange -> DownscaleFactor -> byte[,]
