module PixelRain.Infrastructure.IO.FileSystemStorageInitializer

open System.IO
open PixelRain.Application.Interfaces

let create (root: string) : IPartitionStorageInitializer =
    { new IPartitionStorageInitializer with
        member _.EnsureBatchDirectory(partitionId, batchId) =
            let partitionDir = Path.Combine(root, $"partition-{partitionId}")
            Directory.CreateDirectory(partitionDir) |> ignore
            let batchDir = Path.Combine(partitionDir, $"batch-{batchId}")
            Directory.CreateDirectory(batchDir) |> ignore
            batchDir
    }
