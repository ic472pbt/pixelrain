namespace PixelRain.Application
   
open PixelRain.Domain
open PixelRain.Domain.Entities
open PixelRain.Domain.Services
open PixelRain.Application.Interfaces

module Services =
   type PartitionRouter(partitionCount: int, createWorker: int<partId> -> IPartitionWorker) =
        let workers =
            [|
                for i in 0 .. partitionCount - 1 ->
                    let pid = i |> LanguagePrimitives.Int32WithMeasure
                    pid, createWorker pid
            |] |> dict

        member _.Route(image: ImageWithMetadata) =
            let pid = PartitioningService.computePartition partitionCount image.Id 
            workers[pid].Post image

        member _.CompleteAll() =
            for worker in workers.Values do
                worker.Complete()