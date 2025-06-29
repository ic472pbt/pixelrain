namespace PixelRain.Domain

type Rectangle = {X: int; Y:int; Width: int; Height: int}
    with
        member rectangle.Contains(coord: PixelCoordinate) =
            coord.X >= rectangle.X && coord.X < rectangle.X + rectangle.Width &&
            coord.Y >= rectangle.Y && coord.Y < rectangle.Y + rectangle.Height;

        member rectangle.Enumerate() = 
            seq {            
                for y = rectangle.Y to rectangle.Y + rectangle.Height - 1 do
                    for x = rectangle.X to rectangle.X + rectangle.Width - 1 do
                        yield {X = x; Y = y}
            }
