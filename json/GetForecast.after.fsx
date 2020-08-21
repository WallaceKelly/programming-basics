// #r "./FSharp.Core.4.0.0.1/lib/portable-net45+netcore45/FSharp.Core.dll"
#r "./FSharp.Data.3.3.3/lib/netstandard2.0/FSharp.Data.dll"
open FSharp.Data
open System.IO

// from https://api.weather.gov/gridpoints/LWX/96,70/forecast
type WeatherForecast = JsonProvider< "sample.json" >

let forecast = WeatherForecast.GetSample()

let sw = new StreamWriter("weather.htm")
for p in forecast.Properties.Periods do
    if not(p.Name.Contains("Night")) then
        sw.WriteLine(sprintf "<h1>%s</h1>" p.Name)
        sw.WriteLine(sprintf "<p>%s, high of %d</p>" p.ShortForecast p.Temperature)
        sw.WriteLine(sprintf "<img src='%s'/>" p.Icon)
sw.Close()