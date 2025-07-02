namespace PixelRain.Application.Interfaces

type IPartitionStorageInitializer =
    abstract member EnsureBatchDirectory : partitionId:int * batchId:int -> string
