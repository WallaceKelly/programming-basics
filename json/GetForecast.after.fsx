#r "./FSharp.Data.3.3.3/lib/net45/FSharp.Data.dll"
open FSharp.Data
open System.IO

// from https://api.weather.gov/gridpoints/LWX/96,70/forecast
type WeatherForecast = JsonProvider< "sample.json" >

// let forecast = WeatherForecast.GetSample()
let forecast = WeatherForecast.Load("https://api.weather.gov/gridpoints/TOP/31,80/forecast");

let sw = new StreamWriter("weather.htm")
for p in forecast.Properties.Periods do
    if not(p.Name.Contains("Night")) then
        sw.WriteLine(sprintf "<h1>%s</h1>" p.Name)
        sw.WriteLine(sprintf "<p>%s, high of %d</p>" p.ShortForecast p.Temperature)
        sw.WriteLine(sprintf "<img src='%s'/>" p.Icon)
sw.Close()