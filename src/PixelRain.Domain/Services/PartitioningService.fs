namespace PixelRain.Domain.Services

open PixelRain.Domain

module PartitioningService =
    /// Maps an ID to a stable partition index
    let computePartition (partitionCount: int) (id: string) : int<partId> =
        let hash = id.GetHashCode() &&& 0x7FFFFFFF // Ensure non-negative
        hash % partitionCount |> LanguagePrimitives.Int32WithMeasure<partId>