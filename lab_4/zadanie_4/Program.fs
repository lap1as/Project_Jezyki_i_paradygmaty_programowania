open System
open System.Collections.Generic

// Rekord dla konta
type Account = { AccountNumber: string; mutable Balance: float }

// Mapa przechowująca konta
let accounts = new Dictionary<string, Account>()

// Funkcja tworząca nowe konto
let createAccount () =
    Console.Write("Podaj numer konta: ")
    let accountNumber = Console.ReadLine()
    if accounts.ContainsKey(accountNumber) then
        printfn "Konto o tym numerze już istnieje."
    else
        let newAccount = { AccountNumber = accountNumber; Balance = 0.0 }
        accounts.Add(accountNumber, newAccount)
        printfn "Konto %s zostało utworzone." accountNumber

// Funkcja depozytowa
let deposit () =
    Console.Write("Podaj numer konta: ")
    let accountNumber = Console.ReadLine()
    
    match accounts.TryGetValue(accountNumber) with
    | true, account ->
        Console.Write("Podaj kwotę do wpłaty: ")
        let amount = Convert.ToDouble(Console.ReadLine())
        account.Balance <- account.Balance + amount
        printfn "Złożono %.2f na konto %s." amount accountNumber
    | _ -> printfn "Nie znaleziono konta."

// Funkcja wypłacająca
let withdraw () =
    Console.Write("Podaj numer konta: ")
    let accountNumber = Console.ReadLine()

    match accounts.TryGetValue(accountNumber) with
    | true, account ->
        Console.Write("Podaj kwotę do wypłaty: ")
        let amount = Convert.ToDouble(Console.ReadLine())
        if amount > account.Balance then
            printfn "Brak wystarczających środków na koncie."
        else
            account.Balance <- account.Balance - amount
            printfn "Wypłacono %.2f z konta %s." amount accountNumber
    | _ -> printfn "Nie znaleziono konta."

// Funkcja wyświetlająca saldo
let showBalance () =
    Console.Write("Podaj numer konta: ")
    let accountNumber = Console.ReadLine()
    
    match accounts.TryGetValue(accountNumber) with
    | true, account -> printfn "Saldo konta %s wynosi %.2f." accountNumber account.Balance
    | _ -> printfn "Nie znaleziono konta."

// Menu operacji bankowych
let menu () =
    printfn "1. Utwórz konto"
    printfn "2. Depozytuj środki"
    printfn "3. Wypłać środki"
    printfn "4. Sprawdź saldo"
    printfn "5. Zakończ"
    Console.ReadLine()

// Główna logika programu
let main () =
    let mutable running = true
    while running do
        match menu() with
        | "1" -> createAccount()
        | "2" -> deposit()
        | "3" -> withdraw()
        | "4" -> showBalance()
        | "5" -> running <- false
        | _ -> printfn "Niepoprawny wybór."

main ()
