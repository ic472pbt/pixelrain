namespace PixelRain.Application.Interfaces
open PixelRain.Domain.Entities

type IImageStream =
    abstract member ReadAll : unit -> seq<ImageWithMetadata>
