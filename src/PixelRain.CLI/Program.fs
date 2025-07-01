open PixelRain.Infrastructure.IO.FileSystem
open PixelRain.Application.Interfaces
open PixelRain.Application.UseCases
open PixelRain.Application.Services

let imageStream: IImageStream = FileSystemImageStream(@"r:\a060ed3e-ccf6-11ef-9e19-0242ac120003")
let service: IImageIngestionService = ImageIngestionService()
let map = service.Ingest(imageStream)
map.Count
