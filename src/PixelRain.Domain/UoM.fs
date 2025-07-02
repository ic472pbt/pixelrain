namespace PixelRain.Domain

[<AutoOpen>]
module UoM =
    [<Measure>] type px    // pixel units
    [<Measure>] type batch // batch of images
    [<Measure>] type px2   // square pixels, for areas
    [<Measure>] type partId // unique identifier for a partition