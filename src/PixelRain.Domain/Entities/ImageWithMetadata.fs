namespace PixelRain.Domain.Entities

open System
open PixelRain.Domain.ValueObjects

type ImageWithMetadata = {
    Timestamp: DateTime
    Id: string
    Image: GrayscaleImage    
}