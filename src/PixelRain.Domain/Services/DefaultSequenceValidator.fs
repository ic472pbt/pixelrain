namespace PixelRain.Domain

open System

type DefaultSequenceValidator =
    interface ISequenceValidator with
        member _.Validate(sequence) = 
            {X = 0; Y = 0; Width = sequence.Width; Height = sequence.Height}.Enumerate()
                |> Seq.iter (fun coord ->
                    let stream = sequence.GetStream(coord)
                    if stream.TotalFrames <> sequence.FrameCount then
                        raise <| InvalidOperationException($"Pixel {coord} has inconsistent frame count.");
                )
