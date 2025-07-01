namespace PixelRain.Domain.ValueObjects

open PixelRain.Domain

type Rectangle = {X: int<px>; Y:int<px>; Width: int<px>; Height: int<px>}
    with
        member rectangle.Contains(coord: PixelCoordinate) =
            coord.X >= rectangle.X && coord.X < rectangle.X + rectangle.Width &&
            coord.Y >= rectangle.Y && coord.Y < rectangle.Y + rectangle.Height;
        
        member rectangle.Enumerate() = 
            seq {            
                for y = int rectangle.Y to rectangle.Y + rectangle.Height - 1<px> |> int do
                    for x = int rectangle.X to rectangle.X + rectangle.Width - 1<px> |> int do
                        yield {X = x |> LanguagePrimitives.Int32WithMeasure<px>; Y = y |> LanguagePrimitives.Int32WithMeasure<px>}
            }
