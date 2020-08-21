module Weather.WeatherForecasts

open Browser.Types
open Browser

type Forecast =
    { day: string
      summary: string
      temperatureC: int
      temperatureF: int }
    static member empty =
      { day = ""
        summary = ""
        temperatureC = 0
        temperatureF = 32 }

let get(onDone: Forecast[] -> unit) =

    // create an instance
    let xhr = XMLHttpRequest.Create()
    
    // open the connection
    xhr.``open``(method="GET", url="https://localhost:44307/weatherforecast")
    // setup the event handler that triggers when the content is loaded
    xhr.onreadystatechange <- fun _ ->
        if xhr.readyState = ReadyState.Done
        then
          // printfn "Status code: %d" xhr.status
          // printfn "Content:\n%s" xhr.responseText
          xhr.responseText
          |> Thoth.Json.Decode.Auto.fromString<Forecast[]>
          |> function
              | Ok f -> f
              | Error _ -> [||]
          |> onDone

    // send the request
    xhr.send()

let private iconNames = 
    [
        "Cloudy", "cloud"
        "Chance of rain", "cloud-sun-rain"
        "Partly cloudy", "cloud-sun"
        "Raining", "cloud-showers-heavy"
        "Light rain", "cloud-rain"
        "Thunderstorms", "bolt"
        "Sunny", "sun"
        "Snow", "snowflake"
        "Windy", "wind"
    ] |> dict

let getIconName(summary: string) =
    match iconNames.ContainsKey(summary) with
    | true -> iconNames.[summary]
    | false -> "umbrella-beach"
    