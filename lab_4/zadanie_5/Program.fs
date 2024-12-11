open System

// Reprezentacja planszy
let initialBoard = [| "1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9" |]

// Funkcja wyświetlająca planszę
let displayBoard (board: string[]) =
    printfn "%s | %s | %s" board.[0] board.[1] board.[2]
    printfn "---|---|---"
    printfn "%s | %s | %s" board.[3] board.[4] board.[5]
    printfn "---|---|---"
    printfn "%s | %s | %s" board.[6] board.[7] board.[8]

// Funkcja sprawdzająca, czy ktoś wygrał
let checkWinner (board: string[]) =
    let winPatterns = [
        [0; 1; 2]; [3; 4; 5]; [6; 7; 8];  // poziomo
        [0; 3; 6]; [1; 4; 7]; [2; 5; 8];  // pionowo
        [0; 4; 8]; [2; 4; 6]              // po skosie
    ]
    winPatterns
    |> List.tryFind (fun pattern ->
        let values = pattern |> List.map (fun i -> board.[i])
        values |> List.distinct |> List.length = 1 && values.[0] <> "1" && values.[0] <> "2" && values.[0] <> "3" && values.[0] <> "4" && values.[0] <> "5" && values.[0] <> "6" && values.[0] <> "7" && values.[0] <> "8" && values.[0] <> "9")
    
    |> Option.map (fun _ -> true)
    |> Option.defaultValue false

// Funkcja sprawdzająca, czy jest remis
let isDraw (board: string[]) =
    board |> Array.forall (fun x -> x = "X" || x = "O")

// Funkcja do ruchu gracza
let playerMove (board: string[]) =
    let mutable validMove = false
    while not validMove do
        Console.Write("Podaj numer pola (1-9): ")
        let move = Console.ReadLine() |> int
        if move >= 1 && move <= 9 && board.[move - 1] <> "X" && board.[move - 1] <> "O" then
            board.[move - 1] <- "X"
            validMove <- true
        else
            printfn "Nieprawidłowy ruch! Wybierz inne pole."

// Funkcja do ruchu komputera
let computerMove (board: string[]) =
    let random = Random()
    let mutable moveMade = false
    while not moveMade do
        let move = random.Next(1, 10)
        if board.[move - 1] <> "X" && board.[move - 1] <> "O" then
            board.[move - 1] <- "O"
            moveMade <- true

// Funkcja do zarządzania turami gry
let rec gameLoop (board: string[]) =
    displayBoard board

    if checkWinner board then
        printfn "Gratulacje! Gracz wygrał!"
    elif isDraw board then
        printfn "Remis!"
    else
        // Ruch gracza
        playerMove board
        if checkWinner board || isDraw board then
            displayBoard board
            if checkWinner board then
                printfn "Gratulacje! Gracz wygrał!"
            elif isDraw board then
                printfn "Remis!"
        else
            // Ruch komputera
            computerMove board
            gameLoop board

// Główna logika programu
let main () =
    let board = Array.copy initialBoard
    gameLoop board

main ()
