module Weather.WeatherForecasts

open Browser.Types
open Browser

type Forecast =
    { Day: string
      Summary: string
      TemperatureC: int
      TemperatureF: int }
    static member empty =
      { Day = ""
        Summary = ""
        TemperatureC = 0
        TemperatureF = 32 }

let get(onDone: Forecast -> unit) =

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
          |> Thoth.Json.Decode.Auto.fromString<Forecast>
          |> function
              | Ok f -> f
              | Error _ -> Forecast.empty
          |> onDone

    // send the request
    xhr.send()