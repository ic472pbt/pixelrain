namespace PixelRain.Domain

[<AutoOpen>]
module UoM =
    [<Measure>] type px    // pixel units
    [<Measure>] type frame // time unit for frame index
    [<Measure>] type px2   // square pixels, for areas
    [<Measure>] type partId // unique identifier for a partition