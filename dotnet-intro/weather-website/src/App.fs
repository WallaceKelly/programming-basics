module Weather.App

open Elmish
open Elmish.React
open Feliz
open WeatherForecasts

type State =
    { Forecasts: Deferred<Forecast[]>
      Day: int option }

type Msg =
    | Download
    | Downloaded of Forecast[]
    | NextDay
    | PrevDay

let init() =
    { Forecasts = HasNotStartedYet; Day = None }
    , Cmd.ofMsg Download

let update (msg: Msg) (state: State) =

    let changeDay (direction: int) =
        match state.Forecasts with
        | Resolved forecasts ->
            state.Day
            |> Option.defaultValue 0
            |> fun day ->
                match direction with
                | dir when dir = 0 -> day
                | dir when dir < 0 -> max (day - 1) 0
                | dir -> min (day + 1) (forecasts.Length-1)
                |> Some
        | _ -> None

    match msg with
    | Download ->
        let getData dispatch = WeatherForecasts.get(Downloaded >> dispatch)
        { state with Forecasts = InProgress }, Cmd.ofSub getData
    | Downloaded forecasts -> { state with Forecasts = (Resolved forecasts) }, Cmd.none
    | NextDay -> { state with Day = changeDay +1 }, Cmd.none
    | PrevDay -> { state with Day = changeDay -1 }, Cmd.none

let renderTitle (state: State) = 
    let subtitle =
        match state.Forecasts with
        | HasNotStartedYet -> ""
        | InProgress -> "Downloading..."
        | Resolved forecasts ->
            let day = state.Day |> Option.defaultValue 0
            let forecast = forecasts.[day]
            forecast.day
    Html.div [
        Html.p [
          prop.className "title"
          prop.text "Weather Forecast"
        ]
        Html.p [
            prop.className "subtitle"
            prop.text subtitle
        ]
    ]

let renderForecast (state: State) =
    match state.Forecasts with
    | HasNotStartedYet -> Html.none
    | InProgress -> Html.none
    | Resolved forecasts ->
        let day = state.Day |> Option.defaultValue 0
        let forecast = forecasts.[day]
        let summaryAndTemp = sprintf "%s (%d F)" forecast.summary forecast.temperatureF
        let iconName = forecast.summary |> getIconName |> sprintf "fa-%s"
        Html.div [
            Html.i [ prop.classes [ "fa"; iconName; "fa-5x"] ]
            Html.p summaryAndTemp
        ]
        
let renderButtons (state: State) (dispatch: Msg -> unit) =
    match state.Forecasts with
    | HasNotStartedYet -> Html.none
    | InProgress -> Html.none
    | Resolved forecasts ->
        Html.div [
            Html.button [
                prop.classes [ "button"]
                prop.onClick (fun _ -> dispatch PrevDay)
                prop.children [
                    Html.i [ prop.classes [ "fa"; "fa-backward" ]]
                ]
            ]

            Html.button [
                prop.classes [ "button" ]
                prop.onClick (fun _ -> dispatch Download)
                prop.children [
                    Html.i [ prop.classes [ "fa"; "fa-sync-alt" ]]
                ]
            ]

            Html.button [
                prop.classes [ "button" ]
                prop.onClick (fun _ -> dispatch NextDay)
                prop.children [
                    Html.i [ prop.classes [ "fa"; "fa-forward" ]]
                ]
            ]
        ]


let render (state: State) (dispatch: Msg -> unit) =

  Html.div [
    prop.classes [ "container" ]
    prop.style []
    prop.children [
      Html.div [
        prop.classes [ "notification"; "has-text-centered" ]
        prop.children [
          renderTitle state
          renderForecast state
          renderButtons state dispatch
        ]
      ]
    ]
  ]

Program.mkProgram init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run