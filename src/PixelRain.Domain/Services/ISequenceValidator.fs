namespace PixelRain.Domain

type ISequenceValidator =
    abstract member Validate: IImageSequence -> unit