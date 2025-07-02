namespace PixelRain.Infrastructure

open PixelRain.Domain
open PixelRain.Domain.Entities
open PixelRain.Application.Interfaces

module PartitionWorker =
    type PartitionWorkerMessage =
        | Image of ImageWithMetadata
        | Complete of AsyncReplyChannel<unit>
    let createPartitionWorker 
            (handle: ImageWithMetadata list -> int<batch> -> string -> unit) 
            (batchSize: int)
            (storageInitializer: IPartitionStorageInitializer)
            (id: int<partId>) : IPartitionWorker =

        let partitionId = id / 1<partId>

        let agent = MailboxProcessor.Start(fun inbox ->
            let rec loop batch batchId = async {
                match! inbox.Receive() with
                | Image image when batch |> List.length >= batchSize -> 
                    printfn "Processing batch %i" partitionId
                    storageInitializer.EnsureBatchDirectory(partitionId, int batchId)
                        |> handle batch batchId
                    return! loop [image] (batchId + 1<batch>)
                | Image image ->
                    return! loop (image::batch) batchId
                | Complete rc ->
                    printfn "Shutting down partition %i with pending %i images" partitionId batch.Length
                    if batch.Length > 0 then
                        storageInitializer.EnsureBatchDirectory(partitionId, int batchId)
                            |> handle batch batchId
                    rc.Reply()
            }
            loop [] 0<batch>
        )

        { new IPartitionWorker with
            member _.Post(msg) = Image msg |> agent.Post 
            member _.Complete() = agent.PostAndReply Complete }