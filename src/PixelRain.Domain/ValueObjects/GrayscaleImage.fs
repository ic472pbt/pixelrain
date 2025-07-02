namespace PixelRain.Domain.ValueObjects

type GrayscaleImage = {
    Width: int
    Height: int
    Pixels: byte[] // row-major order  
}