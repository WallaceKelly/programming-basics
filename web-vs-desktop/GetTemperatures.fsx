open System
open System.Threading

let rng = System.Random()

let rec getTemp() : unit =
    let lat = +Math.Round(rng.NextDouble() * 12. + 30., 2)
    let lon = -Math.Round(rng.NextDouble() * 45. + 77., 2)
    printf "Retrieving temperature for %5.2f, %7.2f: " lat lon
    Thread.Sleep(int (Math.Round(rng.NextDouble() * 500. + 500.)))
    let temp = int (Math.Round(rng.NextDouble() * 30. + 50.))
    let color = Console.ForegroundColor
    Console.ForegroundColor <- ConsoleColor.Magenta
    printfn "%d F" temp
    Console.ForegroundColor <- color
    getTemp()

Console.Clear()
getTemp()

