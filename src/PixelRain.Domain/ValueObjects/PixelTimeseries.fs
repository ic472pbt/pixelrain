namespace PixelRain.Domain.ValueObjects

open System

type PixelTimeSeries = {
    Position: PixelCoordinate
    Values: list<uint8>  // could also use array or other structure
    Timestamps: list<DateTime>
}