namespace PixelRain.Infrastructure

open PixelRain.Domain
open PixelRain.Domain.Entities
open PixelRain.Application.Interfaces

module PartitionWorker =
    let createPartitionWorker (handle: ImageWithMetadata -> unit) (id: int<partId>) : IPartitionWorker =
        let partitionId = id / 1<partId> // Convert to a regular int for the mailbox processor
        let agent = MailboxProcessor.Start(fun inbox ->
            let rec loop () = async {
                match! inbox.Receive() with
                    | Some image -> 
                        printfn "%i %s" partitionId image.Id
                        handle image
                        do! Async.Sleep 1000 |> Async.Ignore // Simulate some processing delay  
                        return! loop ()
                    | _ -> () // shutdown
            }
            loop ()
        )

        { new IPartitionWorker with
            member _.Post(msg) = Some msg |> agent.Post 
            member _.Complete() = () } // agent.PostAndReply (fun rc -> rc) } 