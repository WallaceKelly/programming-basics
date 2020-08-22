#r @".\FSharp.Data.3.3.3\lib\netstandard2.0\FSharp.Data.dll"
open FSharp.Data

type WeatherForecast = JsonProvider< "sample.json" >

let forecast = WeatherForecast.Load("https://api.weather.gov/gridpoints/TOP/31,80/forecast")

for p in forecast.Properties.Periods do
    printfn "%d %s %s" p.Temperature p.Name p.ShortForecast


