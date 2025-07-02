namespace PixelRain.Application.Interfaces

open PixelRain.Domain.Entities
open FSharp.Control

type IImageStream =
    abstract member ReadAll : unit -> AsyncSeq<ImageWithMetadata>
