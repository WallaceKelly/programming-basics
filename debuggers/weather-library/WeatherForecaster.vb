Public Class WeatherForecast
    Public Property Day As String
    Public Property Summary As String
    Public Property TemperatureC As Double
    Public ReadOnly Property TemperatureF As Double
        Get
            Return Math.Round(32.0 + TemperatureC / 0.5556)
        End Get
    End Property
End Class


Public Class WeatherForecaster

    Private ReadOnly Summaries As String() = New String() {
        "Cloudy",
        "Chance of rain",
        "Partly cloudy",
        "Raining",
        "Light rain",
        "Thunderstorms",
        "Sunny",
        "Snow",
        "Windy"
    }

    Private Function CreateForecast(i As Integer) As WeatherForecast
        Dim rng = New Random()
        Return New WeatherForecast With {
                    .Day = Date.Today.AddDays(i).DayOfWeek.ToString(),
                    .TemperatureC = rng.Next(0, 100),
                    .Summary = Summaries(rng.Next(Summaries.Length))
                }
    End Function


    Public Function GetForecast() As WeatherForecast()
        Return Enumerable.Range(1, 5).Select(Function(i) CreateForecast(i)).ToArray()
    End Function

End Class
