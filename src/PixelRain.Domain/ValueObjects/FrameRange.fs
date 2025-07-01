namespace PixelRain.Domain.ValueObjects

open PixelRain.Domain

[<Struct>]
type FrameRange = {Start: int<frame>; End: int<frame>}
    with
        member frameRange.Length = frameRange.End - frameRange.Start + 1<frame>;
        member frameRange.Contains(frame) = frame >= frameRange.Start && frame <= frameRange.End;