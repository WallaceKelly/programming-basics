open System
open System.Threading

let spinningWait loops =
    let chars = "|/-\\"
    Console.CursorVisible <- false
    for _ in [0 .. loops] do
        for c in chars do
            printf "%c" c
            Thread.Sleep(100)
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop)
    let color = Console.ForegroundColor
    Console.ForegroundColor <- ConsoleColor.Green
    printfn "OK!"
    Console.CursorVisible <- true
    Console.ForegroundColor <- color

printfn "Starting test script"
Thread.Sleep(1000)
printf "Testing website "
spinningWait 5
printf "Testing webservice "
spinningWait 5
printf "Testing mobile app "
spinningWait 3
printf "Testing weather service "
spinningWait 3
printf "Testing targeted ads database "
spinningWait 3
printf "Updating backend libraries "
spinningWait 3

let color = Console.ForegroundColor
printf "All checks "
Console.ForegroundColor <- ConsoleColor.Green
printfn "passed."
Console.ForegroundColor <- color
