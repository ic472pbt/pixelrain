namespace PixelRain.Application.Services

open PixelRain.Application.UseCases
open PixelRain.Application.Interfaces
open PixelRain.Domain.ValueObjects

type ImageIngestionService() =
    interface IImageIngestionService with
        member _.Ingest(imageStream: IImageStream) =
            let images = imageStream.ReadAll() |> Seq.toList

            match images with
            | [] -> Map.empty
            | {Timestamp = _; Image = {Width = w; Height = h; Pixels = pixels}; Id = id} :: _ ->
                // Build a pixel time series for each (x,y)
                let pixelSeries =
                    [ for y in 0 .. h - 1 do
                        for x in 0 .. w - 1 ->
                            let position = { X = LanguagePrimitives.Int32WithMeasure x; Y = LanguagePrimitives.Int32WithMeasure y }

                            let values, timestamps =
                                images
                                |> List.map (fun {Timestamp = ts; Image = {Width = w; Height = h; Pixels = pixels}; Id = id} ->
                                        let i = y * w + x
                                        pixels[i], ts
                                )
                                |> List.unzip

                            position, { Position = position; Values = values; Timestamps = timestamps } ]

                Map.ofList pixelSeries
