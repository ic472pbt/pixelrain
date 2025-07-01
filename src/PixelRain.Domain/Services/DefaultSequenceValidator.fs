namespace PixelRain.Domain.Services

open System
open PixelRain.Domain
open PixelRain.Domain.ValueObjects

type DefaultSequenceValidator =
    interface ISequenceValidator with
        member _.Validate(sequence) = 
            {X = 0<px>; Y = 0<px>; Width = sequence.Width; Height = sequence.Height}.Enumerate()
                |> Seq.iter (fun coord ->
                    let stream = sequence.GetStream(coord)
                    if stream.TotalFrames <> sequence.FrameCount then
                        raise <| InvalidOperationException($"Pixel {coord} has inconsistent frame count.");
                )
