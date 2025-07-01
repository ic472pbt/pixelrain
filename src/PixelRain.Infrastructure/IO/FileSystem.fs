namespace PixelRain.Infrastructure.IO
open PixelRain.Application.Interfaces
open PixelRain.Domain.ValueObjects
open System.IO
open SixLabors.ImageSharp
open SixLabors.ImageSharp.PixelFormats

module FileSystem =
    type FileSystemImageStream(folderPath: string) =
        interface IImageStream with
            member _.ReadAll() =
                Directory.EnumerateFiles(folderPath, "*.png")
                |> Seq.map (fun file ->
                    use img = Image.Load<L8>(file)
                    let w, h = img.Width, img.Height
                    let pixels =
                        Array.init (w * h) (fun i ->
                            let x, y = i % w, i / w
                            img[x, y].PackedValue)
                    {
                        Timestamp = File.GetLastWriteTime(file)
                        Id = Path.GetFileNameWithoutExtension(file)
                        Image = {Width = w; Height = h; Pixels = pixels}
                    })

