namespace PixelRain.Application.Interfaces

open PixelRain.Domain.Entities

type IPartitionWorker =
    abstract member Post : ImageWithMetadata -> unit
    abstract member Complete : unit -> unit