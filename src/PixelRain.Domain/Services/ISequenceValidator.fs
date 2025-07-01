namespace PixelRain.Domain.Services

open PixelRain.Domain.Entities

type ISequenceValidator =
    abstract member Validate: IImageSequence -> unit