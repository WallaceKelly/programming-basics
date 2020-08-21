module Weather.App

open Elmish
open Elmish.React
open Feliz
open WeatherForecasts

type State =
    { Forecasts: Deferred<Forecast[]>
      Day: int }

type Msg =
    | Download
    | Downloaded of Forecast[]
    | NextDay
    | PrevDay

let init() =
    { Forecast = None; Day = 0 }
    , Cmd.ofMsg(Download)

let update (msg: Msg) (state: State) =
    match msg with
    | Download ->
        
        { state with Forecast = None },

    | NextDay -> 
        { state with Forecast = Some "sunny" }, Cmd.none
    | PrevDay ->
        { state with Forecast = Some "snowy" }, Cmd.none

let appTitle = 
    Html.p [
      prop.className "title"
      prop.text "Weather Forecasts"
    ]

let render (state: State) (dispatch: Msg -> unit) =

  Html.div [
    prop.classes [ "container" ]
    prop.children [
      Html.div [
        prop.classes [ "notification" ]
        prop.children [
          appTitle

          Html.button [
            prop.classes [ "button"; "is-large" ]
            prop.onClick (fun _ -> dispatch NextDay)
            prop.children [
              Html.i [ prop.classes [ "fa"; "fa-backward" ]]
            ]
          ]

          Html.button [
            prop.classes [ "button"; "is-large" ]
            prop.onClick (fun _ -> dispatch PrevDay)
            prop.children [
              Html.i [ prop.classes [ "fa"; "fa-forward" ]]
            ]
          ]

          Html.h1 (state.Forecast |> Option.defaultValue "")

        ]
      ]
    ]
  ]

Program.mkProgram init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run