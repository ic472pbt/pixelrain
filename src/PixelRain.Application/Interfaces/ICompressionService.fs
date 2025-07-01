namespace PixelRain.Application.Interfaces

open PixelRain.Domain.ValueObjects

type ICompressionService =
    abstract member Compress : PixelCoordinate * byte[] -> byte[]
    abstract member Decompress : PixelCoordinate * byte[] -> byte[]
