namespace PixelRain.Domain

[<Struct>]
type FrameRange = {Start: int; End: int}
    with
        member frameRange.Length = frameRange.End - frameRange.Start + 1;
        member frameRange.Contains(frame) = frame >= frameRange.Start && frame <= frameRange.End;