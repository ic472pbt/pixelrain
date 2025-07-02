namespace PixelRain.Infrastructure.IO
open PixelRain.Application.Interfaces
open PixelRain.Domain.ValueObjects
open System.IO
open SixLabors.ImageSharp
open SixLabors.ImageSharp.PixelFormats
open FSharp.Control
open PixelRain.Domain.Entities

module FileSystem =

    /// Efficient async file-based image loader for grayscale images (L8)
    type FileSystemImageStream(folderPath: string) =
        interface IImageStream with
            member _.ReadAll() : AsyncSeq<ImageWithMetadata> =
                Directory.EnumerateFiles(folderPath, "*.png")
                |> AsyncSeq.ofSeq
                |> AsyncSeq.mapAsync (fun file -> async {
                    use! img = Image.LoadAsync<L8>(file) |> Async.AwaitTask
                    let w, h = img.Width, img.Height

                    // Extract pixel memory directly
                    let pixels1D = Array.zeroCreate<byte> (w * h)
                    img.CopyPixelDataTo(pixels1D)

                    return {
                        Timestamp = File.GetLastWriteTime(file)
                        Id = Path.GetFileNameWithoutExtension(file)
                        Image = {
                            Width = w
                            Height = h
                            Pixels = pixels1D
                        }
                    }
                })
